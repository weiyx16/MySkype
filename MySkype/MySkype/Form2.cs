﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Sockets;
using System.Resources;
using System.IO;//读写文件
using System.Threading;//多线程
using System.Net.NetworkInformation;
using System.Net;
using System.Text.RegularExpressions;

//截图时使用
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
//using _SCREEN_CAPTURE;

namespace MySkype
{
    public partial class MainFrm : Form
    {
        /* 监听过程需要使用的变量 */
        private Thread LstThd;//后台侦听线程
        private TcpListener LstTcp;//侦听来自TCP网络客户端的连接
        private TcpClient client;
        private delegate void FlushClient(string FrdName, string received_words); //代理
        private byte[] LstBuffer = new byte[1024];//接收对方发送的信息
        private delegate void File_Send_Show(string FileName, int i, int FileLength, int last_show); //文件传输中的代理
        private delegate void File_Receive_Show(string FileName, int i, int FileLength, int last_show); //文件传输中的代理

        public static IPAddress LocalIP { get; set; }//本机IP
        //private Myfriends newfriend;//新加好友
        //public List<Myfriends> myfriends;//保存好友信息
        My_MessageBox MyMessageBox = new My_MessageBox();

        public MainFrm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Chat_flowLayout.FlowDirection = FlowDirection.LeftToRight;
            Chat_flowLayout.AutoScroll = true;
            Chat_flowLayout.VerticalScroll.Visible = true;
            Chat_flowLayout.HorizontalScroll.Visible = false;

            Glb_Value.Chat_Frd = Glb_Value.Account; //假设当前聊天的即为自己
            Glb_Value.Chatting = false;
            // 欢迎信息
            Frd_name.Text = Glb_Value.Chat_Frd;
            Info_account.Text = Glb_Value.Account;
            int CurHour = DateTime.Now.Hour;
            if (CurHour > 19)
            {
                Info.Text = "Good Evening";
                Welcome_img.Image = new Bitmap(Properties.Resources.evening, Welcome_img.Width, Welcome_img.Height);
            }
            else if (CurHour > 13)
            {
                Info.Text = "Good Afternoon";
                Welcome_img.Image = new Bitmap(Properties.Resources.afternoon, Welcome_img.Width, Welcome_img.Height);
            }
            else if (CurHour > 6)
            {
                Info.Text = "Good Morning";
                Welcome_img.Image = new Bitmap(Properties.Resources.morning, Welcome_img.Width, Welcome_img.Height);
            }
            else
            {
                Info.Text = "Don't stay up!";
                Welcome_img.Image = new Bitmap(Properties.Resources.night, Welcome_img.Width, Welcome_img.Height);
            }

            //开始后台进程的侦听程序
            LstThd = new Thread(Listen);
            LstThd.IsBackground = true;
            LstThd.Start();

        }

        /*
         ------------ 开始后台线程监听别人发的消息 -------------
             */
        private void Listen()
        {
            //监听本用户名对应的串口是否有消息传入
            int LstPort = int.Parse(Glb_Value.Account.Substring(5)) + 10000;
            LstTcp = new TcpListener(IPAddress.Any, LstPort);
            LstTcp.Start();// 开始侦听Tcp接入的请求
            // 如果受到接入请求，调用回调函数进行异步处理
            AsyncCallback LisCallback = new AsyncCallback(AcpClientCallback);
            LstTcp.BeginAcceptTcpClient(LisCallback, LstTcp);
        }
        private void AcpClientCallback(IAsyncResult ar)
        {
            LstTcp = (TcpListener)ar.AsyncState;
            client = LstTcp.EndAcceptTcpClient(ar);
            // 如果收到信息，调用一个新线程 执行Acp_msg函数接收这次信息
            Thread AcpThread = new Thread(Acp_msg);
            AcpThread.Start();
            // 确保继续监听其他请求
            AsyncCallback LisCallback = new AsyncCallback(AcpClientCallback);
            LstTcp.BeginAcceptTcpClient(LisCallback, LstTcp);
        }

