using Microsoft.Data.SqlClient;

namespace A_DataAccess
{
    public static class DatabaseHelper
    {
        private static readonly string _connectionString = "Server=.;Database=BankSystem;User Id=sa;Password=123456;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        // Extension method for SqlDataReader Object
        public static string? GetSafeString(this SqlDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);
            return reader.IsDBNull(index) ? null : reader.GetString(index);
        }
    }
}
