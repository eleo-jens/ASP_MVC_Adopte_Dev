using BLL.Entities;
using MVC.Models.DeveloperViewModels;
using MVC.Models.ITLangViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Handlers
{
    public static class Mapper
    {
        #region Developer
        public static DeveloperListItem ToListItem(this Developer entity)
        {
            if (entity is null) return null;
            return new DeveloperListItem()
            {
                idDev = entity.idDev,
                DevName = entity.DevName,
                DevFirstName = entity.DevFirstName,
                DevPicture = entity.DevPicture,
                DevHourCost = entity.DevHourCost,
                DevCategPrincipal = entity.DevCategPrincipal
            };
        }

        public static DeveloperDetails ToDetails(this Developer entity)
        {
            if (entity is null) return null;
            return new DeveloperDetails()
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
                DevCategPrincipal = entity.DevCategPrincipal,
                Devlangs = entity.Devlangs
            };
        }

        public static Developer ToBLL(this DeveloperCreateForm entity)
        {
            if (entity is null) return null;
            return new Developer()
            {
                idDev = default(int),
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
        public static ITLangListItem ToListItem(this ITLang entity)
        {
            if (entity is null) return null;
            return new ITLangListItem()
            {
                idIT = entity.idIT,
                ITLabel = entity.ITLabel
            };
        }

        public static ITLangDetails ToDetails(this ITLang entity)
        {
            if (entity is null) return null;
            return new ITLangDetails()
            {
                idIT = entity.idIT,
                ITLabel = entity.ITLabel
            };
        }
        #endregion
    }
}
