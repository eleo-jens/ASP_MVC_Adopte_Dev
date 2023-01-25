using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface IDeveloperRepository<TEntity, TId>: IGetRepository<TEntity, TId>, IInsertRepository<TEntity, TId> where TEntity : IDeveloper
    {
    }
}
