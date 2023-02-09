using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Handlers
{
    public class CurrentUser
    {
        public int idUser { get; set; }
        public string login { get; set; }
        public DateTime lastConnexion { get; set; }
    }
}
