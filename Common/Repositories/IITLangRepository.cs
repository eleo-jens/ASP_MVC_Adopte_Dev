using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface IITLangRepository<TEntity, TId> : IGetRepository<TEntity, TId> where TEntity : IITLang
    {
        IEnumerable<TEntity> GetByCategory(int id);
    }
}
