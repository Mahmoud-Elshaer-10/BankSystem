using Microsoft.AspNetCore.Mvc;
using A_DataAccess.Repositories;
using B_Business;
using C_API.Models;

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
            if (clients == null || !clients.Any())
                return NotFound("No Clients Found!");
            return Ok(clients);
        }

        [HttpGet("paged", Name = "GetClientsPaged")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PagedResult<ClientDTO>> GetClientsPaged(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int rowsPerPage = 10,
            [FromQuery] string field = "",
            [FromQuery] string value = "")
        {
            if (pageNumber < 1 || rowsPerPage < 1)
                return BadRequest("Invalid pagination parameters.");

            var clients = Client.GetClientsPaged(pageNumber, rowsPerPage, field, value);
            if (clients == null || !clients.Any())
                return NotFound("No Clients Found!");

            var result = new PagedResult<ClientDTO>
            {
                Items = clients.ToList(),
                TotalRecords = Client.GetClientsCount(field, value),
                TotalPages = (int)Math.Ceiling((double)Client.GetClientsCount(field, value) / rowsPerPage)
            };

            return Ok(result);
        }

        [HttpGet("Filter", Name = "GetClientsByFilter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PagedResult<ClientDTO>> GetClientsByFilter([FromQuery] string field, [FromQuery] string value)
        {
            if (string.IsNullOrEmpty(field) || string.IsNullOrEmpty(value))
                return BadRequest("Field and value are required for filtering.");

            var clients = Client.GetClientsByFilter(field, value);
            if (clients == null || !clients.Any())
                return NotFound($"No clients found for {field} matching '{value}'.");

            var result = new PagedResult<ClientDTO>
            {
                Items = clients.ToList(),
                TotalRecords = Client.GetClientsCount(field, value),
                TotalPages = 1 // Full results for filter endpoint
            };

            return Ok(result);
        }

        [HttpGet("Summary", Name = "GetClientSummary")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<object> GetClientSummary()
        {
            return Ok(new { totalClients = Client.GetClientSummary() });
        }

        [HttpGet("{id}", Name = "GetClientById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ClientDTO> GetClientById(int id)
        {
            if (id < 1)
                return BadRequest($"Not accepted ID {id}");

            Client? client = Client.Find(id);
            if (client == null)
                return NotFound($"Client with ID {id} not found.");

            return Ok(client.ToDTO());
        }

        [HttpPost(Name = "AddClient")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ClientDTO> AddClient(ClientDTO newClientDTO)
        {
            if (newClientDTO == null || string.IsNullOrEmpty(newClientDTO.FullName) || string.IsNullOrEmpty(newClientDTO.Email) || string.IsNullOrEmpty(newClientDTO.Phone) || string.IsNullOrEmpty(newClientDTO.Address))
                return BadRequest("Invalid client data.");

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
                return BadRequest("Invalid Client data.");

            Client? client = Client.Find(id);
            if (client == null)
                return NotFound($"Client with ID {id} not found.");

            client.FullName = updatedClient.FullName;
            client.Email = updatedClient.Email;
            client.Phone = updatedClient.Phone;
            client.Address = updatedClient.Address;

            return client.Save() ? Ok(client.ToDTO()) : StatusCode(500, new { message = "Error Updating Client" });
        }

        [HttpDelete("{id}", Name = "DeleteClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteClient(int id)
        {
            if (id < 1)
                return BadRequest($"Not accepted ID {id}");

            return Client.DeleteClient(id) ? Ok($"Client with ID {id} has been deleted.") : NotFound($"Client with ID {id} not found. no rows deleted!");
        }
    }
}