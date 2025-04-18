

namespace SBRPWebPsi.BindingServices
{
    public class ProductPriceBindingService : ISystemIsolationGroupInterface
    {
        private readonly IMapper m_Mapper;
        private readonly ProductPriceService m_ProductPriceService;
        


        public ProductPriceBindingService( IMapper mapper, ProductPriceService ProductPriceService)
        {
            m_Mapper = mapper;
            m_ProductPriceService = ProductPriceService;
        }


        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_ProductPriceService.SetSIG(_sIGNo);
        }












        public async Task<ProductPriceViewModel> GetEntityAsync(int _productNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<ProductPriceViewModel>(
                await m_ProductPriceService.GetEntityAsync(_productNo, _enableTracking, _includeDetails));
        }


        public List<ProductPriceViewModel> GetList(ProductPrice _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<ProductPriceViewModel>>(
               m_ProductPriceService.GetList(_info, _enableTracking, _includeDetails));
        }
        public async Task<List<ProductPriceViewModel>> GetListAsync(ProductPrice _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<ProductPriceViewModel>>(
               await m_ProductPriceService.GetListAsync(_info, _enableTracking, _includeDetails));
        }


















        // 編輯中
        public async Task<ProductPriceViewModel> AddNewDefaultAsync()
        {
            var result = m_Mapper.Map<ProductPriceViewModel>(
                    await m_ProductPriceService.AddNewDefaultAsync());
            return result;
        }

















        #region "ProductPriceDefinition"
        public async Task<List<ProductPriceDefinition>> GetDefinitionListAsync(byte _sIGNo, bool _enableTracking = false, bool _includeDetails = false)
        {
            return await
                m_ProductPriceService
                    .GetDefinitionListAsync(_sIGNo, _enableTracking, _includeDetails);
        }

        public async Task<List<SelectListItem>> GetDefinitionSelectListAsync(byte _sIGNo, bool _enableTracking = false, bool _includeDetails = false)
        {
            var list = m_Mapper.Map<List<ProductPriceDefinitionViewModel>>(
                await m_ProductPriceService.GetDefinitionListAsync(_sIGNo, _enableTracking, _includeDetails));

            var result = list.ToSelectListItem<ProductPriceDefinitionViewModel>();

            return result;
        }

        public async Task<List<SelectListItem>> GetDefinitionSelectListDisplayNameAsync(byte _sIGNo, bool _enableTracking = false, bool _includeDetails = false)
        {
            var list = m_Mapper.Map<List<ProductPriceDefinitionViewModel>>(
                await m_ProductPriceService.GetDefinitionListAsync(_sIGNo, _enableTracking, _includeDetails));

            var result = list.ToSelectListItemName<ProductPriceDefinitionViewModel>();

            return result;
        }

        public async Task<List<ProductPriceDefinition>> AddNewDefinitionDefaultAsync(byte _sIGNo, byte _priceItemCount)
        {
            return await
                m_ProductPriceService
                    .AddNewDefinitionDefaultAsync(_sIGNo, _priceItemCount);
        }
        public ProductPriceDefinition AddNewDefinitionDefault(byte _sIGNo, byte _priceNo)
        {
            return m_ProductPriceService.AddNewDefinitionDefault(_sIGNo, _priceNo);
        }
        public async Task<BusinessProcessResult> ProcessToInsertDefinitionAsync(List<ProductPriceDefinition> _list)
        {
            return await
                m_ProductPriceService
                    .ProcessToInsertDefinitionAsync(_list);
        }
        #endregion  




    }
}
