using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace SBRPWebPsi.Pages.BasicInfo.Stores
{
    [Authorize]
    public class ListModel : PageModel
    {
        private const string m_PageId = "BIST0101";
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
        private readonly StoreBindingService m_StoreBindingService;

        public ListModel(IOptions<AppSettingsModel> appSetting
            , IHttpContextAccessor httpContextAccessor, WebSystemService webSystemService, AppUserBindingService appUserBindingService, StoreBindingService StoreBindingService)
        {
            m_AppSetting = appSetting.Value;

            m_HttpContextAccessor = httpContextAccessor;
            m_WebSystemService = webSystemService;
            m_AppUserBindingService = appUserBindingService;
            m_StoreBindingService = StoreBindingService;

            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentSIGNo = m_CurrentLoginClaimInfo.SIGNo;
            m_CurrentUserNo = m_CurrentLoginClaimInfo.UserNo;
            m_CurrentLoginActionNo = m_CurrentLoginClaimInfo.LoginActionNo;
            PG_API_UrlRoot = m_AppSetting.PSI_API_RootUrl;
            PG_API_Token = m_CurrentLoginClaimInfo.ApiToken;
            m_StoreBindingService.SetSIG(m_CurrentSIGNo);
        }

                    
        public PageHeaderEntity PG_PageHeaderInfo { get; set; }

        [BindProperty]
        public StoreFilter PG_Filter { get; set; } = new StoreFilter();
        
        public List<StoreViewModel> PG_List { get; set; }




        public async Task Page_InitialAsync()
        {
            PG_PageHeaderInfo = await m_WebSystemService.GetPageHeaderAsync(m_PageId, FormEditModeEnum.List);
            ViewData[AppSystem.VD_PageFullTitle] = PG_PageHeaderInfo.FullTitle;
        }

        public async Task Page_LoadAsync()
        {

        }











        public async Task OnGetAsync()
        {
            await Page_InitialAsync();

            PG_List = await m_StoreBindingService.GetListAsync(PG_Filter);

            await Page_LoadAsync();
        }


    }
}
