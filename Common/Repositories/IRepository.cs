using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface IRepository<TEntity, TId>: IGetRepository<TEntity, TId>, IInsertRepository<TEntity, TId>, TDeleteRepository<TEntity, TId>, IUpdateRepository<TEntity, TId>
    {
    }
}
