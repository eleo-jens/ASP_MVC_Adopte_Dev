using BLL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models.DeveloperViewModels
{
    public class DeveloperListItem
    {
        [DisplayName("Identifiant")]
        [ScaffoldColumn(false)]
        public int idDev {get; set;}

        [DisplayName("Nom de famille: ")]
        public string DevName { get; set; }

        [DisplayName("Prénom: ")]
        public string DevFirstName { get; set; }

        [DisplayName("Salaire horaire (€): ")]
        public double DevHourCost { get; set; }

        [DisplayName("Photo: ")]
        [DataType(DataType.ImageUrl)]
        public string DevPicture { get; set; }

        [ScaffoldColumn(false)]
        public string DevCategPrincipal { get; set; }
        
        [DisplayName("Catégorie principale: ")]
        public string CategoriePrincipale { get; set; }
    }
}
