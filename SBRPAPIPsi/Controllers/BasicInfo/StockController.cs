using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace SBRPAPIPsi.Controllers.BasicInfo
{

    [Route("api/BasicInfo/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly short m_CurrentUserNo;
        private readonly byte m_CurrentSIGNo;
        private readonly int m_CurrentLoginActionSN;

        private readonly IHttpContextAccessor m_HttpContextAccessor;
        private readonly AppUserBindingService m_AppUserBindingService;
        private readonly IdentityClaimEntity m_CurrentLoginClaimInfo;
        private readonly StockBindingService m_StockBindingService;


        public MemberController(IHttpContextAccessor httpContextAccessor, AppUserBindingService appUserBindingService, StockBindingService StockBindingService)
        {
            m_HttpContextAccessor = httpContextAccessor;
            m_AppUserBindingService = appUserBindingService;
            m_StockBindingService = StockBindingService;

            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentSIGNo = m_CurrentLoginClaimInfo.SIGNo;
            m_StockBindingService.SetSIG(m_CurrentSIGNo);
        }












        [AllowAnonymous]
        [HttpGet("SIL")]
        public async Task<List<SelectItemEntity>> GetSelectItemListAsync()
        {
            var list = await 
                m_StockBindingService
                    .GetListAsync(
                        new StockFilterBindingModel());
            return list.ToSelectItemList<StockBindingModel>();
        }



















    }
}
