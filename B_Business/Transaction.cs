using A_DataAccess.Repositories;

namespace B_Business
{
    public class Transaction : BaseEntity<TransactionDTO>
    {
        public int TransactionID { get; set; }
        public int FromAccountID { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public int? ToAccountID { get; set; }
        public DateTime? TransactionDate { get; set; }

        public Transaction(TransactionDTO dto, EntityMode mode = EntityMode.AddNew)
        {
            TransactionID = dto.TransactionID;
            FromAccountID = dto.FromAccountID;
            TransactionType = dto.TransactionType;
            Amount = dto.Amount;
            ToAccountID = dto.ToAccountID;
            TransactionDate = dto.TransactionDate;
            Mode = mode;
        }

        public new bool Save()
        {
            return base.Save();
        }

        public override TransactionDTO ToDTO()
        {
            return new TransactionDTO(TransactionID, FromAccountID, TransactionType, Amount, ToAccountID, TransactionDate);
        }

        protected override bool AddNew()
        {
            TransactionID = TransactionRepository.AddTransaction(ToDTO());
            return TransactionID > 0;
        }

        protected override bool Update()
        {
            // Transactions are immutable; no update logic needed
            return false;
        }

        public static List<TransactionDTO> GetAllTransactions()
        {
            return TransactionRepository.GetAllTransactions();
        }

        public static List<TransactionDTO> GetTransactionsByFilter(string field, string value)
        {
            return TransactionRepository.GetTransactionsByFilter(field, value);
        }

        public static List<TransactionDTO> GetTransactionsPaged(int pageNumber, int rowsPerPage, string field = "", string value = "")
        {
            return TransactionRepository.GetTransactionsPaged(pageNumber, rowsPerPage, field, value);
        }

        public static int GetTransactionsCount(string field = "", string value = "")
        {
            return TransactionRepository.GetTransactionsCount(field, value);
        }

        public static int GetTransactionSummary()
        {
            return TransactionRepository.GetTransactionSummary();
        }

        public static List<TransactionDTO> GetTransactionsByAccount(int fromAccountID, string? field = null, string? value = null)
        {
            return TransactionRepository.GetTransactionsByAccount(fromAccountID, field, value);
        }

        public static Transaction? Find(int transactionID)
        {
            var dto = TransactionRepository.GetTransactionByID(transactionID);
            return dto != null && dto.TransactionID != 0
                ? new Transaction(dto, EntityMode.Update)
                : null;
        }

        public static bool DeleteTransaction(int transactionID)
        {
            return TransactionRepository.DeleteTransaction(transactionID);
        }
    }
}