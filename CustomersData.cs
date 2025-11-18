using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Manage_POS
{
    class CustomersData
    {
        private SqlConnection connect = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\manage_POS.mdf;Integrated Security=True;Connect Timeout=30");

        public int? CustomerId { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? Amount { get; set; }
        public decimal? ChangeAmount { get; set; }
        public DateTime? OrderDate { get; set; }

        // Lấy tất cả khách hàng
        public List<CustomersData> GetAllCustomers()
        {
            return GetCustomersByDate(null);
        }

        // Lấy khách hàng theo ngày (nếu null thì lấy tất cả)
        public List<CustomersData> GetCustomersByDate(DateTime? date)
        {
            List<CustomersData> listData = new List<CustomersData>();

            try
            {
                connect.Open();

                string selectData;
                if (date.HasValue)
                {
                    selectData = "SELECT customer_id, total_price, amount, change_amount, order_date " +
                                 "FROM customers WHERE order_date = @orderdate";
                }
                else
                {
                    selectData = "SELECT customer_id, total_price, amount, change_amount, order_date FROM customers";
                }

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    if (date.HasValue)
                        cmd.Parameters.AddWithValue("@orderdate", date.Value.Date);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomersData cData = new CustomersData
                            {
                                CustomerId = reader["customer_id"] != DBNull.Value ? (int?)Convert.ToInt32(reader["customer_id"]) : null,
                                TotalPrice = reader["total_price"] != DBNull.Value ? (decimal?)Convert.ToDecimal(reader["total_price"]) : null,
                                Amount = reader["amount"] != DBNull.Value ? (decimal?)Convert.ToDecimal(reader["amount"]) : null,
                                ChangeAmount = reader["change_amount"] != DBNull.Value ? (decimal?)Convert.ToDecimal(reader["change_amount"]) : null,
                                OrderDate = reader["order_date"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["order_date"]) : null
                            };

                            listData.Add(cData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu khách hàng: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }

            return listData;
        }

        // Phương thức tiện lợi lấy khách hàng hôm nay
        public List<CustomersData> GetCustomersToday()
        {
            return GetCustomersByDate(DateTime.Today);
        }
    }
}
