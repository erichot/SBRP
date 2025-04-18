

namespace SBRPWebPsi.BindingServices
{
    public class StoreBindingService : ISystemIsolationGroupInterface
    {
        private readonly IMapper m_Mapper;
        private readonly StoreService m_StoreService;
        


        public StoreBindingService( IMapper mapper, StoreService StoreService)
        {
            m_Mapper = mapper;
            m_StoreService = StoreService;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_StoreService.SetSIG(_sIGNo);
        }












        public async Task<StoreViewModel> GetEntityAsync(short _storeNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<StoreViewModel>(
                await m_StoreService.GetEntityAsync(_storeNo));
        }

        public async Task<StoreViewModel?> GetEntityByStockAsync(short _stockNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<StoreViewModel>(
                await m_StoreService.GetEntityByStockAsync(_stockNo));
        }




        public async Task<List<StoreViewModel>> GetListAsync(StoreFilter _filter)
        {
            return m_Mapper.Map<List<StoreViewModel>>(
                await m_StoreService.GetListAsync(_filter));
        }





















        // 編輯中
        public StoreViewModel AddNewDefault()
        {
            var result = m_Mapper.Map<StoreViewModel>(
                m_StoreService.AddNewDefault());
            return result;
        }


        public List<OperationClassStockViewModel> AddNewDefaultOperationClassStockList(short _stockNo)
        {
            return m_Mapper.Map<List<OperationClassStockViewModel>>(
                OperationClassStockService.AddNewListDefault(_stockNo));
        }










        public async Task<BusinessProcessResult> ProcessToInsertAsync(StoreViewModel _info
            , List<OperationClassStockViewModel> _operationClassStockList)
        {
            return await m_StoreService.ProcessToInsertAsync(
                            m_Mapper.Map<Store>(_info)
                            , m_Mapper.Map<List<OperationClassStock>>(_operationClassStockList));
        }






    }
}
