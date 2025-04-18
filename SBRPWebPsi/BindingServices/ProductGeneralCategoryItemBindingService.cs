

namespace SBRPWebPsi.BindingServices
{
    public class ProductGeneralCategoryItemBindingService : ISystemIsolationGroupInterface
    {
        private readonly IMapper m_Mapper;
        private readonly ProductGeneralCategoryItemService m_ProductGeneralCategoryItemService;
        


        public ProductGeneralCategoryItemBindingService( IMapper mapper, ProductGeneralCategoryItemService ProductGeneralCategoryItemService)
        {
            m_Mapper = mapper;
            m_ProductGeneralCategoryItemService = ProductGeneralCategoryItemService;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_ProductGeneralCategoryItemService.SetSIG(_sIGNo);
        }












        public async Task<ProductGeneralCategoryItemViewModel> GetEntityAsync(short _pGCItemNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<ProductGeneralCategoryItemViewModel>(
                await m_ProductGeneralCategoryItemService.GetEntityAsync(_pGCItemNo, _enableTracking, _includeDetails));
        }


        public List<ProductGeneralCategoryItemViewModel> GetList(ProductGeneralCategoryItem? _info = null, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<ProductGeneralCategoryItemViewModel>>(
               m_ProductGeneralCategoryItemService.GetList(_info, _enableTracking, _includeDetails));
        }
        public async Task<List<ProductGeneralCategoryItemViewModel>> GetListAsync(ProductGeneralCategoryItem? _info = null, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<ProductGeneralCategoryItemViewModel>>(
               await m_ProductGeneralCategoryItemService.GetListAsync(_info, _enableTracking, _includeDetails));
        }
        








        public async Task<List<ProductGeneralCategoryItemViewModel>> GetListAsync(ProductGeneralCategoryDefinitionFilter _filter, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<ProductGeneralCategoryItemViewModel>>(
               await m_ProductGeneralCategoryItemService.GetListAsync(
                   new ProductGeneralCategoryItemFilter() { ProductGeneralCategoryDefinitionFilter = _filter}
                   , _includeDetails:true));
        }
        public async Task<List<ProductGeneralCategoryItemViewModel>> GetListAsync(ProductGeneralCategoryItemFilter _filter, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<ProductGeneralCategoryItemViewModel>>(
               await m_ProductGeneralCategoryItemService.GetListAsync(_filter, _enableTracking, _includeDetails));
        }
        public async Task<List<ProductGeneralCategoryItemViewModel>> GetGeneralListAsync(byte? _pGCategoryNo = null, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<ProductGeneralCategoryItemViewModel>>(
               await m_ProductGeneralCategoryItemService.GetGeneralListAsync(_pGCategoryNo, _enableTracking, _includeDetails));
        }












        // 編輯中
        public ProductGeneralCategoryItemViewModel AddNewDefault(byte _pGCategoryNo)
        {
            var result = m_Mapper.Map<ProductGeneralCategoryItemViewModel>(
                    m_ProductGeneralCategoryItemService.AddNewDefault(_pGCategoryNo));
            return result;
        }













        public async Task<BusinessProcessResult> ProcessToInsertAsync(ProductGeneralCategoryItemViewModel _info)
        {
            return await m_ProductGeneralCategoryItemService.ProcessToInsertAsync(
                            m_Mapper.Map<ProductGeneralCategoryItem>(_info));
        }


        public async Task<BusinessProcessResult> ProcessToUpdateAsync(ProductGeneralCategoryItemViewModel _info)
        {
            return await m_ProductGeneralCategoryItemService.ProcessToUpdateAsync(
                            m_Mapper.Map<ProductGeneralCategoryItem>(_info));
        }

        public async Task<BusinessProcessResult> ProcessToDeleteAsync(ProductGeneralCategoryItemViewModel _info)
        {
            return await m_ProductGeneralCategoryItemService.ProcessToDeleteAsync(
                            m_Mapper.Map<ProductGeneralCategoryItem>(_info));
        }






    }
}
