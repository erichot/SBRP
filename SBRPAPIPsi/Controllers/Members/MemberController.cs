using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace SBRPAPIPsi.Controllers.Members
{

    [Route("api/Members/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly short m_CurrentUserNo;
        private readonly byte m_CurrentSIGNo;
        private readonly int m_CurrentLoginActionSN;

        private readonly IHttpContextAccessor m_HttpContextAccessor;
        private readonly AppUserBindingService m_AppUserBindingService;
        private readonly IdentityClaimEntity m_CurrentLoginClaimInfo;
        private readonly MemberBindingService m_MemberBindingService;


        public MemberController(IHttpContextAccessor httpContextAccessor, AppUserBindingService appUserBindingService
            , MemberBindingService memberBindingServic)
        {
            m_HttpContextAccessor = httpContextAccessor;
            m_AppUserBindingService = appUserBindingService;
            m_MemberBindingService = memberBindingServic;

            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentSIGNo = m_CurrentLoginClaimInfo.SIGNo;
            m_MemberBindingService.SetSIG(m_CurrentSIGNo);
        }












        [HttpGet("KD")]
        public async Task<List<SelectItemEntity>> GetSelectItemListAsync([FromQuery(Name = "filter[filters][0][value]")] string _memberId)
        {
            var list = await m_DepartmentService
                .GetListAsync(
                    new DepartmentFilter() { DivisionNo = _divisionNo });
            return list.ToSelectItemList<DepartmentBindingModel>();
        }


















    }
}
