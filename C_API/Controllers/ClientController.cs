using Microsoft.AspNetCore.Mvc;
using A_DataAccess.Repositories;
using B_Business;

namespace C_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        [HttpGet("All", Name = "GetAllClients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ClientDTO>> GetAllClients()
        {
            var clients = Client.GetAllClients();
            if (clients.Count == 0)
            {
                return NotFound("No Clients Found!");
            }
            return Ok(clients);
        }

        [HttpGet("Filter", Name = "GetClientsByFilter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ClientDTO>> GetClientsByFilter([FromQuery] string field, [FromQuery] string value)
        {
            if (string.IsNullOrEmpty(field) || string.IsNullOrEmpty(value))
            {
                return BadRequest("Field and value are required for filtering.");
            }

            var clients = Client.GetClientsByFilter(field, value);
            if (clients == null || clients.Count == 0)
            {
                return NotFound($"No clients found for {field} matching '{value}'.");
            }
            return Ok(clients);
        }

        [HttpGet("Summary", Name = "GetClientSummary")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<object> GetClientSummary()
        {
            var totalClients = Client.GetClientSummary();
            var summary = new { totalClients };
            return Ok(summary);
        }

        [HttpGet("{id}", Name = "GetClientById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ClientDTO> GetClientById(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

            Client Client = Client.Find(id);

            if (Client == null)
            {
                return NotFound($"Client with ID {id} not found.");
            }

            ClientDTO CDTO = Client.ToDTO();
            return Ok(CDTO);
        }

        [HttpPost(Name = "AddClient")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ClientDTO> AddClient(ClientDTO newClientDTO)
        {
            //we validate the data here
            if (newClientDTO == null || string.IsNullOrEmpty(newClientDTO.FullName) || string.IsNullOrEmpty(newClientDTO.Email) || string.IsNullOrEmpty(newClientDTO.Phone) || string.IsNullOrEmpty(newClientDTO.Address))
            {
                return BadRequest("Invalid client data.");
            }
            Client client = new Client(new ClientDTO(newClientDTO.ClientID, newClientDTO.FullName, newClientDTO.Email, newClientDTO.Phone, newClientDTO.Address, newClientDTO.CreatedAt));
            client.Save();
            newClientDTO.ClientID = client.ClientID;
            return CreatedAtRoute("GetClientById", new { id = newClientDTO.ClientID }, newClientDTO);
        }

        [HttpPut("{id}", Name = "UpdateClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ClientDTO> UpdateClient(int id, ClientDTO updatedClient)
        {
            if (id < 1 || updatedClient == null || string.IsNullOrEmpty(updatedClient.FullName) || string.IsNullOrEmpty(updatedClient.Email) || string.IsNullOrEmpty(updatedClient.Phone) || string.IsNullOrEmpty(updatedClient.Address))
            {
                return BadRequest("Invalid Client data.");
            }

            Client Client = Client.Find(id);

            if (Client == null)
            {
                return NotFound($"Client with ID {id} not found.");
            }

            Client.FullName = updatedClient.FullName;
            Client.Email = updatedClient.Email;
            Client.Phone = updatedClient.Phone;
            Client.Address = updatedClient.Address;

            if (Client.Save())
                return Ok(Client.ToDTO());
            else
                return StatusCode(500, new { message = "Error Updating Client" });
        }

        [HttpDelete("{id}", Name = "DeleteClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteClient(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

            if (Client.DeleteClient(id))
                return Ok($"Client with ID {id} has been deleted.");
            else
                return NotFound($"Client with ID {id} not found. no rows deleted!");
        }
    }
}