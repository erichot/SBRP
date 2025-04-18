using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class ProductCostDefinitionRepository : EFCoreRepository<ProductCostDefinition>, ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;
        public ProductCostDefinitionRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
        }

















        #region "Basic based Procedure"
        //public ProductCostDefinition? GetEntity(int _productNo, bool _enableTracking = false, bool _includeDetails = true)
        //{
        //    return GetEntity(
        //        new ProductCostDefinition() { ProductCostDefinitionNo =  _productNo }, _enableTracking, _includeDetails);
        //}
        //public async Task<ProductCostDefinition?> GetEntityAsync(int _productNo, bool _enableTracking = false, bool _includeDetails = true)
        //{
        //    return await
        //        GetEntityAsync(
        //            new ProductCostDefinition() { ProductCostDefinitionNo =  _productNo }, _enableTracking, _includeDetails);
        //}
        //public ProductCostDefinition? GetEntity(string _productId, bool _enableTracking = false, bool _includeDetails = true)
        //{
        //    return GetEntity(
        //        new ProductCostDefinition() { ProductCostDefinitionId = _productId }, _enableTracking, _includeDetails);
        //}
        //public async Task<ProductCostDefinition?> GetEntityAsync(string _productId, bool _enableTracking = false, bool _includeDetails = true)
        //{
        //    return await
        //        GetEntityAsync(
        //            new ProductCostDefinition() { ProductCostDefinitionId = _productId }, _enableTracking, _includeDetails);
        //}    
        //public ProductCostDefinition? GetEntity(ProductCostDefinition _info, bool _enableTracking, bool _includeDetails = true)
        //{
        //    return GetQuery(_info, _enableTracking, _includeDetails)
        //        .FirstOrDefault();
        //}
        //public async Task<ProductCostDefinition?> GetEntityAsync(ProductCostDefinition _info, bool _enableTracking = false, bool _includeDetails = true)
        //{
        //    return await
        //        GetQuery(_info, _enableTracking, _includeDetails)
        //            .FirstOrDefaultAsync();
        //}


        public IQueryable<ProductCostDefinition?> GetQuery(ProductCostDefinition? _info = null, bool _enableTracking = false, bool _includeDetails = false)
        {

            var SIGNo = m_SIGNo;
            var CostNo =  _info?.CostNo;


            IQueryable<ProductCostDefinition?> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_PsiDbContext
                    .ProductCostDefinitions
                        ;
            }
            else
            {
                basedQuery = m_PsiDbContext
                    .ProductCostDefinitions;
            }



            var result = basedQuery
                .Where(c =>
                    (SIGNo.IsNullOrDefault() || c.SIGNo == SIGNo)
                    &&
                    (CostNo.IsNullOrDefault() || c.CostNo == CostNo)
                );

            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion




        public async Task<List<ProductCostDefinition>> GetListAsync(byte _sIGNo, bool _enableTracking = false, bool _includeDetails = false)
        {
            return await
                GetQuery(new ProductCostDefinition() { SIGNo = _sIGNo }
                    , _enableTracking, _includeDetails
                    )
                .ToListAsync();

        }
        




    }
}
