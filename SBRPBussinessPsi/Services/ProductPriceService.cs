using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBussinessPsi.Services
{
    public class ProductPriceService : ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;        
        private readonly ProductPriceRepository m_ProductPriceRepository;
        private readonly ProductPriceDefinitionRepository m_ProductPriceDefinitionRepository;

        public ProductPriceService(PsiDbContext psiDbContext)
        {
            m_PsiDbContext = psiDbContext;

            m_ProductPriceRepository = new ProductPriceRepository(psiDbContext);
            m_ProductPriceDefinitionRepository = new ProductPriceDefinitionRepository(psiDbContext);
        }



        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_ProductPriceRepository.SetSIG(_sIGNo);
            m_ProductPriceDefinitionRepository.SetSIG(_sIGNo);
        }


        
















        #region "Basic based Procedure"
        public ProductPrice? GetEntity(int _productNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_productNo.IsNullOrDefault()) return null;
            return m_ProductPriceRepository.GetEntity(_productNo, _enableTracking, _includeDetails);
        }
        public async Task<ProductPrice?> GetEntityAsync(int _productNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_productNo.IsNullOrDefault()) return null;
            return await m_ProductPriceRepository.GetEntityAsync(_productNo, _enableTracking, _includeDetails);
        }
       
        public ProductPrice? GetEntity(ProductPrice _info, bool _enableTracking, bool _includeDetails = true)
        {
            return m_ProductPriceRepository.GetEntity(_info, _enableTracking, _includeDetails);
        }
        public async Task<ProductPrice?> GetEntityAsync(ProductPrice _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_ProductPriceRepository.GetEntityAsync(_info, _enableTracking, _includeDetails);
        }
        public List<ProductPrice> GetList(ProductPrice _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_ProductPriceRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToList();
        }
        public async Task<List<ProductPrice>> GetListAsync(ProductPrice _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_ProductPriceRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToListAsync();
        }
        public IQueryable<ProductPrice> GetQuery(ProductPrice? _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            return m_ProductPriceRepository.GetQuery(_info, _enableTracking, _includeDetails);
        }
        #endregion




















        public async Task<ProductPrice> AddNewDefaultAsync()
        {
            var result = new ProductPrice();


            //var pgcd = await m_ProductPriceGeneralCategoryDefinitionService.GetGeneralListAsync();

            //var pgcDefault = (from item in pgcd
            //                  select new ProductPriceGeneralCategory(item)
            //                 ).ToList();

            //result.ProductPriceSuppliers = new List<ProductPriceSupplier>() { new ProductPriceSupplier() };

            //result.ProductPriceGeneralCategories = pgcDefault;
            return result;
        }














        #region "ProductPriceDefinition"
        public async Task<List<ProductPriceDefinition>> GetDefinitionListAsync(byte _sIGNo, bool _enableTracking = false, bool _includeDetails = false)
        {
            return await
                m_ProductPriceDefinitionRepository
                    .GetListAsync(_sIGNo, _enableTracking, _includeDetails);
        }
        public async Task<List<ProductPriceDefinition>> AddNewDefinitionDefaultAsync(byte _sIGNo, byte _priceItemCount)
        {
            var result = new List<ProductPriceDefinition>();
            for (byte no = default; no < _priceItemCount; no++)
            {                
                result.Add(
                    AddNewDefinitionDefault(_sIGNo,no));
            }
            return result;
        }
        public ProductPriceDefinition AddNewDefinitionDefault(byte _sIGNo, byte _priceNo)
        {
            var result = new ProductPriceDefinition()
            {
                SIGNo = _sIGNo,
                PriceNo = _priceNo,
                ParentPriceNo = default(int),
                PriceDefinitionName = $"定價{_priceNo + 1}",
                PercentageToParent = 1,
                RoundUpDigitNumber = 0
            };
            if (_priceNo == default(int))
            {
                result.ParentPriceNo = null;
                result.IsInitial = true;
            }
            return result;
        }


        public async Task<BusinessProcessResult> ProcessToInsertDefinitionAsync(List<ProductPriceDefinition> _list)
        {
            var result = new BusinessProcessResult();
            await
                m_ProductPriceDefinitionRepository
                    .AddEntitiesAsync(_list);

            await m_PsiDbContext.SaveChangesAsync();
            return result;
        }
        #endregion







    }
}
