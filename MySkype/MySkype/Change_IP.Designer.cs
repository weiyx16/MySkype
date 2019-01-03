namespace MySkype
{
    partial class Change_IP
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
            this.Port_label = new System.Windows.Forms.Label();
            this.IP_label = new System.Windows.Forms.Label();
            this.Port_in = new System.Windows.Forms.TextBox();
            this.Ip_in = new System.Windows.Forms.TextBox();
            this.Confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Port_label
            // 
            this.Port_label.AutoSize = true;
            this.Port_label.Location = new System.Drawing.Point(52, 103);
            this.Port_label.Name = "Port_label";
            this.Port_label.Size = new System.Drawing.Size(59, 12);
            this.Port_label.TabIndex = 7;
            this.Port_label.Text = "New Port:";
            // 
            // IP_label
            // 
            this.IP_label.AutoSize = true;
            this.IP_label.Location = new System.Drawing.Point(52, 54);
            this.IP_label.Name = "IP_label";
            this.IP_label.Size = new System.Drawing.Size(47, 12);
            this.IP_label.TabIndex = 6;
            this.IP_label.Text = "New IP:";
            // 
            // Port_in
            // 
            this.Port_in.Location = new System.Drawing.Point(129, 100);
            this.Port_in.Name = "Port_in";
            this.Port_in.Size = new System.Drawing.Size(100, 21);
            this.Port_in.TabIndex = 5;
            this.Port_in.Text = "8000";
            // 
            // Ip_in
            // 
            this.Ip_in.Location = new System.Drawing.Point(129, 51);
            this.Ip_in.Name = "Ip_in";
            this.Ip_in.Size = new System.Drawing.Size(100, 21);
            this.Ip_in.TabIndex = 4;
            this.Ip_in.Text = "166.111.140.14";
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(103, 162);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(75, 23);
            this.Confirm.TabIndex = 8;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // Change_IP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 215);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.Port_label);
            this.Controls.Add(this.IP_label);
            this.Controls.Add(this.Port_in);
            this.Controls.Add(this.Ip_in);
            this.Name = "Change_IP";
            this.Text = "Change_IP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Port_label;
        private System.Windows.Forms.Label IP_label;
        private System.Windows.Forms.TextBox Port_in;
        private System.Windows.Forms.TextBox Ip_in;
        private System.Windows.Forms.Button Confirm;
    }
}