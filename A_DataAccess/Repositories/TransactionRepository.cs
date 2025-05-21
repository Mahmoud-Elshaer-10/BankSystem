using Microsoft.Data.SqlClient;

namespace A_DataAccess.Repositories
{
    public static class TransactionRepository
    {
        public static List<TransactionDTO> GetAllTransactions()
        {
            return BaseRepository.ExecuteReader(
                "GetAllTransactions",
                reader => new TransactionDTO(
                    reader.GetInt32(reader.GetOrdinal("TransactionID")),
                    reader.GetInt32(reader.GetOrdinal("FromAccountID")),
                    reader.GetString(reader.GetOrdinal("TransactionType")),
                    reader.GetDecimal(reader.GetOrdinal("Amount")),
                    reader.GetSafeInt32("ToAccountID"),
                    reader.GetSafeDateTime("TransactionDate")));
        }

        public static List<TransactionDTO> GetTransactionsByFilter(string field, string value)
        {
            return BaseRepository.ExecuteReader(
                "GetTransactionsByFilter",
                reader => new TransactionDTO(
                    reader.GetInt32(reader.GetOrdinal("TransactionID")),
                    reader.GetInt32(reader.GetOrdinal("FromAccountID")),
                    reader.GetString(reader.GetOrdinal("TransactionType")),
                    reader.GetDecimal(reader.GetOrdinal("Amount")),
                    reader.GetSafeInt32("ToAccountID"),
                    reader.GetSafeDateTime("TransactionDate")),
                new SqlParameter("@Field", field),
                new SqlParameter("@Value", value ?? ""));
        }

        public static List<TransactionDTO> GetTransactionsPaged(int pageNumber, int rowsPerPage, string field = "", string value = "")
        {
            return BaseRepository.ExecuteReader(
                "GetTransactionsPaged",
                reader => new TransactionDTO(
                    reader.GetInt32(reader.GetOrdinal("TransactionID")),
                    reader.GetInt32(reader.GetOrdinal("FromAccountID")),
                    reader.GetString(reader.GetOrdinal("TransactionType")),
                    reader.GetDecimal(reader.GetOrdinal("Amount")),
                    reader.GetSafeInt32("ToAccountID"),
                    reader.GetSafeDateTime("TransactionDate")),
                new SqlParameter("@PageNumber", pageNumber),
                new SqlParameter("@RowsPerPage", rowsPerPage),
                new SqlParameter("@Field", field),
                new SqlParameter("@Value", value));
        }

        public static int GetTransactionsCount(string field = "", string value = "")
        {
            return BaseRepository.ExecuteScalar(
                "GetTransactionsCount",
                new SqlParameter("@Field", field),
                new SqlParameter("@Value", value));
        }

        public static TransactionDTO? GetTransactionByID(int transactionID)
        {
            return BaseRepository.ExecuteSingle(
                "GetTransactionByID",
                reader => new TransactionDTO(
                    reader.GetInt32(reader.GetOrdinal("TransactionID")),
                    reader.GetInt32(reader.GetOrdinal("FromAccountID")),
                    reader.GetString(reader.GetOrdinal("TransactionType")),
                    reader.GetDecimal(reader.GetOrdinal("Amount")),
                    reader.GetSafeInt32("ToAccountID"),
                    reader.GetSafeDateTime("TransactionDate")),
                new SqlParameter("@TransactionID", transactionID));
        }

        public static List<TransactionDTO> GetTransactionsByAccount(int fromAccountID, string? field = null, string? value = null)
        {
            return BaseRepository.ExecuteReader(
                "GetTransactionsByAccountFiltered",
                reader => new TransactionDTO(
                    reader.GetInt32(reader.GetOrdinal("TransactionID")),
                    reader.GetInt32(reader.GetOrdinal("FromAccountID")),
                    reader.GetString(reader.GetOrdinal("TransactionType")),
                    reader.GetDecimal(reader.GetOrdinal("Amount")),
                    reader.GetSafeInt32("ToAccountID"),
                    reader.GetSafeDateTime("TransactionDate")),
                new SqlParameter("@FromAccountID", fromAccountID),
                new SqlParameter("@Field", field ?? (object)DBNull.Value),
                new SqlParameter("@Value", value ?? (object)DBNull.Value));
        }

        public static int AddTransaction(TransactionDTO transaction)
        {
            return BaseRepository.ExecuteScalar(
                "AddTransaction",
                new SqlParameter("@FromAccountID", transaction.FromAccountID),
                new SqlParameter("@TransactionType", transaction.TransactionType),
                new SqlParameter("@Amount", transaction.Amount),
                new SqlParameter("@ToAccountID", transaction.ToAccountID ?? (object)DBNull.Value));
        }

        public static bool DeleteTransaction(int transactionID)
        {
            return BaseRepository.ExecuteScalar(
                "DeleteTransaction",
                new SqlParameter("@TransactionID", transactionID)) > 0;
        }

        public static int GetTransactionSummary()
        {
            return BaseRepository.ExecuteScalar("GetTransactionSummary");
        }
    }

    public class TransactionDTO(int transactionID, int fromAccountID, string transactionType, decimal amount, int? toAccountID, DateTime? transactionDate)
    {
        public int TransactionID { get; set; } = transactionID;
        public int FromAccountID { get; set; } = fromAccountID;
        public string TransactionType { get; set; } = transactionType;
        public decimal Amount { get; set; } = amount;
        public int? ToAccountID { get; set; } = toAccountID;
        public DateTime? TransactionDate { get; set; } = transactionDate;
    }
}