using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataRmshq.Repositories
{
    public class BF_StoreRepository:EFCoreRepository<BF_Store>
    {
        public readonly RmshqDbContext m_RmshqDbContext;

        public BF_StoreRepository(RmshqDbContext rmshqDbContext) : base(rmshqDbContext)
        {
            m_RmshqDbContext = rmshqDbContext;
        }









        #region "Basic based Procedure"
        public BF_Store GetEntity(string _storeID, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new BF_Store() { StoreID = _storeID }
                , _enableTracking, _includeDetails);
        }
        public async Task<BF_Store> GetEntityAsync(string _storeID, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new BF_Store() { StoreID = _storeID }
                    , _enableTracking, _includeDetails);
        }
        public BF_Store GetEntity(BF_Store _filterInfo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetQuery(_filterInfo, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<BF_Store> GetEntityAsync(BF_Store _filterInfo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_filterInfo, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }


        public IQueryable<BF_Store> GetQuery(BF_Store? _filterInfo, bool _enableTracking = false, bool _includeDetails = false)
        {
            //var InActive = _filterInfo?.InActive;
            //var IsVirtualForTransit = _filterInfo?.IsVirtualForTransit ?? default(false);
            


            IQueryable<BF_Store> basedQuery;

            basedQuery = m_RmshqDbContext
                    .BF_Stores
                    ;


            var result = basedQuery
                .Where(c =>
                    (c.InActive == false)
                    &&
                    (c.IsVirtualForTransit == false)
                );



            if (_enableTracking) return result;

            return result.AsNoTracking();
        }

        #endregion





    }
}
