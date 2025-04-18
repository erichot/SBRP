

namespace SBRPWebPsi.ViewModels
{
    public class SupplierViewModel : Supplier , IBasedViewModelInterface, IBasedViewSelectItemInterface
    {

        public string DisplayIdDashName => AppSystem.ComposeIdAndName(this.SupplierId, this.SupplierNameAbbr);





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
                    Value = this.SupplierNo.ToString()
                    ,
                    Text = this.DisplayIdDashName
                };
            }
        }



        public CompanyViewModel? Company { get; set; } = new CompanyViewModel();

    }








    [ValidateNever]
    public class SupplierFilterViewEntity : SupplierFilter
    {

    }










    public class SupplierSelectorEntity : PageSelectorHelperEntity
    {     

        [BindRequired]
        public short SupplierNo { get; set; }

    }


}
