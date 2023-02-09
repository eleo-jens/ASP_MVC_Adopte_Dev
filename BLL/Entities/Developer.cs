﻿using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    // Objet logique
    public class Developer: IDeveloper
    {
        public int idDev { get; set; }
        public string DevName { get; set; }
        public string DevFirstName { get; set; }
        public DateTime DevBirthDate { get; set; }
        public string DevPicture { get; set; }
        public double DevHourCost { get; set; }
        public double DevDayCost { get; set; }
        public double DevMonthCost { get; set; }
        public string DevMail { get; set; }
        public string DevCategPrincipal { get; set; }
        public Categories CategoriePrincipale { get; set; }
        public IEnumerable<DevLang> Devlangs { get; set; }
    }
}
