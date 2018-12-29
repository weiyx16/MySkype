using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySkype
{
    public partial class My_MessageBox : Form
    {
        public My_MessageBox()
        {
            InitializeComponent();
            this.TopMost = true;        
            this.Location = new Point(MousePosition.X, MousePosition.Y);
            this.StartPosition = FormStartPosition.Manual;
        }
        public void set_message(string message_text)
        {
            message_label.Text = message_text;
        }
        public void set_position(int x, int y)
        {
            this.Location = new Point(x, y);
        }
    }
}
