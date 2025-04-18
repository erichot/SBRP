namespace SBRPAPIPsi.BindingServices
{
    public class StockBindingService
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






        public async Task<List<StockBindingModel>> GetListAsync(StockFilterBindingModel _filter)
        {
            return 
                m_Mapper.Map<List<StockBindingModel>>(
                    await m_StockService.GetListAsync(
                        m_Mapper.Map<StockFilter>(_filter)
                        )
                    );
        }

        
        
        public async Task<List<StockBindingModel>> GetListAsync(StockDtAjaxEntity _filter)
        {
            return
                m_Mapper.Map<List<StockBindingModel>>(
                        await m_StockService.GetListAsync(
                            _filter.ToEntity()
                        )
                    );
        }










        public async Task<BusinessProcessResult<StockBindingModel>> ProcessToInsertAsync(StockBindingModel _info)
        {
            return 
                m_Mapper.Map<BusinessProcessResult<StockBindingModel>>(
                    await m_StockService.ProcessToInsertAsync(
                        m_Mapper.Map<Stock>(_info)
                        )
                    );
        }

       









    }
}
