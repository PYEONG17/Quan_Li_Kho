using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manage_POS
{
    public partial class CashierMainForm : Form
    {
        public CashierMainForm()
        {
            InitializeComponent();
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

        private void cashierOrder1_Load(object sender, EventArgs e)
        {

        }

        private void cashierOrder1_Load_1(object sender, EventArgs e)
        {

        }

        private void uiButton_add_product_Click(object sender, EventArgs e)
        {
            admin_Dashboard1.Visible = false;
            addminProduct1.Visible = true;
            cashierCustomerForm1.Visible = false;
            cashierOrder1.Visible = false;
        }

        private void uiButton_dashboard_Click(object sender, EventArgs e)
        {
            admin_Dashboard1.Visible = true;
            addminProduct1.Visible = false;
            cashierCustomerForm1.Visible = false;
            cashierOrder1.Visible = false;

        }

        private void uiButton_customer_Click(object sender, EventArgs e)
        {
            admin_Dashboard1.Visible = false;
            addminProduct1.Visible = false;
            cashierCustomerForm1.Visible = true;
            cashierOrder1.Visible = false;
        }

        private void dashboard_button_order_Click(object sender, EventArgs e)
        {
            admin_Dashboard1.Visible = false;
            addminProduct1.Visible = false;
            cashierCustomerForm1.Visible = false;
            cashierOrder1.Visible = true;
        }
    }
}
