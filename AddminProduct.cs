using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

namespace Manage_POS
{
    public partial class AddminProduct : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\manage_POS.mdf;Integrated Security=True;Connect Timeout=30");

        public AddminProduct()
        {
            InitializeComponent();
            displayCategories();
            displayAllProducts();
        }
        public void displayAllProducts()
        {
            AddProductData apData = new AddProductData(); 
            List<AddProductData> listData = apData.AllProductData();
            dataGridView_Product.DataSource = listData;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                // Sửa lại filter đúng cú pháp
                dialog.Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png|All Files (*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = dialog.FileName;
                    pictureBox.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
       
        public bool checkEmptyFields()
        {
            if (textBox_id.Text == "" || textBox_Productname.Text == "" || comboBox_category.SelectedIndex == -1 ||
                textBox_Price.Text == "" || textBox_Stock.Text == ""  ||
                comboBox_Status.SelectedIndex == -1 || pictureBox.Image == null )
            {
                return true;
            }
            else
            {
                return false;
            }
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
                                comboBox_category.Items.Add(reader["category"].ToString());
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
        private void uiButton_addProduct_Click(object sender, EventArgs e)
        {
            if (checkEmptyFields())
            {
                MessageBox.Show("Các ô còn trống ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\manage_POS.mdf;Integrated Security=True;Connect Timeout=30";

            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    // kiểm tra tồn tại
                    string checkSql = "SELECT COUNT(*) FROM products WHERE product_id = @product_id";
                    using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@product_id", textBox_id.Text.Trim());
                        int cnt = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (cnt > 0)
                        {
                            MessageBox.Show("Sản phẩm: " + textBox_id.Text.Trim() + " đã tồn tại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // lưu ảnh
                    if (string.IsNullOrEmpty(pictureBox.ImageLocation) || !File.Exists(pictureBox.ImageLocation))
                    {
                        MessageBox.Show("Hình ảnh không hợp lệ.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string relativePath = Path.Combine("Product_directory", textBox_id.Text.Trim() + Path.GetExtension(pictureBox.ImageLocation));
                    string path = Path.Combine(baseDirectory, relativePath);
                    string directoryPath = Path.GetDirectoryName(path);
                    if (!Directory.Exists(directoryPath))
                        Directory.CreateDirectory(directoryPath);
                    File.Copy(pictureBox.ImageLocation, path, true);

                    // insert
                    string insertSql = @"INSERT INTO products 
                (product_id, product_name, category, price, stock, status, img_path, date_insert) 
                VALUES (@product_id, @product_name, @category, @price, @stock, @status, @img_path, @date_insert)";

                    using (SqlCommand insertCmd = new SqlCommand(insertSql, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@product_id", textBox_id.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@product_name", textBox_Productname.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@category", comboBox_category.SelectedItem?.ToString() ?? "");

                        if (!decimal.TryParse(textBox_Price.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal priceDecimal))
                        {
                            MessageBox.Show("Giá không hợp lệ.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (!int.TryParse(textBox_Stock.Text.Trim(), out int stockInt))
                        {
                            MessageBox.Show("Stock không hợp lệ.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        insertCmd.Parameters.AddWithValue("@price", priceDecimal);
                        insertCmd.Parameters.AddWithValue("@stock", stockInt);
                        insertCmd.Parameters.AddWithValue("@status", comboBox_Status.SelectedItem?.ToString() ?? "");
                        insertCmd.Parameters.AddWithValue("@img_path", path);
                        insertCmd.Parameters.AddWithValue("@date_insert", DateTime.Now);

                        int rows = insertCmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Sản phẩm thêm thành công!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            displayAllProducts();
                            clearFields();
                        }
                        else
                        {
                            MessageBox.Show("Thêm sản phẩm thất bại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool CheckConnection()
        {
            if (connect.State != ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void clearFields()
        {
            textBox_id.Text = "";
            textBox_Productname.Text = "";
            comboBox_category.SelectedIndex = -1;
            textBox_Price.Text = "";
            textBox_Stock.Text = "";
            pictureBox.ImageLocation = null;
            comboBox_Status.SelectedItem = -1;
        }
        private void AddminProduct_Load(object sender, EventArgs e)
        {

        }

        private void uiButton_ClearProduct_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private int getID=0;
        private void dataGridView_Product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex !=-1)
            {
                DataGridViewRow row = dataGridView_Product.Rows[e.RowIndex];
                getID = (int)row.Cells[0].Value; // ID
                textBox_id.Text = row.Cells[1].Value.ToString(); // product_id
                textBox_Productname.Text = row.Cells[2].Value.ToString(); // product_name
                comboBox_category.Text = row.Cells[3].Value.ToString(); // category
                textBox_Price.Text = row.Cells[4].Value.ToString(); // price
                textBox_Stock.Text = row.Cells[5].Value.ToString(); // stock
                pictureBox.ImageLocation = row.Cells[6].Value.ToString(); // img_path

                comboBox_Status.Text = row.Cells[7].Value.ToString(); // status

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiButton_updateProduct_Click(object sender, EventArgs e)
        {
            // kiểm tra đã chọn bản ghi để update chưa
            if (getID == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm muốn cập nhật từ danh sách.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // kiểm tra các trường rỗng
            if (checkEmptyFields())
            {
                MessageBox.Show("Các ô còn trống ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string cs = connect.ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    // validate price và stock
                    if (!decimal.TryParse(textBox_Price.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal priceDecimal))
                    {
                        MessageBox.Show("Giá không hợp lệ.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!int.TryParse(textBox_Stock.Text.Trim(), out int stockInt))
                    {
                        MessageBox.Show("Stock không hợp lệ.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Xác định finalImagePath: nếu người dùng chọn ảnh mới (pictureBox.ImageLocation khác với img_path cũ) thì copy và dùng đường dẫn mới,
                    // nếu không thì giữ nguyên img_path hiện có trong DB (lấy từ DataGridView).
                    string finalImagePath = null;
                    // lấy img_path cũ từ grid (nếu có)
                    foreach (DataGridViewRow r in dataGridView_Product.Rows)
                    {
                        if (r.Cells[0].Value != null && (int)r.Cells[0].Value == getID)
                        {
                            finalImagePath = r.Cells[6].Value?.ToString(); // cột 6 theo cấu trúc của bạn
                            break;
                        }
                    }

                    // Nếu pictureBox.ImageLocation khác null và file tồn tại thì coi là ảnh mới -> copy vào thư mục app và cập nhật
                    if (!string.IsNullOrEmpty(pictureBox.ImageLocation) && File.Exists(pictureBox.ImageLocation))
                    {
                        // nếu đường dẫn mới khác đường dẫn cũ thì copy (tránh copy lại nếu user không đổi ảnh)
                        if (!string.Equals(pictureBox.ImageLocation, finalImagePath, StringComparison.OrdinalIgnoreCase))
                        {
                            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                            string relativePath = Path.Combine("Product_directory", textBox_id.Text.Trim() + Path.GetExtension(pictureBox.ImageLocation));
                            string path = Path.Combine(baseDirectory, relativePath);
                            string directoryPath = Path.GetDirectoryName(path);
                            if (!Directory.Exists(directoryPath))
                                Directory.CreateDirectory(directoryPath);

                            File.Copy(pictureBox.ImageLocation, path, true);
                            finalImagePath = path;
                        }
                    }

                    // UPDATE: sửa theo id, không kiểm tra trùng product_id.
                    // Lưu ý: chúng ta để date_insert giữ nguyên (không ghi đè) — do đó cần lấy giá trị date_insert hiện tại từ DB và dùng lại.
                    DateTime existingDateInsert = DateTime.Now;
                    string getDateSql = "SELECT date_insert FROM products WHERE id = @id";
                    using (SqlCommand getDateCmd = new SqlCommand(getDateSql, conn))
                    {
                        getDateCmd.Parameters.AddWithValue("@id", getID);
                        object dobj = getDateCmd.ExecuteScalar();
                        if (dobj != null && dobj != DBNull.Value)
                        {
                            DateTime.TryParse(dobj.ToString(), out existingDateInsert);
                        }
                    }

                    string updateSql = @"UPDATE products SET 
                                    product_id = @product_id,
                                    product_name = @product_name,
                                    category = @category,
                                    price = @price,
                                    stock = @stock,
                                    status = @status,
                                    img_path = @img_path,
                                    date_insert = @date_insert
                                 WHERE id = @id";

                    using (SqlCommand updateCmd = new SqlCommand(updateSql, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@product_id", textBox_id.Text.Trim());
                        updateCmd.Parameters.AddWithValue("@product_name", textBox_Productname.Text.Trim());
                        updateCmd.Parameters.AddWithValue("@category", comboBox_category.SelectedItem?.ToString() ?? "");
                        updateCmd.Parameters.AddWithValue("@price", priceDecimal);
                        updateCmd.Parameters.AddWithValue("@stock", stockInt);
                        updateCmd.Parameters.AddWithValue("@status", comboBox_Status.SelectedItem?.ToString() ?? "");
                        updateCmd.Parameters.AddWithValue("@img_path", (object)finalImagePath ?? DBNull.Value);
                        updateCmd.Parameters.AddWithValue("@date_insert", existingDateInsert);
                        updateCmd.Parameters.AddWithValue("@id", getID);

                        int rowsAffected = updateCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật sản phẩm thành công!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            displayAllProducts();
                            clearFields();
                            getID = 0;
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void uiButton_RemoveProduct_Click(object sender, EventArgs e)
        {
            // 1) Kiểm tra có chọn hàng trong DataGridView không
            if (dataGridView_Product.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn 1 sản phẩm trong danh sách trước khi xóa.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2) Lấy getID một cách an toàn: thử lấy int từ cột 0, nếu fail thì lấy product_id (string) từ cột 1
            int idToDelete = 0;
            string productIdToDelete = null;
            try
            {
                var val0 = dataGridView_Product.CurrentRow.Cells[0].Value;
                if (val0 != null && int.TryParse(val0.ToString(), out int parsedId))
                {
                    idToDelete = parsedId;
                }
                else
                {
                    // thử lấy product_id ở cột 1 (nếu cột 0 không phải id)
                    var val1 = dataGridView_Product.CurrentRow.Cells.Count > 1 ? dataGridView_Product.CurrentRow.Cells[1].Value : null;
                    if (val1 != null)
                        productIdToDelete = val1.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc dữ liệu từ grid: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (idToDelete == 0 && string.IsNullOrEmpty(productIdToDelete))
            {
                MessageBox.Show("Không thể xác định bản ghi để xóa (id/product_id rỗng).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3) Xác nhận xóa
            var confirm = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này không? Hành động này không thể hoàn tác.",
                                          "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            string cs = connect.ConnectionString; // dùng connectionstring hiện tại

            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    // Lấy img_path hiện tại (nếu có) từ row đã chọn
                    string imgPath = null;
                    try
                    {
                        // Giả sử img_path nằm ở cột index 6 (như code cũ). Nếu khác thì sửa index này.
                        if (dataGridView_Product.CurrentRow.Cells.Count > 6 && dataGridView_Product.CurrentRow.Cells[6].Value != null)
                            imgPath = dataGridView_Product.CurrentRow.Cells[6].Value.ToString();
                    }
                    catch { /* không quan trọng nếu fail */ }

                    // Chuẩn bị SQL: nếu có id (int) thì xóa theo id, else xóa theo product_id
                    string deleteSql;
                    SqlCommand deleteCmd = null;
                    if (idToDelete != 0)
                    {
                        deleteSql = "DELETE FROM products WHERE id = @id";
                        deleteCmd = new SqlCommand(deleteSql, conn);
                        deleteCmd.Parameters.AddWithValue("@id", idToDelete);
                    }
                    else
                    {
                        deleteSql = "DELETE FROM products WHERE product_id = @product_id";
                        deleteCmd = new SqlCommand(deleteSql, conn);
                        deleteCmd.Parameters.AddWithValue("@product_id", productIdToDelete);
                    }

                    int rows = deleteCmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        // Thử xóa file ảnh (không gây rollback DB nếu fail)
                        try
                        {
                            if (!string.IsNullOrEmpty(imgPath) && File.Exists(imgPath))
                            {
                                File.Delete(imgPath);
                            }
                        }
                        catch (Exception exFile)
                        {
                            // chỉ thông báo nhẹ
                            MessageBox.Show("Đã xóa bản ghi nhưng không thể xóa file ảnh: " + exFile.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        MessageBox.Show($"Xóa thành công ({rows} bản ghi).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh grid và clear form
                        displayAllProducts();
                        clearFields();
                        getID = 0;
                    }
                    else
                    {
                        MessageBox.Show("Không có bản ghi nào bị xóa (rowsAffected = 0). Kiểm tra id/product_id và DB.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Hiển thị chi tiết SQL exception (FK constraint, permission, ...)
                MessageBox.Show("Lỗi SQL khi xóa: " + sqlEx.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
