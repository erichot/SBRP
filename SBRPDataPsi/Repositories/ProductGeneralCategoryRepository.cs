using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class ProductGeneralCategoryRepository : EFCoreRepository<ProductGeneralCategory>, ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;
        public ProductGeneralCategoryRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
        }

















        #region "Basic based Procedure"
        public ProductGeneralCategory? GetEntity(int _productNo, byte _pGCategoryNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new ProductGeneralCategory() { ProductNo = _productNo, PGCategoryNo =  _pGCategoryNo }, _enableTracking, _includeDetails);
        }
        public async Task<ProductGeneralCategory?> GetEntityAsync(int _productNo, byte _pGCategoryNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new ProductGeneralCategory() {ProductNo = _productNo, PGCategoryNo =  _pGCategoryNo }, _enableTracking, _includeDetails);
        }
          
        public ProductGeneralCategory? GetEntity(ProductGeneralCategory _info, bool _enableTracking, bool _includeDetails = true)
        {
            return GetQuery(_info, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<ProductGeneralCategory?> GetEntityAsync(ProductGeneralCategory _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_info, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }


        public IQueryable<ProductGeneralCategory?> GetQuery(ProductGeneralCategory? _info = null, bool _enableTracking = false, bool _includeDetails = false)
        {

            var SIGNo = m_SIGNo;
            var ProductNo = _info?.ProductNo;
            var PGCategoryNo =  _info?.PGCategoryNo;


            IQueryable<ProductGeneralCategory?> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_PsiDbContext
                 .ProductGeneralCategories
                 .Include(f => f.ProductGeneralCategoryDefinition)
                 .Include(f => f.ProductGeneralCategoryItem);



            }
            else
            {
                basedQuery = m_PsiDbContext
                    .ProductGeneralCategories;
            }



            var result = basedQuery
                .Where(c => 
                    (PGCategoryNo.IsNullOrDefault() || c.PGCategoryNo == PGCategoryNo)
                    &&
                    (ProductNo.IsNullOrDefault() || c.ProductNo == ProductNo)
                    &&
                    (_includeDetails == false || SIGNo.IsNullOrDefault() || c.Product.SIGNo == SIGNo)
                );

            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion







    }
}
