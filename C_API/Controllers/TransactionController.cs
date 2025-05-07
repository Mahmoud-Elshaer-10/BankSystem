using Microsoft.AspNetCore.Mvc;
using A_DataAccess.Repositories;
using B_Business;

namespace C_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        [HttpGet("ByAccount/{fromAccountId}", Name = "GetTransactionsByAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<TransactionDTO>> GetTransactionsByAccount(int fromAccountId)
        {
            if (fromAccountId < 1)
            {
                return BadRequest($"Invalid account ID {fromAccountId}");
            }

            var transactions = Transaction.GetTransactionsByAccount(fromAccountId);
            if (transactions == null || transactions.Count == 0)
            {
                return NotFound($"No transactions found for AccountID {fromAccountId}.");
            }

            return Ok(transactions);
        }

        [HttpPost(Name = "AddTransaction")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TransactionDTO> AddTransaction(TransactionDTO newTransactionDTO)
        {
            if (newTransactionDTO == null ||
                newTransactionDTO.FromAccountID < 1 ||
                string.IsNullOrEmpty(newTransactionDTO.TransactionType) ||
                newTransactionDTO.Amount <= 0 ||
                (newTransactionDTO.TransactionType == "Transfer" && newTransactionDTO.ToAccountID < 1))
            {
                return BadRequest("Invalid transaction data.");
            }

            var transaction = new Transaction(new TransactionDTO(
                0,
                newTransactionDTO.FromAccountID,
                newTransactionDTO.TransactionType,
                newTransactionDTO.Amount,
                newTransactionDTO.ToAccountID,
                null));

            if (!transaction.Save())
            {
                return StatusCode(500, new { message = "Error creating transaction" });
            }

            newTransactionDTO.TransactionID = transaction.TransactionID;
            newTransactionDTO.TransactionDate = transaction.TransactionDate;

            return CreatedAtRoute("GetTransactionsByAccount",
                new { fromAccountId = newTransactionDTO.FromAccountID },
                newTransactionDTO);
        }
    }
}