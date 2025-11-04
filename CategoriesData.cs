using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace Manage_POS
{
   class CategoriesData
    {
        public int ID { get; set; }
        public string Category { get; set; }
        public string date { get; set; }
        public List<CategoriesData> AllcategoriesData()
        {
            List<CategoriesData> listData = new List<CategoriesData>();
            using (SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\manage_POS.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connect.Open();
                string selectData = "SELECT * FROM categories";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CategoriesData cData = new CategoriesData();
                       cData.ID = (int)reader["ID"];
                        cData.Category = reader["Category"].ToString();
                        cData.date = reader["date"].ToString();
                        listData.Add(cData);
                    }
                }
            }
            return listData;
        }
    }
}
