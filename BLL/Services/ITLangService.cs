using BLL.Mapper;
using BO = BLL.Entities;
using BS = BLL.Services;
using Common.Repositories;
using DO = DAL.Entities;
using DS = DAL.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ITLangService : IITLangRepository<BO.ITLang, int>
    {
        private readonly IITLangRepository<DO.ITLang, int> _repository;

        public ITLangService(IITLangRepository<DO.ITLang, int> repository) {
            _repository = repository;
        }

        public IEnumerable<BO.ITLang> Get()
        {
            return _repository.Get().Select(e => e.ToBLL());
        }

        public BO.ITLang Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }
    }
}
