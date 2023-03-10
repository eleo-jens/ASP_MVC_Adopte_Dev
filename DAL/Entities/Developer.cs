using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    // Classe POCO: DATA TRANSFERT OBJECT
    public class Developer : IDeveloper
    {
        // DB: INT
        public int idDev { get; set; }
        //DB: NVARCHAR(50)
        public string DevName { get; set; }
        //DB: NVARCHAR(50)
        public string DevFirstName {get; set;}
        //DB: DATETIME
        public DateTime DevBirthDate { get; set; }
        //DB: NVARCHAR(50) NULL
        public string DevPicture { get; set; }
        //DB: FLOAT
        public double DevHourCost { get; set; }
        //DB: FLOAT
        public double DevDayCost { get; set; }
        //DB: FLOAT
        public double DevMonthCost { get; set; }
        //DB: NVARCHAR(250)
        public string DevMail { get; set; }
        //DB: NVARCHAR(250) NULL
        public string DevCategPrincipal { get; set; }
    }
}
