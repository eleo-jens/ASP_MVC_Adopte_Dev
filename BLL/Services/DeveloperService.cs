using BLL.Entities;
using BLL.Mapper;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DeveloperService : IDeveloperRepository<Developer, int>
    {
        private readonly IDeveloperRepository<DAL.Entities.Developer, int> _repository;
        private readonly IDevLangRepository<DevLang, int> _repodevlang;
        public DeveloperService(IDeveloperRepository<DAL.Entities.Developer, int> repository, IDevLangRepository<DevLang, int> repodevlang)
        {
            _repository = repository;
            _repodevlang = repodevlang;
        }
        public IEnumerable<Developer> Get()
        {
            return _repository.Get().Select(e => e.ToBLL());
        }

        public Developer Get(int id)
        {
            Developer entity = _repository.Get(id).ToBLL();
            entity.devlangs = _repodevlang.Get(id);
            return entity;
        }

        public int Insert(Developer entity)
        {
            return _repository.Insert(entity.ToDAL());
        }
    }
}
