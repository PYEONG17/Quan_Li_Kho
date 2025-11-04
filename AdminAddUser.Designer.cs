namespace Manage_POS
{
    partial class AdminAddUser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_username = new CSharp.Winform.UI.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_password = new CSharp.Winform.UI.TextBox();
            this.comboBox_role = new System.Windows.Forms.ComboBox();
            this.comboBox_status = new System.Windows.Forms.ComboBox();
            this.button_adduser = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.button_remove = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_clear);
            this.panel1.Controls.Add(this.button_remove);
            this.panel1.Controls.Add(this.button_update);
            this.panel1.Controls.Add(this.button_adduser);
            this.panel1.Controls.Add(this.comboBox_status);
            this.panel1.Controls.Add(this.comboBox_role);
            this.panel1.Controls.Add(this.textBox_password);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_username);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 593);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(368, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(622, 593);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // textBox_username
            // 
            this.textBox_username.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_username.Location = new System.Drawing.Point(27, 64);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(307, 40);
            this.textBox_username.TabIndex = 1;
            this.textBox_username.TextChanged += new System.EventHandler(this.textBox_username_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "Vai trò";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 32);
            this.label4.TabIndex = 4;
            this.label4.Text = "Trạng thái";
            // 
            // textBox_password
            // 
            this.textBox_password.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_password.Location = new System.Drawing.Point(27, 158);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(307, 40);
            this.textBox_password.TabIndex = 5;
            this.textBox_password.TextChanged += new System.EventHandler(this.textBox_password_TextChanged);
            // 
            // comboBox_role
            // 
            this.comboBox_role.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_role.FormattingEnabled = true;
            this.comboBox_role.Items.AddRange(new object[] {
            "Admin",
            "Nhân viên"});
            this.comboBox_role.Location = new System.Drawing.Point(27, 249);
            this.comboBox_role.Name = "comboBox_role";
            this.comboBox_role.Size = new System.Drawing.Size(307, 37);
            this.comboBox_role.TabIndex = 6;
            this.comboBox_role.SelectedIndexChanged += new System.EventHandler(this.comboBox_role_SelectedIndexChanged);
            // 
            // comboBox_status
            // 
            this.comboBox_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_status.FormattingEnabled = true;
            this.comboBox_status.Items.AddRange(new object[] {
            "Active",
            "Inactive",
            "Approval"});
            this.comboBox_status.Location = new System.Drawing.Point(27, 343);
            this.comboBox_status.Name = "comboBox_status";
            this.comboBox_status.Size = new System.Drawing.Size(307, 37);
            this.comboBox_status.TabIndex = 7;
            this.comboBox_status.SelectedIndexChanged += new System.EventHandler(this.comboBox_status_SelectedIndexChanged);
            // 
            // button_adduser
            // 
            this.button_adduser.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_adduser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_adduser.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_adduser.Location = new System.Drawing.Point(27, 400);
            this.button_adduser.Name = "button_adduser";
            this.button_adduser.Size = new System.Drawing.Size(146, 57);
            this.button_adduser.TabIndex = 8;
            this.button_adduser.Text = "Add";
            this.button_adduser.UseVisualStyleBackColor = false;
            this.button_adduser.Click += new System.EventHandler(this.button_adduser_Click);
            // 
            // button_update
            // 
            this.button_update.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_update.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_update.Location = new System.Drawing.Point(188, 400);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(146, 57);
            this.button_update.TabIndex = 9;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = false;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // button_remove
            // 
            this.button_remove.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_remove.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_remove.Location = new System.Drawing.Point(27, 490);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(146, 57);
            this.button_remove.TabIndex = 10;
            this.button_remove.Text = "Remove";
            this.button_remove.UseVisualStyleBackColor = false;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // button_clear
            // 
            this.button_clear.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_clear.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_clear.Location = new System.Drawing.Point(188, 490);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(146, 57);
            this.button_clear.TabIndex = 11;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = false;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Dữ liệu người dùng";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(611, 526);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // AdminAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AdminAddUser";
            this.Size = new System.Drawing.Size(993, 625);
            this.Load += new System.EventHandler(this.AdminAddUser_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CSharp.Winform.UI.TextBox textBox_password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private CSharp.Winform.UI.TextBox textBox_username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_adduser;
        private System.Windows.Forms.ComboBox comboBox_status;
        private System.Windows.Forms.ComboBox comboBox_role;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
