
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglAdyn
{
    public class Database
    {
        private static Database instance;
        private string connectionString;

        private Database()
        {

            this.connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        }

        public static Database Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Database();
                }
                return instance;
            }
        }


        public void ExecuteQuery(string query)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

    }



}
