namespace MySkype
{
    partial class LOGIN
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOGIN));
            this.Account = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.Account_label = new System.Windows.Forms.Label();
            this.Password_label = new System.Windows.Forms.Label();
            this.Login_button = new System.Windows.Forms.Button();
            this.Showtime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Show_password = new System.Windows.Forms.CheckBox();
            this.IP_change = new System.Windows.Forms.Button();
            this.Quit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Account
            // 
            this.Account.Location = new System.Drawing.Point(129, 64);
            this.Account.Name = "Account";
            this.Account.Size = new System.Drawing.Size(100, 21);
            this.Account.TabIndex = 0;
            this.Account.Text = "2016011422";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(129, 113);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(100, 21);
            this.Password.TabIndex = 1;
            this.Password.UseSystemPasswordChar = true;
            // 
            // Account_label
            // 
            this.Account_label.AutoSize = true;
            this.Account_label.Location = new System.Drawing.Point(52, 67);
            this.Account_label.Name = "Account_label";
            this.Account_label.Size = new System.Drawing.Size(53, 12);
            this.Account_label.TabIndex = 2;
            this.Account_label.Text = "Account:";
            // 
            // Password_label
            // 
            this.Password_label.AutoSize = true;
            this.Password_label.Location = new System.Drawing.Point(52, 116);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(59, 12);
            this.Password_label.TabIndex = 3;
            this.Password_label.Text = "Password:";
            // 
            // Login_button
            // 
            this.Login_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Login_button.Location = new System.Drawing.Point(129, 171);
            this.Login_button.Name = "Login_button";
            this.Login_button.Size = new System.Drawing.Size(75, 23);
            this.Login_button.TabIndex = 4;
            this.Login_button.Text = "Login!";
            this.Login_button.UseVisualStyleBackColor = true;
            this.Login_button.Click += new System.EventHandler(this.Login_button_Click);
            // 
            // Showtime
            // 
            this.Showtime.AutoSize = true;
            this.Showtime.BackColor = System.Drawing.Color.Transparent;
            this.Showtime.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Showtime.Location = new System.Drawing.Point(34, 20);
            this.Showtime.Name = "Showtime";
            this.Showtime.Size = new System.Drawing.Size(54, 21);
            this.Showtime.TabIndex = 5;
            this.Showtime.Text = "Time";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Show_password
            // 
            this.Show_password.AutoSize = true;
            this.Show_password.Location = new System.Drawing.Point(235, 118);
            this.Show_password.Name = "Show_password";
            this.Show_password.Size = new System.Drawing.Size(102, 16);
            this.Show_password.TabIndex = 6;
            this.Show_password.Text = "Show Password";
            this.Show_password.UseVisualStyleBackColor = true;
            this.Show_password.CheckedChanged += new System.EventHandler(this.Show_password_CheckedChanged);
            // 
            // IP_change
            // 
            this.IP_change.Location = new System.Drawing.Point(255, 221);
            this.IP_change.Name = "IP_change";
            this.IP_change.Size = new System.Drawing.Size(75, 23);
            this.IP_change.TabIndex = 7;
            this.IP_change.Text = "Change IP";
            this.IP_change.UseVisualStyleBackColor = true;
            this.IP_change.MouseClick += new System.Windows.Forms.MouseEventHandler(this.IP_change_MouseClick);
            this.IP_change.MouseLeave += new System.EventHandler(this.IP_change_MouseLeave);
            this.IP_change.MouseMove += new System.Windows.Forms.MouseEventHandler(this.IP_change_MouseMove);
            // 
            // Quit
            // 
            this.Quit.Location = new System.Drawing.Point(30, 221);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(75, 23);
            this.Quit.TabIndex = 8;
            this.Quit.Text = "Quit!";
            this.Quit.UseVisualStyleBackColor = true;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            this.Quit.MouseLeave += new System.EventHandler(this.Quit_MouseLeave);
            this.Quit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Quit_MouseMove);
            // 
            // LOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 261);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.IP_change);
            this.Controls.Add(this.Show_password);
            this.Controls.Add(this.Showtime);
            this.Controls.Add(this.Login_button);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.Account_label);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Account);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LOGIN";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Account;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label Account_label;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.Button Login_button;
        private System.Windows.Forms.Label Showtime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox Show_password;
        private System.Windows.Forms.Button IP_change;
        private System.Windows.Forms.Button Quit;
    }
}

