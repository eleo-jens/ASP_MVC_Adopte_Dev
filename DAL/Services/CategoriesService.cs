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
    public class CategoriesService : BaseService, ICategoriesRepository<Categories, int>
    {
        public CategoriesService(IConfiguration config) : base(config, "AdopteUnDev")
        {

        }

        public IEnumerable<Categories> GetAll()
        {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT [idCategory], [CategLabel] FROM [Categories]";
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                yield return reader.ToCategories();
                            }
                        }

                    }
                }
        }

        public IEnumerable<Categories> GetByDeveloper(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"";

                    connection.Open(); 

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToCategories();
                        }
                    }
                }
            }
        }

        public IEnumerable<Categories> GetByITLang(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT Categories.idCategory, CategLabel
                                            FROM [Categories] JOIN [LangCateg]
                                            ON Categories.idCategory = LangCateg.idCategory
                                            WHERE idIT = @idIT";
                    command.Parameters.AddWithValue("idIT", id);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToCategories();
                        }
                    }
                }
            }
        }
    }
}
