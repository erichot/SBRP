namespace SBRPWebPsi.ViewModels
{
    public class InboundStockOrderViewModel : InboundStockOrder, SBRPData.Interfaces.IEntityEditBriefHistory
    {
        public string OrderDateShortString => this.OrderDate.ToSBRPShortDateString();

        public string OrderDateString => this.OrderDate.ToSBRPDateString();

        public string StockNameAbbr => this.Stock?.StockNameAbbr ?? string.Empty;

        public string SupplierNameAbbr => this.Supplier?.SupplierNameAbbr ?? string.Empty;

        public string TotalQuantityString => this.TotalQuantity.ToNumberString();

        public string TotalAmountString => this.TotalAmount.ToMoneyString();



       
        public string HtmlAttrDisabled => AppSystem.GetHtmlAttrDisabled(m_formEditMode);

        [BindNever]
        [ValidateNever]
        public string HtmlAttrDisabledForIdField => AppSystem.GetHtmlAttrDisabledForIdField(m_formEditMode);
        
        [BindNever]
        [ValidateNever]
        public EntityEditBriefHistory? FormEditHistoryBriefInfo { get; set; }


        [BindNever]        
        [ValidateNever]
        public bool IsReadonly { get; set; } = false;


        [BindNever]        
        [ValidateNever]
        public bool IsReadonlyForIdField { get; set; } = false;


        private FormEditModeEnum m_formEditMode = FormEditModeEnum.Add;
        [BindNever]
        [ValidateNever]
        public FormEditModeEnum FormEditMode
        {
            get
            {
                return m_formEditMode;
            }
            set
            {
                m_formEditMode = value;
                IsReadonly = AppSystem.IsFormReadonly(m_formEditMode);
                IsReadonlyForIdField = AppSystem.IsFormReadonlyForIdField(m_formEditMode);
            }
        }




        /// <summary>
        /// Binding to hndPtItemNo_NewDefault
        /// Store the default value of ItemNo when adding a new record
        /// </summary>
        [BindNever]
        [ValidateNever]
        public short ItemNo_NewDefault { get; set; }



        public SupplierViewModel? Supplier { get; set; }


        public List<InboundStockOrderDetailViewModel> InboundStockOrderDetails { get; set; }

    }















    public class InboundStockOrderFilterViewModel : InboundStockOrderFilter
    {
        public SupplierFilterViewEntity SupplierFilter { get; set; } = new SupplierFilterViewEntity();

    }





}
