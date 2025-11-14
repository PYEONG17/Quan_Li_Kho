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

namespace Manage_POS
{
    public partial class CashierOrder : UserControl
    {
        public CashierOrder()
        {
            InitializeComponent();
            displayAllAvalabelProducts();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        public void displayAllAvalabelProducts()
        {
            AddProductData apData = new AddProductData();
            List<AddProductData> listData = apData.allAvailabelProducts();
            dataGridView1.Rows.Clear();
        }
    }
}
