using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SBRPLogPsi.Repositories
{
    public class EFCoreRepository<TEntity> : SBRPLogPsi.Interfaces.IEFCoreRepository<TEntity> where TEntity : class
    {
        private readonly LogDbContext m_LogDbContext;
        

        public EFCoreRepository(LogDbContext logDbContext)
        {
            m_LogDbContext = logDbContext;
        }

        public virtual TEntity AddEntity(TEntity _tEntity)
        {
            if (_tEntity != null)
            {
                m_LogDbContext.Set<TEntity>().Add(_tEntity);
            }            
            return _tEntity;
        }

        //public virtual async Task<TEntity> AddEntityAsync(TEntity _tEntity, short _userNo)
        //{
        //    if (DbSystem.PIC_UserNo.Contains(_userNo) && _tEntity != null)
        //    {
        //        await m_LogDbContext.Set<TEntity>().AddAsync(_tEntity);
        //    }
           
        //    return _tEntity;
        //}


        public virtual async Task<TEntity> AddEntityAsync(TEntity _tEntity)
        {
                     
            if (_tEntity != null)
            {
                await m_LogDbContext.Set<TEntity>().AddAsync(_tEntity);
            }
            return _tEntity;

            
        }



        public virtual void AddEntities(ICollection<TEntity> _tEntities)
        {
            if (_tEntities != null && _tEntities.Any())
            {
                m_LogDbContext.Set<TEntity>().AddRange(_tEntities);
            }            
        }
        public virtual async Task AddEntitiesAsync(ICollection<TEntity> _tEntities)
        {
            if (_tEntities != null && _tEntities.Any())
            {
                await m_LogDbContext.Set<TEntity>().AddRangeAsync(_tEntities);
            }

        }





        public void SaveDbChanges()
        {
            m_LogDbContext.SaveChanges();

        }
        public async Task SaveDbChangesAsync()
        {
            await m_LogDbContext.SaveChangesAsync();

        }







    }
}
