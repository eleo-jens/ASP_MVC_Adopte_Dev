using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Client: IClient
    {
        // DB: int
        public int idClient { get; set; }
        // DB: nvarchar(50)
        public string CliName { get; set; }
        // DB: nvarchar(50)
        public string CliFirstName { get; set; }
        // DB: nvarchar(250)
        public string CliMail { get; set; }
        // DB: nvarchar(50)
        public string CliCompany { get; set; }
        // DB: nvarchar(50)
        public string CliLogin { get; set; }
        // DB: nvarchar(32)
        public string CliPassword { get; set; }
    }
}
