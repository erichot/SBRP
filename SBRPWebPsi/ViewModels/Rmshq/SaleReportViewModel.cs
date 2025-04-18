namespace SBRPWebPsi.ViewModels.Rmshq
{
    public class SaleReportViewModel
    {
    }



    public class SalePivotStoreReportFilter
    {
        public string UserID { get; set; }
        public string SearchKeywordArray { get; set; }

        
        public DateOnly? Date1 { get; set; }
        public DateOnly? Date2 { get; set; }
        public string StoreSelectionArray { get; set; }
        public bool IsGroupByColor { get; set; }
        public bool IsGroupBySize { get; set; }


        public string Date1Text
        {
            get
            {
                if (Date1 != null)
                    return this.Date1?.ToString("yyyyMMdd")??string.Empty;

                return "（未指定起始日）";
            }
        }


        public string Date2Text
        {
            get
            {
                if (Date2 != null)
                    return this.Date2?.ToString("yyyyMMdd") ?? string.Empty;

                return "（未指定結束日）";
            }
        }

    }
}
