

namespace SBRPWebPsi.ViewModels
{
    public class StockViewModel : Stock, IBasedViewModelInterface, IBasedViewSelectItemInterface
    {

        public string DisplayIdDashName => AppSystem.ComposeIdAndName(this.StockId, this.StockName);


       

        [ValidateNever]
        public string HtmlAttrDisabled => (m_formEditMode == FormEditModeEnum.Read) ? "disabled" : null;
        [ValidateNever]
        public EntityEditBriefHistory? FormEditHistoryBriefInfo { get; set; }

        [ValidateNever]
        public bool IsReadonly { get; set; } = false;

        private FormEditModeEnum m_formEditMode = FormEditModeEnum.Add;
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
                if (m_formEditMode == FormEditModeEnum.Read) IsReadonly = true;
            }
        }





        public SelectListItem SelectItemInfo
        {
            get
            {
                return new SelectListItem
                {
                    Value = this.StockNo.ToString()
                    ,
                    Text = this.DisplayIdDashName
                };
            }
        }





        public virtual StockViewModel? ParentStock { get; set; }



    }



    [ValidateNever]
    public class StockFilterViewEntity : StockFilter
    {
    }








    public class StockSelectorEntity : PageSelectorHelperEntity
    {        
        [BindRequired]
        public short StockNo { get; set; }

    }
}
