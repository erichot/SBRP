using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBussinessPsi.Services
{
    public class ProductService : ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;        
        private readonly ProductRepository m_ProductRepository;
        private readonly ProductCostRepository m_ProductCostRepository;
        private readonly ProductCostDefinitionRepository m_ProductCostDefinitionRepository;
        private readonly ProductPriceRepository m_ProductPriceRepository;
        private readonly ProductPriceDefinitionRepository m_ProductPriceDefinitionRepository;
        private readonly ProductGeneralCategoryRepository m_ProductGeneralCategoryRepository;
        private readonly ProductGeneralCategoryDefinitionRepository m_ProductGeneralCategoryDefinitionRepository;
        private readonly ProductIdStructureDefinitionRepository m_ProductIdStructureDefinitionRepository;
        private readonly ProductSupplierRepository m_ProductSupplierRepository;

        private readonly ProductGeneralCategoryDefinitionService m_ProductGeneralCategoryDefinitionService;

        public ProductService(PsiDbContext psiDbContext)
        {
            m_PsiDbContext = psiDbContext;

            m_ProductRepository = new ProductRepository(psiDbContext);
            m_ProductCostRepository = new ProductCostRepository(psiDbContext);
            m_ProductCostDefinitionRepository = new ProductCostDefinitionRepository(psiDbContext);
            m_ProductPriceRepository = new ProductPriceRepository(psiDbContext);
            m_ProductPriceDefinitionRepository = new ProductPriceDefinitionRepository(psiDbContext);
            m_ProductGeneralCategoryRepository = new ProductGeneralCategoryRepository(psiDbContext);
            m_ProductGeneralCategoryDefinitionRepository = new ProductGeneralCategoryDefinitionRepository(psiDbContext);
            m_ProductIdStructureDefinitionRepository = new ProductIdStructureDefinitionRepository(psiDbContext);
            m_ProductSupplierRepository = new ProductSupplierRepository(psiDbContext);

            m_ProductGeneralCategoryDefinitionService = new ProductGeneralCategoryDefinitionService(psiDbContext);
        }



        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_ProductRepository.SetSIG(_sIGNo);
            m_ProductCostRepository.SetSIG(_sIGNo);
            m_ProductCostDefinitionRepository.SetSIG(_sIGNo);
            m_ProductPriceRepository.SetSIG(_sIGNo);
            m_ProductPriceDefinitionRepository.SetSIG(_sIGNo);
            m_ProductGeneralCategoryRepository.SetSIG(_sIGNo);
            m_ProductGeneralCategoryDefinitionRepository.SetSIG(_sIGNo);
            m_ProductIdStructureDefinitionRepository.SetSIG(_sIGNo);
            m_ProductSupplierRepository.SetSIG(_sIGNo);
            
            m_ProductGeneralCategoryDefinitionService.SetSIG(_sIGNo);
        }


        
















        #region "Basic based Procedure"
        public Product? GetEntity(int _productNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_productNo.IsNullOrDefault()) return null;
            return m_ProductRepository.GetEntity(_productNo, _enableTracking, _includeDetails);
        }
        public async Task<Product?> GetEntityAsync(int _productNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_productNo.IsNullOrDefault()) return null;
            return await m_ProductRepository.GetEntityAsync(_productNo, _enableTracking, _includeDetails);
            
        }
        public Product? GetEntity(string _productId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrWhiteSpace(_productId)) return null;
            return m_ProductRepository.GetEntity(_productId, _enableTracking, _includeDetails);

        }
        public async Task<Product?> GetEntityAsync(string _productId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrWhiteSpace(_productId)) return null;
            return await m_ProductRepository.GetEntityAsync(_productId, _enableTracking, _includeDetails);
        }
        public async Task<Product?> GetEntityAsync(string _productId, DbTableNameEnum _includeTable)
        {
            if (string.IsNullOrWhiteSpace(_productId)) return null;

            if (_includeTable == DbTableNameEnum.ProductCost)
                return await 
                    m_ProductRepository
                        .GetQuery(new Product() { ProductId = _productId }, _enableTracking: false, _includeDetails: false)
                        .Include(f => f.ProductCosts)
                        .FirstOrDefaultAsync();

            return await GetEntityAsync(_productId, _enableTracking: false, _includeDetails: false);
        }
        public Product? GetEntity(Product _info, bool _enableTracking, bool _includeDetails = true)
        {
            return m_ProductRepository.GetEntity(_info, _enableTracking, _includeDetails);
        }
        public async Task<Product?> GetEntityAsync(Product _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_ProductRepository.GetEntityAsync(_info, _enableTracking, _includeDetails);
        }
        public List<Product> GetList(Product _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_ProductRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToList();
        }
        public async Task<List<Product>> GetListAsync(Product _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_ProductRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToListAsync();
        }
        public IQueryable<Product> GetQuery(Product? _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            return m_ProductRepository.GetQuery(_info, _enableTracking, _includeDetails);
        }
        #endregion




        public async Task<Product?> GetEntityWithProductCostAsync(string _productId, bool _enableTracking = false)
        {
            return await 
                GetEntityWithProductCostAsync(
                    new Product() { ProductId = _productId}
                    , _enableTracking);
        }
        public async Task<Product?> GetEntityWithProductCostAsync(Product _info, bool _enableTracking = false)
        {
            return await 
                m_ProductRepository
                    .GetQuery(_info, _enableTracking, DbTableNameEnum.ProductCost)
                    .FirstOrDefaultAsync();
        }



        public async Task<List<Product>> GetListAsync(ProductFilter _filter)
        {
            return await m_ProductRepository
                 .GetQuery(
                    _filter.ToEntity()
                    , _enableTracking:false, _includeDetails:false)
                 .ToListAsync();
        }









        public async Task<bool> IsExistedProductAsync(string _productId)
        {
            if (string.IsNullOrWhiteSpace(_productId) == false)
            {
                var info = await
                    m_ProductRepository
                        .GetEntityAsync(_productId, _enableTracking: false, _includeDetails: false);

                if (info != null && info.ProductNo.IsNullOrDefault() == false)
                    return true;
            }

            return false;
        }
















        public ValidationResultEntity IsValidEntity(Product _info, byte _submitActionModeNo)
        {
            return IsValidEntity(_info, (SubmitActionModeEnum)Enum.ToObject(typeof(SubmitActionModeEnum), _submitActionModeNo));
        }
        public ValidationResultEntity IsValidEntity(Product _info, SubmitActionModeEnum _formEditMode = default)
        {
            var result = new ValidationResultEntity();
            var productNo = _info.ProductNo;

            if (_formEditMode == SubmitActionModeEnum.Remove) {
                if (m_ProductRepository.IsValid_Product_Deleting(productNo) == false)
                {
                    result.SetInValid("Product is in used.");
                    return result;
                }
            }

            return result;
        }























        // 依據[ProductGeneralCategoryDefinition]載入指定順序的空殼[ProductGeneralCategory]列表
        public async Task<Product> AddNewDefaultAsync()
        {
            var result = new Product();



            // --------------------------------------------------
            result.ProductCosts = new List<ProductCost>();
            var pcd = await
                m_ProductCostDefinitionRepository
                    .GetListAsync(m_SIGNo);
            foreach (var item in pcd)
            {
                result.ProductCosts.Add(new ProductCost(item));
            }


            // --------------------------------------------------
            result.ProductPrices = new List<ProductPrice>();
            var pld = await
                m_ProductPriceDefinitionRepository
                    .GetListAsync(m_SIGNo);
            foreach (var item in pld)
            {
                result.ProductPrices.Add(new ProductPrice(item));
            }


            // --------------------------------------------------
            result.ProductSuppliers = new List<ProductSupplier>();
            result.ProductSuppliers.Add(new ProductSupplier((byte)SBRPDataPsi.ProductSuplierEnum.DefaultSupplier));



            // --------------------------------------------------
            var pgcd = await 
                m_ProductGeneralCategoryDefinitionService
                    .GetGeneralListAsync();
            result.ProductGeneralCategories = (from item in pgcd
                              select new ProductGeneralCategory(item)
                             ).ToList();


            result.ProductSuppliers = new List<ProductSupplier>() { new ProductSupplier() };
            return result;
        }






        /// <summary>
        /// 
        /// </summary>
        /// <param name="_info"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        public async Task<BusinessProcessResult<Product>> ProcessToInsertAsync(Product _info)
        {
            var result = new BusinessProcessResult<Product>();
            
            _info.SetSIG(m_SIGNo);


            var entity = await m_ProductRepository.AddEntityAsync(_info);


            await m_PsiDbContext.SaveChangesAsync();
            result.ResultInfo = entity;
            result.ResultNo = entity.ProductNo;

            try
            {
                
            }
            catch (Exception ex)
            {
                result.SetErrorMessage(ex.Message);
            }


            return result;
        }









        public async Task<BusinessProcessResult> ProcessToDeleteAsync(Product _info)
        {
            var dataResult = m_ProductRepository.DELETE_Product(_info.ProductNo);
            return new BusinessProcessResult(dataResult);
        }












    }
}
