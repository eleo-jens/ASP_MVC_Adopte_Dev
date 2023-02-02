using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models.DeveloperViewModels
{
    public class DeveloperCreateForm
    {
        [Required]
        [DisplayName("Nom de famille: ")]
        [MinLength(2)]
        [MaxLength(50)]
        public string DevName { get; set; }

        [Required]
        [DisplayName("Prénom: ")]
        [MinLength(2)]
        [MaxLength(50)]
        public string DevFirstName { get; set; }

        [Required]
        [DisplayName("Date de naissance: ")]
        public DateTime DevBirthDate { get; set; }

        [DisplayName("Photo: ")]
        [DataType(DataType.ImageUrl)]
        public string DevPicture { get; set; }

        [Required]
        [DisplayName("Salaire horaire (€): ")]
        public double DevHourCost { get; set; }

        [Required]
        [DisplayName("Salaire journalier (€): ")]
        public double DevDayCost { get; set; }

        [Required]
        [DisplayName("Salaire mensuel (€): ")]
        public double DevMonthCost { get; set; }

        [Required]
        [DisplayName("Adresse email: ")]
        [EmailAddress]
        public string DevMail { get; set; }

        [DisplayName("Catégorie principale: ")]
        public string DevCategPrincipal { get; set; }
    }
}
