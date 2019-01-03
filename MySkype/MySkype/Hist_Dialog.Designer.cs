namespace MySkype
{
    partial class Hist_Dialog
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Sender = new System.Windows.Forms.Label();
            this.Chat_label = new System.Windows.Forms.Label();
            this.time_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Sender
            // 
            this.Sender.AutoSize = true;
            this.Sender.Location = new System.Drawing.Point(4, 5);
            this.Sender.Name = "Sender";
            this.Sender.Size = new System.Drawing.Size(29, 12);
            this.Sender.TabIndex = 0;
            this.Sender.Text = "2016";
            // 
            // Chat_label
            // 
            this.Chat_label.AutoSize = true;
            this.Chat_label.Location = new System.Drawing.Point(4, 26);
            this.Chat_label.MaximumSize = new System.Drawing.Size(120, 12);
            this.Chat_label.Name = "Chat_label";
            this.Chat_label.Size = new System.Drawing.Size(11, 12);
            this.Chat_label.TabIndex = 1;
            this.Chat_label.Text = "c";
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Location = new System.Drawing.Point(135, 26);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(11, 12);
            this.time_label.TabIndex = 2;
            this.time_label.Text = "t";
            // 
            // Hist_Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.time_label);
            this.Controls.Add(this.Chat_label);
            this.Controls.Add(this.Sender);
            this.Name = "Hist_Dialog";
            this.Size = new System.Drawing.Size(160, 45);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Sender;
        private System.Windows.Forms.Label Chat_label;
        private System.Windows.Forms.Label time_label;
    }
}
