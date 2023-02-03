using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class DevLang : IDevLang
    {
        public int idDev { get; set; }
        public int idIT { get; set; }
        public ITLang itLang {get;set;}
        public DateTime? since { get; set; }
    }
}
