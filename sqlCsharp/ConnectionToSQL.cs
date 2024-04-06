using Microsoft.Data.SqlClient;

namespace sqlCsharp
{
    public class ConnectionToSQL : IConnectionToSQL
    {
        public ConnectionToSQL(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Connection()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))

                try
                {
                    conn.Open();
                    Console.WriteLine("Connected successfully");
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                finally { conn.Close(); }
        }
        public string ConnectionString { get; }
    }
}
