using BLL.Entities;
using MVC.Models.DeveloperViewModels;
using MVC.Models.ITLangViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models.HomeViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<DeveloperListItem> developers { get; set; }
        public IEnumerable<Categories> categories { get; set; }
        public IEnumerable<ITLangListItem> langues { get; set; }

        //public double minHour Cost{ get; set; }

        //public double maxHour Cost{ get; set; }
    }
}
