namespace SBRPAPIPsi.BindingServices
{
    public class StockTransferOrderBindingService
    {
        private IMapper m_Mapper;
        private readonly ProductService m_ProductService;
        private readonly StockTransferOrderService m_StockTransferOrderService;


        public StockTransferOrderBindingService(IMapper mapper
            ,ProductService productService
            ,StockTransferOrderService inboundStockOrderService)
        {
            m_Mapper = mapper;
            m_ProductService = productService;
            m_StockTransferOrderService = inboundStockOrderService;
            
            m_ProductService.SetSIG(m_SIGNo);
            m_StockTransferOrderService.SetSIG(m_SIGNo);
        }


        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_StockTransferOrderService.SetSIG(_sIGNo);
        }











        public async Task<List<StockTransferOrderDetailBindingModel>> GetDetailListAsync(int _orderNo, int? _draftNo)
        {
            var result = new List<StockTransferOrderDetailBindingModel>();

            if (_orderNo.IsNullOrDefault() == false)
            {
                result = m_Mapper.Map<List<StockTransferOrderDetailBindingModel>>(
                    await m_StockTransferOrderService.GetDetailListAsync(_orderNo: _orderNo, _includeDetails:true));
            }

            if (_draftNo.IsNullOrDefault() == false)
            {
                result = m_Mapper.Map<List<StockTransferOrderDetailBindingModel>>(
                    await m_StockTransferOrderService.GetDetailLogListAsync(_logNo: _draftNo.ToInt()));
            }

            return result;
        }







        public async Task<StockTransferOrderDetailBindingModel> AddDetailEntityAsync(StockTransferOrderDetailBindingModel _info)
        {
            var inserting = m_Mapper.Map<StockTransferOrderDetail?>(_info);
            StockTransferOrderDetail? inserted = null;


            if (_info.LogNo.IsNullOrDefault() == false)
            {
                inserted = await
                    m_StockTransferOrderService
                        .InsertDetailLogAsync(inserting);

                inserted.Product = await m_ProductService.GetEntityAsync(inserted.ProductNo);
            }

            return m_Mapper.Map<StockTransferOrderDetailBindingModel>(inserted);
        }







    }
}
