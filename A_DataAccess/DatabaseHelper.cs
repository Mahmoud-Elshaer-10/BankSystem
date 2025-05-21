using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace A_DataAccess
{
    public static class DatabaseHelper
    {
        //private static readonly string _connectionString = "Server=.;Database=BankSystem;User Id=sa;Password=123456;TrustServerCertificate=True;";
        private static string? _connectionString;

        public static void Configure(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("BankSystemDb");
        }

        public static SqlConnection GetConnection()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("DatabaseHelper not configured. Call Configure with IConfiguration.");
            }
            return new SqlConnection(_connectionString);
        }

        // Extension methods for SqlDataReader Object
        public static string? GetSafeString(this SqlDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);
            return reader.IsDBNull(index) ? null : reader.GetString(index);
        }

        public static int? GetSafeInt32(this SqlDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);
            return reader.IsDBNull(index) ? null : reader.GetInt32(index);
        }

        public static decimal? GetSafeDecimal(this SqlDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);
            return reader.IsDBNull(index) ? null : reader.GetDecimal(index);
        }

        public static DateTime? GetSafeDateTime(this SqlDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);
            return reader.IsDBNull(index) ? null : reader.GetDateTime(index);
        }

        public static bool? GetSafeBoolean(this SqlDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);
            return reader.IsDBNull(index) ? null : reader.GetBoolean(index);
        }

        public static double? GetSafeDouble(this SqlDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);
            return reader.IsDBNull(index) ? null : reader.GetDouble(index);
        }
    }
}