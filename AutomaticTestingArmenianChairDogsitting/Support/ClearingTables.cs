using System.Data.SqlClient;

namespace AutomaticTestingArmenianChairDogsitting.Support
{
    public class ClearingTables
    {
        public void ClearAllDB()
        {
            string connectionString = Options.connectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.CommandText = "delete from dbo.[Animal]";
                command.Connection = connection;
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[AnimalOrder]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Client]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Comment]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Order]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[PriceCatalog]";
                command.ExecuteNonQuery();
                
                command.CommandText = "delete from dbo.[Schedule]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Sitter]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[District]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[DistrictSitter]";
                command.ExecuteNonQuery();

                command.CommandText = "delete from dbo.[Promocode]";
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
