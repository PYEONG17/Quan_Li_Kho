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
using System.Security.Cryptography;
using MaterialSkin;
using MaterialSkin.Controls;
namespace Manage_POS
{
    public partial class Login : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\manage_POS.mdf;Integrated Security=True;Connect Timeout=30");

        public Login()
        {
            InitializeComponent();
            
        }

        private void uiLabel2_Click(object sender, EventArgs e)
        {

        }

        private void uiTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialTextBox21_Click(object sender, EventArgs e)
        {

        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (checkConnection())
            {
                try
                {
                    connect.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE username=@username AND password=@password", connect))
                    {
                        cmd.Parameters.AddWithValue("@username", login_username_textbox.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", login_password_textbox.Text.Trim());
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            MessageBox.Show("Đăng nhập thành công !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MainForm mainForm = new MainForm();
                            mainForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                          
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

        private void Login_Load(object sender, EventArgs e)
        {


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void login_password_Click(object sender, EventArgs e)
        {

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
        private void login_show_password_CheckedChanged(object sender, EventArgs e)
        {
           if(login_password_textbox.UseSystemPasswordChar==true)
            {
                login_password_textbox.UseSystemPasswordChar = false;
            }
           else
            {
                login_password_textbox.UseSystemPasswordChar = true;
            }

        }
    }
} 
