using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySkype
{
    public partial class Self_Files : UserControl
    {
        public Self_Files(string filename, int processing)
        {
            InitializeComponent();
            string currenttime;
            if (DateTime.Now.Hour < 10)//小时只有1位则补零
                currenttime = "0" + DateTime.Now.Hour.ToString();
            else
                currenttime = DateTime.Now.Hour.ToString();
            if (DateTime.Now.Minute < 10)//分钟只有1位则补零
                currenttime += ":" + "0" + DateTime.Now.Minute.ToString();
            else
                currenttime += ":" + DateTime.Now.Minute.ToString();
            time_label.Text = currenttime;
            time_label.BringToFront();
            FileName.Text = filename;
            FileName.Visible = true;
            FileName.BringToFront();
            Sender.Text = Glb_Value.Account;
            Sender.BringToFront();
            if (processing != -1)
            {
                string process_now = "";
                for (int i = 0; i < processing; i++)
                {
                    process_now += "#";
                }
                Process.Text = process_now;
                Process.Visible = true;
                Process.BringToFront();
            }
            else
            {
                Process.Text = "Fails!!!!";
                Process.Visible = true;
                Process.BringToFront();
            }
            Process.BringToFront();
            picture.BringToFront();
        }

        public string get_time()
        {
            return time_label.Text;
        }

        public string get_files()
        {
            if (Process.Text.Equals("Fails!!!!"))
            {
                return FileName.Text + " failed";
            }
            return FileName.Text;
        }
    }
}
