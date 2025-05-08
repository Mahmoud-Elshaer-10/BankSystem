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

        public static List<TransactionDTO> GetTransactionsByAccount(int fromAccountID, string field = null, string value = null)
        {
            return TransactionRepository.GetTransactionsByAccount(fromAccountID, field, value);
        }
    }
}