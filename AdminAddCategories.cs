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
            CategoriesData  cData= new CategoriesData();
            List<CategoriesData> listData = new CategoriesData().AllcategoriesData();
            dataGridView_categories.DataSource=listData;

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
                       string checkCategory= "SELECT * FROM categories WHERE Category=@category";
                        using (SqlCommand cmd=new SqlCommand(checkCategory,connect))
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
                                    insertCmd.Parameters.AddWithValue("@date", DateTime.Now);
                                    insertCmd.ExecuteNonQuery();
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
    }
}
