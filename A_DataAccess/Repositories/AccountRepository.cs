using Microsoft.Data.SqlClient;

namespace A_DataAccess.Repositories
{
    public static class AccountRepository
    {
        public static List<AccountDTO> GetAllAccounts()
        {
            return BaseRepository.ExecuteReader(
                "GetAllAccounts",
                reader => new AccountDTO(
                    reader.GetInt32(reader.GetOrdinal("AccountID")),
                    reader.GetInt32(reader.GetOrdinal("ClientID")),
                    reader.GetDecimal(reader.GetOrdinal("Balance")),
                    reader.GetDateTime(reader.GetOrdinal("CreatedAt"))));
        }

        public static List<AccountDTO> GetAccountsByFilter(string field, string value)
        {
            return BaseRepository.ExecuteReader(
                "GetAccountsByFilter",
                reader => new AccountDTO(
                    reader.GetInt32(reader.GetOrdinal("AccountID")),
                    reader.GetInt32(reader.GetOrdinal("ClientID")),
                    reader.GetDecimal(reader.GetOrdinal("Balance")),
                    reader.GetDateTime(reader.GetOrdinal("CreatedAt"))),
                new SqlParameter("@Field", field),
                new SqlParameter("@Value", value ?? ""));
        }

        public static List<AccountDTO> GetAccountsPaged(int pageNumber, int rowsPerPage, string field = "", string value = "")
        {
            return BaseRepository.ExecuteReader(
                "GetAccountsPaged",
                reader => new AccountDTO(
                    reader.GetInt32(reader.GetOrdinal("AccountID")),
                    reader.GetInt32(reader.GetOrdinal("ClientID")),
                    reader.GetDecimal(reader.GetOrdinal("Balance")),
                    reader.GetDateTime(reader.GetOrdinal("CreatedAt"))),
                new SqlParameter("@PageNumber", pageNumber),
                new SqlParameter("@RowsPerPage", rowsPerPage),
                new SqlParameter("@Field", field),
                new SqlParameter("@Value", value));
        }

        public static int GetAccountsCount(string field = "", string value = "")
        {
            return BaseRepository.ExecuteScalar(
                "GetAccountsCount",
                new SqlParameter("@Field", field),
                new SqlParameter("@Value", value));
        }

        public static AccountDTO? GetAccountByID(int accountID)
        {
            return BaseRepository.ExecuteSingle(
                "GetAccountByID",
                reader => new AccountDTO(
                    reader.GetInt32(reader.GetOrdinal("AccountID")),
                    reader.GetInt32(reader.GetOrdinal("ClientID")),
                    reader.GetDecimal(reader.GetOrdinal("Balance")),
                    reader.GetDateTime(reader.GetOrdinal("CreatedAt"))),
                new SqlParameter("@AccountID", accountID));
        }

        public static List<AccountDTO> GetAccountsByClient(int clientID)
        {
            return BaseRepository.ExecuteReader(
                "GetAccountsByClient",
                reader => new AccountDTO(
                    reader.GetInt32(reader.GetOrdinal("AccountID")),
                    reader.GetInt32(reader.GetOrdinal("ClientID")),
                    reader.GetDecimal(reader.GetOrdinal("Balance")),
                    reader.GetDateTime(reader.GetOrdinal("CreatedAt"))),
                new SqlParameter("@ClientID", clientID));
        }

        public static int AddAccount(AccountDTO account)
        {
            return BaseRepository.ExecuteScalar(
                "AddAccount",
                new SqlParameter("@ClientID", account.ClientID),
                new SqlParameter("@Balance", account.Balance));
        }

        public static bool UpdateAccount(AccountDTO account)
        {
            return BaseRepository.ExecuteScalar(
                "UpdateAccount",
                new SqlParameter("@AccountID", account.AccountID),
                new SqlParameter("@ClientID", account.ClientID),
                new SqlParameter("@Balance", account.Balance)) > 0;
        }

        public static bool DeleteAccount(int accountID)
        {
            return BaseRepository.ExecuteScalar(
                "DeleteAccount",
                new SqlParameter("@AccountID", accountID)) > 0;
        }

        public static AccountSummaryDTO GetAccountSummary()
        {
            return BaseRepository.ExecuteSingle(
                "GetAccountSummary",
                reader => new AccountSummaryDTO(
                    reader.GetInt32(reader.GetOrdinal("TotalAccounts")),
                    reader.GetSafeDecimal("AverageBalance") ?? 0,
                    reader.GetSafeDecimal("TotalBalance") ?? 0)
                ) ?? new AccountSummaryDTO(0, 0, 0);
        }
    }

    public class AccountDTO(int accountID, int clientID, decimal balance, DateTime createdAt)
    {
        public int AccountID { get; set; } = accountID;
        public int ClientID { get; set; } = clientID;
        public decimal Balance { get; set; } = balance;
        public DateTime CreatedAt { get; set; } = createdAt;
    }

    public class AccountSummaryDTO(int totalAccounts, decimal averageBalance, decimal totalBalance)
    {
        public int TotalAccounts { get; set; } = totalAccounts;
        public decimal AverageBalance { get; set; } = averageBalance;
        public decimal TotalBalance { get; set; } = totalBalance;
    }
}