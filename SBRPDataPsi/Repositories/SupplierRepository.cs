using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class SupplierRepository : EFCoreRepository<Supplier>, ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;
        public SupplierRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }


        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
        }




        #region "Basic based Procedure"
        public Supplier? GetEntity(short _supplierNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new Supplier() { SupplierNo = _supplierNo }, _enableTracking, _includeDetails);
        }
        public async Task<Supplier?> GetEntityAsync(short _supplierNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new Supplier() { SupplierNo = _supplierNo }, _enableTracking, _includeDetails);
        }
        public Supplier? GetEntity(string _supplierId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new Supplier() { SupplierId = _supplierId }, _enableTracking, _includeDetails);
        }
        public async Task<Supplier?> GetEntityAsync(string _supplierId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new Supplier() { SupplierId = _supplierId }, _enableTracking, _includeDetails);
        }    
        public Supplier? GetEntity(Supplier _info, bool _enableTracking, bool _includeDetails = true)
        {
            return GetQuery(_info, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<Supplier?> GetEntityAsync(Supplier _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_info, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }


        public IQueryable<Supplier> GetQuery(Supplier _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            var SIGNo = m_SIGNo;
            var SupplierNo = _info.SupplierNo;
            var IsDisabled_Filter = _info.IsDisabled_Filter;

            IQueryable<Supplier> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_PsiDbContext
                 .Suppliers
                 .Include(f => f.Company)
                    .ThenInclude(ff => ff.CompanyContactPersons);
            }
            else
            {
                basedQuery = m_PsiDbContext
                    .Suppliers;
            }



            var result = basedQuery
                .Where(c => 
                    (SIGNo.IsNullOrDefault() || c.SIGNo == SIGNo)
                    &&
                    (SupplierNo.IsNullOrDefault() || c.SupplierNo == SupplierNo)
                    &&
                    (IsDisabled_Filter == null || c.IsDisabled == IsDisabled_Filter)
                );

            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion








        public async Task<short> GetRowCountAsync(byte _sIGNo, short _supplierNo)
        {
            return (short)
                await
                    m_PsiDbContext
                        .Suppliers
                        .IgnoreQueryFilters()
                        .Where(c => 
                            (c.SupplierNo <= _supplierNo)
                            &&
                            (_sIGNo.IsNullOrDefault() == true || c.SIGNo == _sIGNo)
                        )
                        .CountAsync();
        }





    }
}
