using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models.ITLangViewModels
{
    public class ITLangDetails
    {
        [DisplayName("Identifiant: ")]
        public int idIT { get; set; }
        [DisplayName("Language IT: ")]
        public string ITLabel { get; set; }
    }
}
