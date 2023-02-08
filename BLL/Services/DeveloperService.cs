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
        private readonly ICategoriesRepository<Categories, int> _repocategories; 
        public DeveloperService(IDeveloperRepository<DAL.Entities.Developer, int> repository, IDevLangRepository<DevLang, int> repodevlang, ICategoriesRepository<Categories, int> repocategories)
        {
            _repository = repository;
            _repodevlang = repodevlang;
            _repocategories = repocategories; 
        }
        public IEnumerable<Developer> Get()
        {
            return _repository.Get().Select(e => e.ToBLL());
        }

        public Developer Get(int id)
        {
            Developer entity = _repository.Get(id).ToBLL();
            entity.Devlangs = _repodevlang.Get(id);
            entity.CategoriePrincipale = _repocategories.Get(int.Parse(entity.DevCategPrincipal)); 
            return entity;
        }

        public int Insert(Developer entity)
        {
            return _repository.Insert(entity.ToDAL());
        }
    }
}
