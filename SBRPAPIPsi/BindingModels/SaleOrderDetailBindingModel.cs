namespace SBRPAPIPsi.BindingModels
{
    public class SaleOrderDetailBindingModel : SaleOrderDetail
    {
        public string DT_RowId => "row_" + this.ItemNo.ToString();


        [ValidateNever]
        public int ProductNo { get; set; }


        

        private string m_ProductId;
        public string ProductId
        {
            get { return Product?.ProductId ?? m_ProductId; }
            set { m_ProductId = value; }
        }


        [ValidateNever]
        public string ProductName => Product?.ProductName??string.Empty;




        [ValidateNever]
        public decimal UnitPrice { get; set; }


        [ValidateNever]
        public decimal DiscountPercentage { get; set; }


        [ValidateNever]
        public decimal ActualSellingPrice { get; set; }

      

        [BindNever]
        [ValidateNever]
        public decimal SubAmount { get; set; }


        [ValidateNever]
        public string? Remark { get; set; }


        [BindNever]
        [ValidateNever]
        public ProductBindingModel? Product { get; set; }

    }




    public class SaleOrderDetailBindingModel_ForUpdating : SaleOrderDetailBindingModel
    {
        [BindNever]
        [ValidateNever]
        public string ProductId { get; set; }

    }



    public class SaleOrderDtAjaxFilter : DT_RequestAjaxEntity
    {
    
    }



    

}
