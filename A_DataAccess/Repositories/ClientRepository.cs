using System.Data;
using Microsoft.Data.SqlClient;

namespace A_DataAccess.Repositories
{
    public class ClientRepository
    {
        public static List<ClientDTO> GetAllClients()
        {
            List<ClientDTO> clients = new List<ClientDTO>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand("GetAllClients", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(new ClientDTO(
                             reader.GetInt32(reader.GetOrdinal("ClientID")),
                             reader.GetString(reader.GetOrdinal("FullName")),
                             reader.GetSafeString("Email"),
                             reader.GetSafeString("Phone"),
                             reader.GetSafeString("Address")
                        ));
                    }
                }
            }
            return clients;
        }

        public static List<ClientDTO> GetClientsByFilter(string field, string value)
        {
            List<ClientDTO> clients = new List<ClientDTO>();
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand("GetClientsByFilter", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Field", field);
                cmd.Parameters.AddWithValue("@Value", value ?? ""); // Handle null value
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(new ClientDTO(
                            reader.GetInt32(reader.GetOrdinal("ClientID")),
                            reader.GetString(reader.GetOrdinal("FullName")),
                            reader.GetSafeString("Email"),
                            reader.GetSafeString("Phone"),
                            reader.GetSafeString("Address")
                        ));
                    }
                }
            }
            return clients;
        }

        public static ClientDTO GetClientByID(int clientID)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand("GetClientByID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientID", clientID);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ClientDTO(
                            reader.GetInt32(reader.GetOrdinal("ClientID")),
                            reader.GetString(reader.GetOrdinal("FullName")),
                            reader.GetSafeString("Email"),
                            reader.GetSafeString("Phone"),
                            reader.GetSafeString("Address")
                        );
                    }
                }
            }
            return null;
        }

        public static int AddClient(ClientDTO client)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand("AddClient", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FullName", client.FullName);
                cmd.Parameters.AddWithValue("@Email", client.Email);
                cmd.Parameters.AddWithValue("@Phone", client.Phone);
                cmd.Parameters.AddWithValue("@Address", client.Address);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static bool UpdateClient(ClientDTO client)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand("UpdateClient", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientID", client.ClientID);
                cmd.Parameters.AddWithValue("@FullName", client.FullName);
                cmd.Parameters.AddWithValue("@Email", client.Email);
                cmd.Parameters.AddWithValue("@Phone", client.Phone);
                cmd.Parameters.AddWithValue("@Address", client.Address);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null && result != DBNull.Value; // True if row updated
            }
        }

        public static bool DeleteClient(int clientID)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand("DeleteClient", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientID", clientID);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null && result != DBNull.Value; // True if row deleted
            }
        }
    }


    public class ClientDTO
    {
        public ClientDTO(int clientID, string fullName, string email, string phone, string address)
        {
            this.ClientID = clientID;
            this.FullName = fullName;
            this.Email = email;
            this.Phone = phone;
            this.Address = address;
        }

        public int ClientID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}