namespace SBRPWebPsi.ViewModels
{
    public class ProductGeneralCategoryItemViewModel : ProductGeneralCategoryItem, IBindingDataInterface
    {

        public string DisplayIdDashName => AppSystem.ComposeIdAndName(this.PGCItemId, this.PGCItemName);


        public string SelectItemValue => this.PGCItemNo.ToString();
        public string SelectItemText => DisplayIdDashName;






        [ValidateNever]
        public string HtmlAttrDisabled => (m_formEditMode == FormEditModeEnum.Read) ? "disabled" : null;
        [ValidateNever]
        public string HtmlAttrDisabledForIdField => (m_formEditMode != FormEditModeEnum.Add) ? "disabled" : null;
        [ValidateNever]
        public EntityEditBriefHistory? FormEditHistoryBriefInfo { get; set; }

        [ValidateNever]
        public bool IsReadonly { get; set; } = false;

        [ValidateNever]
        public bool IsReadonlyForIdField { get; set; } = false;

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
                if (m_formEditMode != FormEditModeEnum.Add ) IsReadonlyForIdField = true;
            }
        }




        [ValidateNever]
        public ProductGeneralCategoryDefinitionViewModel? ProductGeneralCategoryDefinition { get; set; }
                

    }




    //public class ProductGeneralCategoryItemFilterViewModel
    //{


    //    public ProductGeneralCategoryDefinitionFilterViewModel? ProductGeneralCategoryDefinitionFilter { get; set; }


    //}

}
