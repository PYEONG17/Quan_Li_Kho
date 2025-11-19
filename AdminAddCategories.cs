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

namespace Manage_POS
{
    public partial class AdminAddCategories : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\manage_POS.mdf;Integrated Security=True;Connect Timeout=30");

        public AdminAddCategories()
        {
            InitializeComponent();
            displayCategoriesData();
        }
        public void refeshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refeshData);
                return;

            }
            // Load UI

            displayCategoriesData();
        }
        public bool checkConnection()
        {
            try
            {
                connect.Open();
                connect.Close();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Database connection failed.");
                return false;
            }
        }
        public void displayCategoriesData()
        {
            CategoriesData cData = new CategoriesData();
            List<CategoriesData> listData = new CategoriesData().AllcategoriesData();
            // Tạo danh sách mới với cột STT
            var displayList = listData.Select((item, index) => new
            {
                STT = index + 1, // Số thứ tự tự động
                ID = item.ID,
                Category = item.Category,
                date = item.date
            }).ToList();
            dataGridView_categories.DataSource = displayList;
        }
        private void button_addCategory_Click(object sender, EventArgs e)
        {
            if (button_addCategory.Text == " ")
            {
                MessageBox.Show("các trường trống", "error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (checkConnection())
                {
                    try
                    {
                        connect.Open();
                        string checkCategory = "SELECT * FROM categories WHERE Category=@category";
                        using (SqlCommand cmd = new SqlCommand(checkCategory, connect))
                        {
                            cmd.Parameters.AddWithValue("@category", textBox_Categoryname.Text.Trim());
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show("Các trường trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            else
                            {
                                string insertCategory = "INSERT INTO categories (Category,date) VALUES (@category,@date)";
                                using (SqlCommand insertCmd = new SqlCommand(insertCategory, connect))
                                {
                                    insertCmd.Parameters.AddWithValue("@category", textBox_Categoryname.Text.Trim());

                                    DateTime today = DateTime.Today;
                                    insertCmd.Parameters.AddWithValue("@date", today.ToString("MM/dd/yyyy"));

                                    insertCmd.ExecuteNonQuery();
                                    clearFields();

                                    displayCategoriesData();

                                    MessageBox.Show("Thêm danh mục thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    textBox_Categoryname.Clear();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm danh mục: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }
        public void clearFields()
        {
            textBox_Categoryname.Text = " ";
            textBox_Categoryname2.Text = " ";
            getID = 0;
        }
        private void button_clearCatgory_Click(object sender, EventArgs e)
        {
            clearFields();
        }
        private int getID = 0;
        private void dataGridView_categories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView_categories.Rows[e.RowIndex];
                // Nếu cột: 0=STT, 1=ID, 2=Category
                getID = Convert.ToInt32(row.Cells[1].Value); // ID
                                                             // Hiển thị ID vào textbox ID (nếu có)
                textBox_Categoryname2.Text = getID.ToString(); // textbox dành cho ID (hoặc textBox_CategoryID)
                                                               // Hiển thị tên danh mục vào textbox tên
                textBox_Categoryname.Text = row.Cells[2].Value?.ToString() ?? string.Empty; // textbox dành cho tên
            }
        }


        private void button_updateCatgory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_Categoryname.Text))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (getID == 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần cập nhật!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật ID : " + getID + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (checkConnection())
                {
                    try
                    {
                        connect.Open();
                        // Kiểm tra trùng tên danh mục với danh mục khác
                        string checkCategory = "SELECT * FROM categories WHERE Category=@category AND id<>@id";
                        using (SqlCommand cmd = new SqlCommand(checkCategory, connect))
                        {
                            cmd.Parameters.AddWithValue("@id", getID);
                            cmd.Parameters.AddWithValue("@category", textBox_Categoryname.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show("Tên danh mục đã tồn tại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        // Thực hiện cập nhật
                        string updateCategory = "UPDATE categories SET Category=@category WHERE id=@id";
                        using (SqlCommand updateCmd = new SqlCommand(updateCategory, connect))
                        {
                            updateCmd.Parameters.AddWithValue("@id", getID);
                            updateCmd.Parameters.AddWithValue("@category", textBox_Categoryname2.Text.Trim()); // Chỉ dùng 1 biến @category

                            updateCmd.ExecuteNonQuery();
                        }
                        clearFields();
                        displayCategoriesData();
                        MessageBox.Show("Cập nhật danh mục thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật danh mục: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void button_removeCatgory_Click(object sender, EventArgs e)
        {
            if (getID == 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần xóa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục ID: " + getID + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (checkConnection())
                {
                    try
                    {
                        connect.Open();
                        string deleteCategory = "DELETE FROM categories WHERE id=@id";
                        using (SqlCommand cmd = new SqlCommand(deleteCategory, connect))
                        {
                            cmd.Parameters.AddWithValue("@id", getID);
                            cmd.ExecuteNonQuery();
                        }
                        // After deleting all rows, reset identity seed to 1
                        clearFields();
                        displayCategoriesData();
                        MessageBox.Show("Xóa danh mục thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa danh mục: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (getID == 0)
            {

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Categoryname_TextChanged(object sender, EventArgs e)
        {

        }

        private void AdminAddCategories_Load(object sender, EventArgs e)
        {

        }
    }
}