        // 接受别人发送的信息（文本 或者 文件（含表情/截图/正式文件））
        private void Acp_msg()
        {
            NetworkStream Strm2Frd = client.GetStream();
            //先接收对方的握手信息（学号）
            byte[] test_msg = new byte[1000];//10位学号，20字节
            int bytes_length = 0;
            try
            {
                bytes_length = Strm2Frd.Read(test_msg, 0, 1000);
            }
            catch { }
            //转化成字符串，提取对方的身份（学号）
            string FrdName = Encoding.Default.GetString(test_msg, 0, bytes_length);
            //接收到好友尝试连接之后
            //先看我现在的状态，是否正在聊天，如果聊天的话，是否又在和这个人聊天？
            //先回复Hello，有了第一次握手
            if (Glb_Value.Chatting && !(Glb_Value.Chat_Frd.CompareTo(FrdName) == 0))
            {                
                //我现在正在和别人聊天
                byte[] msg = Encoding.Default.GetBytes("Sorry");
                try
                {
                    Strm2Frd.Write(msg, 0, msg.Length);
                }
                catch { }
            }
            else{
                // 我还没开始聊天or我之前就是和你正在聊天
                Glb_Value.Chatting = true;
                Glb_Value.Chat_Frd = FrdName;
                Frd_name.Text = FrdName;
                byte[] msg = Encoding.Default.GetBytes("Hello");
                try
                {
                    Strm2Frd.Write(msg, 0, msg.Length);
                }
                catch { }
                
                //读取正式信息 先读取了前1000位，判断是普通文本还是文件（文件发送默认有编码头/**begin-file-transport**/）
                bytes_length = 0;
                try
                {
                    bytes_length = Strm2Frd.Read(LstBuffer, 0, 1000);
                }
                catch { }
                //查看接收信息头
                string received_words = Encoding.Default.GetString(LstBuffer, 0, bytes_length);
                if (received_words.StartsWith("/**begin-file-transport**/"))
                {
                    //收到了文件
                    receive_file(FrdName, received_words, Strm2Frd);                  
                }
                else
                {
                    //收到了普通文本
                    process_message(FrdName, received_words);//跨线程处理信息+回显
                }
            }
        }

