using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Data;
using Newtonsoft.Json;

using SBRPDataRmshq.Models;
using SBRPDataRmshq.Services;
using SBRPWebPsi.ViewModels.Rmshq;
using SBRPWebPsi.BindingServices.Rmshq;
using System.Diagnostics.CodeAnalysis;




namespace SBRPWebPsi.Pages.Rmshqs.Reports
{
    [AllowAnonymous]
    public class SaleOrderPivotModel : PageModel
    {
        private readonly SBRPWebPsi.BindingServices.Rmshq.StoreBindingService m_StoreBindingService;
        private readonly SBRPDataRmshq.Services.SaleOrderService m_SaleOrderService;

        public SaleOrderPivotModel(SBRPWebPsi.BindingServices.Rmshq.StoreBindingService storeBindingService
            , SBRPDataRmshq.Services.SaleOrderService saleOrderService)
        {
            m_StoreBindingService = storeBindingService;
            m_SaleOrderService = saleOrderService;
        }


        public string PG_FileNameXlsx { get; set; } = "nofileanme.xls";

        public string PG_PivotTableJsonData { get; set; }

        public List<SelectListItem> PG_Stores { get; set; }

        
        public bool PG_IsPostBack { get; set; }

        [BindProperty]
        public SalePivotStoreReportFilter PG_Filter { get; set; }


        //public string PG_SearchKeywordString { get; set; }

        //[BindProperty]
        //public string PG_StoreSelectionArray { get; set; }

        //[BindProperty]
        //public DateOnly? PG_Date1 { get; set; }

        //[BindProperty]
        //public DateOnly? PG_Date2 { get; set; }

        //[BindProperty]
        //public bool PG_IsGroupByColor { get; set; }

        //[BindProperty]
        //public bool PG_IsGroupBySize { get; set; }









        public async Task Page_InitialAsync()
        {
            ViewData["Title"] = "3C銷售數據查詢表";
        }

        public async Task Page_LoadAsync()
        {
            PG_Stores = await m_StoreBindingService.GetSelectListItemAsync(null);

            // PostBack 之後，還原Post之前的選擇狀態
            if (PG_IsPostBack && string.IsNullOrEmpty(PG_Filter.StoreSelectionArray) == false)
            {
                var storeSelection = PG_Filter.StoreSelectionArray.Split(",");
                if (storeSelection != null)
                {
                    PG_Stores
                        .Where(c => storeSelection.Contains(c.Value))
                        .ToList()
                        .ForEach(r => r.Selected = true);
                }
            }

            ViewData[AppSystemRmshq.VD_SEL_StoreList] = PG_Stores;
        }









        public async Task OnGetAsync()
        {
            await Page_InitialAsync();

            PG_Filter = new SalePivotStoreReportFilter();

            await Page_LoadAsync();
        }






        public async Task<IActionResult> OnPostSearchAsync()
        {
            await Page_InitialAsync();

            PG_FileNameXlsx = PG_Filter.Date1Text
                    + "-"
                    + PG_Filter.Date2Text
                    + "銷售數據";
            PG_PivotTableJsonData = GetReportJsonData(PG_Filter);

            PG_IsPostBack = true;

            await Page_LoadAsync();
            return Page();
        }





        public string GetReportJsonData(SalePivotStoreReportFilter _filter)
        {
            var _userID = _filter.UserID;
            var _searchKeywordArray = _filter.SearchKeywordArray;
            var _date1 = _filter.Date1;
            var _date2 = _filter.Date2;
            var _storeSelectionArray = _filter.StoreSelectionArray;
            var _isGroupByColor = _filter.IsGroupByColor;
            var _isGroupBySize = _filter.IsGroupBySize;


            var dt = m_SaleOrderService.SP_GET_OR_SaleOrder_Pivot_SaleQty(
                    _userID
                    , _searchKeywordArray, _date1, _date2
                , _storeSelectionArray
                , _isGroupByColor, _isGroupBySize);


            var result = JsonConvert.SerializeObject(dt);
            return result;
        }






    }
}
