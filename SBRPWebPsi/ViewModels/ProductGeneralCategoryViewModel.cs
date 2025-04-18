using System.ComponentModel.DataAnnotations.Schema;

namespace SBRPWebPsi.ViewModels
{
    public class ProductGeneralCategoryViewModel : ProductGeneralCategory
    {
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
        public ProductViewModel Product { get; set; }


        [BindNever]
        [ValidateNever]
        public ProductGeneralCategoryDefinitionViewModel ProductGeneralCategoryDefinition { get; set; }


        [BindNever]
        [ValidateNever]
        public  ProductGeneralCategoryItemViewModel ProductGeneralCategoryItem { get; set; }




    }
}
