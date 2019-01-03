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
            Chat_label.Location = new Point(320-Chat_label.Width, 21);
            Chat_label.BringToFront();
            Sender.Text = Glb_Value.Account;
            picture.Visible = false;
        }

        //从本地导入表情
        public Self_Dialog(bool emojiflag, string emojipath)
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
            time_label.Text = currenttime;
            picture.Image = Image.FromFile(emojipath);// new Bitmap(emoji, emojisize); // resize
            picture.Refresh();
            picture.Location = new Point(320-40, 21);
            picture.Visible = true;
            picture.BringToFront();
            Sender.Text = Glb_Value.Account;
            Chat_label.Visible = false;
        }
    }
}
