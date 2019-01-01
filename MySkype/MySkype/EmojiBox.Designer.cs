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
            this.Emoji4 = new System.Windows.Forms.PictureBox();
            this.Emoji3 = new System.Windows.Forms.PictureBox();
            this.Emoji2 = new System.Windows.Forms.PictureBox();
            this.Emoji1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Emoji4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Emoji3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Emoji2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Emoji1)).BeginInit();
            this.SuspendLayout();
            // 
            // Emoji4
            // 
            this.Emoji4.Image = global::MySkype.Properties.Resources.emoji_4;
            this.Emoji4.Location = new System.Drawing.Point(289, 12);
            this.Emoji4.Name = "Emoji4";
            this.Emoji4.Size = new System.Drawing.Size(70, 70);
            this.Emoji4.TabIndex = 3;
            this.Emoji4.TabStop = false;
            this.Emoji4.Click += new System.EventHandler(this.Emoji_Click);
            // 
            // Emoji3
            // 
            this.Emoji3.Image = global::MySkype.Properties.Resources.emoji_3;
            this.Emoji3.Location = new System.Drawing.Point(195, 12);
            this.Emoji3.Name = "Emoji3";
            this.Emoji3.Size = new System.Drawing.Size(70, 70);
            this.Emoji3.TabIndex = 2;
            this.Emoji3.TabStop = false;
            this.Emoji3.Click += new System.EventHandler(this.Emoji_Click);
            // 
            // Emoji2
            // 
            this.Emoji2.Image = global::MySkype.Properties.Resources.emoji_2;
            this.Emoji2.Location = new System.Drawing.Point(102, 12);
            this.Emoji2.Name = "Emoji2";
            this.Emoji2.Size = new System.Drawing.Size(70, 70);
            this.Emoji2.TabIndex = 1;
            this.Emoji2.TabStop = false;
            this.Emoji2.Click += new System.EventHandler(this.Emoji_Click);
            // 
            // Emoji1
            // 
            this.Emoji1.Image = global::MySkype.Properties.Resources.emoji_11;
            this.Emoji1.Location = new System.Drawing.Point(12, 12);
            this.Emoji1.Name = "Emoji1";
            this.Emoji1.Size = new System.Drawing.Size(70, 70);
            this.Emoji1.TabIndex = 0;
            this.Emoji1.TabStop = false;
            this.Emoji1.Click += new System.EventHandler(this.Emoji_Click);
            // 
            // EmojiBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(373, 91);
            this.Controls.Add(this.Emoji4);
            this.Controls.Add(this.Emoji3);
            this.Controls.Add(this.Emoji2);
            this.Controls.Add(this.Emoji1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EmojiBox";
            this.Text = "EmojiBox";
            this.Deactivate += new System.EventHandler(this.EmojiBox_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.Emoji4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Emoji3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Emoji2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Emoji1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Emoji1;
        private System.Windows.Forms.PictureBox Emoji2;
        private System.Windows.Forms.PictureBox Emoji3;
        private System.Windows.Forms.PictureBox Emoji4;
    }
}