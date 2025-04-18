using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBussinessPsi.Services
{
    public class ProductCostService : ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;        
        private readonly ProductCostRepository m_ProductCostRepository;
        private readonly ProductCostDefinitionRepository m_ProductCostDefinitionRepository;

        public ProductCostService(PsiDbContext psiDbContext)
        {
            m_PsiDbContext = psiDbContext;

            m_ProductCostRepository = new ProductCostRepository(psiDbContext);
            m_ProductCostDefinitionRepository = new ProductCostDefinitionRepository(psiDbContext);
        }



        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_ProductCostRepository.SetSIG(_sIGNo);
            m_ProductCostDefinitionRepository.SetSIG(_sIGNo);
        }


        
















        #region "Basic based Procedure"
        public ProductCost? GetEntity(int _productNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_productNo.IsNullOrDefault()) return null;
            return m_ProductCostRepository.GetEntity(_productNo, _enableTracking, _includeDetails);
        }
        public async Task<ProductCost?> GetEntityAsync(int _productNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_productNo.IsNullOrDefault()) return null;
            return await m_ProductCostRepository.GetEntityAsync(_productNo, _enableTracking, _includeDetails);
        }
       
        public ProductCost? GetEntity(ProductCost _info, bool _enableTracking, bool _includeDetails = true)
        {
            return m_ProductCostRepository.GetEntity(_info, _enableTracking, _includeDetails);
        }
        public async Task<ProductCost?> GetEntityAsync(ProductCost _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_ProductCostRepository.GetEntityAsync(_info, _enableTracking, _includeDetails);
        }
        public List<ProductCost> GetList(ProductCost _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_ProductCostRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToList();
        }
        public async Task<List<ProductCost>> GetListAsync(ProductCost _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_ProductCostRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToListAsync();
        }
        public IQueryable<ProductCost> GetQuery(ProductCost? _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            return m_ProductCostRepository.GetQuery(_info, _enableTracking, _includeDetails);
        }
        #endregion




















        public async Task<ProductCost> AddNewDefaultAsync()
        {
            var result = new ProductCost();


            //var pgcd = await m_ProductCostGeneralCategoryDefinitionService.GetGeneralListAsync();

            //var pgcDefault = (from item in pgcd
            //                  select new ProductCostGeneralCategory(item)
            //                 ).ToList();

            //result.ProductCostSuppliers = new List<ProductCostSupplier>() { new ProductCostSupplier() };

            //result.ProductCostGeneralCategories = pgcDefault;
            return result;
        }














        #region "ProductCostDefinition"
        public async Task<List<ProductCostDefinition>> GetDefinitionListAsync(byte _sIGNo, bool _enableTracking = false, bool _includeDetails = false)
        {
            return await
                m_ProductCostDefinitionRepository
                    .GetListAsync(_sIGNo, _enableTracking, _includeDetails);
        }
        


        public async Task<BusinessProcessResult> ProcessToInsertDefinitionAsync(List<ProductCostDefinition> _list)
        {
            var result = new BusinessProcessResult();
            await
                m_ProductCostDefinitionRepository
                    .AddEntitiesAsync(_list);

            await m_PsiDbContext.SaveChangesAsync();
            return result;
        }
        #endregion







    }
}
