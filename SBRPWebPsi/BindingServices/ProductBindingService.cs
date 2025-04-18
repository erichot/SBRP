

namespace SBRPWebPsi.BindingServices
{
    public class ProductBindingService : ISystemIsolationGroupInterface
    {
        private readonly IMapper m_Mapper;
        private readonly ProductService m_ProductService;
        


        public ProductBindingService( IMapper mapper, ProductService ProductService)
        {
            m_Mapper = mapper;
            m_ProductService = ProductService;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_ProductService.SetSIG(_sIGNo);
        }












        public async Task<ProductViewModel> GetEntityAsync(int _productNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<ProductViewModel>(
                await m_ProductService.GetEntityAsync(_productNo, _enableTracking, _includeDetails));
        }


        public List<ProductViewModel> GetList(Product _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<ProductViewModel>>(
               m_ProductService.GetList(_info, _enableTracking, _includeDetails));
        }
        public async Task<List<ProductViewModel>> GetListAsync(Product _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<ProductViewModel>>(
               await m_ProductService.GetListAsync(_info, _enableTracking, _includeDetails));
        }



        public async Task<List<ProductViewModel>> GetListAsync(ProductFilterViewModel _filter)
        {
            return m_Mapper.Map<List<ProductViewModel>>(
               await m_ProductService.GetListAsync(
                   m_Mapper.Map<ProductFilter>(_filter))
               );
        }




















        // 編輯中
        public async Task<ProductViewModel> AddNewDefaultAsync()
        {
            var result = m_Mapper.Map<ProductViewModel>(
                    await m_ProductService.AddNewDefaultAsync());
            return result;
        }













        public ValidationResultEntity IsValidEntity(ProductViewModel _info, FormEditModeEnum _formEditMode = default)
        {            
            return m_ProductService.IsValidEntity(
                m_Mapper.Map<Product>(_info), (byte)_formEditMode);
        }






        public async Task<BusinessProcessResult> ProcessToInsertAsync(ProductViewModel _info)
        {
            return await 
                m_ProductService
                    .ProcessToInsertAsync(
                        m_Mapper.Map<Product>(_info));
        }


        public async Task<BusinessProcessResult> ProcessToDeleteAsync(ProductViewModel _info)
        {
            return await
                m_ProductService
                    .ProcessToDeleteAsync(
                        m_Mapper.Map<Product>(_info));
        }











    }
}
