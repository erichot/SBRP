using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataRmshq.Repositories
{
    public class S_SystemCustomerAndStoreRepository:EFCoreRepository<S_SystemCustomerAndStore>
    {
        public readonly RmshqDbContext m_RmshqDbContext;

        public S_SystemCustomerAndStoreRepository(RmshqDbContext rmshqDbContext) : base(rmshqDbContext)
        {
            m_RmshqDbContext = rmshqDbContext;
        }









        #region "Basic based Procedure"
        public S_SystemCustomerAndStore GetEntity(string _storeID, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new S_SystemCustomerAndStore() { StoreID = _storeID }
                , _enableTracking, _includeDetails);
        }
        public async Task<S_SystemCustomerAndStore> GetEntityAsync(string _storeID, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new S_SystemCustomerAndStore() { StoreID = _storeID }
                    , _enableTracking, _includeDetails);
        }
        public S_SystemCustomerAndStore GetEntity(S_SystemCustomerAndStore _filterInfo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetQuery(_filterInfo, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<S_SystemCustomerAndStore> GetEntityAsync(S_SystemCustomerAndStore _filterInfo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_filterInfo, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }


        public IQueryable<S_SystemCustomerAndStore> GetQuery(S_SystemCustomerAndStore? _filterInfo, bool _enableTracking = false, bool _includeDetails = false)
        {
            var IsPrimaryStore = _filterInfo?.IsPrimaryStore;
            


            IQueryable<S_SystemCustomerAndStore> basedQuery;

            basedQuery = m_RmshqDbContext
                    .S_SystemCustomerAndStores
                    ;


            var result = basedQuery
                .Where(c =>
                    (c.SystemCustomerID == "YURUBRA")
                    &&
                    (c.IsPrimaryStore == true)
                );



            if (_enableTracking) return result;

            return result.AsNoTracking();
        }

        #endregion





    }
}
