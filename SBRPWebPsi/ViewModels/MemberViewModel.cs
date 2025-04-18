namespace SBRPWebPsi.ViewModels
{
    public class MemberViewModel : Member
    {

        public string IdAndName => AppSystem.ComposeIdAndName(this.MemberId, this.MemberName);



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





        public PersonViewModel? Person { get; set; }
    }










    public class MemberFilterViewModel : MemberFilter
    {

    }





}
