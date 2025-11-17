using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Manage_POS
{
    class OrderData
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\manage_POS.mdf;Integrated Security=True;Connect Timeout=30";

        // Các thuộc tính (tên nhất quán với DB và các chỗ khác)
        public int customer_id { get; set; }
        public string product_id { get; set; }
        public string product_name { get; set; }
        public string category { get; set; }
        public decimal origin_price { get; set; }
        public int quality { get; set; }
        public decimal total_price { get; set; }
        public DateTime order_date { get; set; }

        // Trả về tất cả orders từ bảng orders
        public List<OrderData> allOrderData()
        {
            List<OrderData> listData = new List<OrderData>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Lấy toàn bộ dữ liệu từ bảng orders
                    string selectSql = "SELECT customer_id, product_id, product_name, category, quality, origin_price, total_price, order_date FROM orders ORDER BY id ASC";
                    using (SqlCommand cmd = new SqlCommand(selectSql, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrderData data = new OrderData();

                            // Gán giá trị an toàn, kiểm tra DBNull
                            data.customer_id = reader["customer_id"] != DBNull.Value ? Convert.ToInt32(reader["customer_id"]) : 0;
                            data.product_id = reader["product_id"] != DBNull.Value ? reader["product_id"].ToString() : "";
                            data.product_name = reader["product_name"] != DBNull.Value ? reader["product_name"].ToString() : "";
                            data.category = reader["category"] != DBNull.Value ? reader["category"].ToString() : "";

                            if (reader["origin_price"] != DBNull.Value)
                                data.origin_price = Convert.ToDecimal(reader["origin_price"]);
                            else
                                data.origin_price = 0m;

                            if (reader["quality"] != DBNull.Value)
                                data.quality = Convert.ToInt32(reader["quality"]);
                            else
                                data.quality = 0;

                            if (reader["total_price"] != DBNull.Value)
                                data.total_price = Convert.ToDecimal(reader["total_price"]);
                            else
                                data.total_price = 0m;

                            if (reader["order_date"] != DBNull.Value)
                                data.order_date = Convert.ToDateTime(reader["order_date"]);
                            else
                                data.order_date = DateTime.MinValue;

                            listData.Add(data);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi load orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return listData;
        }
    }
}
