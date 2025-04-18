using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SBRPWebPsi.Pages.Shared.BasicInfo
{
    [Authorize]
    public class SupplierSelectorHelperModel : PageModel
    {
        private const string m_PageId = "SRBISPSH";
        private readonly byte m_CurrentSIGNo;
        private readonly short m_CurrentUserNo;
        private readonly int m_CurrentLoginActionNo;
        public readonly string PG_API_UrlRoot;
        public readonly string PG_API_Token;


        private readonly AppSettingsModel m_AppSetting;
        private readonly IdentityClaimEntity m_CurrentLoginClaimInfo;
        private readonly IHttpContextAccessor m_HttpContextAccessor;
        private readonly WebSystemService m_WebSystemService;
        private readonly AppUserBindingService m_AppUserBindingService;

        private readonly SupplierBindingService m_SupplierBindingService;


        public SupplierSelectorHelperModel(IOptions<AppSettingsModel> appSetting
            , IHttpContextAccessor httpContextAccessor, WebSystemService webSystemService, AppUserBindingService appUserBindingService            
            , SupplierBindingService supplierBindingService)
        {
            m_AppSetting = appSetting.Value;

            m_HttpContextAccessor = httpContextAccessor;
            m_WebSystemService = webSystemService;
            m_AppUserBindingService = appUserBindingService;
            m_SupplierBindingService = supplierBindingService;

            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentSIGNo = m_CurrentLoginClaimInfo.SIGNo;
            m_CurrentUserNo = m_CurrentLoginClaimInfo.UserNo;
            m_CurrentLoginActionNo = m_CurrentLoginClaimInfo.LoginActionNo;
            PG_API_UrlRoot = m_AppSetting.PSI_API_RootUrl;
            PG_API_Token = m_CurrentLoginClaimInfo.ApiToken;

            m_SupplierBindingService.SetSIG(m_CurrentSIGNo);
        }

        [BindProperty]
        public SupplierFilterViewEntity PG_Filter { get; set; }

        [BindProperty]
        public SupplierSelectorEntity PG_SelectorInfo { get; set; }

        public List<SupplierViewModel> PG_List { get; set; }
        public PageHeaderEntity PG_PageHeaderInfo { get; set; }

        //private FormEditModeEnum m_FormEditModeEnum_SourcePage { get; set; }


        public async Task Page_InitialAsync()
        {
            PG_PageHeaderInfo = await m_WebSystemService.GetPageHeaderAsync(PG_SelectorInfo.SourcePageID);

            var childPageHeaderInfo = await m_WebSystemService.GetPageHeaderAsync(m_PageId);
            PG_PageHeaderInfo.SubTitle = childPageHeaderInfo.Title;
            
            ViewData[AppSystem.VD_PageFullTitle] = PG_PageHeaderInfo.FullTitle;
        }


        public async Task Page_LoadAsync()
        {
            
        }









        public async Task OnGetAsync(string _sourcePageId, string _target, string _handle)
        {
            //var isOrderByTicketPrintTask = false;
            //bool.TryParse(_isTPT.ToString(), out isOrderByTicketPrintTask);

            //if (byte.TryParse(_fem.ToString(), out byte fem))
            //    m_FormEditModeEnum_SourcePage = (FormEditModeEnum)fem;


            PG_SelectorInfo = new SupplierSelectorEntity()
            {
                SourcePageID = _sourcePageId,
                TargetAspPage = _target,
                TargetPageHandle = _handle                
            };
            await Page_InitialAsync();


            PG_Filter = new SupplierFilterViewEntity()
            {   
            };

            

            PG_List = await m_SupplierBindingService.GetListAsync(PG_Filter);
            await Page_LoadAsync();
        }







        public async Task<IActionResult> OnPostSearchAsync()
        {
            await Page_InitialAsync();

            
            PG_List = await m_SupplierBindingService.GetListAsync(PG_Filter);
            await Page_LoadAsync();


            // 僅查詢資料，非［送出下一步］
            // 關閉檢查（ContractNo=0）避免NET Core警告
            ModelState.Remove(nameof(PG_SelectorInfo.SupplierNo));

            return Page();
        }







        public async Task<IActionResult> OnPostNextAsync()
        {
            

            if (!ModelState.IsValid)
            {
                await Page_InitialAsync();

                if (PG_SelectorInfo.SupplierNo < (short)TableColumnSeed.Supplier)
                    ModelState.AddModelError(string.Empty, "請選擇信託契約");

                //PG_List = await m_ContractService.GetListAsync(PG_FilterInfo);
                //await Page_LoadAsync();
                TempData[AppSystem.TD_UI_OnPageLoad_Message_Notification] = "請選擇信託契約";
                return new RedirectToPageResult("SupplierSelectorHelper", new
                {
                    _sourcePageId = PG_SelectorInfo.SourcePageID,
                    _target = PG_SelectorInfo.TargetAspPage,
                    _handle = PG_SelectorInfo.TargetPageHandle
                });
            }

            var pageName = PG_SelectorInfo.TargetAspPage;
            var pageHandle = PG_SelectorInfo.TargetPageHandle;
            object routeObj = new { _no = PG_SelectorInfo.SupplierNo };
            return RedirectToPage(pageName, pageHandle, routeObj);
        }
        
        





    }
}
