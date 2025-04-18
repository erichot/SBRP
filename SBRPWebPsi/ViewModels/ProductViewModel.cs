namespace SBRPWebPsi.ViewModels
{
    public class ProductViewModel : Product
    {

        public string IdAndName => AppSystem.ComposeIdAndName(this.ProductId, this.ProductName);


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


        public List<ProductCostViewModel>? ProductCosts { get; set; }

        public List<ProductPriceViewModel>? ProductPrices { get; set; }

        public List<ProductSupplierViewModel>? ProductSuppliers { get; set; }


        // 留意List.Add的順序，需吻合[ProductGeneralCategoryDefinition].[PGCOrderNo]
        public List<ProductGeneralCategoryViewModel>? ProductGeneralCategories { get; set; }
















        // 僅用於資料編輯時預先載入所需欄位用途
        // 客戶於新增／編輯[Product]時，所需使用的 [ProductGeneralCategory] 數量已是固定的，
        // 一個[Product]所關聯的[ProductGeneralCategory]筆數，來自於[ProductGeneralCategoryDefinition]所指定
        //[BindNever]
        //[ValidateNever]
        //public List<ProductGeneralCategoryDefinitionViewModel>? ProductGeneralCategoryDefinitions { get; set; }

        //public string GetPGCategoryName(byte _pGCategoryNo) => 
        //    ProductGeneralCategoryDefinitions?
        //        .Where(c => c.PGCategoryNo == _pGCategoryNo)?
        //        .FirstOrDefault()?.PGCategoryName ?? string.Empty;



        // 僅用於資料編輯時預先載入所需欄位用途
        //[BindNever]
        //[ValidateNever]
        //public List<ProductGeneralCategoryItemViewModel> ProductGeneralCategoryItems { get; set; }

        //public SelectList GetPGCISelectList(byte _pGCategoryNo) => 
        //    ProductGeneralCategoryItems
        //        .Where(c => c.PGCategoryNo == _pGCategoryNo)
        //        .ToList()
        //        .ToSelectList();


        // 僅用於資料編輯時預先載入所需欄位用途
        [BindNever]
        [ValidateNever]
        public List<ProductIdStructureDefinitionViewModel>? ProductIdStructureDefinitions { get; set; }


        // 僅用於資料編輯時預先載入所需欄位用途
        //[BindNever]
        //[ValidateNever]
        //public List<ProductPriceDefinition>? ProductPriceDefinitions { get; set; }

    }










    public class ProductFilterViewModel : ProductFilter
    {

    }





}
