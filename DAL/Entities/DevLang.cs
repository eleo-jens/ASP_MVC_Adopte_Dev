using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class DevLang : IDevLang
    {
        //DB: INT
        public int idDev { get; set; }
        //DB: INT
        public int idIT { get; set; }
        //DB: datetime NULL
        public DateTime? since {get; set;}
    }
}
