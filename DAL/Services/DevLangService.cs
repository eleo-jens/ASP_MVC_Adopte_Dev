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
    public class DevLangService : BaseService, IDevLangRepository<DevLang, int>
    {
        public DevLangService(IConfiguration config): base(config, "AdopteUnDev") {}

        public DevLangService(string ConnectionString) : base(null, ConnectionString) { }

        public IEnumerable<DevLang> Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idDev], [idIT], [since] FROM [DevLang] WHERE [idDev] = @idDev";
                    command.Parameters.AddWithValue("idDev", id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToDevLang();
                        }
                    }

                }
            }
        }
    }
}
