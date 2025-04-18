using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace SBRPAPIPsi.BindingServices
{
    public class ProductBindingService
    {
        private IMapper m_Mapper;
        private readonly ProductService m_ProductService;

        public ProductBindingService(ProductService productService, IMapper mapper)
        {
            m_ProductService = productService;
            m_Mapper = mapper;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_ProductService.SetSIG(_sIGNo);
        }






        public async Task<ProductBindingModel> GetEntityAsync(int _productNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<ProductBindingModel>(
                    await m_ProductService.GetEntityAsync(_productNo: _productNo, _enableTracking, _includeDetails));
        }
        public async Task<ProductBindingModel> GetEntityAsync(string _productId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<ProductBindingModel>(
                    await m_ProductService.GetEntityAsync(_productId: _productId, _enableTracking, _includeDetails)); 
        }
        public async Task<ProductBindingModel?> GetEntityWithProductCostAsync(string _productId)
        {
            return m_Mapper.Map<ProductBindingModel>(
                await m_ProductService.GetEntityWithProductCostAsync(_productId)
                );
        }



        public async Task<bool> IsExistedProductAsync(string _productId)
        {
            return await 
                m_ProductService.IsExistedProductAsync(_productId);
        }



    }
}
