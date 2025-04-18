using System.Data;
using Microsoft.Data.SqlClient;

namespace A_DataAccess.Repositories
{
    public class AccountRepository
    {
        public static List<AccountDTO> GetAllAccounts()
        {
            List<AccountDTO> accounts = new List<AccountDTO>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand("GetAllAccounts", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        accounts.Add(new AccountDTO(
                            reader.GetInt32(reader.GetOrdinal("AccountID")),
                            reader.GetInt32(reader.GetOrdinal("ClientID")),
                            reader.GetDecimal(reader.GetOrdinal("Balance")),
                            reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                        ));
                    }
                }
            }
            return accounts;
        }

        public static List<AccountDTO> GetAccountsByFilter(string field, string value)
        {
            List<AccountDTO> accounts = new List<AccountDTO>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand("GetAccountsByFilter", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Field", field);
                cmd.Parameters.AddWithValue("@Value", value ?? ""); // Handle null value
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        accounts.Add(new AccountDTO(
                            reader.GetInt32(reader.GetOrdinal("AccountID")),
                            reader.GetInt32(reader.GetOrdinal("ClientID")),
                            reader.GetDecimal(reader.GetOrdinal("Balance")),
                            reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                        ));
                    }
                }
            }
            return accounts;
        }

        public static AccountDTO GetAccountByID(int accountID)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand("GetAccountByID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountID", accountID);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new AccountDTO(
                            reader.GetInt32(reader.GetOrdinal("AccountID")),
                            reader.GetInt32(reader.GetOrdinal("ClientID")),
                            reader.GetDecimal(reader.GetOrdinal("Balance")),
                            reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                        );
                    }
                }
            }
            return new AccountDTO(0, 0, 0, DateTime.MinValue);
        }

        public static List<AccountDTO> GetAccountsByClient(int clientID)
        {
            List<AccountDTO> accounts = new List<AccountDTO>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand("GetAccountsByClient", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientID", clientID);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        accounts.Add(new AccountDTO(
                            reader.GetInt32(reader.GetOrdinal("AccountID")),
                            reader.GetInt32(reader.GetOrdinal("ClientID")),
                            reader.GetDecimal(reader.GetOrdinal("Balance")),
                            reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                        ));
                    }
                }
            }
            return accounts;
        }

        public static int AddAccount(AccountDTO account)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand("AddAccount", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientID", account.ClientID);
                cmd.Parameters.AddWithValue("@Balance", account.Balance);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static bool UpdateAccount(AccountDTO account)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand("UpdateAccount", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountID", account.AccountID);
                cmd.Parameters.AddWithValue("@ClientID", account.ClientID);
                cmd.Parameters.AddWithValue("@Balance", account.Balance);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null && result != DBNull.Value; // True if row updated
            }
        }

        public static bool DeleteAccount(int accountID)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand("DeleteAccount", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountID", accountID);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null && result != DBNull.Value; // True if row deleted
            }
        }

        public static AccountSummaryDTO GetAccountSummary()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand("GetAccountSummary", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new AccountSummaryDTO(
                            reader.GetInt32(reader.GetOrdinal("TotalAccounts")),
                            reader.IsDBNull(reader.GetOrdinal("AverageBalance")) ? 0 : reader.GetDecimal(reader.GetOrdinal("AverageBalance")),
                            reader.IsDBNull(reader.GetOrdinal("TotalBalance")) ? 0 : reader.GetDecimal(reader.GetOrdinal("TotalBalance"))
                        );
                    }
                }
            }
            return new AccountSummaryDTO(0, 0, 0);
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