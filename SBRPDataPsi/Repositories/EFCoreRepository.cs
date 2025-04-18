using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SBRPDataPsi.Repositories
{
    public class EFCoreRepository<TEntity> : SBRPDataPsi.Interfaces.IEFCoreRepository<TEntity> where TEntity : class
    {
        private readonly PsiDbContext m_PsiDbContext;
        

        public EFCoreRepository(PsiDbContext PsiDbContext)
        {
            m_PsiDbContext = PsiDbContext;
        }

        public virtual TEntity AddEntity(TEntity _tEntity)
        {
            if (_tEntity != null)
            {
                m_PsiDbContext.Set<TEntity>().Add(_tEntity);
            }            
            return _tEntity;
        }

        //public virtual async Task<TEntity> AddEntityAsync(TEntity _tEntity, short _userNo)
        //{
        //    if (DbSystem.PIC_UserNo.Contains(_userNo) && _tEntity != null)
        //    {
        //        await m_PsiDbContext.Set<TEntity>().AddAsync(_tEntity);
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
                await m_PsiDbContext.Set<TEntity>().AddAsync(_tEntity);
            }
            return _tEntity;

            
        }



        public virtual void AddEntities(ICollection<TEntity> _tEntities)
        {
            if (_tEntities != null && _tEntities.Any())
            {
                m_PsiDbContext.Set<TEntity>().AddRange(_tEntities);
            }            
        }
        public virtual async Task AddEntitiesAsync(ICollection<TEntity> _tEntities)
        {
            if (_tEntities != null && _tEntities.Any())
            {
                await m_PsiDbContext.Set<TEntity>().AddRangeAsync(_tEntities);
            }

        }




        public virtual void DeleteEntity(TEntity _tEntity)
        {
            m_PsiDbContext.Remove<TEntity>(_tEntity);
        }

        public virtual void DeleteEntities(List<TEntity> _tEntities)
        {
            m_PsiDbContext.RemoveRange(_tEntities);
        }


        public virtual void UpdateEntity(TEntity _tEntity)
        {
            m_PsiDbContext.Entry<TEntity>(_tEntity).State = EntityState.Modified;
            m_PsiDbContext.Update<TEntity>(_tEntity);
        }


        public virtual void UpdateEntities(List<TEntity> _tEntities)
        {
            //m_PsiDbContext.Entry<TEntity>(_tEntity).State = EntityState.Modified;
            m_PsiDbContext.UpdateRange(_tEntities);
        }



        public void SaveDbChanges()
        {
            m_PsiDbContext.SaveChanges();

        }
        public async Task SaveDbChangesAsync()
        {
            await m_PsiDbContext.SaveChangesAsync();

        }







    }
}
