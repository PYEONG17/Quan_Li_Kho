namespace Manage_POS
{
    partial class AddminProduct
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
            this.panel1 = new CSharp.Winform.UI.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_Product = new System.Windows.Forms.DataGridView();
            this.panel2 = new CSharp.Winform.UI.Panel();
            this.comboBox_category = new CSharp.Winform.UI.ComboBox();
            this.uiButton_ClearProduct = new Sunny.UI.UIButton();
            this.uiButton_RemoveProduct = new Sunny.UI.UIButton();
            this.uiButton_updateProduct = new Sunny.UI.UIButton();
            this.uiButton_addProduct = new Sunny.UI.UIButton();
            this.uiButton_nhap = new Sunny.UI.UIButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.comboBox_Status = new CSharp.Winform.UI.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Stock = new CSharp.Winform.UI.TextBox();
            this.textBox_Price = new CSharp.Winform.UI.TextBox();
            this.textBox_Productname = new CSharp.Winform.UI.TextBox();
            this.textBox_id = new CSharp.Winform.UI.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Product)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridView_Product);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel1.Location = new System.Drawing.Point(17, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 348);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tất cả sản phẩm ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridView_Product
            // 
            this.dataGridView_Product.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Product.Location = new System.Drawing.Point(6, 45);
            this.dataGridView_Product.Name = "dataGridView_Product";
            this.dataGridView_Product.RowHeadersWidth = 51;
            this.dataGridView_Product.RowTemplate.Height = 24;
            this.dataGridView_Product.Size = new System.Drawing.Size(970, 300);
            this.dataGridView_Product.TabIndex = 0;
            this.dataGridView_Product.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Product_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox_category);
            this.panel2.Controls.Add(this.uiButton_ClearProduct);
            this.panel2.Controls.Add(this.uiButton_RemoveProduct);
            this.panel2.Controls.Add(this.uiButton_updateProduct);
            this.panel2.Controls.Add(this.uiButton_addProduct);
            this.panel2.Controls.Add(this.uiButton_nhap);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.comboBox_Status);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBox_Stock);
            this.panel2.Controls.Add(this.textBox_Price);
            this.panel2.Controls.Add(this.textBox_Productname);
            this.panel2.Controls.Add(this.textBox_id);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel2.Location = new System.Drawing.Point(17, 384);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(976, 254);
            this.panel2.TabIndex = 1;
            // 
            // comboBox_category
            // 
            this.comboBox_category.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_category.FormattingEnabled = true;
            this.comboBox_category.Location = new System.Drawing.Point(159, 102);
            this.comboBox_category.Name = "comboBox_category";
            this.comboBox_category.Size = new System.Drawing.Size(184, 29);
            this.comboBox_category.TabIndex = 12;
            this.comboBox_category.SelectedIndexChanged += new System.EventHandler(this.comboBox_category_SelectedIndexChanged);
            // 
            // uiButton_ClearProduct
            // 
            this.uiButton_ClearProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_ClearProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiButton_ClearProduct.Location = new System.Drawing.Point(625, 183);
            this.uiButton_ClearProduct.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_ClearProduct.Name = "uiButton_ClearProduct";
            this.uiButton_ClearProduct.Size = new System.Drawing.Size(89, 38);
            this.uiButton_ClearProduct.TabIndex = 11;
            this.uiButton_ClearProduct.Text = "Clear";
            this.uiButton_ClearProduct.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiButton_ClearProduct.Click += new System.EventHandler(this.uiButton_ClearProduct_Click);
            // 
            // uiButton_RemoveProduct
            // 
            this.uiButton_RemoveProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_RemoveProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiButton_RemoveProduct.Location = new System.Drawing.Point(468, 183);
            this.uiButton_RemoveProduct.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_RemoveProduct.Name = "uiButton_RemoveProduct";
            this.uiButton_RemoveProduct.Size = new System.Drawing.Size(89, 38);
            this.uiButton_RemoveProduct.TabIndex = 10;
            this.uiButton_RemoveProduct.Text = "Xóa";
            this.uiButton_RemoveProduct.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiButton_RemoveProduct.Click += new System.EventHandler(this.uiButton_RemoveProduct_Click);
            // 
            // uiButton_updateProduct
            // 
            this.uiButton_updateProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_updateProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiButton_updateProduct.Location = new System.Drawing.Point(309, 183);
            this.uiButton_updateProduct.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_updateProduct.Name = "uiButton_updateProduct";
            this.uiButton_updateProduct.Size = new System.Drawing.Size(89, 38);
            this.uiButton_updateProduct.TabIndex = 9;
            this.uiButton_updateProduct.Text = "Sửa";
            this.uiButton_updateProduct.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiButton_updateProduct.Click += new System.EventHandler(this.uiButton_updateProduct_Click);
            // 
            // uiButton_addProduct
            // 
            this.uiButton_addProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_addProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiButton_addProduct.Location = new System.Drawing.Point(159, 183);
            this.uiButton_addProduct.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_addProduct.Name = "uiButton_addProduct";
            this.uiButton_addProduct.Size = new System.Drawing.Size(85, 38);
            this.uiButton_addProduct.TabIndex = 8;
            this.uiButton_addProduct.Text = "Thêm";
            this.uiButton_addProduct.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiButton_addProduct.Click += new System.EventHandler(this.uiButton_addProduct_Click);
            // 
            // uiButton_nhap
            // 
            this.uiButton_nhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_nhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiButton_nhap.Location = new System.Drawing.Point(845, 113);
            this.uiButton_nhap.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_nhap.Name = "uiButton_nhap";
            this.uiButton_nhap.Size = new System.Drawing.Size(89, 31);
            this.uiButton_nhap.TabIndex = 7;
            this.uiButton_nhap.Text = "Nhập";
            this.uiButton_nhap.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiButton_nhap.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel3.Controls.Add(this.pictureBox);
            this.panel3.Location = new System.Drawing.Point(845, 11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(89, 96);
            this.panel3.TabIndex = 6;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(89, 96);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // comboBox_Status
            // 
            this.comboBox_Status.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Status.FormattingEnabled = true;
            this.comboBox_Status.Items.AddRange(new object[] {
            "Còn hàng",
            "Hết hàng"});
            this.comboBox_Status.Location = new System.Drawing.Point(508, 102);
            this.comboBox_Status.Name = "comboBox_Status";
            this.comboBox_Status.Size = new System.Drawing.Size(184, 29);
            this.comboBox_Status.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Danh mục";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(400, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 21);
            this.label7.TabIndex = 3;
            this.label7.Text = "Trạng thái";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(400, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 21);
            this.label6.TabIndex = 3;
            this.label6.Text = "Kho hàng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(401, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Giá ($)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên sản phẩm ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBox_Stock
            // 
            this.textBox_Stock.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Stock.Location = new System.Drawing.Point(508, 58);
            this.textBox_Stock.Name = "textBox_Stock";
            this.textBox_Stock.Size = new System.Drawing.Size(184, 28);
            this.textBox_Stock.TabIndex = 1;
            this.textBox_Stock.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBox_Price
            // 
            this.textBox_Price.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Price.Location = new System.Drawing.Point(508, 14);
            this.textBox_Price.Name = "textBox_Price";
            this.textBox_Price.Size = new System.Drawing.Size(184, 28);
            this.textBox_Price.TabIndex = 1;
            this.textBox_Price.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBox_Productname
            // 
            this.textBox_Productname.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Productname.Location = new System.Drawing.Point(159, 58);
            this.textBox_Productname.Name = "textBox_Productname";
            this.textBox_Productname.Size = new System.Drawing.Size(184, 28);
            this.textBox_Productname.TabIndex = 1;
            // 
            // textBox_id
            // 
            this.textBox_id.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_id.Location = new System.Drawing.Point(159, 11);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.Size = new System.Drawing.Size(184, 28);
            this.textBox_id.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = " ID ";
            // 
            // AddminProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AddminProduct";
            this.Size = new System.Drawing.Size(1009, 648);
            this.Load += new System.EventHandler(this.AddminProduct_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Product)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CSharp.Winform.UI.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView_Product;
        private CSharp.Winform.UI.Panel panel2;
        private System.Windows.Forms.Label label1;
        private CSharp.Winform.UI.TextBox textBox_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private CSharp.Winform.UI.TextBox textBox_Price;
        private CSharp.Winform.UI.TextBox textBox_Productname;
        private System.Windows.Forms.Label label6;
        private CSharp.Winform.UI.ComboBox comboBox_Status;
        private System.Windows.Forms.Label label7;
        private CSharp.Winform.UI.TextBox textBox_Stock;
        private System.Windows.Forms.Panel panel3;
        private Sunny.UI.UIButton uiButton_nhap;
        private System.Windows.Forms.PictureBox pictureBox;
        private Sunny.UI.UIButton uiButton_ClearProduct;
        private Sunny.UI.UIButton uiButton_RemoveProduct;
        private Sunny.UI.UIButton uiButton_updateProduct;
        private Sunny.UI.UIButton uiButton_addProduct;
        private CSharp.Winform.UI.ComboBox comboBox_category;
    }
}
