namespace SBRPWebPsi.ViewModels
{
    public class ProductPriceDefinitionViewModel : ProductPriceDefinition, IBasedViewSelectItemInterface, IBasedViewSelectItemNameInterface, IBasedViewSelectItemCodeInterface
    {

       

        [BindNever]
        [ValidateNever]
        public string HtmlAttrDisabled => (m_formEditMode == FormEditModeEnum.Read) ? "disabled" : null;

        [BindNever]
        [ValidateNever]
        public string HtmlAttrDisabledForIdField => (m_formEditMode != FormEditModeEnum.Add) ? "disabled" : null;
        
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
                if (m_formEditMode == FormEditModeEnum.Read) IsReadonly = true;
                if (m_formEditMode != FormEditModeEnum.Add) IsReadonlyForIdField = true;
            }
        }








        public SelectListItem SelectItemInfo
        {
            get
            {
                return new SelectListItem
                {
                    Value = this.PriceNo.ToString()
                    ,
                    Text = this.PriceDefinitionName
                };
            }
        }

        public SelectListItem SelectItemNameInfo
        {
            get
            {
                return new SelectListItem
                {
                    Value = this.PriceNo.ToString()
                    ,
                    Text = this.PriceDefinitionDisplayName
                };
            }
        }



        public SelectListItem SelectItemCodeInfo
        {
            get
            {
                return new SelectListItem
                {
                    Value = this.PriceNo.ToString()
                    ,
                    Text = this.PriceDefinitionDisplayName
                };
            }
        }







    }
}
