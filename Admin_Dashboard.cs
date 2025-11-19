using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Manage_POS
{
    public partial class Admin_Dashboard : UserControl
    {
        // Kết nối tới database
        private readonly SqlConnection connect = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\manage_POS.mdf;Integrated Security=True;Connect Timeout=30");

        public Admin_Dashboard()
        {
            InitializeComponent();

            // Tắt hàng thêm rỗng để Rows.Count không +1
            dataGridView_Product.AllowUserToAddRows = false;

            // Load UI
            DisplayAggregatedCustomersToGrid();   // hiển thị mỗi customer 1 dòng (gộp)
            DisplayUniqueCustomerCount();         // hiển thị số khách duy nhất
            DisplayAllUsersCount();    // hiển thị số user active
            displayTodayIncome();
            displayTotalIncomeAll();
        }
        public void refeshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refeshData);
                return;

            }
            // Load UI
            DisplayAggregatedCustomersToGrid();   // hiển thị mỗi customer 1 dòng (gộp)
            DisplayUniqueCustomerCount();         // hiển thị số khách duy nhất
            DisplayAllUsersCount();    // hiển thị số user active
            displayTodayIncome();
            displayTotalIncomeAll();
        }

        /// <summary>
        /// Mở kết nối nếu cần, trả về true nếu có thể dùng connection.
        /// </summary>
        public bool CheckConnection()
        {
            try
            {
                if (connect.State != ConnectionState.Open)
                    connect.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối tới DB: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Hiển thị danh sách khách hàng nhưng gộp theo customer_id (mỗi khách 1 dòng).
        /// Lấy tổng tiền, tổng amount, tổng change, và ngày order mới nhất.
        /// </summary>
        public void DisplayAggregatedCustomersToGrid()
        {
            try
            {
                if (!CheckConnection()) return;

                // Query gộp theo customer_id — thay đổi các cột tuỳ theo cấu trúc bảng của bạn
                string sql = @"
                    SELECT 
                        customer_id AS CustomerId,
                        SUM(COALESCE(total_price,0)) AS TotalPrice,
                        SUM(COALESCE(amount,0)) AS Amount,
                        SUM(COALESCE(change_amount,0)) AS ChangeAmount,
                        MAX(order_date) AS LastOrderDate
                    FROM customers
                    GROUP BY customer_id
                    ORDER BY customer_id";

                using (SqlDataAdapter da = new SqlDataAdapter(sql, connect))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Bind DataTable vào DataGridView
                    dataGridView_Product.AutoGenerateColumns = true;
                    dataGridView_Product.DataSource = null;
                    dataGridView_Product.DataSource = dt;

                    // Đổi header cột
                    if (dataGridView_Product.Columns["CustomerId"] != null)
                        dataGridView_Product.Columns["CustomerId"].HeaderText = "Customer ID";
                    if (dataGridView_Product.Columns["TotalPrice"] != null)
                    {
                        dataGridView_Product.Columns["TotalPrice"].HeaderText = "Total Price";
                        dataGridView_Product.Columns["TotalPrice"].DefaultCellStyle.Format = "N0"; // định dạng số nguyên
                    }
                    if (dataGridView_Product.Columns["Amount"] != null)
                    {
                        dataGridView_Product.Columns["Amount"].HeaderText = "Amount";
                        dataGridView_Product.Columns["Amount"].DefaultCellStyle.Format = "N0";
                    }
                    if (dataGridView_Product.Columns["ChangeAmount"] != null)
                    {
                        dataGridView_Product.Columns["ChangeAmount"].HeaderText = "Change";
                        dataGridView_Product.Columns["ChangeAmount"].DefaultCellStyle.Format = "N0";
                    }
                    if (dataGridView_Product.Columns["LastOrderDate"] != null)
                    {
                        dataGridView_Product.Columns["LastOrderDate"].HeaderText = "Last Order Date";
                        dataGridView_Product.Columns["LastOrderDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị khách gộp: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }

        /// <summary>
        /// Nếu bạn muốn hiển thị tất cả các order (mỗi order 1 dòng), dùng method này thay cho DisplayAggregatedCustomersToGrid.
        /// </summary>
        public void DisplayAllOrdersToGrid()
        {
            try
            {
                if (!CheckConnection()) return;

                string sql = @"SELECT customer_id AS CustomerId, total_price AS TotalPrice, amount AS Amount, change_amount AS ChangeAmount, order_date AS OrderDate FROM customers ORDER BY order_date DESC";

                using (SqlDataAdapter da = new SqlDataAdapter(sql, connect))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView_Product.AutoGenerateColumns = true;
                    dataGridView_Product.DataSource = null;
                    dataGridView_Product.DataSource = dt;

                    // Format giống trên nếu cần
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị tất cả orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }

        /// <summary>
        /// Đếm số khách hàng duy nhất (unique customer_id) và gán vào dashboard_customer label.
        /// </summary>
        public void DisplayUniqueCustomerCount()
        {
            try
            {
                if (!CheckConnection()) return;

                string sql = "SELECT COUNT(DISTINCT customer_id) FROM customers";
                using (SqlCommand cmd = new SqlCommand(sql, connect))
                {
                    object result = cmd.ExecuteScalar();
                    int count = 0;
                    if (result != null && result != DBNull.Value)
                        count = Convert.ToInt32(result);
                    dashboard_customer.Text = count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đếm khách duy nhất: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }

        /// <summary>
        /// Hiển thị tổng số user active (không thay đổi).
        /// </summary>
        public void DisplayAllUsersCount()
        {
            try
            {
                if (!CheckConnection()) return;

                string selectData = "SELECT COUNT(id) FROM users WHERE status = @status";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    cmd.Parameters.AddWithValue("@status", "Active");
                    object result = cmd.ExecuteScalar();
                    int count = 0;
                    if (result != null && result != DBNull.Value)
                        count = Convert.ToInt32(result);
                    dashboard_user.Text = count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đếm user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }
        public void displayTodayIncome()
        {
            try
            {
                if (!CheckConnection()) return;

                string sql = @"
            SELECT SUM(total_price) 
            FROM customers 
            WHERE order_date >= @start 
              AND order_date < @end";

                using (SqlCommand cmd = new SqlCommand(sql, connect))
                {
                    DateTime today = DateTime.Today;
                    DateTime tomorrow = today.AddDays(1);

                    cmd.Parameters.AddWithValue("@start", today);
                    cmd.Parameters.AddWithValue("@end", tomorrow);

                    object result = cmd.ExecuteScalar();
                    decimal total = 0;

                    if (result != null && result != DBNull.Value)
                        total = Convert.ToDecimal(result);

                    dashprice_todayPrice.Text = total.ToString("#,##0");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tổng tiền hôm nay: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }
        public void displayTotalIncomeAll()
        {
            try
            {
                if (!CheckConnection()) return;

                string sql = "SELECT SUM(total_price) FROM customers";

                using (SqlCommand cmd = new SqlCommand(sql, connect))
                {
                    object result = cmd.ExecuteScalar();
                    decimal total = 0;

                    if (result != null && result != DBNull.Value)
                        total = Convert.ToDecimal(result);

                    // Gán vào label bạn muốn hiển thị
                    dashboard_totalPrice.Text = total.ToString("#,##0");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tổng tất cả tiền: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            // nếu cần xử lý click
        }
    }
}
