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
    public partial class Self_Dialog : UserControl
    {
        bool isEmoji = false;
        public Self_Dialog(string chat_text)
        {
            // 如果发送的是纯文本
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
            Chat_label.Text = chat_text;
            Chat_label.Visible = true;
            this.Height = 80;
            Chat_label.Location = new Point(300-Chat_label.Width, 30);
            Chat_label.BringToFront();
            Sender.Text = Glb_Value.Account;
            picture.Visible = false;
        }

        public Self_Dialog(Image img)
        {
            // 如果发送的是表情
            // 注意截图图片是当文件处理的
            isEmoji = true;
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
            picture.Width = 40;
            picture.Height = 40;
            picture.Image = new Bitmap(img, 40, 40);
            picture.Location = new Point(300-40, 30);
            picture.Visible = true;
            picture.BringToFront();
            Chat_label.Visible = false;
            Sender.Text = Glb_Value.Account;
        }
    }
}
