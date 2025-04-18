using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class ProductCostRepository : EFCoreRepository<ProductCost>, ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;
        public ProductCostRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
        }

















        #region "Basic based Procedure"
        public ProductCost? GetEntity(int _productNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new ProductCost() { ProductNo =  _productNo }, _enableTracking, _includeDetails);
        }
        public async Task<ProductCost?> GetEntityAsync(int _productNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new ProductCost() { ProductNo =  _productNo }, _enableTracking, _includeDetails);
        }
       
         
        public ProductCost? GetEntity(ProductCost _info, bool _enableTracking, bool _includeDetails = true)
        {
            return GetQuery(_info, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<ProductCost?> GetEntityAsync(ProductCost _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_info, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }


        public IQueryable<ProductCost?> GetQuery(ProductCost? _info = null, bool _enableTracking = false, bool _includeDetails = false)
        {

            var SIGNo = m_SIGNo;
            var ProductNo =  _info?.ProductNo;
            var CostNo = _info?.CostNo;


            IQueryable<ProductCost?> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_PsiDbContext
                    .ProductCosts
                        ;
            }
            else
            {
                basedQuery = m_PsiDbContext
                    .ProductCosts;
            }



            var result = basedQuery
                .Where(c => 
                    (ProductNo.IsNullOrDefault() || c.ProductNo == ProductNo)
                    &&
                    (CostNo.IsNullOrDefault() || c.CostNo == CostNo)
                );

            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion









    }
}
