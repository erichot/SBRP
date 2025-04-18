using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SBRPDataRmshq.Interfaces;

namespace SBRPDataRmshq.Repositories
{
    public class EFCoreRepository<TEntity> : IEFCoreRepository<TEntity> where TEntity : class
    {
        private readonly RmshqDbContext m_RmshqDbContext;



        public EFCoreRepository(RmshqDbContext RmshqDbContext)
        {
            m_RmshqDbContext = RmshqDbContext;
        }

        public virtual TEntity AddEntity(TEntity _tEntity)
        {
            if (_tEntity != null)
            {
                m_RmshqDbContext.Set<TEntity>().Add(_tEntity);
            }
            return _tEntity;
        }




        public virtual async Task<TEntity> AddEntityAsync(TEntity _tEntity)
        {                    
            if (_tEntity != null)
            {
                await m_RmshqDbContext.Set<TEntity>().AddAsync(_tEntity);
            }
            return _tEntity;
        }

        public virtual void AddEntities(ICollection<TEntity> _tEntities)
        {
            if (_tEntities != null && _tEntities.Any())
            {
                m_RmshqDbContext.Set<TEntity>().AddRange(_tEntities);
            }
        }
        public virtual async Task AddEntitiesAsync(ICollection<TEntity> _tEntities)
        {
            if (_tEntities != null && _tEntities.Any())
            {
                await m_RmshqDbContext.Set<TEntity>().AddRangeAsync(_tEntities);
            }
        }

        public virtual void DeleteEntity(TEntity _tEntity)
        {
            m_RmshqDbContext.Remove<TEntity>(_tEntity);
        }

        public virtual void DeleteEntities(List<TEntity> _tEntities)
        {
            m_RmshqDbContext.RemoveRange(_tEntities);
        }


        public virtual void UpdateEntity(TEntity _tEntity)
        {
            m_RmshqDbContext.Entry<TEntity>(_tEntity).State = EntityState.Modified;
            m_RmshqDbContext.Update<TEntity>(_tEntity);
        }


        public virtual void UpdateEntities(List<TEntity> _tEntities)
        {
            //m_RmshqDbContext.Entry<TEntity>(_tEntity).State = EntityState.Modified;
            m_RmshqDbContext.UpdateRange(_tEntities);
        }



        public void SaveDbChanges()
        {
            m_RmshqDbContext.SaveChanges();

        }
        public async Task SaveDbChangesAsync()
        {
            await m_RmshqDbContext.SaveChangesAsync();
        }




    }
}
