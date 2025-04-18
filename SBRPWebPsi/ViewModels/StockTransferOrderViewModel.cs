namespace SBRPWebPsi.ViewModels
{
    public class StockTransferOrderViewModel : StockTransferOrder, SBRPData.Interfaces.IEntityEditBriefHistory
    {


        public string FromStockName => this.FromStock?.StockName ?? string.Empty;

        public string ToStockName => this.ToStock?.StockName ?? string.Empty;



        [BindNever]
        [ValidateNever]
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





        public StockViewModel FromStock { get; set; }

        public StockViewModel ToStock { get; set; }



        public List<StockTransferOrderDetailViewModel> StockTransferOrderDetails { get; set; }

    }















    public class StockTransferOrderFilterViewModel : StockTransferOrderFilter
    {

    }





}
