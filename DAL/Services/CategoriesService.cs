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

        // Get Categorie By int id(DevCategPrincipal)
        public Categories Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT idCategory, CategLabel FROM Categories 
                                            WHERE idCategory = @id";

                    command.Parameters.AddWithValue("id", id);

                    connection.Open(); 

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToCategories(); 
                        }
                        return null; 
                    }
                }
            }
        }

        public IEnumerable<Categories> Get()
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
                    command.CommandText = 
                        @"SELECT DISTINCTCategories.CategLabel,Categories.idCategory
                            FROM LangCateg
                            JOIN DevLang
                            ON Devlang.idIT = LangCateg.idIT
                            JOIN Categories
                            ON Categories.idCategory = LangCateg.idCategory
                            WHERE idDev = @id";

                    command.Parameters.AddWithValue("idDev", id); 

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
