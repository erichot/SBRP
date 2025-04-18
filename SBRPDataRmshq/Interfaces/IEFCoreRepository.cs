using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataRmshq.Interfaces
{
    interface IEFCoreRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddEntityAsync(TEntity _tEntity);
    }
}
