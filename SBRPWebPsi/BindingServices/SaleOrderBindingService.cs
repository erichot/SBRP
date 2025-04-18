

namespace SBRPWebPsi.BindingServices
{
    public class SaleOrderBindingService : ISystemIsolationGroupInterface
    {
        private readonly IMapper m_Mapper;
        private readonly SaleOrderService m_SaleOrderService;
        


        public SaleOrderBindingService( IMapper mapper, SaleOrderService SaleOrderService)
        {
            m_Mapper = mapper;
            m_SaleOrderService = SaleOrderService;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_SaleOrderService.SetSIG(_sIGNo);
        }












        public async Task<SaleOrderViewModel> GetEntityAsync(int _orderNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<SaleOrderViewModel>(
                await m_SaleOrderService.GetEntityAsync(_orderNo, _enableTracking, _includeDetails));
        }


        public List<SaleOrderViewModel> GetList(SaleOrder _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<SaleOrderViewModel>>(
               m_SaleOrderService.GetList(_info, _enableTracking, _includeDetails));
        }
        public async Task<List<SaleOrderViewModel>> GetListAsync(SaleOrder _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<SaleOrderViewModel>>(
               await m_SaleOrderService.GetListAsync(_info, _enableTracking, _includeDetails));
        }



        public async Task<List<SaleOrderViewModel>> GetListAsync(SaleOrderFilterViewModel _filter)
        {
            return m_Mapper.Map<List<SaleOrderViewModel>>(
               await m_SaleOrderService.GetListAsync(
                   m_Mapper.Map<SaleOrderFilter>(_filter))
               );
        }














        





        // 編輯中
        public async Task<SaleOrderViewModel> AddNewDefaultAsync(SBRPDataPsi.Models.SaleOrder _info)
        {
            var result = m_Mapper.Map<SaleOrderViewModel>(
                    await m_SaleOrderService.AddNewDefaultAsync(_info));
            return result;
        }

        public async Task<SaleOrderViewModel> AddDraftAsync(SaleOrderViewModel _info)
        {
            var info = await m_SaleOrderService.AddDraftAsync(
                        m_Mapper.Map<SaleOrder>(_info));
            return m_Mapper.Map<SaleOrderViewModel>(info);
        }






        public async Task<List<SaleOrderDetailViewModel>> GetDetailLogListAsync(int _logNo)
        {
            var list = await
                    m_SaleOrderService
                        .GetDetailLogListAsync(_logNo: _logNo);
            var result = m_Mapper.Map<List<SaleOrderDetailViewModel>>(list);
            return result;
        }














        public async Task<BusinessProcessResult> ProcessToInsertAsync(SaleOrderViewModel _info)
        {
            var inserting = m_Mapper.Map<SaleOrder>(_info);
            return await 
                m_SaleOrderService
                    .ProcessToInsertAsync(inserting);
        }






    }
}
