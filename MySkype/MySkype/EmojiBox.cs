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
    // 在表情中弹窗，在主窗体中操作，实现类似数据传输的效果
    // 定义了一个委托
    public delegate void Send_Emoji(int number);
    public partial class EmojiBox : Form
    {
        // 定义一个事件 内部触发，交由主函数执行
        public event Send_Emoji send_emoji;
        private static int emoji_num = 3;
        private int[] emoji_location = new int[emoji_num];//3个表情的横坐标位置（以此作为索引）
        public EmojiBox()
        {
            InitializeComponent();
            this.Location = new Point(220, 220);
            this.StartPosition = FormStartPosition.Manual;

            for (int i = 0; i < emoji_num; i++)
                emoji_location[i] = 0;
            //记录每个控件的初始位置
            for (int i = 0; i < this.Controls.Count; i++)
            {
                emoji_location[i] = this.Controls[i].Location.X;
            }
            Application.DoEvents();
        }
        private void Emoji_Click(object sender, EventArgs e)
        {
            Point mouse_pos = this.PointToClient(Control.MousePosition);//求出鼠标相对窗口位置
            
            send_emoji(find_emoji(mouse_pos.X));
        }

        private int find_emoji(int x)//寻找鼠标在哪个表情上
        {
            int j = 0;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (x - emoji_location[this.Controls.Count-i-1] <= 40)
                {
                    j = i;
                    break;
                }
            }
            return j;
        }

        private void EmojiBox_Deactivate(object sender, EventArgs e)
        {
            this.Hide(); // hide or close?
        }


    }
}
