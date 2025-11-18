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
            // Kiểm tra số tiền khách đưa
            if (string.IsNullOrWhiteSpace(CashierOrder_amount.Text))
            {
                MessageBox.Show("Hãy nhập số tiền khách đưa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(CashierOrder_amount.Text, out decimal amount))
            {
                MessageBox.Show("Số tiền khách đưa không hợp lệ!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tính tổng đơn hàng
            decimal totalPrice = GetCurrentOrderTotal();

            if (totalPrice <= 0)
            {
                MessageBox.Show("Không có sản phẩm trong đơn hàng!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal change = amount - totalPrice;
            CashierOrder_change.Text = change.ToString("0.00");

            if (change < 0)
            {
                MessageBox.Show("Khách đưa chưa đủ tiền!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận thanh toán
            if (MessageBox.Show("Bạn muốn thanh toán đơn hàng?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (!CheckConnection())
            {
                MessageBox.Show("Không thể kết nối tới database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
                {
                    conn.Open();

                    // Sinh customer_id mới dựa trên orders hiện có
                    int currentCustomerId = 0;
                    using (SqlCommand cmdMax = new SqlCommand("SELECT ISNULL(MAX(customer_id), 0) FROM orders", conn))
                    {
                        object r = cmdMax.ExecuteScalar();
                        currentCustomerId = Convert.ToInt32(r) + 1;
                    }

                    // Transaction để chắc chắn insert + delete là atomic
                    using (SqlTransaction txn = conn.BeginTransaction())
                    {
                        try
                        {
                            // Insert vào bảng customers (không có product_id)
                            string insertCustomer = @"
                        INSERT INTO customers (customer_id, total_price, amount, change_amount, order_date)
                        VALUES (@customer_id, @total_price, @amount, @change_amount, @order_date)";

                            using (SqlCommand cmdInsert = new SqlCommand(insertCustomer, conn, txn))
                            {
                                cmdInsert.Parameters.AddWithValue("@customer_id", currentCustomerId);
                                cmdInsert.Parameters.AddWithValue("@total_price", totalPrice);
                                cmdInsert.Parameters.AddWithValue("@amount", amount);
                                cmdInsert.Parameters.AddWithValue("@change_amount", change);
                                cmdInsert.Parameters.AddWithValue("@order_date", DateTime.Now);

                                cmdInsert.ExecuteNonQuery();
                            }

                            // Xóa các order của customer hiện tại
                            string deleteOrders = "DELETE FROM orders";
                            using (SqlCommand cmdDelete = new SqlCommand(deleteOrders, conn, txn))
                            {
                                cmdDelete.ExecuteNonQuery();
                            }

                            txn.Commit();
                        }
                        catch
                        {
                            txn.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Thanh toán thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                clearField();
                displayOrders();
                displayTotalPrice();
                CashierOrder_amount.Text = "";
                CashierOrder_change.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thanh toán: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal GetCurrentOrderTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["total_price"].Value != null &&
                    decimal.TryParse(row.Cells["total_price"].Value.ToString(), out decimal price))
                {
                    total += price;
                }
            }
            displayTotalPrice();

            return total;
        }


        private float totalPrice = 0;
        private void CashierOrder_amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            try
            {
                // Lấy tổng tiền hiện tại
                decimal total = GetCurrentOrderTotal();

                // Parse số tiền khách đưa
                if (!decimal.TryParse(CashierOrder_amount.Text, out decimal amount))
                {
                    MessageBox.Show("Số tiền không hợp lệ!", "Error");
                    return;
                }

                decimal change = amount - total;

                if (change < 0)
                {
                    CashierOrder_change.Text = "";
                    MessageBox.Show("Khách đưa chưa đủ tiền!");
                }
                else
                {
                    CashierOrder_change.Text = change.ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Error");
                CashierOrder_amount.Text = "";
                CashierOrder_change.Text = "";
            }
        }
        // Billl
        // dùng để in sau khi thanh toán (lưu tạm)
        private DataTable dtOrdersForPrint = null;
        private int lastPaidCustomerId = 0;

        // index in cho phân trang
        private int printRowIndex = 0;
        private void CashierOrder_bill_Click(object sender, EventArgs e)
        {
            // Nếu vừa thanh toán, dtOrdersForPrint sẽ chứa chi tiết để in
            // Nếu không có dtOrdersForPrint, fallback in từ dataGridView1 hiện tại
            if ((dtOrdersForPrint == null || dtOrdersForPrint.Rows.Count == 0) && (dataGridView1 == null || dataGridView1.Rows.Count == 0))
            {
                MessageBox.Show("Không có dữ liệu để in. Vui lòng thanh toán hoặc chọn đơn hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // reset index in
            printRowIndex = 0;

            // tránh đăng ký event nhiều lần
            printDocument1.BeginPrint -= printDocument1_BeginPrint;
            printDocument1.PrintPage -= printDocument1_PrintPage;
            printDocument1.BeginPrint += printDocument1_BeginPrint;
            printDocument1.PrintPage += printDocument1_PrintPage;

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Width = 900;
            printPreviewDialog1.Height = 700;
            printPreviewDialog1.ShowDialog();
        }
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            printRowIndex = 0;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // chọn nguồn in: ưu tiên dtOrdersForPrint, nếu rỗng dùng dataGridView1
            bool useDataTable = dtOrdersForPrint != null && dtOrdersForPrint.Rows.Count > 0;

            // chuẩn fonts / layout
            Font headerFont = new Font("Tahoma", 14, FontStyle.Bold);
            Font colHeaderFont = new Font("Tahoma", 10, FontStyle.Bold);
            Font bodyFont = new Font("Tahoma", 10, FontStyle.Regular);
            float lineHeight = bodyFont.GetHeight(e.Graphics) + 6f;

            float left = e.MarginBounds.Left;
            float top = e.MarginBounds.Top;
            float right = e.MarginBounds.Right;
            float bottom = e.MarginBounds.Bottom;
            float y = top;

            // Title
            string title = "HÓA ĐƠN BÁN HÀNG";
            SizeF titleSize = e.Graphics.MeasureString(title, headerFont);
            float titleX = left + (e.MarginBounds.Width - titleSize.Width) / 2f;
            e.Graphics.DrawString(title, headerFont, Brushes.Black, titleX, y);
            y += titleSize.Height + 8f;

            // Ngày
            string dateStr = "Ngày: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            e.Graphics.DrawString(dateStr, bodyFont, Brushes.Black, left, y);
            y += lineHeight + 6f;

            // Column headers và tỉ lệ cột (tùy chỉnh)
            string[] headers = new string[] { "Mã SP", "Tên SP", "Danh mục", "SL", "Giá", "Thành tiền", "Ngày" };
            float[] colRatios = new float[] { 12, 32, 16, 8, 12, 12, 8 }; // tổng = 100
            int colCount = headers.Length;
            float tableWidth = e.MarginBounds.Width;
            float[] colWidths = new float[colCount];
            for (int i = 0; i < colCount; i++) colWidths[i] = tableWidth * (colRatios[i] / 100f);

            // vẽ header cột
            float x = left;
            for (int i = 0; i < colCount; i++)
            {
                var rect = new RectangleF(x, y, colWidths[i], lineHeight);
                StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                e.Graphics.DrawRectangle(Pens.Black, rect.X, rect.Y, rect.Width, rect.Height);
                e.Graphics.DrawString(headers[i], colHeaderFont, Brushes.Black, rect, sf);
                x += colWidths[i];
            }
            y += lineHeight;

            // In dữ liệu - xử lý phân trang
            if (useDataTable)
            {
                while (printRowIndex < dtOrdersForPrint.Rows.Count)
                {
                    if (y + lineHeight > bottom - 100) { e.HasMorePages = true; return; }

                    DataRow dr = dtOrdersForPrint.Rows[printRowIndex];
                    x = left;

                    string sProd = dr.Table.Columns.Contains("product_id") ? (dr["product_id"]?.ToString() ?? "") : "";
                    string sName = dr.Table.Columns.Contains("product_name") ? (dr["product_name"]?.ToString() ?? "") : "";
                    string sCategory = dr.Table.Columns.Contains("category") ? (dr["category"]?.ToString() ?? "") : "";
                    string sQty = dr.Table.Columns.Contains("quality") ? (dr["quality"]?.ToString() ?? "") : "";
                    string sPrice = dr.Table.Columns.Contains("origin_price") ? (dr["origin_price"]?.ToString() ?? "") : "";
                    string sTotal = dr.Table.Columns.Contains("total_price") ? (dr["total_price"]?.ToString() ?? "") : "";
                    string sDate = dr.Table.Columns.Contains("order_date") && dr["order_date"] != DBNull.Value ? Convert.ToDateTime(dr["order_date"]).ToString("yyyy-MM-dd") : "";

                    string[] cols = new string[] { sProd, sName, sCategory, sQty, sPrice, sTotal, sDate };

                    for (int c = 0; c < colCount; c++)
                    {
                        var rect = new RectangleF(x, y, colWidths[c], lineHeight);
                        StringFormat sf = new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };
                        // căn phải cho số
                        if (decimal.TryParse(cols[c], out _) || double.TryParse(cols[c], out _)) sf.Alignment = StringAlignment.Far;
                        e.Graphics.DrawRectangle(Pens.Black, rect.X, rect.Y, rect.Width, rect.Height);
                        e.Graphics.DrawString(cols[c], bodyFont, Brushes.Black, rect, sf);
                        x += colWidths[c];
                    }

                    y += lineHeight;
                    printRowIndex++;
                }
            }
            else
            {
                // in từ DataGridView (đảm bảo cột tồn tại)
                while (printRowIndex < dataGridView1.Rows.Count)
                {
                    if (y + lineHeight > bottom - 100) { e.HasMorePages = true; return; }

                    DataGridViewRow row = dataGridView1.Rows[printRowIndex];
                    x = left;

                    // lấy giá trị cột theo tên nếu có, fallback theo chỉ số
                    string sProd = row.Cells["product_id"]?.Value?.ToString() ?? "";
                    string sName = row.Cells["product_name"]?.Value?.ToString() ?? "";
                    string sCategory = row.Cells["category"]?.Value?.ToString() ?? "";
                    string sQty = row.Cells["quality"]?.Value?.ToString() ?? "";
                    string sPrice = row.Cells["origin_price"]?.Value?.ToString() ?? "";
                    string sTotal = row.Cells["total_price"]?.Value?.ToString() ?? "";
                    string sDate = row.Cells["order_date"]?.Value != null ? Convert.ToDateTime(row.Cells["order_date"].Value).ToString("yyyy-MM-dd") : "";

                    string[] cols = new string[] { sProd, sName, sCategory, sQty, sPrice, sTotal, sDate };

                    for (int c = 0; c < colCount; c++)
                    {
                        var rect = new RectangleF(x, y, colWidths[c], lineHeight);
                        StringFormat sf = new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };
                        if (decimal.TryParse(cols[c], out _) || double.TryParse(cols[c], out _)) sf.Alignment = StringAlignment.Far;
                        e.Graphics.DrawRectangle(Pens.Black, rect.X, rect.Y, rect.Width, rect.Height);
                        e.Graphics.DrawString(cols[c], bodyFont, Brushes.Black, rect, sf);
                        x += colWidths[c];
                    }

                    y += lineHeight;
                    printRowIndex++;
                }
            }

            // Footer: tổng, khách đưa, tiền thối — tính tổng từ nguồn in (an toàn)
            decimal totalFromPrint = 0m;
            if (useDataTable)
            {
                foreach (DataRow r in dtOrdersForPrint.Rows)
                    if (r.Table.Columns.Contains("total_price") && r["total_price"] != DBNull.Value)
                        totalFromPrint += Convert.ToDecimal(r["total_price"]);
            }
            else
            {
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (r.IsNewRow) continue;
                    var cell = r.Cells["total_price"]?.Value;
                    if (cell != null && decimal.TryParse(cell.ToString(), out decimal p)) totalFromPrint += p;
                }
            }

            decimal.TryParse(CashierOrder_amount.Text.Trim(), out decimal amountGiven);
            decimal.TryParse(CashierOrder_change.Text.Trim(), out decimal changeAmount);

            float footerY = bottom - 80;
            Font footerFont = new Font("Tahoma", 11, FontStyle.Bold);

            string totalLine = $"TỔNG: {totalFromPrint:0.00}";
            string amountLine = $"KHÁCH ĐƯA: {amountGiven:0.00}";

            SizeF totalSize = e.Graphics.MeasureString(totalLine, footerFont);
            e.Graphics.DrawString(totalLine, footerFont, Brushes.Black, right - totalSize.Width, footerY);
            footerY += lineHeight;
            SizeF amtSize = e.Graphics.MeasureString(amountLine, bodyFont);
            e.Graphics.DrawString(amountLine, bodyFont, Brushes.Black, right - amtSize.Width, footerY);
            footerY += lineHeight;
            e.HasMorePages = false;
        }


    }

}


