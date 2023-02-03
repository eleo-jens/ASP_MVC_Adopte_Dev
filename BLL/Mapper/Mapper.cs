using BO = BLL.Entities;
using DO = DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapper
{
    static class Mapper
    {
        #region Developer

        public static BO.Developer ToBLL(this DO.Developer entity)
        {
            if (entity is null) return null;
            return new BO.Developer()
            {
                idDev = entity.idDev,
                DevName = entity.DevName,
                DevFirstName = entity.DevFirstName,
                DevBirthDate = entity.DevBirthDate,
                DevPicture = entity.DevPicture,
                DevDayCost = entity.DevDayCost,
                DevHourCost = entity.DevHourCost,
                DevMonthCost = entity.DevMonthCost,
                DevMail = entity.DevMail,
                DevCategPrincipal = entity.DevCategPrincipal
            };
        }


        public static DO.Developer ToDAL(this BO.Developer entity)
        {
            if (entity is null) return null;
            return new DO.Developer()
            {
                idDev = entity.idDev,
                DevName = entity.DevName,
                DevFirstName = entity.DevFirstName,
                DevBirthDate = entity.DevBirthDate,
                DevPicture = entity.DevPicture,
                DevDayCost = entity.DevDayCost,
                DevHourCost = entity.DevHourCost,
                DevMonthCost = entity.DevMonthCost,
                DevMail = entity.DevMail,
                DevCategPrincipal = entity.DevCategPrincipal
            };
        }
        #endregion

        #region ITLang

        public static BO.ITLang ToBLL(this DO.ITLang entity)
        {
            if (entity is null) return null;
            return new BO.ITLang()
            {
                idIT = entity.idIT,
                ITLabel = entity.ITLabel
            };
        }
        #endregion

        #region DevLang

        public static BO.DevLang ToBLL(this DO.DevLang entity)
        {
            if (entity is null) return null;
            return new BO.DevLang()
            {
                idDev = entity.idDev,
                idIT = entity.idIT,
                since = entity.since
            }; 
        }
        #endregion
    }
}
