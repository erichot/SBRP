

using SBRPDataPsi.Models;

namespace SBRPAPIPsi.BindingModels
{
    public class StockBindingModel : Stock, IBindingDataInterface
    {
        //public string DT_RowId => "row_" + this.PGCItemNo.ToString();

        public string DisplayIdDashName => ApiSystem.ComposeIdAndName(this.StockId, this.StockName);  

        public string SelectItemValue => this.StockNo.ToString();
        public string SelectItemText => DisplayIdDashName;
        



    }
    





    public class StockFilterBindingModel : StockFilter
    {
        
    }






    public class EdStockResponseEntity
    {
        public List<StockBindingModel> data { get; set; }
    }


    public class EdStockRequestEntity
    {
        [BindRequired]
        public StockBindingModel data { get; set; }


        [BindRequired]
        public string action { get; set; }
    }





    public class EdStockListResponseEntity
    {
        [BindRequired]
        public List<StockBindingModel> data { get; set; }

        //public EdOptionsCodeResponseEntity options { get; set; }
    }





    public class StockDtAjaxEntity : IDataTablesSearchInterface
    {

        [BindRequired]
        public short StockNo { get; set; }




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




        public Stock ToEntity()
        {
            return new Stock()
            {
                StockNo = StockNo
            };
        }

    }












}
