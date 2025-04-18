

namespace SBRPWebPsi.ViewModels
{
    public class StoreViewModel : Store
    {



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









        public StockViewModel? Stock { get; set; }

        public StoreViewModel? ParentStore { get; set; }

        public CompanyViewModel? Company { get; set; }

    }
}
