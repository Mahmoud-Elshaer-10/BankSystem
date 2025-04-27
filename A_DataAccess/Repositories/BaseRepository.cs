using Microsoft.Data.SqlClient;
using System.Data;

namespace A_DataAccess.Repositories
{
    public static class BaseRepository
    {
        public static List<T> ExecuteReader<T>(
            string procedureName,
            Func<SqlDataReader, T> mapper,
            params SqlParameter[] parameters)
        {
            var results = new List<T>();
            using var connection = DatabaseHelper.GetConnection();
            using var command = new SqlCommand(procedureName, connection) { CommandType = CommandType.StoredProcedure };
            if (parameters?.Length > 0) command.Parameters.AddRange(parameters);
            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                results.Add(mapper(reader));
            }
            return results;
        }

        public static T? ExecuteSingle<T>(
            string procedureName,
            Func<SqlDataReader, T> mapper,
            params SqlParameter[] parameters)
        {
            using var connection = DatabaseHelper.GetConnection();
            using var command = new SqlCommand(procedureName, connection) { CommandType = CommandType.StoredProcedure };
            if (parameters?.Length > 0) command.Parameters.AddRange(parameters);
            connection.Open();
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return mapper(reader);
            }
            return default;
        }

        public static int ExecuteScalar(
            string procedureName,
            params SqlParameter[] parameters)
        {
            using var connection = DatabaseHelper.GetConnection();
            using var command = new SqlCommand(procedureName, connection) { CommandType = CommandType.StoredProcedure };
            if (parameters?.Length > 0) command.Parameters.AddRange(parameters);
            connection.Open();
            var result = command.ExecuteScalar();
            return Convert.ToInt32(result);
        }

        // NOT USED > using ExecuteScalar instead for delete because SET NOCOUNT ON; is used in stored procedures, which prevents sending rows affected
        public static bool ExecuteNonQuery(
            string procedureName,
            params SqlParameter[] parameters)
        {
            using var connection = DatabaseHelper.GetConnection();
            using var command = new SqlCommand(procedureName, connection) { CommandType = CommandType.StoredProcedure };
            if (parameters?.Length > 0) command.Parameters.AddRange(parameters);
            connection.Open();
            var result = command.ExecuteNonQuery();
            return result > 0;
        }
    }
}