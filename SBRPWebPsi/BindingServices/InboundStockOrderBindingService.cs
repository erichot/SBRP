

namespace SBRPWebPsi.BindingServices
{
    public class InboundStockOrderBindingService : ISystemIsolationGroupInterface
    {
        private readonly IMapper m_Mapper;
        private readonly InboundStockOrderService m_InboundStockOrderService;
        


        public InboundStockOrderBindingService( IMapper mapper, InboundStockOrderService InboundStockOrderService)
        {
            m_Mapper = mapper;
            m_InboundStockOrderService = InboundStockOrderService;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_InboundStockOrderService.SetSIG(_sIGNo);
        }












        public async Task<InboundStockOrderViewModel> GetEntityAsync(int _orderNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<InboundStockOrderViewModel>(
                await m_InboundStockOrderService.GetEntityAsync(_orderNo, _enableTracking, _includeDetails));
        }


        public List<InboundStockOrderViewModel> GetList(InboundStockOrder _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<InboundStockOrderViewModel>>(
               m_InboundStockOrderService.GetList(_info, _enableTracking, _includeDetails));
        }
        public async Task<List<InboundStockOrderViewModel>> GetListAsync(InboundStockOrder _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<InboundStockOrderViewModel>>(
               await m_InboundStockOrderService.GetListAsync(_info, _enableTracking, _includeDetails));
        }



        public async Task<List<InboundStockOrderViewModel>> GetListAsync(InboundStockOrderFilterViewModel _filter)
        {
            return m_Mapper.Map<List<InboundStockOrderViewModel>>(
               await m_InboundStockOrderService.GetListAsync(
                   m_Mapper.Map<InboundStockOrderFilter>(_filter))
               );
        }














        





        // 編輯中
        public async Task<InboundStockOrderViewModel> AddNewDefaultAsync(SBRPDataPsi.Models.InboundStockOrder _info)
        {
            var result = m_Mapper.Map<InboundStockOrderViewModel>(
                    await m_InboundStockOrderService.AddNewDefaultAsync(_info));
            return result;
        }

        public async Task<InboundStockOrderViewModel> AddDraftAsync(InboundStockOrderViewModel _info)
        {
            var info = await m_InboundStockOrderService.AddDraftAsync(
                        m_Mapper.Map<InboundStockOrder>(_info));
            return m_Mapper.Map<InboundStockOrderViewModel>(info);
        }






        public async Task<List<InboundStockOrderDetailViewModel>> GetDetailLogListAsync(int _logNo)
        {
            var list = await
                    m_InboundStockOrderService
                        .GetDetailLogListAsync(_logNo: _logNo);
            var result = m_Mapper.Map<List<InboundStockOrderDetailViewModel>>(list);
            return result;
        }














        public async Task<BusinessProcessResult> ProcessToInsertAsync(InboundStockOrderViewModel _info)
        {
            var inserting = m_Mapper.Map<InboundStockOrder>(_info);
            return await 
                m_InboundStockOrderService
                    .ProcessToInsertAsync(inserting);
        }






    }
}
