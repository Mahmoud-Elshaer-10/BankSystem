using A_DataAccess.Repositories;

namespace B_Business
{
    public class Account
    {
        public EntityMode Mode = EntityMode.AddNew;

        public AccountDTO ADTO => new AccountDTO(this.AccountID, this.ClientID, this.Balance, this.CreatedAt);

        public int AccountID { get; set; }
        public int ClientID { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }

        public Account(AccountDTO ADTO, EntityMode cMode = EntityMode.AddNew)
        {
            this.AccountID = ADTO.AccountID;
            this.ClientID = ADTO.ClientID;
            this.Balance = ADTO.Balance;
            this.CreatedAt = ADTO.CreatedAt;

            Mode = cMode;
        }

        private bool _AddNewAccount()
        {
            try
            {
                this.AccountID = AccountRepository.AddAccount(ADTO);
                return true; // Success if no exception is thrown
            }
            catch (Exception)
            {
                return false; // Failure if an exception occurs
            }
        }

        private bool _UpdateAccount()
        {
            return AccountRepository.UpdateAccount(ADTO);
        }

        public static List<AccountDTO> GetAllAccounts()
        {
            return AccountRepository.GetAllAccounts();
        }

        public static List<AccountDTO> GetAccountsByFilter(string field, string value)
        {
            return AccountRepository.GetAccountsByFilter(field, value);
        }

        public static List<AccountDTO> GetAccountsByClient(int clientId)
        {
            return AccountRepository.GetAccountsByClient(clientId);
        }

        public static AccountSummaryDTO GetAccountSummary()
        {
            return AccountRepository.GetAccountSummary();
        }

        public static Account Find(int accountID)
        {
            AccountDTO ADTO = AccountRepository.GetAccountByID(accountID);
            if (ADTO.AccountID != 0)
            {
                return new Account(ADTO, EntityMode.Update);
            }
            return new Account(new AccountDTO(0, 0, 0, DateTime.MinValue), EntityMode.AddNew);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case EntityMode.AddNew:
                    if (_AddNewAccount())
                    {
                        Mode = EntityMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case EntityMode.Update:
                    return _UpdateAccount();
            }
            return false;
        }

        public static bool DeleteAccount(int accountID)
        {
            return AccountRepository.DeleteAccount(accountID);
        }
    }
}