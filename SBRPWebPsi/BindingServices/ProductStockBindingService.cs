using System.Text;

namespace SBRPWebPsi.BindingServices
{
    public class ProductStockBindingService : ISystemIsolationGroupInterface
    {
        private readonly IMapper m_Mapper;
        private readonly ProductStockService m_ProductStockService;
        


        public ProductStockBindingService(IMapper mapper, ProductStockService ProductStockService)
        {
            m_Mapper = mapper;
            m_ProductStockService = ProductStockService;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_ProductStockService.SetSIG(_sIGNo);
        }













        public StringBuilder GET_ProductStock_PivotReport(ProductStockPivotReportViewFilter _filter)
        {
            return m_ProductStockService.GET_ProductStock_PivotReport(
                m_Mapper.Map<ProductStockPivotReportFilter>(_filter));
            //var result = new StringBuilder();
            //var dt = m_ProductStockService.GET_ProductStock_PivotReport(
            //    m_Mapper.Map<ProductStockPivotReportFilter>(_filter));

            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    result = new StringBuilder(
            //        System.Text.Json.JsonSerializer.Serialize<System.d>(dt));
            //}

            //return result;
        }




    }
}
