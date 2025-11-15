using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Manage_POS
{
    public partial class CashierOrder : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\manage_POS.mdf;Integrated Security=True;Connect Timeout=30");

        public CashierOrder()
        {
            InitializeComponent();
           displayAllProducts();
            displayCategories();
        }
        public void displayAllProducts()
        {
            AddProductData apData = new AddProductData();
            List<AddProductData> listData = apData.AllProductData();
            dataGridView_Product.DataSource = listData;

        }
        public void displayCategories()
        {
            if (CheckConnection())
            {
                try
                {
                    connect.Open();
                    string selectData = "select * from categories ";
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                CashierOrder_category.Items.Add(reader["category"].ToString());
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void label10_Click(object sender, EventArgs e)
        {

        }
      

        private void CashierOrder_productID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public bool CheckConnection()
        {
            if (connect.State == ConnectionState.Closed)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        

        private void CashierOrder_category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_Product_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uiButton_ClearCashierOrder_Click(object sender, EventArgs e)
        {

        }
    }
}
