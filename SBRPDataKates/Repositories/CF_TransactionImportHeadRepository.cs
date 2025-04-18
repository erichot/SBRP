using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataKates.Repositories
{
    public class CF_TransactionImportHeadRepository: EFCoreRepository<CF_TransactionImportHead>
    {
        private readonly KatesDbContext m_KatesDbContext;

        public CF_TransactionImportHeadRepository(KatesDbContext katesDbContext):base(katesDbContext)
        {
            m_KatesDbContext = katesDbContext;
        }











        public CF_TransactionImportHead GetEntity(int _importOperationNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new CF_TransactionImportHead() { ImportOperationNo = _importOperationNo }, _enableTracking, _includeDetails);
        }
        public async Task<CF_TransactionImportHead> GetEntityAsync(int _importOperationNo, bool _enableTracking = false, bool _includeDetails = true)
        {
           
            return await GetEntityAsync(
                new CF_TransactionImportHead() { ImportOperationNo = _importOperationNo }, _enableTracking, _includeDetails);
        }

        public CF_TransactionImportHead GetEntity(CF_TransactionImportHead _filterInfo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetQuery(_filterInfo, _enableTracking, _includeDetails)
                    .FirstOrDefault();
        }
        public async Task<CF_TransactionImportHead> GetEntityAsync(CF_TransactionImportHead _filterInfo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_filterInfo, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }

        









        public IQueryable<CF_TransactionImportHead> GetQuery(CF_TransactionImportHead? _filterInfo, bool _enableTracking = false, bool _includeDetails = false)
        {
            var ImportOperationNo = _filterInfo?.ImportOperationNo ?? default(int);
            

            IQueryable<CF_TransactionImportHead> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_KatesDbContext
                    .CF_TransactionImportHeads;
            }
            else
            {
                basedQuery = m_KatesDbContext
                    .CF_TransactionImportHeads;
            }



            var result = basedQuery
                .Where(c =>
                    (ImportOperationNo.IsNullOrDefault() && c.ImportOperationNo == ImportOperationNo)
                    
                )
                ;


            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }














    }
}
