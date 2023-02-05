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
    public class ITLangService : BaseService, IITLangRepository<ITLang, int>
    {
        public ITLangService(IConfiguration config) : base(config, "AdopteUnDev") { }
        public ITLangService(string ConnectionString) : base(null, ConnectionString) { }

        public IEnumerable<ITLang> Get()
        {
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idIT], [ITLabel] FROM [ITLang]";
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToITLang();
                        }
                    }

                }
            }
        }

        public ITLang Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idIT], [ITLabel] FROM [ITLang] WHERE [idIT] = @idIT";
                    command.Parameters.AddWithValue("idIT", id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToITLang();
                        }
                        return null;
                    }

                }
            }
        }

        public IEnumerable<ITLang> GetByCategory(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT ITLang.idIT, ITLabel
                                            FROM ITLang JOIN LangCateg
                                            ON ITLang.idIT = LangCateg.idIT
                                            WHERE idCategory = @idCategory";
                    command.Parameters.AddWithValue("idCategory", id);

                    connection.Open();

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToITLang();
                        }
                    }
                }
            }
        }
    }
}
