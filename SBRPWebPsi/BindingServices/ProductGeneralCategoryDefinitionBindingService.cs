

using SBRPDataPsi.Models;

namespace SBRPWebPsi.BindingServices
{
    public class ProductGeneralCategoryDefinitionBindingService : ISystemIsolationGroupInterface
    {
        private readonly IMapper m_Mapper;
        private readonly ProductGeneralCategoryDefinitionService m_ProductGeneralCategoryDefinitionService;
        


        public ProductGeneralCategoryDefinitionBindingService( IMapper mapper, ProductGeneralCategoryDefinitionService ProductGeneralCategoryDefinitionService)
        {
            m_Mapper = mapper;
            m_ProductGeneralCategoryDefinitionService = ProductGeneralCategoryDefinitionService;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_ProductGeneralCategoryDefinitionService.SetSIG(_sIGNo);
        }












        public async Task<ProductGeneralCategoryDefinitionViewModel> GetEntityAsync(byte _pGCategoryNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<ProductGeneralCategoryDefinitionViewModel>(
                await m_ProductGeneralCategoryDefinitionService.GetEntityAsync(_pGCategoryNo, _enableTracking, _includeDetails));
        }


        public List<ProductGeneralCategoryDefinitionViewModel> GetList(ProductGeneralCategoryDefinition _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<ProductGeneralCategoryDefinitionViewModel>>(
               m_ProductGeneralCategoryDefinitionService.GetList(_info, _enableTracking, _includeDetails));
        }
        public async Task<List<ProductGeneralCategoryDefinitionViewModel>> GetListAsync(ProductGeneralCategoryDefinition _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<ProductGeneralCategoryDefinitionViewModel>>(
               await m_ProductGeneralCategoryDefinitionService.GetListAsync(_info, _enableTracking, _includeDetails));
        }










        public async Task<List<ProductGeneralCategoryDefinitionViewModel>> GetGeneralListAsync()
        {
            return m_Mapper.Map<List<ProductGeneralCategoryDefinitionViewModel>>(
                await m_ProductGeneralCategoryDefinitionService.GetGeneralListAsync()
                );
        }














        public ValidationResultEntity IsValidEntity(ProductGeneralCategoryDefinitionViewModel _info, FormEditModeEnum _formEditMode)
        {
            return m_ProductGeneralCategoryDefinitionService.IsValidEntity(
                m_Mapper.Map<ProductGeneralCategoryDefinition>(_info), (byte)_formEditMode);
        }


        // 編輯中
        public ProductGeneralCategoryDefinitionViewModel AddNewDefault()
        {
            var result = m_Mapper.Map<ProductGeneralCategoryDefinitionViewModel>(
                    m_ProductGeneralCategoryDefinitionService.AddNewDefault());
            return result;
        }













        public async Task<BusinessProcessResult> ProcessToInsertAsync(ProductGeneralCategoryDefinitionViewModel _info)
        {
            return await m_ProductGeneralCategoryDefinitionService.ProcessToInsertAsync(
                            m_Mapper.Map<ProductGeneralCategoryDefinition>(_info));
        }


        public async Task<BusinessProcessResult> ProcessToDeleteAsync(ProductGeneralCategoryDefinitionViewModel _info)
        {
            return await m_ProductGeneralCategoryDefinitionService.ProcessToDeleteAsync(
                            m_Mapper.Map<ProductGeneralCategoryDefinition>(_info));
        }






    }
}
