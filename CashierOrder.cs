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
            displayOrders();
            displayTotalPrice();
        }
        public void displayAllProducts()
        {
            AddProductData apData = new AddProductData();
            List<AddProductData> listData = apData.AllProductData();
            dataGridView_Product.DataSource = listData;

        }
        public void displayOrders()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM orders ORDER BY id DESC";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu orders: " + ex.Message);
            }
        }


        public void displayTotalPrice()
        {
            try
            {
                decimal sum = 0m;
                using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
                {
                    conn.Open();
                    string selectData = "SELECT ISNULL(SUM(total_price), 0) FROM orders";
                    using (SqlCommand cmd = new SqlCommand(selectData, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            sum = Convert.ToDecimal(result);
                    }
                }
                CashierOrder_total.Text = sum.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load total price: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        public void clearField()
        {
            CashierOrder_category.SelectedIndex = -1;
            CashierOrder_productID.SelectedIndex = -1;
            CashierOrder_productName.Text = "";
            CashierOrder_price.Text = "";
            CashierOrder_quality.Value = 0;
        }
        private void uiButton_ClearCashierOrder_Click(object sender, EventArgs e)
        {
            clearField();

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
            displayOrders();
            displayTotalPrice();
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
            if (product_id == 0)
            {
                MessageBox.Show("Hãy chọn sản phẩm để xóa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xoá sản phẩm ID: " + product_id + " này không ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (CheckConnection())
                    {
                        try
                        {
                            connect.Open();
                            string selectDelete = "DELETE FROM orders WHERE id=@id";
                            using (SqlCommand cmd = new SqlCommand(selectDelete, connect))
                            {
                                cmd.Parameters.AddWithValue("@id", product_id);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show(" Xóa sản phẩm thành công  ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi xóa sản phẩm: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                }
            }
            displayOrders();
            displayTotalPrice();
        }

        private int product_id = 0;

        private void dataGridView_Product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView_Product.Rows[e.RowIndex];
                dataGridView1.CurrentRow.Selected = true;
                product_id = (int)row.Cells["id"].Value;

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                dataGridView1.CurrentRow.Selected = true;
                product_id = (int)row.Cells["id"].Value;

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CashierOrder_pay_Click(object sender, EventArgs e)
        {
            IDGenarator();
            if (CashierOrder_amount.Text == "" || dataGridView1.Rows.Count < 0)
            {
                MessageBox.Show("Hãy nhập số tiền khách đưa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Bạn muốn thanh toán ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (CheckConnection())
                    {
                        try
                        {
                            connect.Open();
                            string insertData = "Insert into customers(customer_id,product_id,total_price,amount,change_amount,order_date)" +
                                "values (@customer_id,@product_id,@total_price,@amount,@change_amount,@order_date)";
                            using (SqlCommand cmd = new SqlCommand(insertData, connect))
                            {
                                cmd.Parameters.AddWithValue("@customer_id", idGen);
                                cmd.Parameters.AddWithValue("@product_id", CashierOrder_productID.SelectedItem);
                                cmd.Parameters.AddWithValue("@total_price", CashierOrder_total.Text);
                                cmd.Parameters.AddWithValue("@amount", CashierOrder_amount.Text);
                                cmd.Parameters.AddWithValue("@change_amount", CashierOrder_change.Text);
                                DateTime now = DateTime.Now;
                                cmd.Parameters.AddWithValue("@order_date", now.ToString("MM/dd/yyyy"));
                                cmd.ExecuteNonQuery();

                                clearField();

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi thanh toán: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                }
            }
            displayTotalPrice();

        }
        private float totalPrice = 0;
        private void CashierOrder_amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    float getAmount = Convert.ToSingle(CashierOrder_amount.Text);
                    float getChange = (getAmount - totalPrice);
                    if (getChange <= -1)
                    {
                        CashierOrder_amount.Text = " ";
                        CashierOrder_change.Text = " ";

                    }
                    else
                    {
                        CashierOrder_change.Text = getChange.ToString("0.00");
                    }
                }
                catch
                    (Exception ex)
                {
                    MessageBox.Show("Lỗi  " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CashierOrder_amount.Text = " ";
                    CashierOrder_change.Text = " ";
                }

            }
        }
    }
}
