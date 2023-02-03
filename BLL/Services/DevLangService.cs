using BLL.Mapper;
using Common.Repositories;
using DO = DAL.Entities;
using BO = BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Services
{
    public class DevLangService : IDevLangRepository<BO.DevLang, int>
    {
        private readonly IDevLangRepository<DO.DevLang, int> _repository;
        private readonly IITLangRepository<DO.ITLang, int> _repolang; 

        public DevLangService (IDevLangRepository<DO.DevLang, int> repository, IITLangRepository<DO.ITLang, int> repolang)
        {
            _repository = repository;
            _repolang = repolang; 
        }

        public IEnumerable<BO.DevLang> Get(int id)
        {
            IEnumerable<DevLang> entities = _repository.Get(id).Select(e => e.ToBLL());
            entities = entities.Select(e => {
                e.itLang = _repolang.Get(e.idIT).ToBLL(); 
                return e; 
            });
            return entities;
        }
    }
}
