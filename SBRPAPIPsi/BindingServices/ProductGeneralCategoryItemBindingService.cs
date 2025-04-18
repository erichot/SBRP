namespace SBRPAPIPsi.BindingServices
{
    public class ProductGeneralCategoryItemBindingService
    {
        private readonly IMapper m_Mapper;
        private readonly ProductGeneralCategoryItemService m_ProductGeneralCategoryItemService;

        public ProductGeneralCategoryItemBindingService(IMapper mapper, ProductGeneralCategoryItemService productGeneralCategoryItemService)
        {
            m_Mapper = mapper;
            m_ProductGeneralCategoryItemService = productGeneralCategoryItemService;
        }




        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_ProductGeneralCategoryItemService.SetSIG(_sIGNo);
        }






        public async Task<List<ProductGeneralCategoryItemBindingModel>> GetListAsync(ProductGeneralCategoryItemFilterBindingModel _filter)
        {
            return 
                m_Mapper.Map<List<ProductGeneralCategoryItemBindingModel>>(
                    await m_ProductGeneralCategoryItemService.GetListAsync(
                        m_Mapper.Map<ProductGeneralCategoryItemFilter>(_filter)
                        , _includeDetails: true)   // _includeDetails 為了載入[ProductGeneralCategoryDefinition]，用以篩選SIGNo
                    );
        }

        
        
        public async Task<List<ProductGeneralCategoryItemBindingModel>> GetListAsync(ProductGeneralCategoryItemDtAjaxEntity _filter)
        {
            return
                m_Mapper.Map<List<ProductGeneralCategoryItemBindingModel>>(
                        await m_ProductGeneralCategoryItemService.GetListAsync(
                            _filter.ToEntity()
                            , _includeDetails:true)   // _includeDetails 為了載入[ProductGeneralCategoryDefinition]，用以篩選SIGNo
                    );
        }










        public async Task<BusinessProcessResult<ProductGeneralCategoryItemBindingModel>> ProcessToInsertAsync(ProductGeneralCategoryItemBindingModel _info)
        {
            return 
                m_Mapper.Map<BusinessProcessResult<ProductGeneralCategoryItemBindingModel>>(
                    await m_ProductGeneralCategoryItemService.ProcessToInsertAsync(
                        m_Mapper.Map<ProductGeneralCategoryItem>(_info)
                        )
                    );
        }

        public async Task<BusinessProcessResult> ProcessToUpdateAsync(ProductGeneralCategoryItemBindingModel _info)
        {
            return
                await m_ProductGeneralCategoryItemService.ProcessToUpdateAsync(
                    m_Mapper.Map<ProductGeneralCategoryItem>(_info)
                    );
        }

        public async Task<BusinessProcessResult> ProcessToDeleteAsync(ProductGeneralCategoryItemBindingModel _info)
        {
            return
                await m_ProductGeneralCategoryItemService.ProcessToDeleteAsync(
                    m_Mapper.Map<ProductGeneralCategoryItem>(_info)
                    );
        }





    }
}
