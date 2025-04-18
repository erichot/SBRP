using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataKates.Repositories
{
    public class OR_TransactionRepository: EFCoreRepository<OR_Transaction>
    {
        private readonly KatesDbContext m_KatesDbContext;

        public OR_TransactionRepository(KatesDbContext katesDbContext):base(katesDbContext)
        {
            m_KatesDbContext = katesDbContext;
        }











        public OR_Transaction GetEntity(int _tranSID, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new OR_Transaction() { TranSID = _tranSID }, _enableTracking, _includeDetails);
        }
        public async Task<OR_Transaction> GetEntityAsync(int _tranSID, bool _enableTracking = false, bool _includeDetails = true)
        {
           
            return await GetEntityAsync(
                new OR_Transaction() { TranSID = _tranSID }, _enableTracking, _includeDetails);
        }

        public OR_Transaction GetEntity(OR_Transaction _filterInfo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetQuery(_filterInfo, _enableTracking, _includeDetails)
                    .FirstOrDefault();
        }
        public async Task<OR_Transaction> GetEntityAsync(OR_Transaction _filterInfo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_filterInfo, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }

        






        public async Task<OR_Transaction?> GetLastEntityAsync(bool _enableTracking = false, bool _includeDetails = false)
        {
            return await GetQuery(
                        null, false, _includeDetails)
                    .OrderByDescending(c => c.TranSID)
                    .FirstOrDefaultAsync();
        }






        public IQueryable<OR_Transaction> GetQuery(OR_Transaction? _filterInfo, bool _enableTracking = false, bool _includeDetails = false)
        {
            var TranSID = _filterInfo?.TranSID;
            

            IQueryable<OR_Transaction> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_KatesDbContext
                    .OR_Transactions;
            }
            else
            {
                basedQuery = m_KatesDbContext
                    .OR_Transactions;
            }



            var result = basedQuery
                .Where(c =>
                    (TranSID.IsNullOrDefault() || c.TranSID == TranSID)
                )
                ;


            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }














    }
}
