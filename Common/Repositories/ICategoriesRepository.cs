using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface ICategoriesRepository<TEntity, TId> : IGetRepository<TEntity, TId> where TEntity : ICategories
    {
        IEnumerable<TEntity> GetByDeveloper(int id);
        IEnumerable<TEntity> GetByITLang(int id);
    }
}
