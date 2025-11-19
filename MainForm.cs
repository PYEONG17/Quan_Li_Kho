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
using System.Data;
using Sunny.UI;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
namespace Manage_POS
{
    public partial class MainForm : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\manage_POS.mdf;Integrated Security=True;Connect Timeout=30");

        public MainForm()
        {
            InitializeComponent();
        }

        private void uiAvatar1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }



        private void uiButton_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit the application?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {
                Application.Exit();
            }
        }

        private void uiButton_log_out_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất tài khoản ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Hide();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void adminDashboard1_Load(object sender, EventArgs e)
        {

        }

        private void adminAddUser1_Load(object sender, EventArgs e)
        {

        }

        private void adminAddCategories1_Load(object sender, EventArgs e)
        {

        }

        private void uiButton_dashboard_Click(object sender, EventArgs e)
        {
            admin_Dashboard1.Visible = true;
            adminAddUser1.Visible = false;
            adminAddCategories1.Visible = false;
            addminProduct1.Visible = false;
            cashierCustomerForm1.Visible = false;
            Admin_Dashboard adForm = admin_Dashboard1 as Admin_Dashboard;
            if (adForm != null)
            {
                adForm.refeshData();
            }
        }

        private void uiButton_add_user_Click(object sender, EventArgs e)
        {
            admin_Dashboard1.Visible = false;
            adminAddUser1.Visible = true;
            adminAddCategories1.Visible = false;
            addminProduct1.Visible = false;
            cashierCustomerForm1.Visible = false;
            AdminAddUser userForm = adminAddUser1 as AdminAddUser;
            if (userForm != null)
            {
                userForm.refeshData();
            }
        }
        private void uiButton_add_categories_Click(object sender, EventArgs e)
        {
            admin_Dashboard1.Visible = false;
            adminAddUser1.Visible = false;
            adminAddCategories1.Visible = true;
            addminProduct1.Visible = false;
            cashierCustomerForm1.Visible = false;
            AdminAddCategories cateForm = adminAddCategories1 as AdminAddCategories;
            if (cateForm != null)
            {
                cateForm.refeshData();
            }
        }


        private void uiButton_add_product_Click(object sender, EventArgs e)
        {
            admin_Dashboard1.Visible = false;
            adminAddUser1.Visible = false;
            adminAddCategories1.Visible = false;
            addminProduct1.Visible = true;
            cashierCustomerForm1.Visible = false;

        }


        private void uiButton_customer_Click(object sender, EventArgs e)
        {
            admin_Dashboard1.Visible = false;
            adminAddUser1.Visible = false;
            adminAddCategories1.Visible = false;
            addminProduct1.Visible = false;
            cashierCustomerForm1.Visible = true;
            AdminAddUser userForm = adminAddUser1 as AdminAddUser;
            if (userForm != null)
            {
                userForm.refeshData();
            }
        }
    }
}

