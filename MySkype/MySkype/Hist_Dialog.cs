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
    public partial class Hist_Dialog : UserControl
    {
        public Hist_Dialog(string chat_text, string Frd_name, string currenttime)
        {
            InitializeComponent();
            this.time_label.Text = currenttime;
            this.time_label.BringToFront();
            this.Chat_label.Text = chat_text;
            this.Chat_label.Visible = true;
            this.Chat_label.BringToFront();
            this.Sender.Text = Frd_name;
            this.Sender.BringToFront();
        }
    }
}
