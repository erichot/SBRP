using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class SupplierGroupRepository : EFCoreRepository<SupplierGroup>, ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;
        public SupplierGroupRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }


        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
        }




        #region "Basic based Procedure"
        public SupplierGroup? GetEntity(short _supplierGroupNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new SupplierGroup() { SupplierGroupNo = _supplierGroupNo }, _enableTracking, _includeDetails);
        }
        public async Task<SupplierGroup?> GetEntityAsync(short _supplierGroupNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new SupplierGroup() { SupplierGroupNo = _supplierGroupNo }, _enableTracking, _includeDetails);
        }
        public SupplierGroup? GetEntity(string _supplierGroupId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new SupplierGroup() { SupplierGroupId = _supplierGroupId }, _enableTracking, _includeDetails);
        }
        public async Task<SupplierGroup?> GetEntityAsync(string _supplierGroupId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new SupplierGroup() { SupplierGroupId = _supplierGroupId }, _enableTracking, _includeDetails);
        }    
        public SupplierGroup? GetEntity(SupplierGroup _info, bool _enableTracking, bool _includeDetails = true)
        {
            return GetQuery(_info, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<SupplierGroup?> GetEntityAsync(SupplierGroup _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_info, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }


        public IQueryable<SupplierGroup> GetQuery(SupplierGroup _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            var SIGNo = m_SIGNo;
            var SupplierGroupNo = _info.SupplierGroupNo;
         

            IQueryable<SupplierGroup> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_PsiDbContext
                 .SupplierGroups;
                 
            }
            else
            {
                basedQuery = m_PsiDbContext
                    .SupplierGroups;
            }



            var result = basedQuery
                .Where(c => 
                    (SIGNo.IsNullOrDefault() || c.SIGNo == SIGNo)
                    &&
                    (SupplierGroupNo.IsNullOrDefault() || c.SupplierGroupNo == SupplierGroupNo)
                    
                );

            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion








        public async Task<short> GetRowCountAsync(byte _sIGNo, short _supplierGroupNo)
        {
            return (short)
                await
                    m_PsiDbContext
                        .SupplierGroups
                        .IgnoreQueryFilters()
                        .Where(c => 
                            (c.SupplierGroupNo <= _supplierGroupNo)
                            &&
                            (_sIGNo.IsNullOrDefault() == true || c.SIGNo == _sIGNo)
                        )
                        .CountAsync();
        }





    }
}
