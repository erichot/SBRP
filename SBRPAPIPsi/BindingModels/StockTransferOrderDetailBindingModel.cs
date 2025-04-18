namespace SBRPAPIPsi.BindingModels
{
    public class StockTransferOrderDetailBindingModel : StockTransferOrderDetail
    {

        public string DT_RowId => "row_" + this.ItemNo.ToString();


        private string m_ProductId;
        public string ProductId
        {
            get { return Product?.ProductId ?? m_ProductId; }
            set { m_ProductId = value; }
        }


        [ValidateNever]
        public string ProductName => Product?.ProductName??string.Empty;


        
        [BindNever]
        [ValidateNever]
        public ProductBindingModel? Product { get; set; }

    }








    

}
