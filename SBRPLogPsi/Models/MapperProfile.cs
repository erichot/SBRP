
namespace SBRPLogPsi.Models
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {

            CreateMap<InboundStockOrder, InboundStockOrderLog>();
            CreateMap<InboundStockOrderLog, InboundStockOrder>();

            CreateMap<InboundStockOrderDetail, InboundStockOrderDetailLog>();
            CreateMap<InboundStockOrderDetailLog, InboundStockOrderDetail>();
            CreateMap<InboundStockOrderDetailLog, InboundStockOrderDetailLog>();




            CreateMap<StockTransferOrder, StockTransferOrderLog>();
            CreateMap<StockTransferOrderLog, StockTransferOrder>();

            CreateMap<StockTransferOrderDetail, StockTransferOrderDetailLog>();
            CreateMap<StockTransferOrderDetailLog, StockTransferOrderDetail>();
        }
    }
}

