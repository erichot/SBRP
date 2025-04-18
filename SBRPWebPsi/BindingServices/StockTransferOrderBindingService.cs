

namespace SBRPWebPsi.BindingServices
{
    public class StockTransferOrderBindingService : ISystemIsolationGroupInterface
    {
        private readonly IMapper m_Mapper;
        private readonly StockTransferOrderService m_StockTransferOrderService;
        


        public StockTransferOrderBindingService( IMapper mapper, StockTransferOrderService StockTransferOrderService)
        {
            m_Mapper = mapper;
            m_StockTransferOrderService = StockTransferOrderService;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_StockTransferOrderService.SetSIG(_sIGNo);
        }












        public async Task<StockTransferOrderViewModel> GetEntityAsync(int _orderNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<StockTransferOrderViewModel>(
                    await m_StockTransferOrderService.GetEntityAsync(_orderNo, _enableTracking, _includeDetails));
        }


        public List<StockTransferOrderViewModel> GetList(StockTransferOrder _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<StockTransferOrderViewModel>>(
               m_StockTransferOrderService.GetList(_info, _enableTracking, _includeDetails));
        }
        public async Task<List<StockTransferOrderViewModel>> GetListAsync(StockTransferOrder _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<StockTransferOrderViewModel>>(
               await m_StockTransferOrderService.GetListAsync(_info, _enableTracking, _includeDetails));
        }



        public async Task<List<StockTransferOrderViewModel>> GetListAsync(StockTransferOrderFilterViewModel _filter)
        {
            return m_Mapper.Map<List<StockTransferOrderViewModel>>(
               await m_StockTransferOrderService.GetListAsync(
                   m_Mapper.Map<StockTransferOrderFilter>(_filter))
               );
        }














        





        // 編輯中
        public async Task<StockTransferOrderViewModel> AddNewDefaultAsync(SBRPDataPsi.Models.StockTransferOrder _info)
        {
            var newDefault = await m_StockTransferOrderService.AddNewDefaultAsync(_info);
            var result = m_Mapper.Map<StockTransferOrderViewModel>(
                    newDefault);
            return result;
        }

        public async Task<StockTransferOrderViewModel> AddDraftAsync(StockTransferOrderViewModel _info)
        {
            var info = await m_StockTransferOrderService.AddDraftAsync(
                        m_Mapper.Map<StockTransferOrder>(_info));
            return m_Mapper.Map<StockTransferOrderViewModel>(info);
        }






        public async Task<List<StockTransferOrderDetailViewModel>> GetDetailLogListAsync(int _logNo)
        {
            var list = await
                    m_StockTransferOrderService
                        .GetDetailLogListAsync(_logNo: _logNo);
            var result = m_Mapper.Map<List<StockTransferOrderDetailViewModel>>(list);
            return result;
        }














        public async Task<BusinessProcessResult> ProcessToInsertAsync(StockTransferOrderViewModel _info)
        {
            var inserting = m_Mapper.Map<StockTransferOrder>(_info);
            return await 
                m_StockTransferOrderService
                    .ProcessToInsertAsync(inserting);
        }






    }
}
