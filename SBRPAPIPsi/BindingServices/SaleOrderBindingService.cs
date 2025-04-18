namespace SBRPAPIPsi.BindingServices
{
    public class SaleOrderBindingService
    {
        private IMapper m_Mapper;
        private readonly ProductService m_ProductService;
        private readonly SaleOrderService m_SaleOrderService;


        public SaleOrderBindingService(IMapper mapper
            ,ProductService productService
            ,SaleOrderService SaleOrderService)
        {
            m_Mapper = mapper;
            m_ProductService = productService;
            m_SaleOrderService = SaleOrderService;
            
            m_ProductService.SetSIG(m_SIGNo);
            m_SaleOrderService.SetSIG(m_SIGNo);
        }


        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_SaleOrderService.SetSIG(_sIGNo);
        }











        public async Task<List<SaleOrderDetailBindingModel>> GetDetailListAsync(int _orderNo, int? _draftNo)
        {
            var result = new List<SaleOrderDetailBindingModel>();

            if (_orderNo.IsNullOrDefault() == false)
            {
                result = m_Mapper.Map<List<SaleOrderDetailBindingModel>>(
                    await m_SaleOrderService
                        .GetDetailListAsync(_orderNo: _orderNo, _includeDetails:true));
            }

            if (_draftNo.IsNullOrDefault() == false)
            {
                result = m_Mapper.Map<List<SaleOrderDetailBindingModel>>(
                    await m_SaleOrderService
                        .GetDetailLogListAsync(_logNo: _draftNo.ToInt()));
            }

            return result;
        }







        public async Task<SaleOrderDetailBindingModel> AddDetailEntityAsync(SaleOrderDetailBindingModel _info)
        {
            var inserting = m_Mapper.Map<SaleOrderDetail?>(_info);
            SaleOrderDetail? inserted = null;


            if (_info.LogNo.IsNullOrDefault() == false)
            {
                inserted = await
                    m_SaleOrderService
                        .InsertDetailLogAsync(inserting);

                if (inserted != null)
                    inserted.Product = await m_ProductService.GetEntityAsync(inserted.ProductNo, _enableTracking:false, _includeDetails:false);
            }

            return m_Mapper.Map<SaleOrderDetailBindingModel>(inserted);
        }


        public async Task<SaleOrderDetailBindingModel> UpdateDetailEntityAsync(SaleOrderDetailBindingModel_ForUpdating _info)
        {
            var updating = m_Mapper.Map<SaleOrderDetail?>(_info);
            SaleOrderDetail? updated = null;


            if (_info.LogNo.IsNullOrDefault() == false)
            {
                updated = await
                    m_SaleOrderService
                        .UpdateDetailLogAsync(updating);

                if (updated != null)
                    updated.Product = await m_ProductService.GetEntityAsync(updated.ProductNo, _enableTracking: false, _includeDetails: false);
            }

            return m_Mapper.Map<SaleOrderDetailBindingModel>(updated);
        }




        public async Task DeleteDetailEntityAsync(SaleOrderDetailBindingModel _info)
        {
            //if (_info.OrderNo.IsNullOrDefault() == false)
            //{
            //    await m_SaleOrderService.DeleteDetailAsync(_orderNo, _itemNo);
            //}
            await m_SaleOrderService.DeleteDetailLogAsync(
                m_Mapper.Map<SaleOrderDetail>(_info));
        }




    }
}
