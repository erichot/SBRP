using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace SBRPAPIPsi.Controllers.BasicInfo
{

    [Route("api/BasicInfo/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly short m_CurrentUserNo;
        private readonly byte m_CurrentSIGNo;
        private readonly int m_CurrentLoginActionSN;

        private readonly IHttpContextAccessor m_HttpContextAccessor;
        private readonly AppUserBindingService m_AppUserBindingService;
        private readonly IdentityClaimEntity m_CurrentLoginClaimInfo;
        private readonly SupplierBindingService m_SupplierBindingService;


        public SupplierController(IHttpContextAccessor httpContextAccessor, AppUserBindingService appUserBindingService, SupplierBindingService SupplierBindingService)
        {
            m_HttpContextAccessor = httpContextAccessor;
            m_AppUserBindingService = appUserBindingService;
            m_SupplierBindingService = SupplierBindingService;

            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentSIGNo = m_CurrentLoginClaimInfo.SIGNo;
            m_SupplierBindingService.SetSIG(m_CurrentSIGNo);
        }












       
        [HttpGet("SIL")]
        public async Task<List<SelectItemEntity>> GetSelectItemListAsync()
        {
            var list = await 
                m_SupplierBindingService
                    .GetListAsync(
                        new SupplierFilterBindingModel());
            return list.ToSelectItemList<SupplierBindingModel>();
        }



















    }
}
