using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace SBRPWebPsi.Pages.Reports.ProductStocks
{
    public class ProductStockPivotYuruReportModel : PageModel
    {
        private const string m_PageId = "RPPS0101";
        private readonly byte m_CurrentSIGNo;
        private readonly short m_CurrentUserNo;
        private readonly int m_CurrentLoginActionNo;
        public readonly string PG_API_UrlRoot;
        public readonly string PG_API_Token;

        private readonly AppSettingsModel m_AppSetting;
        private readonly IdentityClaimEntity m_CurrentLoginClaimInfo;
        private IHttpContextAccessor m_HttpContextAccessor;
        private readonly WebSystemService m_WebSystemService;
        private readonly AppUserBindingService m_AppUserBindingService;
        private readonly ProductStockBindingService m_ProductStockBindingService;

        public ProductStockPivotYuruReportModel(IOptions<AppSettingsModel> appSetting
            , IHttpContextAccessor httpContextAccessor, WebSystemService webSystemService, AppUserBindingService appUserBindingService
            , ProductStockBindingService productStockBindingService)
        {
            m_AppSetting = appSetting.Value;

            m_HttpContextAccessor = httpContextAccessor;
            m_WebSystemService = webSystemService;
            m_AppUserBindingService = appUserBindingService;
            m_ProductStockBindingService = productStockBindingService;

            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentSIGNo = m_CurrentLoginClaimInfo.SIGNo;
            m_CurrentUserNo = m_CurrentLoginClaimInfo.UserNo;
            m_CurrentLoginActionNo = m_CurrentLoginClaimInfo.LoginActionNo;
            PG_API_UrlRoot = m_AppSetting.PSI_API_RootUrl;
            PG_API_Token = m_CurrentLoginClaimInfo.ApiToken;
            m_ProductStockBindingService.SetSIG(m_CurrentSIGNo);
        }


        public bool PG_IsPostBack { get; set; }

        public StringBuilder PG_TableRawJsonData { get; set; }

        public PageHeaderEntity PG_PageHeaderInfo { get; set; }

        public ProductStockPivotReportViewFilter PG_Filter { get; set; }






        public async Task Page_InitialAsync()
        {
            PG_PageHeaderInfo = await m_WebSystemService.GetPageHeaderAsync(m_PageId, FormEditModeEnum.List);
            ViewData[AppSystem.VD_PageFullTitle] = PG_PageHeaderInfo.FullTitle;
        }

        public async Task Page_LoadAsync()
        {

        }











        public async Task OnGetAsync(bool? _isPb)
        {
            PG_IsPostBack = _isPb ?? false;

            await Page_InitialAsync();

            
            if (PG_IsPostBack || 1==1)
                PG_TableRawJsonData = m_ProductStockBindingService
                    .GET_ProductStock_PivotReport(PG_Filter);

            await Page_LoadAsync();
        }












        public async Task<IActionResult> OnPostRefreshAsync()
        {
            return new RedirectToPageResult("ProductStockPivotYuruReport"
                , new {
                    _isPb = true
                });
        }



    }
}

