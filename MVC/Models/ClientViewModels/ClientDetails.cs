using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models.ClientViewModels
{
    public class ClientDetails
    {
        [DisplayName("Identifiant: ")]
        public int idClient { get; set; }
        [DisplayName("Nom de famille: ")]
        public string CliName { get; set; }
        [DisplayName("Prénom: ")]
        public string CliFirstName { get; set; }
        [DisplayName("Email: ")]
        public string CliMail { get; set; }
        [DisplayName("Compagnie: ")]
        public string CliCompany { get; set; }
    }
}
