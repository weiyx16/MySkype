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
using System.Runtime.InteropServices;//窗体效果
using System.IO;//读写文件
using System.Net.NetworkInformation;
using System.Net;
using System.Text.RegularExpressions;

namespace MySkype
{
    public partial class LOGIN : Form
    {
        My_MessageBox MyMessageBox = new My_MessageBox();
        public LOGIN()
        {
            InitializeComponent();
            //屏幕居中显示
            this.StartPosition = FormStartPosition.CenterScreen;
            //设置默认服务器IP和端口号
            Glb_Value.ServerIp = "166.111.140.14";
            Glb_Value.ServerPort = 8000;
            this.DialogResult = DialogResult.Retry;
            Glb_Value.login_cls = false;
        }

        // return the account to the main function
        public string AccountValue
        {
            get
            {
                return this.Account.Text;
            }
        }

        private void Login_button_Click(object sender, EventArgs e)
        {    
            if (Account_judge())
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
                    string Info2Ser = Account.Text + "_" + Password.Text;
                    byte[] msg = Encoding.Default.GetBytes(Info2Ser);
                    Strm2Ser.Write(msg, 0, msg.Length); // write into the stream
                    //Strm2Ser.Read(msg, 0, msg.Length); // read stream from the server

                    byte[] msg_get = new byte[50];
                    int bytes_length = 0;
                    Strm2Ser.ReadTimeout = 1000;
                    bool istimeout = false;
                    try
                    {
                        bytes_length = Strm2Ser.Read(msg_get, 0, 50);
                    }
                    catch
                    {
                        istimeout = true;
                        MessageBox.Show("The client is busy now", "ConnectError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Strm2Ser.Close();
                        client.Close();
                    }
                    string succ_flag = Encoding.Default.GetString(msg_get, 0, bytes_length);
                    Regex r = new Regex(@"^lol");
                    
                    //if successfully log in which means the account and password is right
                    //if (msg[0] == 'l' && msg[1] == 'o' && msg[2] == 'l' && istimeout == false) // if you directly use msg is just ok
                    if (r.IsMatch(@succ_flag) && istimeout == false)
                    {
                        Glb_Value.Account = Account.Text;
                        MessageBox.Show("Success Login!", "Congratulation!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        Glb_Value.login_cls = true;                         
                        Strm2Ser.Close();
                        client.Close();
                    }
                    else
                    {
                        MessageBox.Show("Check the password or account which I don't know. Or if the client is down?", "PasswordError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Password.Clear();
                    }
                }
                else
                {
                    client.Close();
                }
            }
        }

        // 初始判断登录合法性
        public bool Account_judge()
        {
            string account = Account.Text;
            string password = Password.Text;
            int acc_length = Account.TextLength;

            bool login_confirm_flag = false;
            // judge the logical account first
            if ((account == null || account.Length == 0) || (password == null || password.Length==0))
            {
                MessageBox.Show("The account or the password should not be null", "EmptyError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return login_confirm_flag;
            }
            else
            {
                string pattern = @"^20160[0-9]{5}";
                if (!Regex.IsMatch(account, pattern))
                {
                    MessageBox.Show("Check the account which should be 10 numbers", "AccountError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Account.Clear();
                    Password.Clear();
                    return login_confirm_flag;
                }
                /*
                if (String.Compare(password, "net2018") != 0)
                {
                    MessageBox.Show("Check the password which I don't know", "PasswordError", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                    Password.Clear();
                    return login_confirm_flag;
                }
                */
                // repeat login
                int Port = int.Parse(account.Substring(5)) + 10000; //11422->21422
                if (Port_Occupy(Port)){
                    MessageBox.Show("This account has logged in!", "ReLoginError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Password.Clear();
                    Account.Clear();
                    return login_confirm_flag;
                }
                login_confirm_flag = true;
                return login_confirm_flag;
            }
        }

        public bool Port_Occupy(int cur_port)//检查我方端口是否被占用 (TODO) 貌似没啥用？得到后面登录了打开监听的线程了才有用
        {
            bool port_occ = false;
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();

            foreach (IPEndPoint endpoint in ipEndPoints)
            {
                if (endpoint.Port == cur_port)
                {
                    port_occ = true;
                    break;
                }
            }
            return port_occ;
        }

        // Show the current time
        private void timer1_Tick(object sender, EventArgs e)
        {
            Showtime.Text = DateTime.Now.ToString();
        }

        // Show the password
        private void Show_password_CheckedChanged(object sender, EventArgs e)
        {
            if (Show_password.Checked == true)
            {
                Password.UseSystemPasswordChar = false;
            }
            else
            {
                Password.UseSystemPasswordChar = true; 
            }
        }

        // Help change the IP and Port
        // 这个函数还没写 changeIp的窗口
        private void IP_change_MouseClick(object sender, MouseEventArgs e)
        {
            Change_IP change_ip = new Change_IP();
            change_ip.ShowDialog();
        }

        private void IP_change_MouseMove(object sender, MouseEventArgs e)
        {      
            Point pt = Control.MousePosition;
            MyMessageBox.set_message("Change IP and Port");
            MyMessageBox.set_position(pt.X + 5, pt.Y + 5);
            MyMessageBox.Show();
        }

        private void IP_change_MouseLeave(object sender, EventArgs e)
        {
            MyMessageBox.Visible = false;
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            Glb_Value.login_cls = true;
            this.DialogResult = DialogResult.No;
        }

        private void Quit_MouseMove(object sender, MouseEventArgs e)
        {
            Point pt = Control.MousePosition;
            MyMessageBox.set_message("Cancel the login");
            MyMessageBox.set_position(pt.X + 5, pt.Y + 5);
            MyMessageBox.Show();
        }

        private void Quit_MouseLeave(object sender, EventArgs e)
        {
            MyMessageBox.Visible = false;
        }
    }
}
