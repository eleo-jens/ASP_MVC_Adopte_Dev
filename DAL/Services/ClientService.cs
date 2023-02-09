using Common.Repositories;
using DAL.Entities;
using DAL.Mapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class ClientService : BaseService, IClientRepository<Client, int>
    {
        public ClientService(IConfiguration config) : base(config, "AdopteUnDev")
        {
        }

        public Client Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idClient], [CliName], [CliFirstName], [CliMail], [CliCompany], [CliLogin], [CliPassword] FROM [Client] where idClient = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open(); 

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToClient();
                        }
                        return null;
                    }
                }
            }
        }

        public int Insert(Client entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Client_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("name", entity.CliName);
                    command.Parameters.AddWithValue("firstname", entity.CliFirstName);
                    command.Parameters.AddWithValue("mail", entity.CliMail);
                    command.Parameters.AddWithValue("company", entity.CliCompany);
                    command.Parameters.AddWithValue("login", entity.CliLogin);
                    command.Parameters.AddWithValue("password", entity.CliPassword);

                    connection.Open();

                    return (int)command.ExecuteScalar();
                }
            }
        }

        int? IAuthRepository.CheckPassword(string login, string password)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText= "SP_Client_CheckPassword";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("login", login);
                    command.Parameters.AddWithValue("password", password);

                    connection.Open();

                    object result = command.ExecuteScalar();
                    return (result is DBNull) ? null : (int?)result; 
                }
            }
        }
    }
}
