

using SBRPDataPsi.Models;

namespace SBRPAPIPsi.BindingModels
{
    public class SupplierBindingModel : Supplier, IBindingDataInterface
    {
        //public string DT_RowId => "row_" + this.PGCItemNo.ToString();

        public string DisplayIdDashName => ApiSystem.ComposeIdAndName(this.SupplierId, this.SupplierName);  

        public string SelectItemValue => this.SupplierNo.ToString();
        public string SelectItemText => DisplayIdDashName;
        



        [JsonIgnore]
        [BindNever]
        [ValidateNever]
        public ProductGeneralCategoryDefinitionBindingModel? ProductGeneralCategoryDefinition { get; set; }
    }
    





    public class SupplierFilterBindingModel : SupplierFilter
    {
        
    }






    public class EdSupplierResponseEntity
    {
        public List<SupplierBindingModel> data { get; set; }
    }


    public class EdSupplierRequestEntity
    {
        [BindRequired]
        public SupplierBindingModel data { get; set; }


        [BindRequired]
        public string action { get; set; }
    }





    public class EdSupplierListResponseEntity
    {
        [BindRequired]
        public List<SupplierBindingModel> data { get; set; }

        //public EdOptionsCodeResponseEntity options { get; set; }
    }





    public class SupplierDtAjaxEntity : IDataTablesSearchInterface
    {

        [BindRequired]
        public short SupplierNo { get; set; }




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




        public Supplier ToEntity()
        {
            return new Supplier()
            {
                SupplierNo = SupplierNo
            };
        }

    }












}
