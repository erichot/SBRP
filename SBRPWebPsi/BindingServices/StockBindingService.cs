

namespace SBRPWebPsi.BindingServices
{
    public class StockBindingService : ISystemIsolationGroupInterface
    {
        private readonly IMapper m_Mapper;
        private readonly StockService m_StockService;
        


        public StockBindingService(IMapper mapper, StockService StockService)
        {
            m_Mapper = mapper;
            m_StockService = StockService;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_StockService.SetSIG(_sIGNo);
        }












        public async Task<StockViewModel> GetEntityAsync(short _storeNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<StockViewModel>(
                await m_StockService.GetEntityAsync(_storeNo));
        }






        public async Task<List<StockViewModel>> GetListAsync(StockFilter _filter)
        {
            return m_Mapper.Map<List<StockViewModel>>(
                await m_StockService.GetListAsync(_filter));
        }








        public async Task<List<SelectListItem>> GetSelectItemListAsync(OperationClassEnum _operationClass)
        {
            var list = m_Mapper.Map<List<StockViewModel>>(
                await m_StockService.GetListAsync(_operationClass));

            var result = list.ToSelectListItem<StockViewModel>();

            return result;
        }












    }
}