        //处理收到的文字信息
        private void process_message(string FrdName, string received_words)
        {
            //注意这里Acp_msg是由另一个监听的异步触发产生的线程所调用的，需要特殊的处理
            //约束只能同时和一个人聊天/传送
            
            //等待异步 处理
            //调用方位于创建控件线程之外的线程里，所以对调用方进行invoke
            if (this.Chat_flowLayout.InvokeRequired)
            {
                FlushClient FC = new FlushClient(process_message);
                this.Invoke(FC, new object[] { FrdName, received_words }); //通过代理调用刷新方法
            }
            else
            {
                //更新我当前对话方的Ip地址，用户名以及界面上的信息
                Glb_Value.Chat_Frd_IP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                Glb_Value.Chat_Frd = FrdName;       
                Frd_name.Text = FrdName;
                //要把这个线程的信息显示在主线程程序上
                Frd_Dialog show_frds = new Frd_Dialog(received_words, FrdName);
                Chat_flowLayout.Controls.Add(show_frds);
                show_frds.Parent = Chat_flowLayout;
                show_frds.Show();
                MessageBox.Show(received_words, "FileReceiveError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /*
         -------------  收发文件处理 -------------
             */
        //点击文件选择按钮，弹出目录选择
        private void Files_Click(object sender, EventArgs e)
        {
            // 限制不能发送给自己
            if (Glb_Value.Chat_Frd == Glb_Value.Account)
            {
                MessageBox.Show("Don't Send files to Yourself!", "ObjectError!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                OpenFileDialog Files_Chs_Dlg = new OpenFileDialog();
                Files_Chs_Dlg.Filter = "All files (*.*)|*.*"; // 对文件种类没有限制
                if (Files_Chs_Dlg.ShowDialog() == DialogResult.OK) // 弹出窗口选中后点击确定
                {                   
                    string filename = Glb_Value.Chat_Frd + Files_Chs_Dlg.FileName;
                    // 由于文件本身作为参数，所以需要使用带参的线程
                    Thread FileThread = new Thread(new ParameterizedThreadStart(Send_file));
                    FileThread.Start((object)filename);
                }
            }
        }

        //文件发送线程内执行的函数
        private void Send_file(object filename)
        {
            string _filename = (string)filename;
            string FrdName = Glb_Value.Chat_Frd; // _filename.Substring(0, 10);
            string FilePath = _filename.Substring(10); // Files_Chs_Dlg.FileName;
            string FileName = FilePath.Substring(FilePath.LastIndexOf('\\') + 1);
            FileStream FileStrm = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            int max_size = 1024;
            byte[] fileBuffer = new byte[max_size]; //一次传输1024字节 1KB
            int FileLength = (int)(FileStrm.Length + 1023) / 1024; // 获取目前文件是多少KB
            if (FileLength > 0)
            {
                // 每次发送前再次确认对方Ip和在线状态 和 send_text一样
                string Frd_IP = Check_Online(Glb_Value.Chat_Frd);
                if (Frd_IP == "Fail")
                {
                    MessageBox.Show("The friend is not available.", "ObjectError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    Glb_Value.Chat_Frd_IP = Frd_IP;
                    TcpClient client = new TcpClient();
                    // 先尝试连接对应的Ip+端口
                    try
                    {
                        int port = Convert.ToInt16(Glb_Value.Chat_Frd.Substring(5)) + 10000; // 此端口协议双方协定好了
                        client.Connect(Frd_IP, port);
                    }
                    catch
                    {
                        MessageBox.Show("The friend is not available.", "ObjectError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (client.Connected)
                    {
                        NetworkStream Strm2Frd = client.GetStream();
                        // 约定发送方每次发送信息，先发送自身账号确保接收方正确返回Hello作为ACK，再进行后续的发送
                        byte[] testmsg = Encoding.Default.GetBytes(Glb_Value.Account);
                        Strm2Frd.Write(testmsg, 0, testmsg.Length);

                        byte[] msg_get = new byte[testmsg.Length];
                        int bytes_length = 0;
                        Strm2Frd.ReadTimeout = 10000;
                        try
                        {
                            bytes_length = Strm2Frd.Read(msg_get, 0, msg_get.Length);
                        }
                        catch
                        {
                            Strm2Frd.Close();
                            client.Close();
                            return;
                        }
                        string succ_flag = Encoding.Default.GetString(msg_get, 0, bytes_length);
                        Regex suc = new Regex(@"^Hello");
                        Regex busy = new Regex(@"^Sorry");
                        if (suc.IsMatch(@succ_flag)) {
                            //双方交互协议与文本相同，在这里进行传送
                            //只不过文件传送在文件前加上一个头
                            byte[] headmsg = Encoding.Default.GetBytes("/**begin-file-transport**/" + "/*FileName*/" + FileName + "/*FileLength*/" + FileLength.ToString());
                            try
                            {
                                Strm2Frd.Write(headmsg, 0, headmsg.Length);
                            }
                            catch { }
                            // 文件头发送完毕，对方get要发送文件了！以及对文件大小也有了预判
                            // 接下来传送文件body!
                            Strm2Frd.WriteTimeout = 10000;
                            int i = 0;
                            int last_show = 0;
                            bool success = true;
                            for (i = 0; i < FileLength; i++)
                            {
                                try
                                {
                                    int bufsize = FileStrm.Read(fileBuffer, 0, max_size); // 从文件中读取的
                                    if (bufsize > 0)
                                    {
                                        Strm2Frd.Write(fileBuffer, 0, bufsize);
                                    }
                                    else
                                    {
                                        MessageBox.Show("The friend is not available. And the transport failed", "ObjectError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        //传递失败，如果有控件的话，显示失败
                                        file_send_show(FileName, i, FileLength, -1);
                                        success = false;
                                        break;
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("The friend is not available. And the transport failed", "ObjectError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    //传递失败，如果有控件的话，显示失败
                                    file_send_show(FileName, i, FileLength, -1);
                                    success = false;
                                    break;
                                }
                                //可以在这里显示传递进度（以控件的形式）每10%更新一次进度
                                if (((i + 1) * 10) / FileLength >= last_show) { 
                                    file_send_show(FileName, i, FileLength, last_show);
                                    last_show += 1;
                                }
                            }
                            //发送完毕
                            FileStrm.Flush();
                            FileStrm.Close();
                            Strm2Frd.Close();
                            client.Close();
                            if (success) { 
                                MessageBox.Show("Succeed to transport the file.", "Succeed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else if (busy.IsMatch(@succ_flag))
                        {
                            //对方退出了当前的窗口，那么也就不维护了，停止发送！
                            FileStrm.Flush();
                            FileStrm.Close();
                            Strm2Frd.Close();
                            client.Close();
                            MessageBox.Show("The friend is not available.", "ObjectError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else
                        {
                            //完全不行的情况
                            FileStrm.Flush();
                            FileStrm.Close();
                            Strm2Frd.Close();
                            client.Close();
                            MessageBox.Show("The friend is not available.", "ObjectError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    else
                    {
                        //建立TCP失败了
                        FileStrm.Flush();
                        FileStrm.Close();
                        client.Close();
                        MessageBox.Show("The friend is not available.", "ObjectError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
            else
            {
                FileStrm.Flush();
                FileStrm.Close();
                MessageBox.Show("The file size is out of range.", "FileSizeError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //文件接收线程调用的函数
        private void receive_file(string FrdName, string msg, NetworkStream Strm2Frd)
        {
            //更新我当前对话方的Ip地址，用户名以及界面上的信息
            Glb_Value.Chat_Frd_IP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
            Glb_Value.Chat_Frd = FrdName;
            Frd_name.Text = FrdName;

            //当前msg即是对方发过来的文件头，有文件名/文件长度和注明是文件信息的公共头
            //首先进行解析！
            string filehead = "/**begin-file-transport**/";
            string FileNameLabel = "/*FileName*/";
            string FileLengthLabel = "/*FileLength*/";
            msg = msg.Substring(filehead.Length + FileNameLabel.Length); // 先把头去掉
            int Name_location = msg.IndexOf(FileLengthLabel);
            int Length_location = Name_location + FileLengthLabel.Length;
            string FileName = msg.Substring(0, Name_location);
            int FileLength = int.Parse(msg.Substring(Length_location));

            //为接收的文件找到存储的位置
            string SavePath = ".\\" + Glb_Value.Account + "\\Download";
            if (Directory.Exists(SavePath)) { }
            else
            {
                DirectoryInfo directory = new DirectoryInfo(SavePath);
                directory.Create();
            }
            SavePath = SavePath + "\\" + FileName;
            //由于同名文件会存在，先解决文件名冲突的问题
            FileStream WRStream; // 主要思想就是拿一个FileStream取尝试写这个同名文件
            for (int number=1; ; number++)
            {
                try
                {
                    WRStream = new FileStream(SavePath, FileMode.CreateNew, FileAccess.Write);
                    break; // 成功了就break，否则往后头加(number)
                }
                catch
                {
                    if (number == 1)
                    {  
                        // 该文件还没有冲突过，所以文件名正常 
                        int format_index = SavePath.LastIndexOf("."); // 先找到后缀的位置
                        string format = SavePath.Substring(format_index);
                        string _filename = SavePath.Substring(0, format_index);
                        SavePath = _filename + "(1)" + format;
                    }
                    else
                    {
                        // 该文件已经冲突过了，文件名后面已经有(x)，只能改成(x+1)
                        int format_index = SavePath.LastIndexOf("."); // 先找到后缀的位置
                        string format = SavePath.Substring(format_index);
                        string _filename = SavePath.Substring(0, format_index-3); // 去掉(x)的文件名
                        SavePath = _filename + "(" + number.ToString() + ")" + format;
                    }
                }
            }
            //正式接收了！
            byte[] FileBuffer = new byte[1024]; //1KB-by-1KB
            Strm2Frd.ReadTimeout = 10000;
            bool success = true;
            int last_show = 0;
            for (int i=0; i < FileLength; i++)
            {
                try
                {
                    int bufsize = Strm2Frd.Read(FileBuffer, 0, 1024);
                    if (bufsize > 0) //成功接收，存到文件中
                    {
                        WRStream.Write(FileBuffer, 0, bufsize);
                    }
                    else
                    {
                        //传递失败，如果有控件的话，显示失败
                        file_receive_show(FileName, i, FileLength, -1);
                        MessageBox.Show("Fail to receive files.", "FileReceiveError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        success = false;
                        break;
                    }
                }
                catch
                {
                    //传递失败，如果有控件的话，显示失败
                    file_receive_show(FileName, i, FileLength, -1);
                    MessageBox.Show("Fail to receive files.", "FileReceiveError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    success = false;
                    break;
                }
                //可以在这里显示传递进度（以控件的形式）
                if (((i + 1) * 10) / FileLength >= last_show)
                {
                    file_receive_show(FileName, i, FileLength, last_show);
                    last_show += 1;
                }
            }
            // 传送成功
            WRStream.Flush();
            WRStream.Close();
            Strm2Frd.Close();
            if (success) {
                MessageBox.Show("Succeed Receive File.", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //文件传输进度显示的相关函数
        private void file_send_show(string FileName, int i, int FileLength, int last_show)
        {
            //注意这里函数是由另一个监听的异步触发产生的线程所调用的，需要特殊的处理

            //等待异步 处理
            //调用方位于创建控件线程之外的线程里，所以对调用方进行invoke
            if (this.Chat_flowLayout.InvokeRequired)
            {
                File_Send_Show fss= new File_Send_Show(file_send_show);
                this.Invoke(fss, new object[] { FileName, i, FileLength, last_show }); //通过代理调用刷新方法
            }
            else
            {
                if (last_show == 0)
                {
                    Self_Files show_mine_file = new Self_Files(FileName, (int)(((i + 1) * 10) / FileLength));
                    this.Chat_flowLayout.Controls.Add(show_mine_file);
                    show_mine_file.Parent = this.Chat_flowLayout;
                    show_mine_file.Show();
                }
                else if(last_show!=-1)
                {
                    Self_Files show_mine_file = new Self_Files(FileName, (int)(((i + 1) * 10) / FileLength));
                    int curr_num = Chat_flowLayout.Controls.Count - 1;
                    Control remove_one = Chat_flowLayout.Controls[curr_num];
                    Chat_flowLayout.Controls.Remove(remove_one);
                    this.Chat_flowLayout.Controls.Add(show_mine_file);
                    show_mine_file.Parent = this.Chat_flowLayout;
                    show_mine_file.Show();
                }
                else
                {
                    Self_Files show_mine_file = new Self_Files(FileName, -1);
                    this.Chat_flowLayout.Controls.Add(show_mine_file);
                    show_mine_file.Parent = this.Chat_flowLayout;
                    show_mine_file.Show();
                }
            }
        }

        private void file_receive_show(string FileName, int i, int FileLength, int last_show)
        {
            //注意这里函数是由另一个监听的异步触发产生的线程所调用的，需要特殊的处理

            //等待异步 处理
            //调用方位于创建控件线程之外的线程里，所以对调用方进行invoke
            if (this.Chat_flowLayout.InvokeRequired)
            {
                File_Receive_Show fss = new File_Receive_Show(file_receive_show);
                this.Invoke(fss, new object[] { FileName, i, FileLength, last_show }); //通过代理调用刷新方法
            }
            else
            {
                if (last_show == 0)
                {
                    Frd_Files show_mine_file = new Frd_Files(FileName, (int)(((i + 1) * 10) / FileLength));
                    this.Chat_flowLayout.Controls.Add(show_mine_file);
                    show_mine_file.Parent = this.Chat_flowLayout;
                    show_mine_file.Show();
                }
                else if (last_show != -1)
                {
                    //先前已经有一个文件传输状态的控件了。把这个控件删掉，然后更新新的控件
                    Frd_Files show_mine_file = new Frd_Files(FileName, (int)(((i + 1) * 10) / FileLength));
                    int curr_num = Chat_flowLayout.Controls.Count - 1;
                    Control remove_one = Chat_flowLayout.Controls[curr_num];
                    Chat_flowLayout.Controls.Remove(remove_one);
                    this.Chat_flowLayout.Controls.Add(show_mine_file);
                    show_mine_file.Parent = this.Chat_flowLayout;
                    show_mine_file.Show();
                }
                else
                {
                    Frd_Files show_mine_file = new Frd_Files(FileName, -1);
                    this.Chat_flowLayout.Controls.Add(show_mine_file);
                    show_mine_file.Parent = this.Chat_flowLayout;
                    show_mine_file.Show();
                }
            }
        }

        /*
         ------------- 查找朋友 并发起聊天 -------------
             */
        private void Search_button_Click(object sender, EventArgs e)
        {
            if (Search_frd.Text.Length != 10)
            {
                MessageBox.Show("Account should be 10 numbers!", "SearchError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Search_frd.Clear();
            }
            else
            {
                // 查询自己
                if (this.Search_frd.Text == Glb_Value.Account)
                {
                    MessageBox.Show("You needn't to search yourself!", "SearchError", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    Search_frd.Clear();
                }
                else
                {
                    string Frd_IP = Check_Online(this.Search_frd.Text);
                    if (Frd_IP == "Fail") {
                        Search_frd.Clear();
                    }
                    else
                    {
                        DialogResult Dr = MessageBox.Show("This friend is online, chat now?", "Check", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);                 
                        if (Dr == DialogResult.OK)
                        {
                            // 可以开始聊天
                            Frd_name.Text = Search_frd.Text;
                            Glb_Value.Chat_Frd = Search_frd.Text;
                            Glb_Value.Chat_Frd_IP = Frd_IP;
                            Glb_Value.Chatting = true;
                        }
                    }
                }
            }
        }

        // 清空提示信息
        private void Search_frd_Click(object sender, EventArgs e)
        {
            if (Search_frd.Text.CompareTo("Search Friends") == 0)
            {
                Search_frd.Clear();
                Search_frd.MaxLength = 10;
                Search_frd.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        //查看对应Ip的朋友是否在线
        private string Check_Online(string FrdName)
        {
            string Result = "Fail";

            TcpClient client = new TcpClient();
            try
            {
                client.Connect(Glb_Value.ServerIp, Glb_Value.ServerPort);
            }
            catch
            {
                MessageBox.Show("The client is busy now", "ConnectError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                client.Close();
                return Result;
            }
            if (client.Connected)
            {
                NetworkStream Strm2Ser = client.GetStream();
                string ask = "q" + FrdName;
                byte[] msg = Encoding.Default.GetBytes(ask);
                Strm2Ser.Write(msg, 0, msg.Length);

                byte[] msg_get = new byte[50];
                int bytesRead = 0;
                Strm2Ser.ReadTimeout = 1000;
                bool istimeout = false;
                try
                {
                    bytesRead = Strm2Ser.Read(msg_get, 0, 50);
                }
                catch
                {
                    istimeout = true;
                    MessageBox.Show("The client is busy now", "ConnectError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Strm2Ser.Close();
                    client.Close();
                    return Result;
                }
                if (msg_get[0] == 'n')//朋友不在线
                {
                    MessageBox.Show("The friend is offline know", "OfflineError", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Strm2Ser.Close();
                    client.Close();
                    return Result;
                }
                else if (istimeout == false)//朋友在线
                {
                    string friend_IP = Encoding.Default.GetString(msg_get, 0, bytesRead);
                    Strm2Ser.Close();
                    client.Close();
                    return friend_IP;
                }
                else
                {
                    Strm2Ser.Close();
                    client.Close();
                    return Result;
                }
            }
            else
            {
                client.Close();
                return Result;
            }
        }

        /*
            --------------  退出登录 ---------------
            */
        private void Exit_button_Click(object sender, EventArgs e)
        {
            DialogResult Dr = MessageBox.Show("Ready to logout?", "Check", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Dr == DialogResult.OK)
            {
                TcpClient client = new TcpClient();
                // try to connet the client and check if we lose it
                try
                {
                    client.Connect(Glb_Value.ServerIp, Glb_Value.ServerPort);
                }
                catch
                {
                    MessageBox.Show("The client is busy now", "ConnectError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (client.Connected)
                {
                    // stream send to the server and with it we can login
                    NetworkStream Strm2Ser = client.GetStream();
                    string Info2Ser = "logout" + Glb_Value.Account;
                    byte[] msg = Encoding.Default.GetBytes(Info2Ser);
                    Strm2Ser.Write(msg, 0, msg.Length); // write into the stream                                                      
                    // read stream from the server
                    byte[] msg_get = new byte[50];
                    int bytesRead = 0;
                    Strm2Ser.ReadTimeout = 1000;
                    bool istimeout = false;
                    try
                    {
                        bytesRead = Strm2Ser.Read(msg_get, 0, 50);
                    }
                    catch
                    {
                        istimeout = true;
                        MessageBox.Show("The client is busy now", "ConnectError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Strm2Ser.Close();
                        client.Close();
                    }
                    string succ_flag = Encoding.Default.GetString(msg_get, 0, bytesRead);
                    Regex r = new Regex(@"^loo");

                    if (r.IsMatch(@succ_flag) && istimeout == false)
                    {
                        MessageBox.Show("Succeed Logout! See you next time", "Byebye", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Strm2Ser.Close();
                        client.Close();
                        this.Close();
                        System.Environment.Exit(0);//关闭所有进程
                    }
                    else
                    {
                        MessageBox.Show("The client is busy now", "ConnectError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    client.Close();
                }
            }
            
        }

        /*
            ------------- 发送文本消息 ---------------
             */
        // 点击消息发送时的调用
        private void Chat_send_Click(object sender, EventArgs e)
        {
            // 这里规定不能给自己发送消息
            if (Glb_Value.Chat_Frd == Glb_Value.Account)
            {
                MessageBox.Show("Don't Speak to Yourself!", "ObjectError!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Chat_cmd.Clear();
            }
            // 发送框为空
            else if (Chat_cmd.Text.Length == 0)
            {
                MyMessageBox.set_message("Notice Empty Content!");
                Point pt = Control.MousePosition;
                MyMessageBox.set_position(pt.X, pt.Y + 10);
                MyMessageBox.Show();
            }
            else
            {
                // 正式发送
                List<string> messages = Seg_Img_Text(Glb_Value.Chat_Frd);
                Chat_cmd.Clear();
                string Img_head = "/**Is-a-Img**/"; // 注意这个要和后面进行图片文字分割时统一
                for (int i = 0; i < messages.Count; i++)
                {
                    // 如果找到照片数据流，以文件形式处理
                    if (messages[i].StartsWith(Img_head))
                    {
                        //去掉之前检索图片的头，加上目标用户名的头，和文件发送相同
                        string Img_name = Glb_Value.Chat_Frd + messages[i].Substring(Img_head.Length);
                        try {
                            // 开一个新的文件线程
                            // TODO:做截图时用
                            Thread SendFile;
                        }
                        catch { } 
                    }
                    // 普通文本传递
                    else
                    {
                        bool send_suc = Send_Text(messages[i]);
                        if (!send_suc)
                        {
                            MessageBox.Show("Your friend are not available", "MissError!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break; // 出现连接失败、对方下线等各种情况下，就停止发送，或者对方和别人聊天去了！
                        }
                        else
                        {
                            Self_Dialog show_mine = new Self_Dialog(messages[i]);
                            this.Chat_flowLayout.Controls.Add(show_mine);
                            show_mine.Parent = this.Chat_flowLayout;
                            show_mine.Show();
                        }
                    }
                }
            }
        }
        // 发送纯本文函数 成功返回true
        private bool Send_Text(string msg)
        {
            // 每次发送前再次确认对方Ip和在线状态
            string Frd_IP = Check_Online(Glb_Value.Chat_Frd);
            if (Frd_IP == "Fail")
            {
                return false;
            }
            else
            {
                Glb_Value.Chat_Frd_IP = Frd_IP;
                TcpClient client = new TcpClient();
                // 先尝试连接对应的Ip+端口
                try
                {
                    int port = Convert.ToInt16(Glb_Value.Chat_Frd.Substring(5)) + 10000; // 此端口协议双方协定好了
                    client.Connect(Frd_IP, port);
                }
                catch { }
                if (client.Connected)
                {
                    NetworkStream Strm2Frd = client.GetStream();
                    // 约定发送方每次发送信息，先发送自身账号确保接收方正确返回Hello作为ACK，再进行后续的发送
                    byte[] testmsg = Encoding.Default.GetBytes(Glb_Value.Account);
                    Strm2Frd.Write(testmsg, 0, testmsg.Length);

                    byte[] msg_get = new byte[testmsg.Length];
                    int bytes_length = 0;
                    Strm2Frd.ReadTimeout = 10000;
                    try
                    {
                        bytes_length = Strm2Frd.Read(msg_get, 0, msg_get.Length);
                    }
                    catch
                    {                       
                        Strm2Frd.Close();
                        client.Close();
                        return false;
                    }
                    string succ_flag = Encoding.Default.GetString(msg_get, 0, bytes_length);
                    Regex suc = new Regex(@"^Hello");
                    Regex busy = new Regex(@"^Sorry");
                    if (suc.IsMatch(@succ_flag))
                    {
                        byte[] Sendmsg = Encoding.Default.GetBytes(msg);
                        try
                        {
                            Strm2Frd.Write(Sendmsg, 0, msg.Length);
                        }
                        catch { }
                        Strm2Frd.Close();
                        client.Close();
                        return true;
                    }
                    else if(busy.IsMatch(@succ_flag))
                    {
                        Strm2Frd.Close();
                        client.Close();
                        return false;
                    }
                    else
                    {
                        Strm2Frd.Close();
                        client.Close();
                        return false;
                    }
                }
                // Tcp建立失败
                return false;
            }
        }

        // 空文本发送时的提示
        private void Chat_send_MouseMove(object sender, MouseEventArgs e)
        {
            if (Chat_cmd.Text.Length == 0)
            {
                MyMessageBox.set_message("Notice Empty Content!");
                Point pt = Control.MousePosition;
                MyMessageBox.set_position(pt.X, pt.Y + 10);
                MyMessageBox.Show();
            }
        }

        private void Chat_send_MouseLeave(object sender, EventArgs e)
        {
            MyMessageBox.Visible = false;
        }

        // 使用发送截图时直接复制到rich text box中，可能出现文字图片混合情况，分开发送
        private List<string> Seg_Img_Text(string Chat_Frd)
        {
            // 创建存储发送图片的文件夹 TODO不知道有什么用
            string spath = ".\\" + Glb_Value.Account + "\\Send" + "\\To" + Chat_Frd;
            // 创建信息列表
            List<string> messages = new List<string>();
            List<string> pictures = new List<string>();
            // 先判断是否有图片
            if (Chat_cmd.Rtf.IndexOf(@"{\pict\") > -1)
            {
                //TODO做截图时用
                //注意在图片数据头上加上head：/**Is-a-Img**/ 便于发送时区别发送
            }
            else
            {
                string _msg = Chat_cmd.Text;
                if (_msg.Length > 0)
                {
                    messages.Add(_msg);
                }
            }
            return messages;
        }

        private void Chat_quit_Click(object sender, EventArgs e)
        {
            DialogResult Dr = MessageBox.Show("Ready to Quit Current dialog?", "Check", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Dr == DialogResult.OK)
            {
                Glb_Value.Chatting = false;
                Glb_Value.Chat_Frd = Glb_Value.Account;
                Frd_name.Text = Glb_Value.Account;
                this.Chat_flowLayout.Controls.Clear();
            }
        }

        //划过文件按钮有显示
        private void Files_MouseMove(object sender, MouseEventArgs e)
        {
            MyMessageBox.set_message("Send files here!");
            Point pt = Control.MousePosition;
            MyMessageBox.set_position(pt.X, pt.Y + 10);
            MyMessageBox.Show();
        }

        private void Files_MouseLeave(object sender, EventArgs e)
        {
            MyMessageBox.Visible = false;
        }
    }
}
