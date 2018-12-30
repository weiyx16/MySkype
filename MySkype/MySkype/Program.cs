using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace MySkype
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LOGIN loginFrm = new LOGIN();
            loginFrm.ShowDialog();
            while (!Glb_Value.login_cls) { loginFrm.ShowDialog(); }
            if (loginFrm.DialogResult == DialogResult.OK && Glb_Value.login_cls)
            {
                loginFrm.Close();
                Application.Run(new MainFrm());
                quit();
                System.Environment.Exit(0); //关闭时结束所有进程
            }

        }
        //用户直接关闭窗口时，可能服务器繁忙，那就不退出，直接释放所有线程
        static void quit()
        {
            DialogResult Dr = MessageBox.Show("Force Quit Here", "Check", MessageBoxButtons.OK, MessageBoxIcon.Question);
            TcpClient client = new TcpClient();
            // try to connet the client and check if we lose it
            try
            {
                client.Connect(Glb_Value.ServerIp, Glb_Value.ServerPort);
            }
            catch
            {
                MessageBox.Show("The client is busy now. We just close the software here!", "ConnectError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    MessageBox.Show("The client is busy now. We just close the software here!", "ConnectError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Strm2Ser.Close();
                    client.Close();
                    System.Environment.Exit(0);//关闭所有进程
                }
                string succ_flag = Encoding.Default.GetString(msg_get, 0, bytesRead);
                Regex r = new Regex(@"^loo");

                if (r.IsMatch(@succ_flag) && istimeout == false)
                {
                    MessageBox.Show("Succeed Logout! See you next time", "Byebye", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Strm2Ser.Close();
                    client.Close();
                    System.Environment.Exit(0);//关闭所有进程
                }
                else
                {
                    MessageBox.Show("The client is busy now. We just close the software here!", "ConnectError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Strm2Ser.Close();
                    client.Close();
                    System.Environment.Exit(0);//关闭所有进程
                }
            }
            else
            {
                client.Close();
                System.Environment.Exit(0);//关闭所有进程
            }
        }
    }
}
