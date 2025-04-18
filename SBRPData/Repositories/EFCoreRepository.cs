using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SBRPData.Repositories
{
    public class EFCoreRepository<TEntity> : SBRPData.Interfaces.IEFCoreRepository<TEntity> where TEntity : class
    {
        private readonly CommonDbContext m_CommonDbContext;
        

        public EFCoreRepository(CommonDbContext CommonDbContext)
        {
            m_CommonDbContext = CommonDbContext;
        }

        public virtual TEntity AddEntity(TEntity _tEntity)
        {
            if (_tEntity != null)
            {
                m_CommonDbContext.Set<TEntity>().Add(_tEntity);
            }            
            return _tEntity;
        }

        //public virtual async Task<TEntity> AddEntityAsync(TEntity _tEntity, short _userNo)
        //{
        //    if (DbSystem.PIC_UserNo.Contains(_userNo) && _tEntity != null)
        //    {
        //        await m_CommonDbContext.Set<TEntity>().AddAsync(_tEntity);
        //    }
           
        //    return _tEntity;
        //}


        public virtual async Task<TEntity> AddEntityAsync(TEntity _tEntity)
        {
            //if (IsHasPermission())
            //{

            //}
            // return null;            
            if (_tEntity != null)
            {
                await m_CommonDbContext.Set<TEntity>().AddAsync(_tEntity);
            }
            return _tEntity;

            
        }



        public virtual void AddEntities(ICollection<TEntity> _tEntities)
        {
            if (_tEntities != null && _tEntities.Any())
            {
                m_CommonDbContext.Set<TEntity>().AddRange(_tEntities);
            }            
        }
        public virtual async Task AddEntitiesAsync(ICollection<TEntity> _tEntities)
        {
            if (_tEntities != null && _tEntities.Any())
            {
                await m_CommonDbContext.Set<TEntity>().AddRangeAsync(_tEntities);
            }

        }




        public virtual void DeleteEntity(TEntity _tEntity)
        {
            m_CommonDbContext.Remove<TEntity>(_tEntity);
        }

        public virtual void DeleteEntities(List<TEntity> _tEntities)
        {
            m_CommonDbContext.RemoveRange(_tEntities);
        }


        public virtual void UpdateEntity(TEntity _tEntity)
        {
            m_CommonDbContext.Entry<TEntity>(_tEntity).State = EntityState.Modified;
            m_CommonDbContext.Update<TEntity>(_tEntity);
        }


        public virtual void UpdateEntities(List<TEntity> _tEntities)
        {
            //m_CommonDbContext.Entry<TEntity>(_tEntity).State = EntityState.Modified;
            m_CommonDbContext.UpdateRange(_tEntities);
        }



        public void SaveDbChanges()
        {
            m_CommonDbContext.SaveChanges();

        }
        public async Task SaveDbChangesAsync()
        {
            await m_CommonDbContext.SaveChangesAsync();

        }







    }
}
