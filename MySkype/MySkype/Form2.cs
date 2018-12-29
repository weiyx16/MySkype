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
        private Thread LstThd;//后台侦听线程
        private TcpListener LstTcp;//侦听来自TCP网络客户端的连接
        //public List<Myfriends> myfriends;//保存好友信息
        public static IPAddress LocalIP { get; set; }//本机IP
        //private Myfriends newfriend;//新加好友
        My_MessageBox MyMessageBox = new My_MessageBox();

        public MainFrm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Info_account.Text = Glb_Value.Account;

            Glb_Value.Chat_Frd = Glb_Value.Account; //假设当前聊天的即为自己
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
                    string Frd_IP = Check_Online(this.Search_frd.Text, true);
                    if (Frd_IP == "Fail") {
                        Search_frd.Clear();
                    }
                    else
                    {
                        DialogResult Dr = MessageBox.Show("This friend has been found, chat now?", "Check", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);                 
                        if (Dr == DialogResult.OK)
                        {
                            // 开始聊天
                            Frd_name.Text = Search_frd.Text;
                            // TODO:
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
        private string Check_Online(string FrdName, bool show)
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

        //退出登录
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
                    //Strm2Ser.Read(msg, 0, msg.Length); // read stream from the server

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

                    //if successfully log in which means the account and password is right
                    //if (msg[0] == 'l' && msg[1] == 'o' && msg[2] == 'l' && istimeout == false) // if you directly use msg is just ok
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
    }
}
