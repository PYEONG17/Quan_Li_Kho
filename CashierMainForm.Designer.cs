namespace Manage_POS
{
    partial class CashierMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashierMainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.uiButton_log_out = new Sunny.UI.UIButton();
            this.uiButton_customer = new Sunny.UI.UIButton();
            this.uiButton_add_product = new Sunny.UI.UIButton();
            this.uiButton_dashboard = new Sunny.UI.UIButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new CSharp.Winform.UI.Panel();
            this.cashierOrder1 = new Manage_POS.CashierOrder();
            this.addminProduct1 = new Manage_POS.AddminProduct();
            this.admin_Dashboard1 = new Manage_POS.Admin_Dashboard();
            this.cashierCustomerForm1 = new Manage_POS.CashierCustomerForm();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1206, 51);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(437, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hệ thống quản lý xe hơi";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.Controls.Add(this.uiButton1);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.uiButton_log_out);
            this.panel2.Controls.Add(this.uiButton_customer);
            this.panel2.Controls.Add(this.uiButton_add_product);
            this.panel2.Controls.Add(this.uiButton_dashboard);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(203, 634);
            this.panel2.TabIndex = 2;
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiButton1.Location = new System.Drawing.Point(6, 281);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Radius = 8;
            this.uiButton1.RectHoverColor = System.Drawing.Color.DodgerBlue;
            this.uiButton1.Size = new System.Drawing.Size(194, 38);
            this.uiButton1.TabIndex = 9;
            this.uiButton1.Text = "Đặt hàng";
            this.uiButton1.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(62, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(75, 75);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // uiButton_log_out
            // 
            this.uiButton_log_out.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_log_out.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiButton_log_out.Location = new System.Drawing.Point(6, 455);
            this.uiButton_log_out.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_log_out.Name = "uiButton_log_out";
            this.uiButton_log_out.Radius = 8;
            this.uiButton_log_out.RectHoverColor = System.Drawing.Color.DodgerBlue;
            this.uiButton_log_out.Size = new System.Drawing.Size(194, 38);
            this.uiButton_log_out.TabIndex = 7;
            this.uiButton_log_out.Text = "Đăng xuất";
            this.uiButton_log_out.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiButton_log_out.Click += new System.EventHandler(this.uiButton_log_out_Click);
            // 
            // uiButton_customer
            // 
            this.uiButton_customer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiButton_customer.Location = new System.Drawing.Point(6, 237);
            this.uiButton_customer.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_customer.Name = "uiButton_customer";
            this.uiButton_customer.Radius = 8;
            this.uiButton_customer.RectHoverColor = System.Drawing.Color.DodgerBlue;
            this.uiButton_customer.Size = new System.Drawing.Size(194, 38);
            this.uiButton_customer.TabIndex = 6;
            this.uiButton_customer.Text = "Khách hàng";
            this.uiButton_customer.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // uiButton_add_product
            // 
            this.uiButton_add_product.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_add_product.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiButton_add_product.Location = new System.Drawing.Point(6, 193);
            this.uiButton_add_product.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_add_product.Name = "uiButton_add_product";
            this.uiButton_add_product.Radius = 8;
            this.uiButton_add_product.RectHoverColor = System.Drawing.Color.DodgerBlue;
            this.uiButton_add_product.Size = new System.Drawing.Size(194, 38);
            this.uiButton_add_product.TabIndex = 5;
            this.uiButton_add_product.Text = "Sản phẩm";
            this.uiButton_add_product.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // uiButton_dashboard
            // 
            this.uiButton_dashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_dashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiButton_dashboard.Location = new System.Drawing.Point(9, 149);
            this.uiButton_dashboard.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_dashboard.Name = "uiButton_dashboard";
            this.uiButton_dashboard.Radius = 8;
            this.uiButton_dashboard.RectHoverColor = System.Drawing.Color.DodgerBlue;
            this.uiButton_dashboard.Size = new System.Drawing.Size(191, 38);
            this.uiButton_dashboard.TabIndex = 2;
            this.uiButton_dashboard.Text = "Dashboard";
            this.uiButton_dashboard.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Welcome !";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cashierCustomerForm1);
            this.panel3.Controls.Add(this.cashierOrder1);
            this.panel3.Controls.Add(this.addminProduct1);
            this.panel3.Controls.Add(this.admin_Dashboard1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel3.Location = new System.Drawing.Point(203, 51);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1003, 634);
            this.panel3.TabIndex = 3;
            // 
            // cashierOrder1
            // 
            this.cashierOrder1.Location = new System.Drawing.Point(7, 7);
            this.cashierOrder1.Name = "cashierOrder1";
            this.cashierOrder1.Size = new System.Drawing.Size(1009, 648);
            this.cashierOrder1.TabIndex = 2;
            this.cashierOrder1.Load += new System.EventHandler(this.cashierOrder1_Load_1);
            // 
            // addminProduct1
            // 
            this.addminProduct1.Location = new System.Drawing.Point(3, 0);
            this.addminProduct1.Name = "addminProduct1";
            this.addminProduct1.Size = new System.Drawing.Size(1009, 688);
            this.addminProduct1.TabIndex = 1;
            // 
            // admin_Dashboard1
            // 
            this.admin_Dashboard1.Location = new System.Drawing.Point(3, 0);
            this.admin_Dashboard1.Name = "admin_Dashboard1";
            this.admin_Dashboard1.Size = new System.Drawing.Size(993, 625);
            this.admin_Dashboard1.TabIndex = 0;
            // 
            // cashierCustomerForm1
            // 
            this.cashierCustomerForm1.Location = new System.Drawing.Point(6, 3);
            this.cashierCustomerForm1.Name = "cashierCustomerForm1";
            this.cashierCustomerForm1.Size = new System.Drawing.Size(993, 622);
            this.cashierCustomerForm1.TabIndex = 3;
            // 
            // CashierMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 685);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CashierMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CashierMainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Sunny.UI.UIButton uiButton_log_out;
        private Sunny.UI.UIButton uiButton_customer;
        private Sunny.UI.UIButton uiButton_add_product;
        private Sunny.UI.UIButton uiButton_dashboard;
        private System.Windows.Forms.Label label2;
        private Sunny.UI.UIButton uiButton1;
        private CSharp.Winform.UI.Panel panel3;
        private Admin_Dashboard admin_Dashboard1;
        private AddminProduct addminProduct1;
        private CashierOrder cashierOrder1;
        private CashierCustomerForm cashierCustomerForm1;
    }
}