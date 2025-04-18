using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SBRPAPIPsi.Controllers.Products
{
    [Route("api/Products/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly short m_CurrentUserNo;
        private readonly byte m_CurrentSIGNo;
        private readonly int m_CurrentLoginActionSN;

        private readonly IHttpContextAccessor m_HttpContextAccessor;
        private readonly AppUserBindingService m_AppUserBindingService;
        private readonly IdentityClaimEntity m_CurrentLoginClaimInfo;
        private readonly ProductBindingService m_ProductBindingService;

        public ProductController(IHttpContextAccessor httpContextAccessor, AppUserBindingService appUserBindingService
            , ProductBindingService productBindingService)
        {
            m_HttpContextAccessor = httpContextAccessor;
            m_AppUserBindingService = appUserBindingService;
            m_ProductBindingService = productBindingService;

            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentSIGNo = m_CurrentLoginClaimInfo.SIGNo;
            m_ProductBindingService.SetSIG(m_CurrentSIGNo);
        }





        [HttpGet("Brief/ProductName/{_productId}")]
        public async Task<ActionResult<ProductBindingModel_Brief>> GetProductNameAsync(string _productId)
        {
            if (string.IsNullOrWhiteSpace(_productId) == false)
            {
                var product = await
                    m_ProductBindingService.GetEntityAsync(_productId, _enableTracking: false, _includeDetails: false);

                if (product != null)
                {
                    return new ProductBindingModel_Brief(product);
                }
            }
            return null;
        }



        [HttpGet("Brief/ProductNameWithCost/{_costNo}/{_productId}")]
        public async Task<ActionResult<ProductBindingModel_Brief>> GetProductNameWithCostAsync(string _productId
            ,byte _costNo)
        {
            if (string.IsNullOrWhiteSpace(_productId) == false)
            {
                var product = await
                    m_ProductBindingService.GetEntityAsync(_productId, _enableTracking: false, _includeDetails: true);

                if (product != null)
                {
                    return new ProductBindingModel_Brief(product);
                }
            }
            return null;
        }





    }
}
