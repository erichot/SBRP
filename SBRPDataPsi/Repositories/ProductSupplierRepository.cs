using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class ProductSupplierRepository : EFCoreRepository<ProductSupplier>, ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;
        public ProductSupplierRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
        }

















        #region "Basic based Procedure"
        public ProductSupplier? GetEntity(int _productNo, short _supplierNo, byte _itemNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new ProductSupplier() { ProductNo =  _productNo, SupplierNo = _supplierNo, ItemNo = _itemNo }, _enableTracking, _includeDetails);
        }
        public async Task<ProductSupplier?> GetEntityAsync(int _productNo, short _supplierNo, byte _itemNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new ProductSupplier() { ProductNo = _productNo, SupplierNo = _supplierNo, ItemNo = _itemNo }, _enableTracking, _includeDetails);
        }
      
        public ProductSupplier? GetEntity(ProductSupplier _info, bool _enableTracking, bool _includeDetails = true)
        {
            return GetQuery(_info, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<ProductSupplier?> GetEntityAsync(ProductSupplier _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_info, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }


        public IQueryable<ProductSupplier?> GetQuery(ProductSupplier? _info = null, bool _enableTracking = false, bool _includeDetails = false)
        {

            var SIGNo = m_SIGNo;
            var ProductNo =  _info?.ProductNo;
            var SupplierNo = _info?.SupplierNo;
            var ItemNo = _info?.ItemNo;


            IQueryable<ProductSupplier?> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_PsiDbContext
                 .ProductSuppliers
                 .Include(f => f.Product)
                 .Include(f => f.Supplier);
            }
            else
            {
                basedQuery = m_PsiDbContext
                    .ProductSuppliers;
            }



            var result = basedQuery
                .Where(c => 
                    (ProductNo.IsNullOrDefault() || c.ProductNo == ProductNo)
                    &&
                    (SupplierNo.IsNullOrDefault() || c.SupplierNo == SupplierNo)
                    &&
                    (ItemNo.IsNullOrDefault() || c.ItemNo == ItemNo)
                    &&
                    (_includeDetails == false || SIGNo.IsNullOrDefault() || c.Product.SIGNo == SIGNo)
                );

            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion







    }
}
