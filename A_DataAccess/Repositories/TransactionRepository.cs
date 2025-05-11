using Microsoft.Data.SqlClient;

namespace A_DataAccess.Repositories
{
    public static class TransactionRepository
    {
        public static int AddTransaction(TransactionDTO transaction)
        {
            return BaseRepository.ExecuteScalar(
                "AddTransaction",
                new SqlParameter("@FromAccountID", transaction.FromAccountID),
                new SqlParameter("@TransactionType", transaction.TransactionType),
                new SqlParameter("@Amount", transaction.Amount),
                new SqlParameter("@ToAccountID", transaction.ToAccountID ?? (object)DBNull.Value));
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
                    reader.IsDBNull(reader.GetOrdinal("ToAccountID")) ? null : reader.GetInt32(reader.GetOrdinal("ToAccountID")),
                    reader.GetDateTime(reader.GetOrdinal("TransactionDate"))),
                new SqlParameter("@FromAccountID", fromAccountID),
                new SqlParameter("@Field", field ?? (object)DBNull.Value),
                new SqlParameter("@Value", value ?? (object)DBNull.Value));
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