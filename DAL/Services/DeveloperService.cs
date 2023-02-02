using Common.Repositories;
using DAL.Entities;
using DAL.Mapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class DeveloperService : BaseService, IDeveloperRepository<Developer, int>
    {
        // constructeur qui hérite du parent BaseService pour accéder à la connection string 
        // Par héritage de BaseService, DeveloperService subit aussi l'injection de dépendance de IConfiguration
        public DeveloperService(IConfiguration config): base(config, "AdopteUnDev") { }

        // deuxieme constructeur juste pour le test en console, car en console on ne peut pas utiliser IConfiguration config car pas d'injection de dépendance, ni de fichier de configuration (console est un outil très simple) - à supprimer après 
        public DeveloperService(string ConnectionString): base(null, ConnectionString) { }

        public IEnumerable<Developer> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idDev], [DevName], [DevFirstName], [DevBirthDate], [DevPicture], [DevHourCost], [DevDayCost], [DevMonthCost], [DevMail], [DevCategPrincipal] FROM [Developer]";

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToDeveloper();
                        }
                    }
                }

            }
        }

        public Developer Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idDev], [DevName], [DevFirstName], [DevBirthDate], [DevPicture], [DevHourCost], [DevDayCost], [DevMonthCost], [DevMail], [DevCategPrincipal] FROM [Developer] WHERE [idDev] = @idDev";
                    command.Parameters.AddWithValue("idDev", id); 
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToDeveloper();
                        }
                        return null;
                    }
                }
            }
        }

        public int Insert(Developer entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO [Developer] ([DevName], [DevFirstName], [DevBirthDate], [DevPicture], [DevHourCost], [DevDayCost], [DevMonthCost], [DevMail], [DevCategPrincipal]) OUTPUT [inserted].[idDev] VALUES (@DevName, @DevFirstName, @DevBirthDate, @DevPicture, @DevHourCost, @DevDayCost, @DevMonthCost, @DevMail, @DevCategPrincipal)";

                    command.Parameters.AddWithValue("DevName", (object)entity.DevName);
                    command.Parameters.AddWithValue("DevFirstName", (object)entity.DevFirstName);
                    command.Parameters.AddWithValue("DevBirthDate", (object)entity.DevBirthDate);
                    command.Parameters.AddWithValue("DevPicture", (object)entity.DevPicture ?? DBNull.Value);
                    command.Parameters.AddWithValue("DevHourCost", (object)entity.DevHourCost);
                    command.Parameters.AddWithValue("DevDayCost", (object)entity.DevDayCost);
                    command.Parameters.AddWithValue("DevMonthCost", (object)entity.DevMonthCost);
                    command.Parameters.AddWithValue("DevMail", (object)entity.DevMail);
                    command.Parameters.AddWithValue("DevCategPrincipal", (object)entity.DevCategPrincipal ?? DBNull.Value);

                    connection.Open();
                    return (int)command.ExecuteScalar();

                }
            }
        }
    }
}
