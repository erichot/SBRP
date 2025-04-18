using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class ProductGeneralCategoryItemRepository : EFCoreRepository<ProductGeneralCategoryItem>, ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;
        public ProductGeneralCategoryItemRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
        }

















        #region "Basic based Procedure"
        public ProductGeneralCategoryItem? GetEntity(short _pGCItemNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new ProductGeneralCategoryItem() { PGCItemNo =  _pGCItemNo }, _enableTracking, _includeDetails);
        }
        public async Task<ProductGeneralCategoryItem?> GetEntityAsync(short _pGCItemNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new ProductGeneralCategoryItem() { PGCItemNo =  _pGCItemNo }, _enableTracking, _includeDetails);
        }
        public ProductGeneralCategoryItem? GetEntity(string _pGCItemId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new ProductGeneralCategoryItem() { PGCItemId = _pGCItemId }, _enableTracking, _includeDetails);
        }
        public async Task<ProductGeneralCategoryItem?> GetEntityAsync(string _pGCItemId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new ProductGeneralCategoryItem() { PGCItemId = _pGCItemId }, _enableTracking, _includeDetails);
        }    
        public ProductGeneralCategoryItem? GetEntity(ProductGeneralCategoryItem _info, bool _enableTracking, bool _includeDetails = true)
        {
            return GetQuery(_info, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<ProductGeneralCategoryItem?> GetEntityAsync(ProductGeneralCategoryItem _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_info, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }


        public IQueryable<ProductGeneralCategoryItem> GetQuery(ProductGeneralCategoryItem _info, bool _enableTracking = false, bool _includeDetails = false)
        {

            var SIGNo = m_SIGNo;
            var PGCItemNo = _info?.PGCItemNo;
            var PGCategoryNo =  _info?.PGCategoryNo;
            var PGCItemId = _info?.PGCItemId;

            var PGCategoryId = _info?.ProductGeneralCategoryDefinition?.PGCategoryId;



            IQueryable<ProductGeneralCategoryItem> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_PsiDbContext
                 .ProductGeneralCategoryItems
                    .Include(c => c.ProductGeneralCategoryDefinition);
            }
            else
            {
                basedQuery = m_PsiDbContext
                    .ProductGeneralCategoryItems;
            }



            var result = basedQuery
                .Where(c =>
                    (PGCItemNo.IsNullOrDefault() || c.PGCItemNo == PGCItemNo)
                    &&
                    (PGCategoryNo.IsNullOrDefault() || c.PGCategoryNo == PGCategoryNo)
                    &&
                    (string.IsNullOrWhiteSpace(PGCItemId) || c.PGCItemId == PGCItemId)
                    &&
                    (_includeDetails == false || string.IsNullOrWhiteSpace(PGCategoryId) || c.ProductGeneralCategoryDefinition.PGCategoryId == PGCategoryId)
                    &&
                    (_includeDetails == false || (SIGNo.IsNullOrDefault() || c.ProductGeneralCategoryDefinition.SIGNo == SIGNo))
                );

            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion







    }
}
