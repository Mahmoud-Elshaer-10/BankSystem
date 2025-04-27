using Microsoft.AspNetCore.Mvc;
using A_DataAccess.Repositories;
using B_Business;

namespace C_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllAccounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<AccountDTO>> GetAllAccounts()
        {
            var accounts = Account.GetAllAccounts();
            if (accounts.Count == 0)
            {
                return NotFound("No Accounts Found!");
            }
            return Ok(accounts);
        }

        [HttpGet("Filter", Name = "GetAccountsByFilter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<AccountDTO>> GetAccountsByFilter([FromQuery] string field, [FromQuery] string value)
        {
            if (string.IsNullOrEmpty(field) || string.IsNullOrEmpty(value))
            {
                return BadRequest("Field and value are required for filtering.");
            }

            var accounts = Account.GetAccountsByFilter(field, value);
            if (accounts == null || accounts.Count == 0)
            {
                return NotFound($"No accounts found for {field} matching '{value}'.");
            }
            return Ok(accounts);
        }

        [HttpGet("Summary", Name = "GetAccountSummary")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<object> GetAccountSummary()
        {
            var summary = Account.GetAccountSummary();
            return Ok(new
            {
                totalAccounts = summary.TotalAccounts,
                averageBalance = summary.AverageBalance,
                totalBalance = summary.TotalBalance
            });
        }

        [HttpGet("ByClient/{clientId}", Name = "GetAccountsByClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<AccountDTO>> GetAccountsByClient(int clientId)
        {
            if (clientId < 1)
            {
                return BadRequest($"Not accepted ID {clientId}");
            }

            var accounts = Account.GetAccountsByClient(clientId);

            if (accounts == null || accounts.Count == 0)
            {
                return NotFound($"No accounts found for ClientID {clientId}.");
            }

            return Ok(accounts);
        }

        [HttpGet("{id}", Name = "GetAccountById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AccountDTO> GetAccountById(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

            Account account = Account.Find(id);

            if (account == null)
            {
                return NotFound($"Account with ID {id} not found.");
            }

            return Ok(account.ToDTO());
        }

        [HttpPost(Name = "AddAccount")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AccountDTO> AddAccount(AccountDTO newAccountDTO)
        {
            if (newAccountDTO == null || newAccountDTO.ClientID < 1 || newAccountDTO.Balance < 0)
            {
                return BadRequest("Invalid account data.");
            }

            Account account = new Account(new AccountDTO(0, newAccountDTO.ClientID, newAccountDTO.Balance, DateTime.Now));
            account.Save();
            newAccountDTO.AccountID = account.AccountID;

            return CreatedAtRoute("GetAccountById", new { id = newAccountDTO.AccountID }, newAccountDTO);
        }

        [HttpPut("{id}", Name = "UpdateAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AccountDTO> UpdateAccount(int id, AccountDTO updatedAccount)
        {
            if (id < 1 || updatedAccount == null || updatedAccount.ClientID < 1 || updatedAccount.Balance < 0)
            {
                return BadRequest("Invalid account data.");
            }

            Account account = Account.Find(id);
            if (account == null)
            {
                return NotFound($"Account with ID {id} not found.");
            }

            account.ClientID = updatedAccount.ClientID;
            account.Balance = updatedAccount.Balance;

            if (account.Save())
                return Ok(account.ToDTO());
            else
                return StatusCode(500, new { message = "Error Updating Account" });
        }

        [HttpDelete("{id}", Name = "DeleteAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteAccount(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

            if (Account.DeleteAccount(id))
                return Ok($"Account with ID {id} has been deleted.");
            else
                return NotFound($"Account with ID {id} not found. No rows deleted!");
        }
    }
}