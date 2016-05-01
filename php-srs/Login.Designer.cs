namespace php_srs
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.user_login_l = new System.Windows.Forms.Label();
            this.pass_login_l = new System.Windows.Forms.Label();
            this.heading_img = new System.Windows.Forms.Panel();
            this.login_p = new System.Windows.Forms.Panel();
            this.quit_b = new System.Windows.Forms.Button();
            this.passlog_t = new System.Windows.Forms.TextBox();
            this.enter_b = new System.Windows.Forms.Button();
            this.userlog_t = new System.Windows.Forms.TextBox();
            this.error_l = new System.Windows.Forms.Label();
            this.login_p.SuspendLayout();
            this.SuspendLayout();
            // 
            // user_login_l
            // 
            this.user_login_l.BackColor = System.Drawing.Color.LightBlue;
            this.user_login_l.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.user_login_l.Location = new System.Drawing.Point(103, 27);
            this.user_login_l.Name = "user_login_l";
            this.user_login_l.Size = new System.Drawing.Size(125, 20);
            this.user_login_l.TabIndex = 0;
            this.user_login_l.Text = "Username: ";
            this.user_login_l.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pass_login_l
            // 
            this.pass_login_l.BackColor = System.Drawing.Color.LightBlue;
            this.pass_login_l.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pass_login_l.Location = new System.Drawing.Point(103, 55);
            this.pass_login_l.Name = "pass_login_l";
            this.pass_login_l.Size = new System.Drawing.Size(125, 20);
            this.pass_login_l.TabIndex = 1;
            this.pass_login_l.Text = "Password: ";
            this.pass_login_l.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // heading_img
            // 
            this.heading_img.BackColor = System.Drawing.Color.Transparent;
            this.heading_img.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("heading_img.BackgroundImage")));
            this.heading_img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.heading_img.Location = new System.Drawing.Point(64, -50);
            this.heading_img.Name = "heading_img";
            this.heading_img.Size = new System.Drawing.Size(346, 212);
            this.heading_img.TabIndex = 2;
            // 
            // login_p
            // 
            this.login_p.BackColor = System.Drawing.Color.Transparent;
            this.login_p.Controls.Add(this.error_l);
            this.login_p.Controls.Add(this.quit_b);
            this.login_p.Controls.Add(this.passlog_t);
            this.login_p.Controls.Add(this.enter_b);
            this.login_p.Controls.Add(this.pass_login_l);
            this.login_p.Controls.Add(this.userlog_t);
            this.login_p.Controls.Add(this.user_login_l);
            this.login_p.Location = new System.Drawing.Point(0, 100);
            this.login_p.Name = "login_p";
            this.login_p.Size = new System.Drawing.Size(500, 200);
            this.login_p.TabIndex = 3;
            // 
            // quit_b
            // 
            this.quit_b.Location = new System.Drawing.Point(175, 124);
            this.quit_b.Name = "quit_b";
            this.quit_b.Size = new System.Drawing.Size(125, 25);
            this.quit_b.TabIndex = 4;
            this.quit_b.Text = "Quit";
            this.quit_b.UseVisualStyleBackColor = true;
            this.quit_b.Click += new System.EventHandler(this.quit_b_Click);
            // 
            // passlog_t
            // 
            this.passlog_t.Location = new System.Drawing.Point(248, 55);
            this.passlog_t.Name = "passlog_t";
            this.passlog_t.PasswordChar = '*';
            this.passlog_t.Size = new System.Drawing.Size(125, 20);
            this.passlog_t.TabIndex = 3;
            // 
            // enter_b
            // 
            this.enter_b.Location = new System.Drawing.Point(175, 93);
            this.enter_b.Name = "enter_b";
            this.enter_b.Size = new System.Drawing.Size(125, 25);
            this.enter_b.TabIndex = 3;
            this.enter_b.Text = "Login";
            this.enter_b.UseVisualStyleBackColor = true;
            this.enter_b.Click += new System.EventHandler(this.enter_b_Click);
            // 
            // userlog_t
            // 
            this.userlog_t.Location = new System.Drawing.Point(248, 27);
            this.userlog_t.Name = "userlog_t";
            this.userlog_t.Size = new System.Drawing.Size(125, 20);
            this.userlog_t.TabIndex = 2;
            // 
            // error_l
            // 
            this.error_l.AutoSize = true;
            this.error_l.Location = new System.Drawing.Point(248, 78);
            this.error_l.Name = "error_l";
            this.error_l.Size = new System.Drawing.Size(0, 13);
            this.error_l.TabIndex = 5;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.login_p);
            this.Controls.Add(this.heading_img);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(500, 300);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "People Health Pharmacy Login";
            this.login_p.ResumeLayout(false);
            this.login_p.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label user_login_l;
        private System.Windows.Forms.Label pass_login_l;
        private System.Windows.Forms.Panel heading_img;
        private System.Windows.Forms.Panel login_p;
        private System.Windows.Forms.TextBox passlog_t;
        private System.Windows.Forms.TextBox userlog_t;
        private System.Windows.Forms.Button enter_b;
        private System.Windows.Forms.Button quit_b;
        private System.Windows.Forms.Label error_l;
    }
}