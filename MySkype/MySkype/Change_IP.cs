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
    public partial class Change_IP : Form
    {
        public Change_IP()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            Glb_Value.ServerIp = Ip_in.Text;
            Glb_Value.ServerPort = int.Parse(Port_in.Text);
            this.Close();
        }
    }
}
