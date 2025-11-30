using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionDeInformacion.Domain.Model;
using Microsoft.Graph;
using MySql.Data.MySqlClient;

namespace GestionDeinformacion.infraestructure.adapters
{
    public class MySqlUserPort
    {
        public User FindUserById(User user)
        {
            if (user == null || user.document <= 0) throw new ArgumentNullException(nameof(user), "El usuario no puede ser nulo.");

            try
            {
                using var connection = dbConnection.GetConnection();
                string query = "SELECT * FROM usuarios WHERE id = @id";
                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", user.Id);

                using var reader = command.ExecuteReader();
                return !reader.Read() ? null : new User
                {
                    Id = reader.GetUInt64("id"),
                    NameUser = reader.GetString("name_user"),
                    Password = reader.GetString("password"),
                    Role = reader.GetString("role"),
                    Name = reader.GetString("name"),
                    document = reader.GetUInt64("document"),
                    Email = reader.GetString("email"),
                    Phone = reader.GetInt32("phone"),
                    DateBirth = reader.GetDateTime("date_birth"),
                    Direction = reader.GetString("direction"),
                    EmergencyContact = new Contact
                    {
                        Name = reader.GetString("contact_name"),
                        Relation = reader.GetString("contact_relation"),
                        PhoneNumber = reader.GetString("contact_phone"),
                        Email = reader.GetString("contact_email")
                    }
                };
            }
            finally
            {
                dbConnection.CloseConnection();
            }

        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

