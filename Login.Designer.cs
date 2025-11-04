namespace Manage_POS
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
            this.panel1 = new CSharp.Winform.UI.Panel();
            this.login_username_textbox = new CSharp.Winform.UI.TextBox();
            this.login_password_textbox = new CSharp.Winform.UI.TextBox();
            this.login_show_password = new CSharp.Winform.UI.CheckBox();
            this.label2 = new CSharp.Winform.UI.Label();
            this.label1 = new CSharp.Winform.UI.Label();
            this.Login_button = new MaterialSkin.Controls.MaterialButton();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Cornsilk;
            this.panel1.Controls.Add(this.login_username_textbox);
            this.panel1.Controls.Add(this.login_password_textbox);
            this.panel1.Controls.Add(this.login_show_password);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Login_button);
            this.panel1.Controls.Add(this.uiLabel3);
            this.panel1.Controls.Add(this.uiLabel2);
            this.panel1.Controls.Add(this.uiLabel1);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel1.Location = new System.Drawing.Point(79, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 448);
            this.panel1.TabIndex = 0;
            // 
            // login_username_textbox
            // 
            this.login_username_textbox.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_username_textbox.Location = new System.Drawing.Point(175, 110);
            this.login_username_textbox.Name = "login_username_textbox";
            this.login_username_textbox.Size = new System.Drawing.Size(333, 40);
            this.login_username_textbox.TabIndex = 7;
            // 
            // login_password_textbox
            // 
            this.login_password_textbox.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_password_textbox.Location = new System.Drawing.Point(175, 179);
            this.login_password_textbox.Name = "login_password_textbox";
            this.login_password_textbox.Size = new System.Drawing.Size(333, 40);
            this.login_password_textbox.TabIndex = 7;
            this.login_password_textbox.UseSystemPasswordChar = true;
            // 
            // login_show_password
            // 
            this.login_show_password.AutoSize = true;
            this.login_show_password.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.login_show_password.Location = new System.Drawing.Point(384, 241);
            this.login_show_password.Name = "login_show_password";
            this.login_show_password.Size = new System.Drawing.Size(124, 21);
            this.login_show_password.TabIndex = 5;
            this.login_show_password.Text = "show password";
            this.login_show_password.UseVisualStyleBackColor = true;
            this.login_show_password.CheckedChanged += new System.EventHandler(this.login_show_password_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(379, 396);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Register here";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(214, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Have no account yet ?";
            // 
            // Login_button
            // 
            this.Login_button.AutoSize = false;
            this.Login_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Login_button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.Login_button.Depth = 0;
            this.Login_button.HighEmphasis = true;
            this.Login_button.Icon = null;
            this.Login_button.Location = new System.Drawing.Point(277, 291);
            this.Login_button.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Login_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.Login_button.Name = "Login_button";
            this.Login_button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Login_button.Size = new System.Drawing.Size(126, 45);
            this.Login_button.TabIndex = 3;
            this.Login_button.Text = "Login";
            this.Login_button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Login_button.UseAccentColor = false;
            this.Login_button.UseVisualStyleBackColor = true;
            this.Login_button.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Location = new System.Drawing.Point(41, 186);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(141, 36);
            this.uiLabel3.TabIndex = 0;
            this.uiLabel3.Text = "Password";
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(65, 117);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 36);
            this.uiLabel2.TabIndex = 0;
            this.uiLabel2.Text = "User";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(291, 10);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(126, 39);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "Login";
            this.uiLabel1.Click += new System.EventHandler(this.uiLabel1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(800, 524);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CSharp.Winform.UI.Panel panel1;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel1;
        private MaterialSkin.Controls.MaterialButton Login_button;
        private CSharp.Winform.UI.Label label2;
        private CSharp.Winform.UI.Label label1;
        private CSharp.Winform.UI.CheckBox login_show_password;
        private CSharp.Winform.UI.TextBox login_username_textbox;
        private CSharp.Winform.UI.TextBox login_password_textbox;
    }
}

