using Microsoft.Data.SqlClient;

namespace A_DataAccess.Repositories
{
    public static class ClientRepository
    {
        public static List<ClientDTO> GetAllClients()
        {
            return BaseRepository.ExecuteReader(
                "GetAllClients",
                reader => new ClientDTO(
                    reader.GetInt32(reader.GetOrdinal("ClientID")),
                    reader.GetString(reader.GetOrdinal("FullName")),
                    reader.GetSafeString("Email"),
                    reader.GetSafeString("Phone"),
                    reader.GetSafeString("Address"),
                    reader.GetDateTime(reader.GetOrdinal("CreatedAt"))));
        }

        public static List<ClientDTO> GetClientsByFilter(string field, string value)
        {
            return BaseRepository.ExecuteReader(
                "GetClientsByFilter",
                reader => new ClientDTO(
                    reader.GetInt32(reader.GetOrdinal("ClientID")),
                    reader.GetString(reader.GetOrdinal("FullName")),
                    reader.GetSafeString("Email"),
                    reader.GetSafeString("Phone"),
                    reader.GetSafeString("Address"),
                    reader.GetDateTime(reader.GetOrdinal("CreatedAt"))),
                new SqlParameter("@Field", field),
                new SqlParameter("@Value", value ?? ""));
        }

        public static List<ClientDTO> GetClientsPaged(int pageNumber, int rowsPerPage, string field = "", string value = "")
        {
            return BaseRepository.ExecuteReader(
                "GetClientsPaged",
                reader => new ClientDTO(
                    reader.GetInt32(reader.GetOrdinal("ClientID")),
                    reader.GetString(reader.GetOrdinal("FullName")),
                    reader.GetSafeString("Email"),
                    reader.GetSafeString("Phone"),
                    reader.GetSafeString("Address"),
                    reader.GetDateTime(reader.GetOrdinal("CreatedAt"))),
                new SqlParameter("@PageNumber", pageNumber),
                new SqlParameter("@RowsPerPage", rowsPerPage),
                new SqlParameter("@Field", field),
                new SqlParameter("@Value", value));
        }

        public static int GetClientsCount(string field = "", string value = "")
        {
            return BaseRepository.ExecuteScalar(
                "GetClientsCount",
                new SqlParameter("@Field", field),
                new SqlParameter("@Value", value));
        }

        public static ClientDTO? GetClientByID(int clientID)
        {
            return BaseRepository.ExecuteSingle(
                "GetClientByID",
                reader => new ClientDTO(
                    reader.GetInt32(reader.GetOrdinal("ClientID")),
                    reader.GetString(reader.GetOrdinal("FullName")),
                    reader.GetSafeString("Email"),
                    reader.GetSafeString("Phone"),
                    reader.GetSafeString("Address"),
                    reader.GetDateTime(reader.GetOrdinal("CreatedAt"))),
                new SqlParameter("@ClientID", clientID));
        }

        public static int AddClient(ClientDTO client)
        {
            return BaseRepository.ExecuteScalar(
                "AddClient",
                new SqlParameter("@FullName", client.FullName),
                new SqlParameter("@Email", client.Email),
                new SqlParameter("@Phone", client.Phone),
                new SqlParameter("@Address", client.Address));
        }

        public static bool UpdateClient(ClientDTO client)
        {
            return BaseRepository.ExecuteScalar(
                "UpdateClient",
                new SqlParameter("@ClientID", client.ClientID),
                new SqlParameter("@FullName", client.FullName),
                new SqlParameter("@Email", client.Email),
                new SqlParameter("@Phone", client.Phone),
                new SqlParameter("@Address", client.Address)) > 0;
        }

        public static bool DeleteClient(int clientID)
        {
            return BaseRepository.ExecuteScalar(
                "DeleteClient",
                new SqlParameter("@ClientID", clientID)) > 0;
        }

        public static int GetClientSummary()
        {
            return BaseRepository.ExecuteScalar("GetClientSummary");
        }
    }

    public class ClientDTO(int clientID, string? fullName, string? email, string? phone, string? address, DateTime? createdAt)
    {
        public int ClientID { get; set; } = clientID;
        public string? FullName { get; set; } = fullName;
        public string? Email { get; set; } = email;
        public string? Phone { get; set; } = phone;
        public string? Address { get; set; } = address;
        public DateTime? CreatedAt { get; set; } = createdAt;
    }
}