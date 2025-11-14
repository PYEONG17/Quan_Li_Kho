using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Manage_POS
{
    class AddProductData
    {
        public int ID { set; get; }
        public string ProductID { set; get; }
        public string ProductName { set; get; }
        public string Category { set; get; }
        public string Price { set; get; }
        public string Stock { set; get; }
        public string ImagePath { set; get; }

        public string Status { set; get; }
        public string Date { set; get; }

        public List<AddProductData> AllProductData()
        {
            List<AddProductData> listData = new List<AddProductData>();
            using (SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\manage_POS.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connect.Open();
                string selectData = "SELECT * FROM products";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        AddProductData apData = new AddProductData();
                        apData.ID = (int)reader["id"];
                        apData.ProductID = reader["product_id"].ToString();
                        apData.ProductName = reader["product_name"].ToString();
                        apData.Category = reader["category"].ToString();
                        apData.Price = reader["price"].ToString();
                        apData.Stock = reader["stock"].ToString();
                        apData.ImagePath = reader["img_path"].ToString();
                        apData.Status = reader["status"].ToString();
                        apData.Date = reader["date_insert"].ToString();
                        listData.Add(apData);
                    }
                }
            }
            return listData;
        }
        public List<AddProductData>allAvailabelProducts()
        {
            List<AddProductData> listData = new List<AddProductData>();
            using (SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\manage_POS.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connect.Open();
                string selectData = "SELECT * FROM products WHERE status=@status";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    cmd.Parameters.AddWithValue("@status", "Available");
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        AddProductData apData = new AddProductData();
                        apData.ID = (int)reader["id"];
                        apData.ProductID = reader["product_id"].ToString();
                        apData.ProductName = reader["product_name"].ToString();
                        apData.Category = reader["category"].ToString();
                        apData.Price = reader["price"].ToString();
                        apData.Stock = reader["stock"].ToString();
                        apData.ImagePath = reader["img_path"].ToString();
                        apData.Status = reader["status"].ToString();
                        apData.Date = reader["date_insert"].ToString();
                        listData.Add(apData);
                    }
                }
            }
            return listData;
        }
    }
}
