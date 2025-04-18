

namespace SBRPWebPsi.BindingServices
{
    public class ProductIdStructureDefinitionBindingService : ISystemIsolationGroupInterface
    {
        private readonly IMapper m_Mapper;
        private readonly ProductIdStructureDefinitionService m_ProductIdStructureDefinitionService;
        


        public ProductIdStructureDefinitionBindingService( IMapper mapper, ProductIdStructureDefinitionService ProductIdStructureDefinitionService)
        {
            m_Mapper = mapper;
            m_ProductIdStructureDefinitionService = ProductIdStructureDefinitionService;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_ProductIdStructureDefinitionService.SetSIG(_sIGNo);
        }














        public List<ProductIdStructureDefinitionViewModel> GetList(ProductIdStructureDefinition _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<ProductIdStructureDefinitionViewModel>>(
               m_ProductIdStructureDefinitionService.GetList(_info, _enableTracking, _includeDetails));
        }
        public async Task<List<ProductIdStructureDefinitionViewModel>> GetListAsync(ProductIdStructureDefinition? _info = null, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<ProductIdStructureDefinitionViewModel>>(
               await m_ProductIdStructureDefinitionService.GetListAsync(_info, _enableTracking, _includeDetails));
        }


        public async Task<List<ProductIdStructureDefinitionViewModel>> GetGeneralListAsync(bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<ProductIdStructureDefinitionViewModel>>(
               await m_ProductIdStructureDefinitionService.GetGeneralListAsync(_enableTracking, _includeDetails));
        }





















        // 編輯中
        public List<ProductIdStructureDefinitionViewModel> AddNewDefault()
        {
            var result = m_Mapper.Map<List<ProductIdStructureDefinitionViewModel>>(
                    m_ProductIdStructureDefinitionService.AddNewDefault());
            return result;
        }
        public async Task<List<ProductIdStructureDefinitionViewModel>> AddNewDefaultAsync()
        {
            var result = m_Mapper.Map<List<ProductIdStructureDefinitionViewModel>>(
                    await m_ProductIdStructureDefinitionService.AddNewDefaultAsync());
            return result;
        }












        public async Task<BusinessProcessResult> ProcessToInsertAsync(List<ProductIdStructureDefinitionViewModel> _list)
        {
            return await 
                m_ProductIdStructureDefinitionService
                    .ProcessToInsertAsync(
                        m_Mapper.Map<List<ProductIdStructureDefinition>>(_list));
        }






    }
}
