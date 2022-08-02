using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticTestingArmenianChairDogsitting.DBController
{
    public class ClearBase
    {
        public void ClearAllBase()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ServerSettings._connectionString))
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "";
                cmd.Connection = sqlConnection;
                var i = cmd.ExecuteNonQuery();

            }
        }
    }
}
