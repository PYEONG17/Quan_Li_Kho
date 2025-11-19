using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data.SqlClient;
using Sunny.UI;

namespace Manage_POS
{
    public partial class AdminAddUser : UserControl
    {
        SqlConnection connect = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\manage_POS.mdf;Integrated Security=True;Connect Timeout=30");

        public AdminAddUser()
        {
            InitializeComponent();

            // Tắt hàng thêm rỗng và bật AutoGenerateColumns để hiển thị đúng
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = true;

       
        }
        public void refeshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refeshData);
                return;

            }
            // Load UI
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = true;
        }
        public void displayAllUsersData()
        {
            try
            {
                if (!CheckConnection()) return;

                UserData userData = new UserData();
                List<UserData> users = userData.AllUserData();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open) connect.Close();
            }
        }

        private void AdminAddUser_Load(object sender, EventArgs e)
        {

        }

        // Mở kết nối nếu cần, trả về true nếu kết nối thành công/đã mở
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

        private void button_adduser_Click(object sender, EventArgs e)
        {
            // Sử dụng IsNullOrWhiteSpace để kiểm tra đúng (không chỉ là dấu cách)
            if (string.IsNullOrWhiteSpace(textBox_username.Text) ||
                string.IsNullOrWhiteSpace(textBox_password.Text) ||
                comboBox_role.SelectedIndex == -1 ||
                comboBox_status.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng điền tất cả các trường!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!CheckConnection()) return;

            try
            {
                // Kiểm tra username tồn tại nhanh bằng COUNT
                string checkUsername = "SELECT COUNT(1) FROM users WHERE username = @username";
                using (SqlCommand cmd = new SqlCommand(checkUsername, connect))
                {
                    cmd.Parameters.AddWithValue("@username", textBox_username.Text.Trim());
                    int exist = Convert.ToInt32(cmd.ExecuteScalar());
                    if (exist > 0)
                    {
                        MessageBox.Show(textBox_username.Text.Trim() + " đã được sử dụng", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Thêm user
                string insertData = "INSERT INTO users (username, password, role, status, date) VALUES (@username, @password, @role, @status, @date)";
                using (SqlCommand insertCmd = new SqlCommand(insertData, connect))
                {
                    insertCmd.Parameters.AddWithValue("@username", textBox_username.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@password", textBox_password.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@role", comboBox_role.SelectedItem.ToString());
                    insertCmd.Parameters.AddWithValue("@status", comboBox_status.SelectedItem.ToString());
                    insertCmd.Parameters.AddWithValue("@date", DateTime.Today);

                    int rows = insertCmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Người dùng đã được thêm thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearFields();

                        // QUAN TRỌNG: cập nhật lại DataGridView sau khi thêm
                        displayAllUsersData();
                    }
                    else
                    {
                        MessageBox.Show("Thêm người dùng thất bại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại! " + ex.Message, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open) connect.Close();
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_username.Text) ||
                string.IsNullOrWhiteSpace(textBox_password.Text) ||
                comboBox_role.SelectedIndex == -1 ||
                comboBox_status.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng điền tất cả các trường!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật ID : " + getID + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!CheckConnection()) return;

                try
                {
                    // Chỉ kiểm tra username trùng nếu username này thuộc về user khác (không phải user đang update)
                    string checkUsername = "SELECT COUNT(1) FROM users WHERE username = @username AND id <> @id";
                    using (SqlCommand cmd = new SqlCommand(checkUsername, connect))
                    {
                        cmd.Parameters.AddWithValue("@username", textBox_username.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", getID);
                        int exist = Convert.ToInt32(cmd.ExecuteScalar());
                        if (exist > 0)
                        {
                            MessageBox.Show(textBox_username.Text.Trim() + " đã được sử dụng", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string updateData = "UPDATE users SET username=@username, password=@password, role=@role, status=@status WHERE id=@id";
                    using (SqlCommand updateCmd = new SqlCommand(updateData, connect))
                    {
                        updateCmd.Parameters.AddWithValue("@username", textBox_username.Text.Trim());
                        updateCmd.Parameters.AddWithValue("@password", textBox_password.Text.Trim());
                        updateCmd.Parameters.AddWithValue("@role", comboBox_role.SelectedItem.ToString());
                        updateCmd.Parameters.AddWithValue("@status", comboBox_status.SelectedItem.ToString());
                        updateCmd.Parameters.AddWithValue("@id", getID);
                        updateCmd.ExecuteNonQuery();
                        clearFields();
                        MessageBox.Show("Người dùng đã được cập nhật thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // cập nhật lại DataGridView sau khi update
                        displayAllUsersData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kết nối thất bại! " + ex.Message, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (connect.State == ConnectionState.Open) connect.Close();
                }
            }
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            // Nếu muốn mình có thể implement xóa luôn (soft delete hoặc hard delete)
            if (getID <= 0)
            {
                MessageBox.Show("Vui lòng chọn 1 user để xóa.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ID: " + getID + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!CheckConnection()) return;

                try
                {
                    string deleteSql = "DELETE FROM users WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(deleteSql, connect))
                    {
                        cmd.Parameters.AddWithValue("@id", getID);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Xóa thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearFields();
                            displayAllUsersData();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (connect.State == ConnectionState.Open) connect.Close();
                }
            }
        }

        public void clearFields()
        {
            textBox_username.Text = "";
            textBox_password.Text = "";
            comboBox_role.SelectedIndex = -1;
            comboBox_status.SelectedIndex = -1;
            getID = 0;
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void textBox_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_role_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private int getID = 0;
        private object id;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                // assuming id is in column 0
                int id = Convert.ToInt32(row.Cells[0].Value);
                string username = row.Cells[1].Value?.ToString() ?? "";
                string password = row.Cells[2].Value?.ToString() ?? "";
                string role = row.Cells[3].Value?.ToString() ?? "";
                string status = row.Cells[4].Value?.ToString() ?? "";
                textBox_username.Text = username;
                textBox_password.Text = password;
                comboBox_role.SelectedItem = role;
                comboBox_status.SelectedItem = status;

                getID = id; // set id for update/delete
            }
        }
    }
}
