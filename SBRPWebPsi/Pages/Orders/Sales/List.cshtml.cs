using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace SBRPWebPsi.Pages.Orders.Sales
{
    [Authorize]
    public class ListModel : PageModel
    {
        private const string m_PageId = "ORIS0101";
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
        private readonly MemberBindingService m_MemberBindingService;
        private readonly StockBindingService m_StockBindingService;
        private readonly SaleOrderBindingService m_SaleOrderBindingService;

        public ListModel(IOptions<AppSettingsModel> appSetting
            , IHttpContextAccessor httpContextAccessor, WebSystemService webSystemService, AppUserBindingService appUserBindingService
            , MemberBindingService memberBindingService
            , SaleOrderBindingService SaleOrderBindingService
            , StockBindingService StockBindingService)
        {
            m_AppSetting = appSetting.Value;

            m_HttpContextAccessor = httpContextAccessor;
            m_WebSystemService = webSystemService;
            m_AppUserBindingService = appUserBindingService;
            m_MemberBindingService = memberBindingService;
            m_SaleOrderBindingService = SaleOrderBindingService;
            m_StockBindingService = StockBindingService;


            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentSIGNo = m_CurrentLoginClaimInfo.SIGNo;
            m_CurrentUserNo = m_CurrentLoginClaimInfo.UserNo;
            m_CurrentLoginActionNo = m_CurrentLoginClaimInfo.LoginActionNo;
            PG_API_UrlRoot = m_AppSetting.PSI_API_RootUrl;
            PG_API_Token = m_CurrentLoginClaimInfo.ApiToken;

            m_StockBindingService.SetSIG(m_CurrentSIGNo);
            m_SaleOrderBindingService.SetSIG(m_CurrentSIGNo);
            m_MemberBindingService.SetSIG(m_CurrentSIGNo);
        }

                    
        public PageHeaderEntity PG_PageHeaderInfo { get; set; }

        [BindProperty]
        public SaleOrderFilterViewModel PG_Filter { get; set; } = new SaleOrderFilterViewModel();
        
        public List<SaleOrderViewModel> PG_List { get; set; }




        public async Task Page_InitialAsync()
        {
            PG_PageHeaderInfo = await m_WebSystemService.GetPageHeaderAsync(m_PageId, FormEditModeEnum.List);
            ViewData[AppSystem.VD_PageFullTitle] = PG_PageHeaderInfo.FullTitle;
        }

        public async Task Page_LoadAsync()
        {
            ViewData[AppSystem.VD_Stock_SLI] = await m_StockBindingService.GetSelectListItemAsync();
        }











        public async Task OnGetAsync()
        {
            await Page_InitialAsync();

            //string cookie = Request.Cookies["su"];
            //if (short.TryParse(cookie, out var aaa)) PG_Filter.StockNo = aaa;

            PG_List = await 
                m_SaleOrderBindingService
                    .GetListAsync(PG_Filter);

            await Page_LoadAsync();
        }



        public async Task OnPostRefreshAsync()
        {
            await Page_InitialAsync();

            PG_List = await
                m_SaleOrderBindingService
                    .GetListAsync(PG_Filter);

            //Response.Cookies.Append("su", PG_Filter.StockNo?.ToString()??string.Empty);
            await Page_LoadAsync();
        }










    }
}
