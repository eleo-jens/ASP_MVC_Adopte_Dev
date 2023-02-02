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
        private IDeveloperRepository<DAL.Entities.Developer, int> _repository;
        public DeveloperService(IDeveloperRepository<DAL.Entities.Developer, int> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Developer> Get()
        {
            return _repository.Get().Select(e => e.ToBLL());
        }

        public Developer Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public int Insert(Developer entity)
        {
            return _repository.Insert(entity.ToDAL());
        }
    }
}
