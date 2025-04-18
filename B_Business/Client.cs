using A_DataAccess.Repositories;

namespace B_Business
{
    public class Client
    {
        public EntityMode Mode = EntityMode.AddNew;

        public ClientDTO CDTO => new ClientDTO(this.ClientID, this.FullName, this.Email, this.Phone, this.Address, this.CreatedAt);
        public int ClientID { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime? CreatedAt { get; set; }

        public Client(ClientDTO CDTO, EntityMode cMode = EntityMode.AddNew)
        {
            this.ClientID = CDTO.ClientID;
            this.FullName = CDTO.FullName;
            this.Email = CDTO.Email;
            this.Phone = CDTO.Phone;
            this.Address = CDTO.Address;
            this.CreatedAt = CDTO.CreatedAt;

            Mode = cMode;
        }

        private bool _AddNewClient()
        {
            try
            {
                this.ClientID = ClientRepository.AddClient(CDTO);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool _UpdateClient()
        {
            return ClientRepository.UpdateClient(CDTO);
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

        public static Client Find(int clientID)
        {
            ClientDTO CDTO = ClientRepository.GetClientByID(clientID);
            if (CDTO.ClientID != 0)
            {
                return new Client(CDTO, EntityMode.Update);
            }
            return new Client(new ClientDTO(0, null, null, null, null, null), EntityMode.AddNew);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case EntityMode.AddNew:
                    if (_AddNewClient())
                    {
                        Mode = EntityMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case EntityMode.Update:
                    return _UpdateClient();
            }
            return false;
        }

        public static bool DeleteClient(int clientID)
        {
            return ClientRepository.DeleteClient(clientID);
        }
    }
}