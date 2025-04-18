

namespace SBRPWebPsi.BindingServices
{
    public class OperationClassStockBindingService : ISystemIsolationGroupInterface
    {
        private readonly IMapper m_Mapper;
        private readonly OperationClassStockService m_OperationClassStockService;
        


        public OperationClassStockBindingService( IMapper mapper, OperationClassStockService OperationClassStockService)
        {
            m_Mapper = mapper;
            m_OperationClassStockService = OperationClassStockService;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_OperationClassStockService.SetSIG(_sIGNo);
        }












        public async Task<OperationClassStockViewModel> GetEntityAsync(OperationClassEnum _operationClassNo, short _storeNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<OperationClassStockViewModel>(
                await m_OperationClassStockService.GetEntityAsync(_operationClassNo, _storeNo));
        }



        public async Task<List<OperationClassStockViewModel>> GetListAsync(OperationClassStock _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<OperationClassStockViewModel>>(
                await 
                    m_OperationClassStockService
                        .GetListAsync(_info, _enableTracking, _includeDetails)
                        );
        }
        public async Task<List<OperationClassStockViewModel>> GetListAsync(short _stockNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<OperationClassStockViewModel>>(
                await
                    m_OperationClassStockService
                        .GetListAsync(_stockNo, _enableTracking, _includeDetails)
                    );
        }




















        // 編輯中
        public List<OperationClassStockViewModel> AddNewListDefault(short _stockNo)
        {
            var result = m_Mapper.Map<List<OperationClassStockViewModel>>(
                OperationClassStockService.AddNewListDefault(_stockNo));
            return result;
        }



















    }
}
