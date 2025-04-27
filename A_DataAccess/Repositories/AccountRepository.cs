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
                    reader.IsDBNull(reader.GetOrdinal("AverageBalance")) ? 0 : reader.GetDecimal(reader.GetOrdinal("AverageBalance")),
                    reader.IsDBNull(reader.GetOrdinal("TotalBalance")) ? 0 : reader.GetDecimal(reader.GetOrdinal("TotalBalance")))
                ) ?? new AccountSummaryDTO(0, 0, 0);
        }
    }

    public class AccountDTO
    {
        public AccountDTO(int accountID, int clientID, decimal balance, DateTime createdAt)
        {
            AccountID = accountID;
            ClientID = clientID;
            Balance = balance;
            CreatedAt = createdAt;
        }

        public int AccountID { get; set; }
        public int ClientID { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class AccountSummaryDTO
    {
        public AccountSummaryDTO(int totalAccounts, decimal averageBalance, decimal totalBalance)
        {
            TotalAccounts = totalAccounts;
            AverageBalance = averageBalance;
            TotalBalance = totalBalance;
        }

        public int TotalAccounts { get; set; }
        public decimal AverageBalance { get; set; }
        public decimal TotalBalance { get; set; }
    }
}