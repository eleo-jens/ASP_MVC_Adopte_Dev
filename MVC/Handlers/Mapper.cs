using BLL.Entities;
using MVC.Models.DeveloperViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Handlers
{
    public static class Mapper
    {
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
                DevCategPrincipal = entity.DevCategPrincipal
            }; 
        }
    }
}
