

namespace SBRPAPIPsi.Interfaces
{
    public interface IDataTablesSearchInterface
    {


        int? draw { get; set; }
        int? start { get; set; }

        //int? recordsTotal { get; set; }

        //int? recordsFiltered { get; set; }

        List<DT_RequestDataColumn>? columns { get; set; }

        List<DT_RequestDataOrder>? order { get; set; }

        DT_RequestDataColumnSearch? search { get; set; }


    }





}
