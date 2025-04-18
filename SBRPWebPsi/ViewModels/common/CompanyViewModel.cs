using SBRPData.Models;

namespace SBRPWebPsi.ViewModels.common
{
    public class CompanyViewModel : Company
    {







        [BindNever]
        [ValidateNever]
        public string HtmlAttrDisabled => (m_formEditMode == FormEditModeEnum.Read) ? "disabled" : null;
        [BindNever]
        [ValidateNever]
        public EntityEditBriefHistory FormEditHistoryBriefInfo { get; set; }


        [BindNever]
        [ValidateNever]
        public bool IsReadonly { get; set; } = false;

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
                if (m_formEditMode == FormEditModeEnum.Read) IsReadonly = true;
            }
        }
       


















        public List<CompanyContactPersonViewModel> CompanyContactPersons { get; set; } = new List<CompanyContactPersonViewModel>();




    }
}
