

namespace SBRPWebPsi.ViewModels
{
    public class StockTransferOrderDetailViewModel : StockTransferOrderDetail
    {
        public string ProductId => this.Product?.ProductId ?? string.Empty;
                
        public string ProductName => this.Product?.ProductName ?? string.Empty;

        public ProductViewModel? Product { get; set; }
    }
}
