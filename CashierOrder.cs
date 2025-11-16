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
using System.Runtime.Serialization;

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
        // thay thế displayCategories()
        public void displayCategories()
        {
            if (CheckConnection())
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
                    using (SqlCommand cmd = new SqlCommand("SELECT category FROM categories", conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            CashierOrder_category.Items.Clear();
                            while (reader.Read())
                            {
                                CashierOrder_category.Items.Add(reader["category"].ToString());
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi load categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }


        // thay thế CashierOrder_productID_SelectedIndexChanged
        private void CashierOrder_productID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProductId = CashierOrder_productID.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedProductId)) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT product_name, price FROM products WHERE product_id = @pid AND status = @status", conn))
                {
                    cmd.Parameters.AddWithValue("@pid", selectedProductId);
                    cmd.Parameters.AddWithValue("@status", "Còn hàng");

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CashierOrder_productName.Text = reader["product_name"].ToString();

                            // xử lý giá an toàn
                            object rawPrice = reader["price"];
                            decimal priceDecimal = 0m;
                            if (rawPrice != DBNull.Value && decimal.TryParse(rawPrice.ToString(), out priceDecimal))
                            {
                                CashierOrder_price.Text = priceDecimal.ToString("0.00");
                            }
                            else
                            {
                                CashierOrder_price.Text = "0.00";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load product detail: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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


        // thay thế CashierOrder_category_SelectedIndexChanged
        private void CashierOrder_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            CashierOrder_productID.SelectedIndex = -1;
            CashierOrder_productID.Items.Clear();
            CashierOrder_productName.Text = "";
            CashierOrder_price.Text = "";

            string selectedCategory = CashierOrder_category.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedCategory)) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT product_id FROM products WHERE category = @category AND status = @status", conn))
                {
                    cmd.Parameters.AddWithValue("@category", selectedCategory);
                    cmd.Parameters.AddWithValue("@status", "Còn hàng");

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CashierOrder_productID.Items.Add(reader["product_id"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load products theo category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void uiButton_addCashierOrder_Click(object sender, EventArgs e)
        {
            // Sinh customer_id mới dựa trên orders
            IDGenarator();

            // Kiểm tra dữ liệu nhập
            if (CashierOrder_category.SelectedIndex == -1 ||
                CashierOrder_productID.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(CashierOrder_productName.Text) ||
                string.IsNullOrWhiteSpace(CashierOrder_price.Text) ||
                CashierOrder_quality.Value == 0)
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string productId = CashierOrder_productID.SelectedItem.ToString();
            int quantity = Convert.ToInt32(CashierOrder_quality.Value);
            decimal price = Convert.ToDecimal(CashierOrder_price.Text);
            decimal totalPrice = price * quantity;

            try
            {
                using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
                {
                    conn.Open();

                    string insertQuery = @"
                INSERT INTO orders 
                (customer_id, product_id, product_name, category, quality, origin_price, total_price, order_date)
                VALUES (@customer_id, @product_id, @product_name, @category, @quality, @origin_price, @total_price, @order_date)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@customer_id", idGen);
                        cmd.Parameters.AddWithValue("@product_id", productId);
                        cmd.Parameters.AddWithValue("@product_name", CashierOrder_productName.Text.Trim());
                        cmd.Parameters.AddWithValue("@category", CashierOrder_category.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@quality", quantity);
                        cmd.Parameters.AddWithValue("@origin_price", price);
                        cmd.Parameters.AddWithValue("@total_price", totalPrice);
                        cmd.Parameters.AddWithValue("@order_date", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thêm sản phẩm thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear form
                    CashierOrder_productID.SelectedIndex = -1;
                    CashierOrder_category.SelectedIndex = -1;
                    CashierOrder_productName.Text = "";
                    CashierOrder_price.Text = "";
                    CashierOrder_quality.Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int idGen;
        public void IDGenarator()
        {
            using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
            {
                conn.Open();
                string selectData = "SELECT ISNULL(MAX(customer_id),0) FROM orders";
                using (SqlCommand cmd = new SqlCommand(selectData, conn))
                {
                    object result = cmd.ExecuteScalar();
                    idGen = Convert.ToInt32(result) + 1; // id mới
                }
            }
        }


        private void uiButton_RemoveCashierOrder_Click(object sender, EventArgs e)
        {

        }
    }
}
