

namespace SBRPAPIPsi.BindingModels
{
    public class ProductGeneralCategoryItemBindingModel : ProductGeneralCategoryItem, IBindingDataInterface
    {
        public string DT_RowId => "row_" + this.PGCItemNo.ToString();

        public string DisplayIdDashName => ApiSystem.ComposeIdAndName(this.PGCItemId, this.PGCItemName);

        public string SelectItemValue => this.PGCItemNo.ToString();
        public string SelectItemText => DisplayIdDashName;
        



        [JsonIgnore]
        [BindNever]
        [ValidateNever]
        public ProductGeneralCategoryDefinitionBindingModel? ProductGeneralCategoryDefinition { get; set; }
    }
    





    public class ProductGeneralCategoryItemFilterBindingModel : ProductGeneralCategoryItemFilter
    {
        
    }






    public class EdProductGeneralCategoryItemResponseEntity
    {
        public List<ProductGeneralCategoryItemBindingModel> data { get; set; }
    }


    public class EdProductGeneralCategoryItemRequestEntity
    {
        [BindRequired]
        public ProductGeneralCategoryItemBindingModel data { get; set; }


        [BindRequired]
        public string action { get; set; }
    }





    public class EdProductGeneralCategoryItemListResponseEntity
    {
        [BindRequired]
        public List<ProductGeneralCategoryItemBindingModel> data { get; set; }

        //public EdOptionsCodeResponseEntity options { get; set; }
    }





    public class ProductGeneralCategoryItemDtAjaxEntity : IDataTablesSearchInterface
    {

        [BindRequired]
        public byte PGCategoryNo { get; set; }




        [BindRequired]
        public int? draw { get; set; }

        [BindRequired]
        public int? start { get; set; }


        [BindRequired]
        public List<DT_RequestDataColumn>? columns { get; set; }

        [BindRequired]
        public List<DT_RequestDataOrder>? order { get; set; }

        [BindRequired]
        public DT_RequestDataColumnSearch? search { get; set; }




        public ProductGeneralCategoryItem ToEntity()
        {
            return new ProductGeneralCategoryItem()
            {
                PGCategoryNo = PGCategoryNo 
            };
        }

    }












}
