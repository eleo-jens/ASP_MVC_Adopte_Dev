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
        [Required(ErrorMessage = "Cette information est obligatoire")]
        [DisplayName("Nom de famille: * ")]
        [MinLength(2)]
        [MaxLength(50)]
        public string DevName { get; set; }

        [Required(ErrorMessage = "Cette information est obligatoire")]
        [DisplayName("Prénom: *")]
        [MinLength(2)]
        [MaxLength(50)]
        public string DevFirstName { get; set; }

        [Required(ErrorMessage = "Cette information est obligatoire")]
        [DisplayName("Date de naissance: *")]
        [DataType(DataType.Date)]
        public DateTime DevBirthDate { get; set; }

        [DisplayName("Photo: ")]
        [DataType(DataType.ImageUrl)]
        public string DevPicture { get; set; }

        [Required(ErrorMessage = "Cette information est obligatoire")]
        [DisplayName("Salaire horaire (€): *")]
        [DataType(DataType.Currency)]
        public double DevHourCost { get; set; }

        [Required(ErrorMessage = "Cette information est obligatoire")]
        [DisplayName("Salaire journalier (€): *")]
        [DataType(DataType.Currency)]
        public double DevDayCost { get; set; }

        [Required(ErrorMessage = "Cette information est obligatoire")]
        [DisplayName("Salaire mensuel (€): *")]
        [DataType(DataType.Currency)]
        public double DevMonthCost { get; set; }

        [Required(ErrorMessage = "Cette information est obligatoire")]
        [DisplayName("Adresse email: *")]
        [EmailAddress]
        [MinLength(5)]
        [MaxLength(250)]
        public string DevMail { get; set; }

        [DisplayName("Catégorie principale: ")]
        [MinLength(2)]
        [MaxLength(250)]
        public string DevCategPrincipal { get; set; }
    }
}
