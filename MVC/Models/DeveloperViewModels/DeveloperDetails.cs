using BLL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models.DeveloperViewModels
{
    public class DeveloperDetails
    {
        [DisplayName("Identifiant")]
        [ScaffoldColumn(false)]
        public int idDev { get; set; }

        [DisplayName("Nom de famille: ")]
        public string DevName { get; set; }

        [DisplayName("Prénom: ")]
        public string DevFirstName { get; set; }
        [DisplayName("Date de naissance: ")]
        public DateTime DevBirthDate { get; set; }

        [DisplayName("Photo: ")]
        [DataType(DataType.ImageUrl)]
        public string DevPicture { get; set; }

        [DisplayName("Salaire horaire (€): ")]
        public double DevHourCost { get; set; }
        [DisplayName("Salaire journalier (€): ")]
        public double DevDayCost { get; set; }
        [DisplayName("Salaire mensuel (€): ")]
        public double DevMonthCost { get; set; }

        [DisplayName("Adresse email: ")]
        [EmailAddress]
        public string DevMail { get; set; }

        [DisplayName("Catégorie principale: ")]
        public string DevCategPrincipal { get; set; }

        public Categories CategoriePrincipale { get; set; }

        [DisplayName("Langues maitrisées: ")]
        public IEnumerable<DevLang> Devlangs { get; set; }
    }
}
