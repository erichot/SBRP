

namespace SBRPWebPsi.BindingServices
{
    public class ProductCostBindingService : ISystemIsolationGroupInterface
    {
        private readonly IMapper m_Mapper;
        private readonly ProductCostService m_ProductCostService;
        


        public ProductCostBindingService( IMapper mapper, ProductCostService ProductCostService)
        {
            m_Mapper = mapper;
            m_ProductCostService = ProductCostService;
        }


        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_ProductCostService.SetSIG(_sIGNo);
        }












        public async Task<ProductCostViewModel> GetEntityAsync(int _productNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<ProductCostViewModel>(
                await m_ProductCostService.GetEntityAsync(_productNo, _enableTracking, _includeDetails));
        }


        public List<ProductCostViewModel> GetList(ProductCost _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<ProductCostViewModel>>(
               m_ProductCostService.GetList(_info, _enableTracking, _includeDetails));
        }
        public async Task<List<ProductCostViewModel>> GetListAsync(ProductCost _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<ProductCostViewModel>>(
               await m_ProductCostService.GetListAsync(_info, _enableTracking, _includeDetails));
        }


















        // 編輯中
        public async Task<ProductCostViewModel> AddNewDefaultAsync()
        {
            var result = m_Mapper.Map<ProductCostViewModel>(
                    await m_ProductCostService.AddNewDefaultAsync());
            return result;
        }

















        #region "ProductCostDefinition"
        public async Task<List<ProductCostDefinition>> GetDefinitionListAsync(byte _sIGNo, bool _enableTracking = false, bool _includeDetails = false)
        {
            return await
                m_ProductCostService
                    .GetDefinitionListAsync(_sIGNo, _enableTracking, _includeDetails);
        }

     
        #endregion  




    }
}
