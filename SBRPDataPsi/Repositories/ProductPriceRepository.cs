using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class ProductPriceRepository : EFCoreRepository<ProductPrice>, ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;
        public ProductPriceRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
        }

















        #region "Basic based Procedure"
        public ProductPrice? GetEntity(int _productNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new ProductPrice() { ProductNo =  _productNo }, _enableTracking, _includeDetails);
        }
        public async Task<ProductPrice?> GetEntityAsync(int _productNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new ProductPrice() { ProductNo =  _productNo }, _enableTracking, _includeDetails);
        }
       
         
        public ProductPrice? GetEntity(ProductPrice _info, bool _enableTracking, bool _includeDetails = true)
        {
            return GetQuery(_info, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<ProductPrice?> GetEntityAsync(ProductPrice _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_info, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }


        public IQueryable<ProductPrice?> GetQuery(ProductPrice? _info = null, bool _enableTracking = false, bool _includeDetails = false)
        {

            var SIGNo = m_SIGNo;
            var ProductNo =  _info?.ProductNo;
            var PriceNo = _info?.PriceNo;


            IQueryable<ProductPrice?> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_PsiDbContext
                    .ProductPrices
                        ;
            }
            else
            {
                basedQuery = m_PsiDbContext
                    .ProductPrices;
            }



            var result = basedQuery
                .Where(c => 
                    (ProductNo.IsNullOrDefault() || c.ProductNo == ProductNo)
                    &&
                    (PriceNo.IsNullOrDefault() || c.PriceNo == PriceNo)
                );

            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion









    }
}
