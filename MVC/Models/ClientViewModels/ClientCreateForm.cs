using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MVC.Handlers;

namespace MVC.Models.ClientViewModels
{
    public class ClientCreateForm
    { 
        [Required(ErrorMessage = ConstantMessages.errorMessage)]
        [DisplayName("Nom de famille: *")]
        [MinLength(2)]
        [MaxLength(50)]
        public string CliName { get; set; }

        [Required(ErrorMessage = ConstantMessages.errorMessage)]
        [DisplayName("Prénom: *")]
        [MinLength(2)]
        [MaxLength(50)]
        public string CliFirstName { get; set; }

        [Required(ErrorMessage = ConstantMessages.errorMessage)]
        [DisplayName("Adresse email: *")]
        [MinLength(2)]
        [MaxLength(250)]
        [EmailAddress]
        public string CliMail { get; set; }

        [Required(ErrorMessage = ConstantMessages.errorMessage)]
        [DisplayName("Nom de votre compagnie: *")]
        [MinLength(2)]
        [MaxLength(50)]
        public string CliCompany { get; set; }

        [Required(ErrorMessage = ConstantMessages.errorMessage)]
        [DisplayName("Votre login: *")]
        [MinLength(2)]
        [MaxLength(50)]
        public string CliLogin { get; set; }

        [Required(ErrorMessage = ConstantMessages.errorMessage)]
        [DisplayName("Mot de passe: *")]
        [MinLength(8)]
        [MaxLength(32)]
        [DataType(DataType.Password)]
        public string CliPassword { get; set; }

        [Required(ErrorMessage = ConstantMessages.errorMessage)]
        [DisplayName("Confirmez le mot de passe: *")]
        [MinLength(8)]
        [MaxLength(32)]
        [DataType(DataType.Password)]
        [Compare(nameof(CliPassword))]
        public string confirmCliPassword { get; set; }
    }
}
