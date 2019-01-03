using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;//读写文件

namespace MySkype
{
    public partial class historybox : Form
    {
        public historybox(string filename)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            string str = File.ReadAllText(@filename);
            history.Text = str;
        }

        private void quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
