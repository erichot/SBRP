using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataKates.Repositories
{
    public class CF_UserImportHeadRepository: EFCoreRepository<CF_UserImportHead>
    {
        private readonly KatesDbContext m_KatesDbContext;

        public CF_UserImportHeadRepository(KatesDbContext katesDbContext):base(katesDbContext)
        {
            m_KatesDbContext = katesDbContext;
        }











        public CF_UserImportHead GetEntity(int _importOperationNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new CF_UserImportHead() { ImportOperationNo = _importOperationNo }, _enableTracking, _includeDetails);
        }
        public async Task<CF_UserImportHead> GetEntityAsync(int _importOperationNo, bool _enableTracking = false, bool _includeDetails = true)
        {
           
            return await GetEntityAsync(
                new CF_UserImportHead() { ImportOperationNo = _importOperationNo }, _enableTracking, _includeDetails);
        }

        public CF_UserImportHead GetEntity(CF_UserImportHead _filterInfo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetQuery(_filterInfo, _enableTracking, _includeDetails)
                    .FirstOrDefault();
        }
        public async Task<CF_UserImportHead> GetEntityAsync(CF_UserImportHead _filterInfo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_filterInfo, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }

        









        public IQueryable<CF_UserImportHead> GetQuery(CF_UserImportHead? _filterInfo, bool _enableTracking = false, bool _includeDetails = false)
        {
            var ImportOperationNo = _filterInfo?.ImportOperationNo ?? default(int);
            

            IQueryable<CF_UserImportHead> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_KatesDbContext
                    .CF_UserImportHeads;
            }
            else
            {
                basedQuery = m_KatesDbContext
                    .CF_UserImportHeads;
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
