namespace SBRPWebPsi.ViewModels
{
    public class ProductIdStructureDefinitionViewModel : ProductIdStructureDefinition
    {


        [BindNever]
        [ValidateNever]
        public string PGCategoryName => this.ProductGeneralCategoryDefinition?.PGCategoryName ?? string.Empty;


        [BindNever]
        [ValidateNever]
        public string ItemIdMinLengthText => this.ProductGeneralCategoryDefinition?.ItemIdMinLength.ToString() ?? string.Empty;


        [BindNever]
        [ValidateNever]
        public string ItemIdMaxLengthText => this.ProductGeneralCategoryDefinition?.ItemIdMaxLength.ToString() ?? string.Empty;


        [BindNever]
        [ValidateNever]
        public string HtmlAttrDisabled => (m_formEditMode == FormEditModeEnum.Read) ? "disabled" : null;
        

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
                if (m_formEditMode == FormEditModeEnum.Read) IsReadonly = true;
            }
        }




        [BindNever]
        [ValidateNever]
        public ProductGeneralCategoryDefinitionViewModel? ProductGeneralCategoryDefinition { get; set; }


    }





}
