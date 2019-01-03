namespace MySkype
{
    partial class historybox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(historybox));
            this.history = new System.Windows.Forms.RichTextBox();
            this.info = new System.Windows.Forms.Label();
            this.quit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // history
            // 
            this.history.Location = new System.Drawing.Point(21, 39);
            this.history.Name = "history";
            this.history.Size = new System.Drawing.Size(339, 226);
            this.history.TabIndex = 0;
            this.history.Text = "";
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Location = new System.Drawing.Point(21, 21);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(77, 12);
            this.info.TabIndex = 1;
            this.info.Text = "History here";
            // 
            // quit
            // 
            this.quit.Location = new System.Drawing.Point(157, 271);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(75, 23);
            this.quit.TabIndex = 2;
            this.quit.Text = "Ok";
            this.quit.UseVisualStyleBackColor = true;
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // historybox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(385, 304);
            this.Controls.Add(this.quit);
            this.Controls.Add(this.info);
            this.Controls.Add(this.history);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "historybox";
            this.Text = "historybox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox history;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Button quit;
    }
}