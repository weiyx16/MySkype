using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;

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
                System.Environment.Exit(0); //关闭时结束所有进程
            }

        }
    }
}
