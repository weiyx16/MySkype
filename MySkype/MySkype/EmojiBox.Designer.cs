namespace MySkype
{
    partial class EmojiBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmojiBox));
            this.Emoji3 = new System.Windows.Forms.PictureBox();
            this.Emoji2 = new System.Windows.Forms.PictureBox();
            this.Emoji1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Emoji3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Emoji2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Emoji1)).BeginInit();
            this.SuspendLayout();
            // 
            // Emoji3
            // 
            this.Emoji3.Image = global::MySkype.Properties.Resources.emoji2;
            this.Emoji3.Location = new System.Drawing.Point(137, 12);
            this.Emoji3.Name = "Emoji3";
            this.Emoji3.Size = new System.Drawing.Size(40, 40);
            this.Emoji3.TabIndex = 2;
            this.Emoji3.TabStop = false;
            this.Emoji3.Click += new System.EventHandler(this.Emoji_Click);
            // 
            // Emoji2
            // 
            this.Emoji2.Image = global::MySkype.Properties.Resources.emoji1;
            this.Emoji2.Location = new System.Drawing.Point(81, 12);
            this.Emoji2.Name = "Emoji2";
            this.Emoji2.Size = new System.Drawing.Size(40, 40);
            this.Emoji2.TabIndex = 1;
            this.Emoji2.TabStop = false;
            this.Emoji2.Click += new System.EventHandler(this.Emoji_Click);
            // 
            // Emoji1
            // 
            this.Emoji1.Image = global::MySkype.Properties.Resources.emoji0;
            this.Emoji1.Location = new System.Drawing.Point(24, 12);
            this.Emoji1.Name = "Emoji1";
            this.Emoji1.Size = new System.Drawing.Size(40, 40);
            this.Emoji1.TabIndex = 0;
            this.Emoji1.TabStop = false;
            this.Emoji1.Click += new System.EventHandler(this.Emoji_Click);
            // 
            // EmojiBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(197, 65);
            this.Controls.Add(this.Emoji3);
            this.Controls.Add(this.Emoji2);
            this.Controls.Add(this.Emoji1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EmojiBox";
            this.Text = "EmojiBox";
            this.Deactivate += new System.EventHandler(this.EmojiBox_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.Emoji3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Emoji2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Emoji1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Emoji1;
        private System.Windows.Forms.PictureBox Emoji2;
        private System.Windows.Forms.PictureBox Emoji3;
    }
}