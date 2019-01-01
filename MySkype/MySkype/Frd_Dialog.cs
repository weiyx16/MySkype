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
    public partial class Frd_Dialog : UserControl
    {
        bool isEmoji = false; // 接口暂留，万一要用
        public Frd_Dialog(string chat_text, string Frd_name)
        {
            InitializeComponent();
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
            this.time_label.Text = currenttime;
            this.time_label.BringToFront();
            this.Chat_label.Text = chat_text;
            this.Chat_label.Visible = true;
            this.Chat_label.Location = new Point(90, 21);
            this.Chat_label.BringToFront();
            this.Sender.Text = Frd_name;
            this.Sender.BringToFront();
            this.picture.Visible = false;
        }

        public Frd_Dialog(bool emojiflag, string emojipath, string Frd_name)
        {
            InitializeComponent();
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
            this.time_label.Text = currenttime;
            this.time_label.BringToFront();
            this.picture.Width = 40;
            this.picture.Height = 40;
            Size emojisize = new Size(40, 40);
            Bitmap emoji = new Bitmap(emojipath);
            this.picture.Image = new Bitmap(emoji, emojisize); // resize
            this.picture.Location = new Point(90, 21);
            this.picture.Visible = true;
            this.picture.BringToFront();
            this.Chat_label.Visible = false;
            this.Sender.Text = Frd_name;
            this.Sender.BringToFront();
        }

    }
}
