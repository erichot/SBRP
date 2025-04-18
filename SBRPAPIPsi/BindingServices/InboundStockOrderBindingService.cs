namespace SBRPAPIPsi.BindingServices
{
    public class InboundStockOrderBindingService
    {
        private IMapper m_Mapper;
        private readonly ProductService m_ProductService;
        private readonly InboundStockOrderService m_InboundStockOrderService;


        public InboundStockOrderBindingService(IMapper mapper
            ,ProductService productService
            ,InboundStockOrderService inboundStockOrderService)
        {
            m_Mapper = mapper;
            m_ProductService = productService;
            m_InboundStockOrderService = inboundStockOrderService;
            
            m_ProductService.SetSIG(m_SIGNo);
            m_InboundStockOrderService.SetSIG(m_SIGNo);
        }


        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_InboundStockOrderService.SetSIG(_sIGNo);
        }











        public async Task<List<InboundStockOrderDetailBindingModel>> GetDetailListAsync(int _orderNo, int? _draftNo)
        {
            var result = new List<InboundStockOrderDetailBindingModel>();

            if (_orderNo.IsNullOrDefault() == false)
            {
                result = m_Mapper.Map<List<InboundStockOrderDetailBindingModel>>(
                    await m_InboundStockOrderService
                        .GetDetailListAsync(_orderNo: _orderNo, _includeDetails:true));
            }

            if (_draftNo.IsNullOrDefault() == false)
            {
                result = m_Mapper.Map<List<InboundStockOrderDetailBindingModel>>(
                    await m_InboundStockOrderService
                        .GetDetailLogListAsync(_logNo: _draftNo.ToInt()));
            }

            return result;
        }







        public async Task<InboundStockOrderDetailBindingModel> AddDetailEntityAsync(InboundStockOrderDetailBindingModel _info)
        {
            var inserting = m_Mapper.Map<InboundStockOrderDetail?>(_info);
            InboundStockOrderDetail? inserted = null;


            if (_info.LogNo.IsNullOrDefault() == false)
            {
                inserted = await
                    m_InboundStockOrderService
                        .InsertDetailLogAsync(inserting);

                if (inserted != null)
                    inserted.Product = await m_ProductService.GetEntityAsync(inserted.ProductNo, _enableTracking:false, _includeDetails:false);
            }

            return m_Mapper.Map<InboundStockOrderDetailBindingModel>(inserted);
        }


        public async Task<InboundStockOrderDetailBindingModel> UpdateDetailEntityAsync(InboundStockOrderDetailBindingModel_ForUpdating _info)
        {
            var updating = m_Mapper.Map<InboundStockOrderDetail?>(_info);
            InboundStockOrderDetail? updated = null;


            if (_info.LogNo.IsNullOrDefault() == false)
            {
                updated = await
                    m_InboundStockOrderService
                        .UpdateDetailLogAsync(updating);

                if (updated != null)
                    updated.Product = await m_ProductService.GetEntityAsync(updated.ProductNo, _enableTracking: false, _includeDetails: false);
            }

            return m_Mapper.Map<InboundStockOrderDetailBindingModel>(updated);
        }




        public async Task DeleteDetailEntityAsync(InboundStockOrderDetailBindingModel _info)
        {
            //if (_info.OrderNo.IsNullOrDefault() == false)
            //{
            //    await m_InboundStockOrderService.DeleteDetailAsync(_orderNo, _itemNo);
            //}
            await m_InboundStockOrderService.DeleteDetailLogAsync(
                m_Mapper.Map<InboundStockOrderDetail>(_info));
        }




    }
}
