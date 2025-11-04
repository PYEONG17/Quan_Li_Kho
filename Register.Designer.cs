namespace Manage_POS
{
    partial class Register
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
            this.register_confirm_password = new CSharp.Winform.UI.TextBox();
            this.register_username_textbox = new CSharp.Winform.UI.TextBox();
            this.register_password_textbox = new CSharp.Winform.UI.TextBox();
            this.register_show_password = new CSharp.Winform.UI.CheckBox();
            this.label_login_here = new CSharp.Winform.UI.Label();
            this.close_click = new Sunny.UI.UIButton();
            this.SignUp_button = new MaterialSkin.Controls.MaterialButton();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Cornsilk;
            this.panel1.Controls.Add(this.register_confirm_password);
            this.panel1.Controls.Add(this.register_username_textbox);
            this.panel1.Controls.Add(this.register_password_textbox);
            this.panel1.Controls.Add(this.register_show_password);
            this.panel1.Controls.Add(this.label_login_here);
            this.panel1.Controls.Add(this.close_click);
            this.panel1.Controls.Add(this.SignUp_button);
            this.panel1.Controls.Add(this.uiLabel4);
            this.panel1.Controls.Add(this.uiLabel3);
            this.panel1.Controls.Add(this.uiLabel2);
            this.panel1.Controls.Add(this.uiLabel1);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel1.Location = new System.Drawing.Point(81, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 448);
            this.panel1.TabIndex = 1;
            // 
            // register_confirm_password
            // 
            this.register_confirm_password.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register_confirm_password.Location = new System.Drawing.Point(171, 255);
            this.register_confirm_password.Name = "register_confirm_password";
            this.register_confirm_password.Size = new System.Drawing.Size(333, 40);
            this.register_confirm_password.TabIndex = 9;
            this.register_confirm_password.UseSystemPasswordChar = true;
            // 
            // register_username_textbox
            // 
            this.register_username_textbox.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register_username_textbox.Location = new System.Drawing.Point(171, 117);
            this.register_username_textbox.Name = "register_username_textbox";
            this.register_username_textbox.Size = new System.Drawing.Size(333, 40);
            this.register_username_textbox.TabIndex = 8;
            // 
            // register_password_textbox
            // 
            this.register_password_textbox.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register_password_textbox.Location = new System.Drawing.Point(171, 186);
            this.register_password_textbox.Name = "register_password_textbox";
            this.register_password_textbox.Size = new System.Drawing.Size(333, 40);
            this.register_password_textbox.TabIndex = 8;
            this.register_password_textbox.UseSystemPasswordChar = true;
            // 
            // register_show_password
            // 
            this.register_show_password.AutoSize = true;
            this.register_show_password.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.register_show_password.Location = new System.Drawing.Point(384, 311);
            this.register_show_password.Name = "register_show_password";
            this.register_show_password.Size = new System.Drawing.Size(124, 21);
            this.register_show_password.TabIndex = 6;
            this.register_show_password.Text = "show password";
            this.register_show_password.UseVisualStyleBackColor = true;
            this.register_show_password.CheckedChanged += new System.EventHandler(this.register_show_password_CheckedChanged);
            // 
            // label_login_here
            // 
            this.label_login_here.AutoSize = true;
            this.label_login_here.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_login_here.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label_login_here.Location = new System.Drawing.Point(297, 410);
            this.label_login_here.Name = "label_login_here";
            this.label_login_here.Size = new System.Drawing.Size(83, 18);
            this.label_login_here.TabIndex = 5;
            this.label_login_here.Text = "Sign in here";
            this.label_login_here.Click += new System.EventHandler(this.label_login_here_Click);
            // 
            // close_click
            // 
            this.close_click.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close_click.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.close_click.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.close_click.Location = new System.Drawing.Point(567, 410);
            this.close_click.MinimumSize = new System.Drawing.Size(1, 1);
            this.close_click.Name = "close_click";
            this.close_click.Size = new System.Drawing.Size(62, 25);
            this.close_click.TabIndex = 4;
            this.close_click.Text = "Exit";
            this.close_click.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.close_click.Click += new System.EventHandler(this.close_click_Click);
            // 
            // SignUp_button
            // 
            this.SignUp_button.AutoSize = false;
            this.SignUp_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SignUp_button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.SignUp_button.Depth = 0;
            this.SignUp_button.HighEmphasis = true;
            this.SignUp_button.Icon = null;
            this.SignUp_button.Location = new System.Drawing.Point(278, 341);
            this.SignUp_button.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.SignUp_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.SignUp_button.Name = "SignUp_button";
            this.SignUp_button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.SignUp_button.Size = new System.Drawing.Size(131, 45);
            this.SignUp_button.TabIndex = 3;
            this.SignUp_button.Text = "Sign Up";
            this.SignUp_button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.SignUp_button.UseAccentColor = false;
            this.SignUp_button.UseVisualStyleBackColor = true;
            this.SignUp_button.Click += new System.EventHandler(this.SignUp_button_Click);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel4.Location = new System.Drawing.Point(50, 259);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(106, 36);
            this.uiLabel4.TabIndex = 0;
            this.uiLabel4.Text = "Confirm";
            this.uiLabel4.Click += new System.EventHandler(this.uiLabel4_Click);
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
            this.uiLabel2.Size = new System.Drawing.Size(91, 36);
            this.uiLabel2.TabIndex = 0;
            this.uiLabel2.Text = "User";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(271, 25);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(165, 39);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "Register";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.panel1);
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CSharp.Winform.UI.Panel panel1;
        private MaterialSkin.Controls.MaterialButton SignUp_button;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIButton close_click;
        private CSharp.Winform.UI.Label label_login_here;
        private Sunny.UI.UILabel uiLabel4;
        private CSharp.Winform.UI.CheckBox register_show_password;
        private CSharp.Winform.UI.TextBox register_password_textbox;
        private CSharp.Winform.UI.TextBox register_confirm_password;
        private CSharp.Winform.UI.TextBox register_username_textbox;
    }
}