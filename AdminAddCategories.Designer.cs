namespace Manage_POS
{
    partial class AdminAddCategories
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
            this.textBox_Categoryname2 = new CSharp.Winform.UI.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_clearCatgory = new System.Windows.Forms.Button();
            this.button_removeCatgory = new System.Windows.Forms.Button();
            this.button_updateCatgory = new System.Windows.Forms.Button();
            this.button_addCategory = new System.Windows.Forms.Button();
            this.textBox_Categoryname = new CSharp.Winform.UI.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView_categories = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_categories)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_Categoryname2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button_clearCatgory);
            this.panel1.Controls.Add(this.button_removeCatgory);
            this.panel1.Controls.Add(this.button_updateCatgory);
            this.panel1.Controls.Add(this.button_addCategory);
            this.panel1.Controls.Add(this.textBox_Categoryname);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 593);
            this.panel1.TabIndex = 2;
            // 
            // textBox_Categoryname2
            // 
            this.textBox_Categoryname2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Categoryname2.Location = new System.Drawing.Point(27, 169);
            this.textBox_Categoryname2.Name = "textBox_Categoryname2";
            this.textBox_Categoryname2.Size = new System.Drawing.Size(307, 40);
            this.textBox_Categoryname2.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 32);
            this.label2.TabIndex = 12;
            this.label2.Text = "Danh mục";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button_clearCatgory
            // 
            this.button_clearCatgory.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_clearCatgory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_clearCatgory.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_clearCatgory.Location = new System.Drawing.Point(179, 307);
            this.button_clearCatgory.Name = "button_clearCatgory";
            this.button_clearCatgory.Size = new System.Drawing.Size(146, 57);
            this.button_clearCatgory.TabIndex = 11;
            this.button_clearCatgory.Text = "Clear";
            this.button_clearCatgory.UseVisualStyleBackColor = false;
            this.button_clearCatgory.Click += new System.EventHandler(this.button_clearCatgory_Click);
            // 
            // button_removeCatgory
            // 
            this.button_removeCatgory.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_removeCatgory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_removeCatgory.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_removeCatgory.Location = new System.Drawing.Point(13, 307);
            this.button_removeCatgory.Name = "button_removeCatgory";
            this.button_removeCatgory.Size = new System.Drawing.Size(146, 57);
            this.button_removeCatgory.TabIndex = 10;
            this.button_removeCatgory.Text = "Xóa";
            this.button_removeCatgory.UseVisualStyleBackColor = false;
            this.button_removeCatgory.Click += new System.EventHandler(this.button_removeCatgory_Click);
            // 
            // button_updateCatgory
            // 
            this.button_updateCatgory.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_updateCatgory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_updateCatgory.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_updateCatgory.Location = new System.Drawing.Point(179, 231);
            this.button_updateCatgory.Name = "button_updateCatgory";
            this.button_updateCatgory.Size = new System.Drawing.Size(146, 57);
            this.button_updateCatgory.TabIndex = 9;
            this.button_updateCatgory.Text = "Sửa";
            this.button_updateCatgory.UseVisualStyleBackColor = false;
            this.button_updateCatgory.Click += new System.EventHandler(this.button_updateCatgory_Click);
            // 
            // button_addCategory
            // 
            this.button_addCategory.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_addCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_addCategory.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_addCategory.Location = new System.Drawing.Point(13, 231);
            this.button_addCategory.Name = "button_addCategory";
            this.button_addCategory.Size = new System.Drawing.Size(146, 57);
            this.button_addCategory.TabIndex = 8;
            this.button_addCategory.Text = "Thêm";
            this.button_addCategory.UseVisualStyleBackColor = false;
            this.button_addCategory.Click += new System.EventHandler(this.button_addCategory_Click);
            // 
            // textBox_Categoryname
            // 
            this.textBox_Categoryname.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Categoryname.Location = new System.Drawing.Point(27, 64);
            this.textBox_Categoryname.Name = "textBox_Categoryname";
            this.textBox_Categoryname.Size = new System.Drawing.Size(307, 40);
            this.textBox_Categoryname.TabIndex = 1;
            this.textBox_Categoryname.TextChanged += new System.EventHandler(this.textBox_Categoryname_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView_categories);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(377, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(622, 593);
            this.panel2.TabIndex = 3;
            // 
            // dataGridView_categories
            // 
            this.dataGridView_categories.AllowUserToAddRows = false;
            this.dataGridView_categories.AllowUserToDeleteRows = false;
            this.dataGridView_categories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_categories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_categories.Location = new System.Drawing.Point(8, 67);
            this.dataGridView_categories.Name = "dataGridView_categories";
            this.dataGridView_categories.ReadOnly = true;
            this.dataGridView_categories.RowHeadersVisible = false;
            this.dataGridView_categories.RowHeadersWidth = 51;
            this.dataGridView_categories.RowTemplate.Height = 24;
            this.dataGridView_categories.Size = new System.Drawing.Size(611, 526);
            this.dataGridView_categories.TabIndex = 1;
            this.dataGridView_categories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_categories_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Danh mục";
            // 
            // AdminAddCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "AdminAddCategories";
            this.Size = new System.Drawing.Size(1009, 638);
            this.Load += new System.EventHandler(this.AdminAddCategories_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_categories)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_clearCatgory;
        private System.Windows.Forms.Button button_removeCatgory;
        private System.Windows.Forms.Button button_updateCatgory;
        private System.Windows.Forms.Button button_addCategory;
        private CSharp.Winform.UI.TextBox textBox_Categoryname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView_categories;
        private System.Windows.Forms.Label label5;
        private CSharp.Winform.UI.TextBox textBox_Categoryname2;
        private System.Windows.Forms.Label label2;
    }
}
