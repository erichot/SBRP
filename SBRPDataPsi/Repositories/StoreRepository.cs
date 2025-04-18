using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class StoreRepository : EFCoreRepository<Store>, ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;
        public StoreRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
        }

















        #region "Basic based Procedure"
        public Store? GetEntity(short _storeNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new Store() { StoreNo = _storeNo }, _enableTracking, _includeDetails);
        }
        public async Task<Store?> GetEntityAsync(short _storeNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new Store() { StoreNo = _storeNo }, _enableTracking, _includeDetails);
        }
        public Store? GetEntity(string _StoreId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new Store() { StoreId = _StoreId }, _enableTracking, _includeDetails);
        }
        public async Task<Store?> GetEntityAsync(string _StoreId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new Store() { StoreId = _StoreId }, _enableTracking, _includeDetails);
        }    
        public Store? GetEntity(Store _info, bool _enableTracking, bool _includeDetails = true)
        {
            return GetQuery(_info, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<Store?> GetEntityAsync(Store _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_info, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }


        public IQueryable<Store> GetQuery(Store _info, bool _enableTracking = false, bool _includeDetails = false)
        {

            var SIGNo = m_SIGNo;
            var StoreNo = _info.StoreNo;

            IQueryable<Store> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_PsiDbContext
                 .Stores
                 .Include(f => f.Company)
                    .ThenInclude(ff => ff.CompanyContactPersons);
            }
            else
            {
                basedQuery = m_PsiDbContext
                    .Stores;
            }



            var result = basedQuery
                .Where(c => 
                    (SIGNo.IsNullOrDefault() || c.SIGNo == SIGNo)
                    &&
                    (StoreNo.IsNullOrDefault() || c.StoreNo == StoreNo)
                );

            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion







    }
}
