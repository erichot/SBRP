using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace SBRPAPIPsi.Controllers.Products
{

    [Route("api/Products/[controller]")]
    [ApiController]
    public class GeneralCategoryItemController : ControllerBase
    {
        private readonly short m_CurrentUserNo;
        private readonly byte m_CurrentSIGNo;
        private readonly int m_CurrentLoginActionSN;

        private readonly IHttpContextAccessor m_HttpContextAccessor;
        private readonly AppUserBindingService m_AppUserBindingService;
        private readonly IdentityClaimEntity m_CurrentLoginClaimInfo;
        private readonly ProductGeneralCategoryItemBindingService m_ProductGeneralCategoryItemBindingService;

        public GeneralCategoryItemController(IHttpContextAccessor httpContextAccessor, AppUserBindingService appUserBindingService, ProductGeneralCategoryItemBindingService productGeneralCategoryItemBindingService)
        {
            m_HttpContextAccessor = httpContextAccessor;
            m_AppUserBindingService = appUserBindingService;
            m_ProductGeneralCategoryItemBindingService = productGeneralCategoryItemBindingService;

            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentSIGNo = m_CurrentLoginClaimInfo.SIGNo;
            m_ProductGeneralCategoryItemBindingService.SetSIG(m_CurrentSIGNo);
        }












        [AllowAnonymous]
        [HttpGet("SIL")]
        public async Task<List<SelectItemEntity>> GetSelectItemListAsync()
        {
            var list = await 
                m_ProductGeneralCategoryItemBindingService
                    .GetListAsync(
                        new ProductGeneralCategoryItemFilterBindingModel());
            return list.ToSelectItemList<ProductGeneralCategoryItemBindingModel>();
        }









        [HttpPost("DT")]
        public async Task<EdProductGeneralCategoryItemListResponseEntity> GetListDtAsync(
            ProductGeneralCategoryItemDtAjaxEntity _filter)
        {

            var list = await 
                m_ProductGeneralCategoryItemBindingService
                    .GetListAsync(_filter);

            var result = new EdProductGeneralCategoryItemListResponseEntity() { data = list };
            return result;
        }











        [HttpPost("ED")]
        public async Task<ActionResult<EdProductGeneralCategoryItemResponseEntity>> AddEntityAsync(
            EdProductGeneralCategoryItemRequestEntity _request)
        {
            var inserting = _request.data;
            inserting.SetCreatePerson(m_CurrentUserNo);


            // =====================================================================



            // =====================================================================
            var bpResult = await
                m_ProductGeneralCategoryItemBindingService
                    .ProcessToInsertAsync(inserting);
            if (bpResult.HasError)
            {
                return StatusCode(ApiStatusCode.InternalServerError, bpResult.Message);
            }


            var inserted = bpResult.ResultInfo;
            if (inserted == null || inserted.PGCItemNo <= default(byte))
            {
                return StatusCode(ApiStatusCode.InternalServerError, "No inserting info");
            }


            // ============================================================================
            return new EdProductGeneralCategoryItemResponseEntity()
            {
                data = new List<ProductGeneralCategoryItemBindingModel>() { inserted }
            };
        }













        [HttpPut("ED")]
        public async Task<ActionResult<EdProductGeneralCategoryItemResponseEntity>> UpdateEntityAsync(
            EdProductGeneralCategoryItemRequestEntity _request)
        {
            var updating = _request.data;
            updating.SetUpdatePerson(m_CurrentUserNo);


            // ======================================================================


            // ======================================================================
            var bpResult = await
                m_ProductGeneralCategoryItemBindingService
                    .ProcessToUpdateAsync(updating);
            if (bpResult.HasError)
            {
                return StatusCode(ApiStatusCode.InternalServerError, "No inserting info");
            }


            // =========================================================================
            return new EdProductGeneralCategoryItemResponseEntity()
            {
                data = new List<ProductGeneralCategoryItemBindingModel>() { updating }
            };
        }
















        [HttpDelete("ED")]
        public async Task<ActionResult<EdProductGeneralCategoryItemResponseEntity>> DeleteEntityAsync(
            EdProductGeneralCategoryItemRequestEntity _request)
        {
            var deleting = _request.data;
            deleting.SetDeletePerson(m_CurrentUserNo);

            // ==============================================================


            // ==============================================================
            var bpResult = await
                m_ProductGeneralCategoryItemBindingService
                    .ProcessToDeleteAsync(deleting);
            if (bpResult.HasError)
            {
                return StatusCode(ApiStatusCode.InternalServerError, bpResult.Message);
            }

            // ==============================================================
            return new EdProductGeneralCategoryItemResponseEntity()
            {
                data = new List<ProductGeneralCategoryItemBindingModel>() { deleting }
            };
        }




















    }
}
