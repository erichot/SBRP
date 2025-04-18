using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SBRPWebPsi.Pages.Shared.BasicInfo
{
    [Authorize]
    public class StockSelectorHelperModel : PageModel
    {
        private const string m_PageId = "SRBISTSH";
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

        private readonly StockBindingService m_StockBindingService;


        private bool m_IsTransferFromStock = false;

        public StockSelectorHelperModel(IOptions<AppSettingsModel> appSetting
            , IHttpContextAccessor httpContextAccessor, WebSystemService webSystemService, AppUserBindingService appUserBindingService            
            , StockBindingService stockBindingService)
        {
            m_AppSetting = appSetting.Value;

            m_HttpContextAccessor = httpContextAccessor;
            m_WebSystemService = webSystemService;
            m_AppUserBindingService = appUserBindingService;
            m_StockBindingService = stockBindingService;

            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentSIGNo = m_CurrentLoginClaimInfo.SIGNo;
            m_CurrentUserNo = m_CurrentLoginClaimInfo.UserNo;
            m_CurrentLoginActionNo = m_CurrentLoginClaimInfo.LoginActionNo;
            PG_API_UrlRoot = m_AppSetting.PSI_API_RootUrl;
            PG_API_Token = m_CurrentLoginClaimInfo.ApiToken;

            m_StockBindingService.SetSIG(m_CurrentSIGNo);
        }

        [BindProperty]
        public StockFilterViewEntity PG_Filter { get; set; }

        [BindProperty]
        public StockSelectorEntity PG_SelectorInfo { get; set; }

        public List<StockViewModel> PG_List { get; set; }
        public PageHeaderEntity PG_PageHeaderInfo { get; set; }

    


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









        public async Task OnGetAsync(string _sourcePageId, string _target, string _handle
            , bool? _isTsFrom)
        {
            if (_isTsFrom == true) m_IsTransferFromStock = true;

            PG_SelectorInfo = new StockSelectorEntity()
            {
                SourcePageID = _sourcePageId,
                TargetAspPage = _target,
                TargetPageHandle = _handle                
            };
            await Page_InitialAsync();


            PG_Filter = new StockFilterViewEntity()
            {   
            };

            

            PG_List = await m_StockBindingService.GetListAsync(PG_Filter);
            await Page_LoadAsync();
        }







        public async Task<IActionResult> OnPostSearchAsync()
        {
            await Page_InitialAsync();

            
            PG_List = await m_StockBindingService.GetListAsync(PG_Filter);
            await Page_LoadAsync();


            // 僅查詢資料，非［送出下一步］
            // 關閉檢查（ContractNo=0）避免NET Core警告
            ModelState.Remove(nameof(PG_SelectorInfo.StockNo));

            return Page();
        }







        public async Task<IActionResult> OnPostNextAsync()
        {
            

            if (!ModelState.IsValid)
            {
                await Page_InitialAsync();

                if (PG_SelectorInfo.StockNo < (short)TableColumnSeed.Stock)
                    ModelState.AddModelError(string.Empty, "請選擇倉庫");

              
                TempData[AppSystem.TD_UI_OnPageLoad_Message_Notification] = "請選擇倉庫";
                return new RedirectToPageResult("StockSelectorHelper", new
                {
                    _sourcePageId = PG_SelectorInfo.SourcePageID,
                    _target = PG_SelectorInfo.TargetAspPage,
                    _handle = PG_SelectorInfo.TargetPageHandle
                });
            }

            var pageName = PG_SelectorInfo.TargetAspPage;
            var pageHandle = PG_SelectorInfo.TargetPageHandle;
            object routeObj = new { _no = PG_SelectorInfo.StockNo };
            return RedirectToPage(pageName, pageHandle, routeObj);
        }
        
        





    }
}
