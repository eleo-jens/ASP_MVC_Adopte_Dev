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
            IEnumerable<Developer> developers; 
            developers = _repository.Get().Select(e => e.ToBLL());
            developers = developers.Select(e =>
            {
                if (int.TryParse(e.DevCategPrincipal, out int id))
                {
                    e.CategoriePrincipale = _repocategories.Get(id); 
                }
                else
                {
                    e.CategoriePrincipale = new Categories() { CategLabel = e.DevCategPrincipal };
                }

                return e;
            }); 
            return developers; 
        }

        public Developer Get(int id)
        {
            Developer entity = _repository.Get(id).ToBLL();
            entity.Devlangs = _repodevlang.Get(id);
            if (int.TryParse(entity.DevCategPrincipal, out int idCat))
            {
                entity.CategoriePrincipale = _repocategories.Get(idCat); 

            }
            else
            {
                entity.CategoriePrincipale = new Categories() { CategLabel = entity.DevCategPrincipal };
            }
            return entity;
        }

        public int Insert(Developer entity)
        {
            return _repository.Insert(entity.ToDAL());
        }
    }
}
