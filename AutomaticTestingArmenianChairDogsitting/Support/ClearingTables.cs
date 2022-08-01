using System.Data.SqlClient;

namespace AutomaticTestingArmenianChairDogsitting.Support
{
    public class ClearingTables
    {
        public void AfterScenario()
        {
            string connectionString = @"";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.CommandText = "delete from dbo.[Animal]";
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

                command.CommandText = "delete from dbo.[Sitter]";
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
