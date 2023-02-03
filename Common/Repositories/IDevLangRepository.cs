using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface IDevLangRepository<TEntity, TId> where TEntity: IDevLang
    {
        IEnumerable<TEntity> Get(int id);
    }
}
