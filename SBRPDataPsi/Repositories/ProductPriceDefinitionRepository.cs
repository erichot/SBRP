using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class ProductPriceDefinitionRepository : EFCoreRepository<ProductPriceDefinition>, ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;
        public ProductPriceDefinitionRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
        }

















        #region "Basic based Procedure"
        //public ProductPriceDefinition? GetEntity(int _productNo, bool _enableTracking = false, bool _includeDetails = true)
        //{
        //    return GetEntity(
        //        new ProductPriceDefinition() { ProductPriceDefinitionNo =  _productNo }, _enableTracking, _includeDetails);
        //}
        //public async Task<ProductPriceDefinition?> GetEntityAsync(int _productNo, bool _enableTracking = false, bool _includeDetails = true)
        //{
        //    return await
        //        GetEntityAsync(
        //            new ProductPriceDefinition() { ProductPriceDefinitionNo =  _productNo }, _enableTracking, _includeDetails);
        //}
        //public ProductPriceDefinition? GetEntity(string _productId, bool _enableTracking = false, bool _includeDetails = true)
        //{
        //    return GetEntity(
        //        new ProductPriceDefinition() { ProductPriceDefinitionId = _productId }, _enableTracking, _includeDetails);
        //}
        //public async Task<ProductPriceDefinition?> GetEntityAsync(string _productId, bool _enableTracking = false, bool _includeDetails = true)
        //{
        //    return await
        //        GetEntityAsync(
        //            new ProductPriceDefinition() { ProductPriceDefinitionId = _productId }, _enableTracking, _includeDetails);
        //}    
        //public ProductPriceDefinition? GetEntity(ProductPriceDefinition _info, bool _enableTracking, bool _includeDetails = true)
        //{
        //    return GetQuery(_info, _enableTracking, _includeDetails)
        //        .FirstOrDefault();
        //}
        //public async Task<ProductPriceDefinition?> GetEntityAsync(ProductPriceDefinition _info, bool _enableTracking = false, bool _includeDetails = true)
        //{
        //    return await
        //        GetQuery(_info, _enableTracking, _includeDetails)
        //            .FirstOrDefaultAsync();
        //}


        public IQueryable<ProductPriceDefinition?> GetQuery(ProductPriceDefinition? _info = null, bool _enableTracking = false, bool _includeDetails = false)
        {

            var SIGNo = m_SIGNo;
            var PriceNo =  _info?.PriceNo;


            IQueryable<ProductPriceDefinition?> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_PsiDbContext
                    .ProductPriceDefinitions
                        ;
            }
            else
            {
                basedQuery = m_PsiDbContext
                    .ProductPriceDefinitions;
            }



            var result = basedQuery
                .Where(c =>
                    (SIGNo.IsNullOrDefault() || c.SIGNo == SIGNo)
                    &&
                    (PriceNo.IsNullOrDefault() || c.PriceNo == PriceNo)
                );

            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion




        public async Task<List<ProductPriceDefinition>> GetListAsync(byte _sIGNo, bool _enableTracking = false, bool _includeDetails = false)
        {
            return await
                GetQuery(new ProductPriceDefinition() { SIGNo = _sIGNo }
                    , _enableTracking, _includeDetails
                    )
                .ToListAsync();

        }
        




    }
}
