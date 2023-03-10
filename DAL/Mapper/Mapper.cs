using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapper
{
    static class Mapper
    {
        #region Developer

        public static Developer ToDeveloper(this IDataRecord record)
        {
            if (record is null) return null;
            return new Developer()
            {
                idDev = (int)record[nameof(Developer.idDev)],
                DevName = (string)record[nameof(Developer.DevName)],
                DevFirstName = (string)record[nameof(Developer.DevFirstName)],
                DevBirthDate = (DateTime)(record[nameof(Developer.DevBirthDate)]),
                DevPicture = (record[nameof(Developer.DevPicture)] is DBNull) ? null : (string)record[nameof(Developer.DevPicture)],
                DevHourCost = (double)record[nameof(Developer.DevHourCost)],
                DevDayCost = (double)record[nameof(Developer.DevDayCost)],
                DevMonthCost = (double)record[nameof(Developer.DevMonthCost)],
                DevMail = (string)record[nameof(Developer.DevMail)],
                DevCategPrincipal = (record[nameof(Developer.DevCategPrincipal)] is DBNull) ? null : (string)record[nameof(Developer.DevCategPrincipal)]
            };
        }

        #endregion

        #region ITLang

        public static ITLang ToITLang(this IDataRecord record)
        {
            if (record is null) return null;
            return new ITLang()
            {
                idIT = (int)record[nameof(ITLang.idIT)],
                ITLabel = (string)record[nameof(ITLang.ITLabel)]
            };
        }
        #endregion

        #region DevLang
        public static DevLang ToDevLang(this IDataRecord record)
        {
            if (record is null) return null;
            return new DevLang()
            {
                idDev = (int)record[nameof(DevLang.idDev)],
                idIT = (int)record[nameof(DevLang.idIT)],
                since = (record[nameof(DevLang.since)] is DBNull) ? null : (DateTime)record[nameof(DevLang.since)]
            };
        }
        #endregion

        #region Categories
        public static Categories ToCategories(this IDataRecord record){
            if (record is null) return null;
            return new Categories()
            {
                idCategory = (int)record[nameof(Categories.idCategory)],
                CategLabel = (string)record[nameof(Categories.CategLabel)]
            };
        }
        #endregion

        #region Client

        public static Client ToClient(this IDataRecord record)
        {
            if (record is null) return null;
            return new Client()
            {
                idClient = (int)record[nameof(Client.idClient)],
                CliName = (string)record[nameof(Client.CliName)],
                CliFirstName = (string)record[nameof(Client.CliFirstName)],
                CliMail = (string)record[nameof(Client.CliMail)],
                CliCompany = (string)record[nameof(Client.CliCompany)],
                CliLogin = (string)record[nameof(Client.CliLogin)],
                CliPassword = "********" 
            }; 
        }

        #endregion
    }
}
