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
            using (SqlConnection sqlConnection = new SqlConnection("Data Source=80.78.240.16;Initial Catalog = ArmenianChairDogsitting.DB;Persist Security Info=True;User ID = student;Password=qwe!23;"))
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandText = "delete from dbo.[Sitter]";
                var i = cmd.ExecuteNonQuery();
                sqlConnection.Close();

            }
        }
    }
}
