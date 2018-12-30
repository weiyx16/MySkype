namespace MySkype
{
    partial class Frd_Files
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
            this.FileName = new System.Windows.Forms.Label();
            this.Process = new System.Windows.Forms.Label();
            this.Sender = new System.Windows.Forms.Label();
            this.time_label = new System.Windows.Forms.Label();
            this.picture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // FileName
            // 
            this.FileName.AutoSize = true;
            this.FileName.Location = new System.Drawing.Point(131, 24);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(29, 12);
            this.FileName.TabIndex = 11;
            this.FileName.Text = "name";
            // 
            // Process
            // 
            this.Process.AutoSize = true;
            this.Process.Location = new System.Drawing.Point(131, 43);
            this.Process.Name = "Process";
            this.Process.Size = new System.Drawing.Size(65, 12);
            this.Process.TabIndex = 10;
            this.Process.Text = "##########";
            // 
            // Sender
            // 
            this.Sender.AutoSize = true;
            this.Sender.Location = new System.Drawing.Point(19, 21);
            this.Sender.Name = "Sender";
            this.Sender.Size = new System.Drawing.Size(65, 12);
            this.Sender.TabIndex = 8;
            this.Sender.Text = "2016000000";
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Location = new System.Drawing.Point(190, 6);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(35, 12);
            this.time_label.TabIndex = 7;
            this.time_label.Text = "01:11";
            // 
            // picture
            // 
            this.picture.Image = global::MySkype.Properties.Resources.file_send_use;
            this.picture.Location = new System.Drawing.Point(84, 21);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(40, 40);
            this.picture.TabIndex = 9;
            this.picture.TabStop = false;
            // 
            // Frd_Files
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.Controls.Add(this.FileName);
            this.Controls.Add(this.Process);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.Sender);
            this.Controls.Add(this.time_label);
            this.Name = "Frd_Files";
            this.Size = new System.Drawing.Size(408, 70);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FileName;
        private System.Windows.Forms.Label Process;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Label Sender;
        private System.Windows.Forms.Label time_label;
    }
}
