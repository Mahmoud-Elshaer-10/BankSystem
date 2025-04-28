using A_DataAccess.Repositories;
using System.Text.RegularExpressions;

namespace B_Business
{
    public class Client : BaseEntity<ClientDTO>
    {
        public int ClientID { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime? CreatedAt { get; set; }

        public Client(ClientDTO dto, EntityMode mode = EntityMode.AddNew)
        {
            ClientID = dto.ClientID;
            FullName = dto.FullName;
            Email = dto.Email;
            Phone = dto.Phone;
            Address = dto.Address;
            CreatedAt = dto.CreatedAt;
            Mode = mode;
        }

        public new bool Save()
        {
            return base.Save();
        }

        public override ClientDTO ToDTO()
        {
            return new ClientDTO(ClientID, FullName, Email, Phone, Address, CreatedAt);
        }

        protected override bool AddNew()
        {
            ClientID = ClientRepository.AddClient(ToDTO());
            return ClientID > 0;
        }

        protected override bool Update()
        {
            return ClientRepository.UpdateClient(ToDTO());
        }

        public static List<ClientDTO> GetAllClients()
        {
            return ClientRepository.GetAllClients();
        }

        public static List<ClientDTO> GetClientsByFilter(string field, string value)
        {
            return ClientRepository.GetClientsByFilter(field, value);
        }

        public static int GetClientSummary()
        {
            return ClientRepository.GetClientSummary();
        }

        public static Client? Find(int clientID)
        {
            var dto = ClientRepository.GetClientByID(clientID);
            return dto != null && dto.ClientID != 0
                ? new Client(dto, EntityMode.Update)
                : null;
        }

        public static bool DeleteClient(int clientID)
        {
            return ClientRepository.DeleteClient(clientID);
        }
    }
}