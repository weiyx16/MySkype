using System;
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
        private byte[] LstBuffer = new byte[1024];//接收对方发送的信息

        public static IPAddress LocalIP { get; set; }//本机IP
        //private Myfriends newfriend;//新加好友
        //public List<Myfriends> myfriends;//保存好友信息
        My_MessageBox MyMessageBox = new My_MessageBox();

        public MainFrm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            
            Glb_Value.Chat_Frd = Glb_Value.Account; //假设当前聊天的即为自己
            // 欢迎信息
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
         // TODO: ? what is the theory?????
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
            //接收到好友尝试连接之后先回复Test，有了第一次握手
            byte[] msg = Encoding.Default.GetBytes("Test");
            try
            {
                Strm2Frd.Write(msg, 0, msg.Length);
            }
            catch { }
            //同时把之前收到的信息转化成字符串，提取对方的身份（学号）
            string FrdName = Encoding.Default.GetString(test_msg, 0, bytes_length);

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
                //receive_file(FrdName, received_words, Stream2Friend);
                //TODO:
            }
            else
            {
                //收到了普通文本
                process_message(FrdName, received_words);//跨线程处理信息+回显
            }
        }

        //处理收到的文字信息
        private void process_message(string FrdName, string received_words)
        {
            //注意这里Acp_msg是由另一个监听的异步触发产生的线程所调用的，需要特殊的处理
            //那么怎么处理呢？
            //有个问题，当我在和A聊天，然后B给我发消息了，怎么办
            //TODO 这里先假设我就只和A聊天
            //先获取对方的Ip地址
            Glb_Value.Chat_Frd_IP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
            Glb_Value.Chat_Frd = FrdName;
            Frd_name.Text = FrdName;
            //TODONOW
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
                        string Img_name = Glb_Value.Chat_Frd + messages[i].Substring(Img_head.Length);
                        try {
                            // 开一个新的文件线程
                            // TODO做截图时用
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
                            MessageBox.Show("Your friend logs out", "MissError!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break; // 出现连接失败、对方下线等各种情况下，就停止发送！
                        }
                        else
                        {
                            //怎么显示在flowoutlayer上？
                            //TODO
                            MessageBox.Show(messages[i], "Have Sent!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    // 约定发送方每次发送信息，先发送自身账号确保接收方正确返回Test作为ACK，再进行后续的发送
                    byte[] testmsg = Encoding.Default.GetBytes(Glb_Value.Account);
                    Strm2Frd.Write(testmsg, 0, testmsg.Length);

                    byte[] msg_get = new byte[testmsg.Length];
                    int bytes_length = 0;
                    Strm2Frd.ReadTimeout = 1000;
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
                    Regex r = new Regex(@"^Test");
                    if (r.IsMatch(@succ_flag))
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
    }
}
