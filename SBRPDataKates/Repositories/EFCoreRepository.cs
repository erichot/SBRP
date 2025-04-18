using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SBRPDataKates.Interfaces;

namespace SBRPDataKates.Repositories
{
    public class EFCoreRepository<TEntity> : IEFCoreRepository<TEntity> where TEntity : class
    {
        private readonly KatesDbContext m_KatesDbContext;



        public EFCoreRepository(KatesDbContext KatesDbContext)
        {
            m_KatesDbContext = KatesDbContext;
        }

        public virtual TEntity AddEntity(TEntity _tEntity)
        {
            if (_tEntity != null)
            {
                m_KatesDbContext.Set<TEntity>().Add(_tEntity);
            }
            return _tEntity;
        }




        public virtual async Task<TEntity> AddEntityAsync(TEntity _tEntity)
        {                    
            if (_tEntity != null)
            {
                await m_KatesDbContext.Set<TEntity>().AddAsync(_tEntity);
            }
            return _tEntity;
        }

        public virtual void AddEntities(ICollection<TEntity> _tEntities)
        {
            if (_tEntities != null && _tEntities.Any())
            {
                m_KatesDbContext.Set<TEntity>().AddRange(_tEntities);
            }
        }
        public virtual async Task AddEntitiesAsync(ICollection<TEntity> _tEntities)
        {
            if (_tEntities != null && _tEntities.Any())
            {
                await m_KatesDbContext.Set<TEntity>().AddRangeAsync(_tEntities);
            }
        }

        public virtual void DeleteEntity(TEntity _tEntity)
        {
            m_KatesDbContext.Remove<TEntity>(_tEntity);
        }

        public virtual void DeleteEntities(List<TEntity> _tEntities)
        {
            m_KatesDbContext.RemoveRange(_tEntities);
        }


        public virtual void UpdateEntity(TEntity _tEntity)
        {
            m_KatesDbContext.Entry<TEntity>(_tEntity).State = EntityState.Modified;
            m_KatesDbContext.Update<TEntity>(_tEntity);
        }


        public virtual void UpdateEntities(List<TEntity> _tEntities)
        {
            //m_KatesDbContext.Entry<TEntity>(_tEntity).State = EntityState.Modified;
            m_KatesDbContext.UpdateRange(_tEntities);
        }



        public void SaveDbChanges()
        {
            m_KatesDbContext.SaveChanges();

        }
        public async Task SaveDbChangesAsync()
        {
            await m_KatesDbContext.SaveChangesAsync();
        }




    }
}
