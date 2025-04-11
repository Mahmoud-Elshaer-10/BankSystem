using A_DataAccess.Repositories;

namespace B_Business
{
    public class Client
    {
        public EntityMode Mode = EntityMode.AddNew;

        public ClientDTO CDTO => new ClientDTO(this.ClientID, this.FullName, this.Email, this.Phone, this.Address);
        public int ClientID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public Client(ClientDTO CDTO, EntityMode cMode = EntityMode.AddNew)
        {
            this.ClientID = CDTO.ClientID;
            this.FullName = CDTO.FullName;
            this.Email = CDTO.Email;
            this.Phone = CDTO.Phone;
            this.Address = CDTO.Address;

            Mode = cMode;
        }

        private bool _AddNewClient()
        {
            try
            {
                this.ClientID = ClientRepository.AddClient(CDTO);
                return true; // Success if no exception is thrown
            }
            catch (Exception)
            {
                return false; // Failure if an exception occurs
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

        public static Client Find(int clientID)
        {
            ClientDTO CDTO = ClientRepository.GetClientByID(clientID);
            if (CDTO != null)
            {
                return new Client(CDTO, EntityMode.Update);
            }
            else
                return null;
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