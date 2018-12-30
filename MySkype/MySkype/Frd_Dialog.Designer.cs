namespace MySkype
{
    partial class Frd_Dialog
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
            this.time_label = new System.Windows.Forms.Label();
            this.Sender = new System.Windows.Forms.Label();
            this.picture = new System.Windows.Forms.PictureBox();
            this.Chat_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Location = new System.Drawing.Point(190, 15);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(35, 12);
            this.time_label.TabIndex = 1;
            this.time_label.Text = "01:11";
            // 
            // Sender
            // 
            this.Sender.AutoSize = true;
            this.Sender.Location = new System.Drawing.Point(19, 30);
            this.Sender.Name = "Sender";
            this.Sender.Size = new System.Drawing.Size(65, 12);
            this.Sender.TabIndex = 3;
            this.Sender.Text = "2016000000";
            // 
            // picture
            // 
            this.picture.Location = new System.Drawing.Point(90, 30);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(40, 40);
            this.picture.TabIndex = 4;
            this.picture.TabStop = false;
            this.picture.Visible = false;
            // 
            // Chat_label
            // 
            this.Chat_label.AutoSize = true;
            this.Chat_label.Location = new System.Drawing.Point(90, 30);
            this.Chat_label.Name = "Chat_label";
            this.Chat_label.Size = new System.Drawing.Size(11, 12);
            this.Chat_label.TabIndex = 5;
            this.Chat_label.Text = "C";
            // 
            // Frd_Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Chat_label);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.Sender);
            this.Controls.Add(this.time_label);
            this.Name = "Frd_Dialog";
            this.Size = new System.Drawing.Size(414, 80);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label time_label;
        private System.Windows.Forms.Label Sender;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Label Chat_label;
    }
}
