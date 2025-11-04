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
using System.Data;

namespace Manage_POS
{
    public partial class AdminAddUser : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\manage_POS.mdf;Integrated Security=True;Connect Timeout=30");
        public void displayAllUsersData()
        {
            UserData userData = new UserData();
            List<UserData> users = userData.AllUserData();
            dataGridView1.DataSource=users;

        }
        public AdminAddUser()
        {
            InitializeComponent();
            displayAllUsersData();
        }

        private void AdminAddUser_Load(object sender, EventArgs e)
        {

        }
        public bool checkConnection()
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

        private void button_adduser_Click(object sender, EventArgs e)
        {
            if (textBox_username.Text == " " || textBox_password.Text == " " || comboBox_role.SelectedIndex == -1 || comboBox_status.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng điền tất cả các trường!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            { 
                if(checkConnection())
                {
                    try
                    {
                        connect.Open();
                        string checkUsername = "SELECT * FROM users WHERE username=@username";
                        using(SqlCommand cmd= new SqlCommand(checkUsername, connect))
                        {
                            cmd.Parameters.AddWithValue("@username", textBox_username.Text.Trim());
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show(textBox_username.Text.Trim() + " đã được sử dụng", "Error Message ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            { 
                                string insertData = "INSERT INTO users (username, password,role,status,date)"+ " VALUES (@username, @password,@role,@status,@date)";
                                using (SqlCommand insertCmd = new SqlCommand(insertData, connect))
                                {
                                    insertCmd.Parameters.AddWithValue("@username", textBox_username.Text.Trim());
                                    insertCmd.Parameters.AddWithValue("@password", textBox_password.Text.Trim());
                                    insertCmd.Parameters.AddWithValue("@role", comboBox_role.SelectedItem.ToString());
                                    insertCmd.Parameters.AddWithValue("@status", comboBox_status.SelectedItem.ToString());
                                    DateTime today = DateTime.Today;
                                    insertCmd.Parameters.AddWithValue("@date", today);
                                  
                                    insertCmd.ExecuteNonQuery();          
                                    clearFields();

                                    MessageBox.Show("Người dùng đã được thêm thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kết nối thất bại !" + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (textBox_username.Text == " " || textBox_password.Text == " " || comboBox_role.SelectedIndex == -1 || comboBox_status.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng điền tất cả các trường!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật ID : " + getID + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {
                            connect.Open();
                            // Chỉ kiểm tra username trùng nếu username này thuộc về user khác (không phải user đang update)
                            string checkUsername = "SELECT * FROM users WHERE username=@username AND id<>@id";
                            using (SqlCommand cmd = new SqlCommand(checkUsername, connect))
                            {
                                cmd.Parameters.AddWithValue("@username", textBox_username.Text.Trim());
                                cmd.Parameters.AddWithValue("@id", getID);
                                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                                DataTable table = new DataTable();
                                adapter.Fill(table);
                                if (table.Rows.Count > 0)
                                {
                                    MessageBox.Show(textBox_username.Text.Trim() + " đã được sử dụng", "Error Message ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
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
                                        displayAllUsersData();
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Kết nối thất bại !" + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                }
            }
        }

        private void button_remove_Click(object sender, EventArgs e)
        {

        }
        public void clearFields()
        {
            textBox_username.Text = "";
            textBox_password.Text = "";
            comboBox_role.SelectedIndex = -1;
            comboBox_status.SelectedIndex = -1;
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
                int id = (int)row.Cells[0].Value;
                string username = row.Cells[1].Value.ToString();
                string password = row.Cells[2].Value.ToString();
                string role = row.Cells[3].Value.ToString();
                string status = row.Cells[4].Value.ToString();
                textBox_username.Text = username;
                textBox_password.Text = password;
                comboBox_role.SelectedItem = role;
                comboBox_status.SelectedItem = status;

                getID = id; // Add this line to set getID for update
            }
        }
    }
}
