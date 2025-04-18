using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPLogPsi.Interfaces
{
    interface IEFCoreRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddEntityAsync(TEntity _tEntity);
    }
}
