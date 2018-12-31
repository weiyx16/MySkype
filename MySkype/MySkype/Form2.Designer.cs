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
            this.Chat_cmd = new System.Windows.Forms.RichTextBox();
            this.Chat_send = new System.Windows.Forms.Button();
            this.Chat_flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.Chat_quit = new System.Windows.Forms.Button();
            this.Logout_label = new System.Windows.Forms.Label();
            this.Frd_flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.Welcome_img = new System.Windows.Forms.PictureBox();
            this.History = new System.Windows.Forms.PictureBox();
            this.Shots = new System.Windows.Forms.PictureBox();
            this.Files = new System.Windows.Forms.PictureBox();
            this.Emoji = new System.Windows.Forms.PictureBox();
            this.Exit_button = new System.Windows.Forms.PictureBox();
            this.Search_button = new System.Windows.Forms.PictureBox();
            this.TopLeft = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Chat_bg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Welcome_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.History)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Shots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Files)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Emoji)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Search_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chat_bg)).BeginInit();
            this.SuspendLayout();
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.BackColor = System.Drawing.SystemColors.Control;
            this.Info.Location = new System.Drawing.Point(91, 9);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(53, 12);
            this.Info.TabIndex = 0;
            this.Info.Text = "Welcome!";
            // 
            // Info_account
            // 
            this.Info_account.AutoSize = true;
            this.Info_account.BackColor = System.Drawing.SystemColors.Control;
            this.Info_account.Location = new System.Drawing.Point(91, 33);
            this.Info_account.Name = "Info_account";
            this.Info_account.Size = new System.Drawing.Size(59, 12);
            this.Info_account.TabIndex = 1;
            this.Info_account.Text = "User_name";
            // 
            // Frd_name
            // 
            this.Frd_name.AutoSize = true;
            this.Frd_name.BackColor = System.Drawing.Color.Snow;
            this.Frd_name.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Frd_name.Location = new System.Drawing.Point(367, 29);
            this.Frd_name.Name = "Frd_name";
            this.Frd_name.Size = new System.Drawing.Size(88, 16);
            this.Frd_name.TabIndex = 2;
            this.Frd_name.Text = "2016011422";
            // 
            // Search_frd
            // 
            this.Search_frd.BackColor = System.Drawing.Color.White;
            this.Search_frd.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Search_frd.Location = new System.Drawing.Point(12, 53);
            this.Search_frd.Name = "Search_frd";
            this.Search_frd.Size = new System.Drawing.Size(162, 21);
            this.Search_frd.TabIndex = 3;
            this.Search_frd.Text = "Search Friends";
            this.Search_frd.Click += new System.EventHandler(this.Search_frd_Click);
            // 
            // Chat_cmd
            // 
            this.Chat_cmd.BackColor = System.Drawing.Color.White;
            this.Chat_cmd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Chat_cmd.Location = new System.Drawing.Point(190, 333);
            this.Chat_cmd.Name = "Chat_cmd";
            this.Chat_cmd.Size = new System.Drawing.Size(433, 109);
            this.Chat_cmd.TabIndex = 6;
            this.Chat_cmd.Text = "";
            this.Chat_cmd.MouseLeave += new System.EventHandler(this.Chat_cmd_MouseLeave);
            this.Chat_cmd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Chat_cmd_MouseMove);
            // 
            // Chat_send
            // 
            this.Chat_send.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Chat_send.Location = new System.Drawing.Point(539, 418);
            this.Chat_send.Name = "Chat_send";
            this.Chat_send.Size = new System.Drawing.Size(75, 23);
            this.Chat_send.TabIndex = 7;
            this.Chat_send.Text = "Send";
            this.Chat_send.UseVisualStyleBackColor = false;
            this.Chat_send.Click += new System.EventHandler(this.Chat_send_Click);
            this.Chat_send.MouseLeave += new System.EventHandler(this.Chat_send_MouseLeave);
            this.Chat_send.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Chat_send_MouseMove);
            // 
            // Chat_flowLayout
            // 
            this.Chat_flowLayout.AutoScroll = true;
            this.Chat_flowLayout.BackColor = System.Drawing.Color.Snow;
            this.Chat_flowLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Chat_flowLayout.Location = new System.Drawing.Point(189, 53);
            this.Chat_flowLayout.Name = "Chat_flowLayout";
            this.Chat_flowLayout.Size = new System.Drawing.Size(434, 255);
            this.Chat_flowLayout.TabIndex = 8;
            this.Chat_flowLayout.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.Chat_flowLayout_ControlAdded);
            this.Chat_flowLayout.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Chat_flowLayout_MouseDown);
            this.Chat_flowLayout.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Chat_flowLayout_MouseUp);
            // 
            // Chat_quit
            // 
            this.Chat_quit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Chat_quit.Location = new System.Drawing.Point(201, 419);
            this.Chat_quit.Name = "Chat_quit";
            this.Chat_quit.Size = new System.Drawing.Size(95, 22);
            this.Chat_quit.TabIndex = 14;
            this.Chat_quit.Text = "Quit Current";
            this.Chat_quit.UseVisualStyleBackColor = false;
            this.Chat_quit.Click += new System.EventHandler(this.Chat_quit_Click);
            // 
            // Logout_label
            // 
            this.Logout_label.AutoSize = true;
            this.Logout_label.BackColor = System.Drawing.Color.Snow;
            this.Logout_label.Location = new System.Drawing.Point(540, 6);
            this.Logout_label.Name = "Logout_label";
            this.Logout_label.Size = new System.Drawing.Size(53, 12);
            this.Logout_label.TabIndex = 15;
            this.Logout_label.Text = "Log Out:";
            // 
            // Frd_flowLayout
            // 
            this.Frd_flowLayout.BackColor = System.Drawing.SystemColors.Control;
            this.Frd_flowLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Frd_flowLayout.Location = new System.Drawing.Point(0, 89);
            this.Frd_flowLayout.Name = "Frd_flowLayout";
            this.Frd_flowLayout.Size = new System.Drawing.Size(189, 358);
            this.Frd_flowLayout.TabIndex = 17;
            // 
            // Welcome_img
            // 
            this.Welcome_img.BackColor = System.Drawing.SystemColors.Control;
            this.Welcome_img.Image = global::MySkype.Properties.Resources.morning;
            this.Welcome_img.Location = new System.Drawing.Point(25, 9);
            this.Welcome_img.Name = "Welcome_img";
            this.Welcome_img.Size = new System.Drawing.Size(48, 38);
            this.Welcome_img.TabIndex = 13;
            this.Welcome_img.TabStop = false;
            // 
            // History
            // 
            this.History.BackColor = System.Drawing.Color.White;
            this.History.Image = global::MySkype.Properties.Resources.History;
            this.History.Location = new System.Drawing.Point(285, 312);
            this.History.Name = "History";
            this.History.Size = new System.Drawing.Size(22, 20);
            this.History.TabIndex = 12;
            this.History.TabStop = false;
            // 
            // Shots
            // 
            this.Shots.BackColor = System.Drawing.Color.White;
            this.Shots.Image = global::MySkype.Properties.Resources.Shots;
            this.Shots.Location = new System.Drawing.Point(257, 312);
            this.Shots.Name = "Shots";
            this.Shots.Size = new System.Drawing.Size(22, 20);
            this.Shots.TabIndex = 11;
            this.Shots.TabStop = false;
            this.Shots.Click += new System.EventHandler(this.Shots_Click);
            // 
            // Files
            // 
            this.Files.BackColor = System.Drawing.Color.White;
            this.Files.Image = global::MySkype.Properties.Resources.file;
            this.Files.Location = new System.Drawing.Point(229, 312);
            this.Files.Name = "Files";
            this.Files.Size = new System.Drawing.Size(22, 20);
            this.Files.TabIndex = 10;
            this.Files.TabStop = false;
            this.Files.Click += new System.EventHandler(this.Files_Click);
            this.Files.MouseLeave += new System.EventHandler(this.Files_MouseLeave);
            this.Files.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Files_MouseMove);
            // 
            // Emoji
            // 
            this.Emoji.BackColor = System.Drawing.Color.White;
            this.Emoji.Image = global::MySkype.Properties.Resources.Emoji;
            this.Emoji.Location = new System.Drawing.Point(201, 312);
            this.Emoji.Name = "Emoji";
            this.Emoji.Size = new System.Drawing.Size(22, 20);
            this.Emoji.TabIndex = 9;
            this.Emoji.TabStop = false;
            // 
            // Exit_button
            // 
            this.Exit_button.BackColor = System.Drawing.Color.Snow;
            this.Exit_button.Image = global::MySkype.Properties.Resources.退出;
            this.Exit_button.Location = new System.Drawing.Point(595, 3);
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
            this.Search_button.Location = new System.Drawing.Point(136, 54);
            this.Search_button.Name = "Search_button";
            this.Search_button.Size = new System.Drawing.Size(19, 19);
            this.Search_button.TabIndex = 4;
            this.Search_button.TabStop = false;
            this.Search_button.Click += new System.EventHandler(this.Search_button_Click);
            // 
            // TopLeft
            // 
            this.TopLeft.BackColor = System.Drawing.SystemColors.Control;
            this.TopLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TopLeft.Location = new System.Drawing.Point(0, 0);
            this.TopLeft.Name = "TopLeft";
            this.TopLeft.Size = new System.Drawing.Size(189, 89);
            this.TopLeft.TabIndex = 16;
            this.TopLeft.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Snow;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(189, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(434, 54);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // Chat_bg
            // 
            this.Chat_bg.BackColor = System.Drawing.Color.White;
            this.Chat_bg.Location = new System.Drawing.Point(189, 308);
            this.Chat_bg.Name = "Chat_bg";
            this.Chat_bg.Size = new System.Drawing.Size(434, 137);
            this.Chat_bg.TabIndex = 18;
            this.Chat_bg.TabStop = false;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 454);
            this.Controls.Add(this.Logout_label);
            this.Controls.Add(this.Chat_quit);
            this.Controls.Add(this.Welcome_img);
            this.Controls.Add(this.History);
            this.Controls.Add(this.Shots);
            this.Controls.Add(this.Files);
            this.Controls.Add(this.Emoji);
            this.Controls.Add(this.Chat_flowLayout);
            this.Controls.Add(this.Chat_send);
            this.Controls.Add(this.Chat_cmd);
            this.Controls.Add(this.Exit_button);
            this.Controls.Add(this.Search_button);
            this.Controls.Add(this.Search_frd);
            this.Controls.Add(this.Frd_name);
            this.Controls.Add(this.Info_account);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.TopLeft);
            this.Controls.Add(this.Frd_flowLayout);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Chat_bg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFrm";
            this.Text = "MainFrm";
            ((System.ComponentModel.ISupportInitialize)(this.Welcome_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.History)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Shots)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Files)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Emoji)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Search_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chat_bg)).EndInit();
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
        private System.Windows.Forms.RichTextBox Chat_cmd;
        private System.Windows.Forms.Button Chat_send;
        private System.Windows.Forms.FlowLayoutPanel Chat_flowLayout;
        private System.Windows.Forms.PictureBox Emoji;
        private System.Windows.Forms.PictureBox Files;
        private System.Windows.Forms.PictureBox Shots;
        private System.Windows.Forms.PictureBox History;
        private System.Windows.Forms.PictureBox Welcome_img;
        private System.Windows.Forms.Button Chat_quit;
        private System.Windows.Forms.Label Logout_label;
        private System.Windows.Forms.PictureBox TopLeft;
        private System.Windows.Forms.FlowLayoutPanel Frd_flowLayout;
        private System.Windows.Forms.PictureBox Chat_bg;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}