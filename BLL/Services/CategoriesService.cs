using BO = BLL.Entities;
using DO = DAL.Entities;
using Common.Repositories;
using BLL.Mapper; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Services
{
    public class CategoriesService : ICategoriesRepository<BO.Categories, int>
    {
        private readonly ICategoriesRepository<DO.Categories, int> _repository; 
        public CategoriesService(ICategoriesRepository<DO.Categories, int> repository)
        {
            _repository = repository; 
        }
        public IEnumerable<Categories> Get()
        {
            return _repository.Get().Select(e => e.ToBLL()); 
        }

        public Categories Get(int id)
        {
            return _repository.Get(id).ToBLL(); 
        }

        public IEnumerable<Categories> GetByDeveloper(int id)
        {
            return _repository.GetByDeveloper(id).Select(e => e.ToBLL()); 
        }

        public IEnumerable<Categories> GetByITLang(int id)
        {
            return _repository.GetByITLang(id).Select(e => e.ToBLL()); 
        }
    }
}
