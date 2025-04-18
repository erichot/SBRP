using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SBRPAPIPsi.BindingModels
{
    public class DataTablesBindingModel
    {
    }










    public class DT_DataTableResponse<T>
    {
        [BindNever]
        public int draw { get; set; }

        [BindNever]
        public int recordsTotal { get; set; }

        [BindNever]
        public int recordsFiltered { get; set; }

        [BindRequired]
        public List<T> data { get; set; }
    }





    public class DT_RequestAjaxEntity : IDataTablesSearchInterface
    {


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

    }




    public class DT_RequestDataColumn
    {
        [BindRequired]
        public string? data { get; set; }


        [BindRequired]
        public string? name { get; set; }


        [BindRequired]
        public bool? searchable { get; set; }


        [BindRequired]
        public bool? orderable { get; set; }


        [BindRequired]
        public DT_RequestDataColumnSearch? search { get; set; }
    }




    public class DT_RequestDataColumnSearch
    {
        [BindRequired]
        public string? value { get; set; }


        [BindRequired]
        public bool? regex { get; set; }
    }


    public class DT_RequestDataOrder
    {
        [BindRequired]
        public int? column { get; set; }


        [BindRequired]
        public string? dir { get; set; }
    }




    public class KD_FilterEntity
    {
        public string logic { get; set; }
        public List<KD_FilterDetailEntity> filters { get; set; }
    }
    public class KD_FilterDetailEntity
    {
        public string value { get; set; }
        public string field { get; set; }
        public bool ignoreCase { get; set; }
    }













    public class EdItemRequestEntity<T>
    {
        [BindRequired]
        public T data { get; set; }

        [BindRequired]
        public string action { get; set; }
    }

    public class EdItemResponseEntity<T>
    {
        [BindRequired]
        public List<T> data { get; set; }
    }


    public class EdItemListResponseEntity<T>
    {
        [BindRequired]
        public List<T> data { get; set; }

        //public EdOptionsCodeResponseEntity options { get; set; }
    }

}
