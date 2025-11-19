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
    public partial class CashierCustomerForm : UserControl
    {
        public CashierCustomerForm()
        {
            InitializeComponent();
            DisplayTodayCustomers();
        }
        public void refeshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refeshData);
                return;

            }
            // Load UI

            DisplayTodayCustomers();
        }
        public void DisplayTodayCustomers()
        {
            try
            {
                CustomersData cData = new CustomersData();
                List<CustomersData> listToday = cData.GetCustomersToday();

                DataTable dt = new DataTable();
                dt.Columns.Add("Customer ID");
                dt.Columns.Add("Total Price");
                dt.Columns.Add("Amount");
                dt.Columns.Add("Change");
                dt.Columns.Add("Order Date");

                foreach (var c in listToday)
                {
                    dt.Rows.Add(
                        c.CustomerId.HasValue ? c.CustomerId.Value.ToString() : "",
                        c.TotalPrice.HasValue ? c.TotalPrice.Value.ToString("0.00") : "",
                        c.Amount.HasValue ? c.Amount.Value.ToString("0.00") : "",
                        c.ChangeAmount.HasValue ? c.ChangeAmount.Value.ToString("0.00") : "",
                        c.OrderDate.HasValue ? c.OrderDate.Value.ToString("yyyy-MM-dd") : ""
                    );
                }

                dataGridView_Product.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load khách hôm nay: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
