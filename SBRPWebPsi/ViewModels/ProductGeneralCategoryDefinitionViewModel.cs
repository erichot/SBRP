namespace SBRPWebPsi.ViewModels
{
    public class ProductGeneralCategoryDefinitionViewModel : ProductGeneralCategoryDefinition
    {

        


        [BindNever]
        [ValidateNever]
        public string HtmlAttrDisabled => AppSystem.IsFormReadonly(m_formEditMode) ? "disabled" : null;

        [BindNever]
        [ValidateNever]
        public EntityEditBriefHistory? FormEditHistoryBriefInfo { get; set; }

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
                IsReadonly = AppSystem.IsFormReadonly(m_formEditMode);
            }
        }






    }




    //public class ProductGeneralCategoryDefinitionFilterViewModel
    //{
    //    public string PGCategoryId { get; set; } = string.Empty;
    //}





}
