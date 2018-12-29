namespace MySkype
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.Info = new System.Windows.Forms.Label();
            this.Info_account = new System.Windows.Forms.Label();
            this.Frd_name = new System.Windows.Forms.Label();
            this.Search_frd = new System.Windows.Forms.TextBox();
            this.Exit_button = new System.Windows.Forms.PictureBox();
            this.Search_button = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Exit_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Search_button)).BeginInit();
            this.SuspendLayout();
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Location = new System.Drawing.Point(12, 9);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(53, 12);
            this.Info.TabIndex = 0;
            this.Info.Text = "Welcome!";
            // 
            // Info_account
            // 
            this.Info_account.AutoSize = true;
            this.Info_account.Location = new System.Drawing.Point(72, 9);
            this.Info_account.Name = "Info_account";
            this.Info_account.Size = new System.Drawing.Size(0, 12);
            this.Info_account.TabIndex = 1;
            // 
            // Frd_name
            // 
            this.Frd_name.AutoSize = true;
            this.Frd_name.Location = new System.Drawing.Point(400, 33);
            this.Frd_name.Name = "Frd_name";
            this.Frd_name.Size = new System.Drawing.Size(65, 12);
            this.Frd_name.TabIndex = 2;
            this.Frd_name.Text = "2016011422";
            // 
            // Search_frd
            // 
            this.Search_frd.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Search_frd.Location = new System.Drawing.Point(13, 33);
            this.Search_frd.Name = "Search_frd";
            this.Search_frd.Size = new System.Drawing.Size(162, 21);
            this.Search_frd.TabIndex = 3;
            this.Search_frd.Text = "Search Friends";
            this.Search_frd.Click += new System.EventHandler(this.Search_frd_Click);
            // 
            // Exit_button
            // 
            this.Exit_button.Image = global::MySkype.Properties.Resources.退出;
            this.Exit_button.Location = new System.Drawing.Point(626, 3);
            this.Exit_button.Name = "Exit_button";
            this.Exit_button.Size = new System.Drawing.Size(21, 18);
            this.Exit_button.TabIndex = 5;
            this.Exit_button.TabStop = false;
            this.Exit_button.Click += new System.EventHandler(this.Exit_button_Click);
            // 
            // Search_button
            // 
            this.Search_button.BackColor = System.Drawing.Color.White;
            this.Search_button.Image = global::MySkype.Properties.Resources.search_small;
            this.Search_button.Location = new System.Drawing.Point(137, 34);
            this.Search_button.Name = "Search_button";
            this.Search_button.Size = new System.Drawing.Size(19, 21);
            this.Search_button.TabIndex = 4;
            this.Search_button.TabStop = false;
            this.Search_button.Click += new System.EventHandler(this.Search_button_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 453);
            this.Controls.Add(this.Exit_button);
            this.Controls.Add(this.Search_button);
            this.Controls.Add(this.Search_frd);
            this.Controls.Add(this.Frd_name);
            this.Controls.Add(this.Info_account);
            this.Controls.Add(this.Info);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFrm";
            this.Text = "MainFrm";
            ((System.ComponentModel.ISupportInitialize)(this.Exit_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Search_button)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.Label Info_account;
        private System.Windows.Forms.Label Frd_name;
        private System.Windows.Forms.TextBox Search_frd;
        private System.Windows.Forms.PictureBox Search_button;
        private System.Windows.Forms.PictureBox Exit_button;
    }
}