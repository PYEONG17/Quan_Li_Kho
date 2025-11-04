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
    class UserData
    {
        private SqlConnection connect;

        public UserData(SqlConnection connect)
        {
            this.connect = connect;
        }
        // Add a parameterless constructor to fix CS7036
        public UserData()
        {
        }

        public int id { set; get; }
        public string username { set; get; }
        public string password { set; get; }
        public string role { set; get; }
        public string status { set; get; }
        public string date { set; get; }

        public List<UserData> AllUserData()
        { 
            List<UserData> users = new List<UserData>();
            using(SqlConnection connect= new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\manage_POS.mdf;Integrated Security=True;Connect Timeout=30"))
            {
              connect.Open();
              string selectData="SELECT * FROM users";
              using (SqlCommand cmd = new SqlCommand(selectData, connect))
                { 
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        UserData user = new UserData();
                        user.id = (int)reader["id"];
                        user.username = reader["username"].ToString();
                        user.password = reader["password"].ToString();
                        user.role = reader["role"].ToString();
                        user.status = reader["status"].ToString();
                        user.date = reader["date"].ToString();
                        users.Add(user);
                    }
                }
            }
            return users;
        }
    }
}
