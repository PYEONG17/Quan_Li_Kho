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
using MaterialSkin;
using MaterialSkin.Controls;

namespace Manage_POS
{
    public partial class Register : Form

    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\manage_POS.mdf;Integrated Security=True;Connect Timeout=30");

        public Register()
        {
            InitializeComponent();
        }

        private void close_click_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void label_login_here_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void SignUp_button_Click(object sender, EventArgs e)
        {
            if(register_username_textbox.Text=="" || register_password_textbox.Text=="" || register_confirm_password.Text=="")
            { 
                MessageBox.Show("Vui lòng điền tất cả thông tin !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (checkConnection())
                {
                    try
                    {
                        connect = new SqlConnection(connect.ConnectionString);
                        connect.Open();
                        string checkUsername= "SELECT * FROM users WHERE username=@username";

                        using(SqlCommand cmd=new SqlCommand(checkUsername, connect))
                        {
                            cmd.Parameters.AddWithValue("@username",register_username_textbox.Text.Trim());
                            SqlDataAdapter adapter=  new SqlDataAdapter(cmd);
                            DataTable table= new DataTable();
                            adapter.Fill(table);
                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show(register_username_textbox.Text.Trim() + "đã được sử dụng", "Error Message ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            else if (register_password_textbox.Text.Length < 6)
                            {
                                MessageBox.Show(" Mật khẩu cần tối thiểu 6 kí tự  ", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (register_password_textbox.Text.Trim() != register_confirm_password.Text.Trim())
                            {
                                MessageBox.Show("Mật khẩu không khớp.","Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);

                            }
                            
                        }

                        string insertData= "INSERT INTO users (username, password,role,status,date) VALUES (@username, @password,@role,@status,@date)";
                        using(SqlCommand insertD= new SqlCommand(insertData, connect))
                        {
                            insertD.Parameters.AddWithValue("@username", register_username_textbox.Text.Trim());
                            insertD.Parameters.AddWithValue("@password", register_password_textbox.Text.Trim());
                            insertD.Parameters.AddWithValue("@role", "User");
                            insertD.Parameters.AddWithValue("@status", "Active");

                            DateTime today = DateTime.Today;
                            insertD.Parameters.AddWithValue("@date", DateTime.Now);

                            insertD.ExecuteNonQuery();
                            MessageBox.Show("Đăng kí thành công !", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Login login = new Login();
                            login.Show();
                            this.Hide();


                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kết nối thất bại : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
                
            
        }
        }
        private bool checkConnection()
        {
            try
            {
                connect.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                connect.Close();
            }
        }

        private void register_password_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel4_Click(object sender, EventArgs e)
        {

        }

        private void register_show_password_CheckedChanged(object sender, EventArgs e)
        {
            if (register_show_password.Checked)
            {
                register_password_textbox.UseSystemPasswordChar = false;
                register_confirm_password.UseSystemPasswordChar = false;
            }
            else
            {
                register_password_textbox.UseSystemPasswordChar = true;
                register_confirm_password.UseSystemPasswordChar = true;
            }
        }
    }
}
