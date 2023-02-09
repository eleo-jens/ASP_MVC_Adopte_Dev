using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MVC.Handlers; 

namespace MVC.Models.AuthViewModels
{
    public class LoginForm
    {
        [Required(ErrorMessage = ConstantMessages.errorMessage)]
        [MinLength(2)]
        [MaxLength(50)]
        [DisplayName("Login: *")]
        public string login { get; set; }

        [Required(ErrorMessage = ConstantMessages.errorMessage )]
        [MinLength(8)]
        [MaxLength(32)]
        [DataType(DataType.Password)]
        [DisplayName("Mot de passe: *")]
        public string password { get; set; }
    }
}
