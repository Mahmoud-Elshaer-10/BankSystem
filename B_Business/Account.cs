using A_DataAccess.Repositories;

namespace B_Business
{
    public class Account : BaseEntity<AccountDTO>
    {
        public int AccountID { get; set; }
        public int ClientID { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }

        public Account(AccountDTO dto, EntityMode mode = EntityMode.AddNew)
        {
            AccountID = dto.AccountID;
            ClientID = dto.ClientID;
            Balance = dto.Balance;
            CreatedAt = dto.CreatedAt;
            Mode = mode;
        }

        public new bool Save()
        {
            return base.Save();
        }

        public override AccountDTO ToDTO()
        {
            return new AccountDTO(AccountID, ClientID, Balance, CreatedAt);
        }

        protected override bool AddNew()
        {
            AccountID = AccountRepository.AddAccount(ToDTO());
            return AccountID > 0;
        }

        protected override bool Update()
        {
            return AccountRepository.UpdateAccount(ToDTO());
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

        public static List<AccountDTO> GetAccountsPaged(int pageNumber, int rowsPerPage, string field = "", string value = "")
        {
            return AccountRepository.GetAccountsPaged(pageNumber, rowsPerPage, field, value);
        }

        public static int GetAccountsCount(string field = "", string value = "")
        {
            return AccountRepository.GetAccountsCount(field, value);
        }

        public static AccountSummaryDTO GetAccountSummary()
        {
            return AccountRepository.GetAccountSummary();
        }

        public static Account? Find(int accountID)
        {
            var dto = AccountRepository.GetAccountByID(accountID);
            return dto != null && dto.AccountID != 0
                ? new Account(dto, EntityMode.Update)
                : null;
        }

        public static bool DeleteAccount(int accountID)
        {
            return AccountRepository.DeleteAccount(accountID);
        }
    }
}