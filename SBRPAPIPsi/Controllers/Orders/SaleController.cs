using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SBRPAPIPsi.Controllers.Orders
{
    [Route("api/Orders/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly short m_CurrentUserNo;
        private readonly byte m_CurrentSIGNo;
        private readonly int m_CurrentLoginActionNo;

        private readonly IHttpContextAccessor m_HttpContextAccessor;
        private readonly AppUserBindingService m_AppUserBindingService;
        private readonly IdentityClaimEntity m_CurrentLoginClaimInfo;

        private readonly ProductBindingService m_ProductBindingService;
        private readonly SaleOrderBindingService m_SaleOrderBindingService;

        public SaleController(IHttpContextAccessor httpContextAccessor, AppUserBindingService appUserBindingService
            , ProductBindingService productBindingService
            , SaleOrderBindingService SaleOrderBindingService)
        {
            m_HttpContextAccessor = httpContextAccessor;
            m_AppUserBindingService = appUserBindingService;
            m_ProductBindingService = productBindingService;
            m_SaleOrderBindingService = SaleOrderBindingService;

            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentSIGNo = m_CurrentLoginClaimInfo.SIGNo;
            m_CurrentLoginActionNo = m_CurrentLoginClaimInfo.LoginActionNo;

            m_ProductBindingService.SetSIG(m_CurrentSIGNo);
            m_SaleOrderBindingService.SetSIG(m_CurrentSIGNo);
        }
















        [HttpPost("Detail/DT/{_orderNo}/{_draftNo?}")]
        public async Task<EdItemResponseEntity<SaleOrderDetailBindingModel>> GetDetailListDtAsync(
            int _orderNo, int? _draftNo)
        {
            var result = new EdItemResponseEntity<SaleOrderDetailBindingModel>();

            var list = await
                m_SaleOrderBindingService
                    .GetDetailListAsync(_orderNo, _draftNo);

            result.data = list;

            return result;
        }







        




        [HttpPost("Detail/ED/{_priceNo?}")]
        public async Task<ActionResult<EdItemResponseEntity<SaleOrderDetailBindingModel>>> AddEntityAsync(
            EdItemRequestEntity<SaleOrderDetailBindingModel> _request, byte? _priceNo)
        {
            var inserting = _request.data;
            var productId = _request.data.ProductId?.Trim()?.ToUpper();
            var costNo = _priceNo.ToByte();

            inserting.ProductId = productId;
            inserting.LoginActionNo = m_CurrentLoginActionNo;

            // =====================================================================
            var product = await m_ProductBindingService.GetEntityWithProductCostAsync(productId);
            if (product == null)
                return StatusCode(ApiStatusCode.NotAcceptable, new ApiErrorMessageResponeEntity("查無此貨號"));


            // =====================================================================
            inserting.ProductNo = product.ProductNo;
            inserting.UnitCost = product.GetProductCost(costNo);
            //inserting.SubAmount = inserting.Quantity * inserting.UnitCost;

            var inserted = await
                m_SaleOrderBindingService
                    .AddDetailEntityAsync(inserting);

            inserted.Product = product;
            // ============================================================================
            return new EdItemResponseEntity<SaleOrderDetailBindingModel>()
            {
                data = new List<SaleOrderDetailBindingModel>() { inserted }
            };
        }




        [HttpPut("Detail/ED/")]
        public async Task<ActionResult<EdItemResponseEntity<SaleOrderDetailBindingModel>>> UpdateEntityAsync(
            EdItemRequestEntity<SaleOrderDetailBindingModel_ForUpdating> _request)
        {
            var updating = _request.data;

            if (updating.OrderNo.IsNullOrDefault() && updating.LogNo.IsNullOrDefault())
                return StatusCode(ApiStatusCode.NotAcceptable, new ApiErrorMessageResponeEntity("請輸入入庫單號"));


            if (updating.ItemNo.IsNullOrDefault())
                return StatusCode(ApiStatusCode.NotAcceptable, new ApiErrorMessageResponeEntity("請輸入ItemNo"));


            // =====================================================================
            updating.LoginActionNo = m_CurrentLoginActionNo;

            var updated = await
                m_SaleOrderBindingService
                    .UpdateDetailEntityAsync(updating);

            // ============================================================================
            return new EdItemResponseEntity<SaleOrderDetailBindingModel>()
            {
                data = new List<SaleOrderDetailBindingModel>() { updated }
            };
        }





        [HttpDelete("Detail/ED/")]
        public async Task<ActionResult<EdItemResponseEntity<SaleOrderDetailBindingModel>>> DeleteEntityAsync(
            EdItemRequestEntity<SaleOrderDetailBindingModel_ForUpdating> _request)
        {
            var deleting = _request.data;
            var logNo = deleting.LogNo;

            if (deleting.OrderNo.IsNullOrDefault() && logNo.IsNullOrDefault())
                return StatusCode(ApiStatusCode.NotAcceptable, new ApiErrorMessageResponeEntity("請輸入入庫單號"));
            
            if (deleting.ItemNo.IsNullOrDefault())
                return StatusCode(ApiStatusCode.NotAcceptable, new ApiErrorMessageResponeEntity("請輸入ItemNo"));
            
            // =====================================================================
            if (logNo.IsNullOrDefault() == false)
            {
                await m_SaleOrderBindingService
                        .DeleteDetailEntityAsync(deleting);
            }

            // ============================================================================
            return new EdItemResponseEntity<SaleOrderDetailBindingModel>()
            {
                data = new List<SaleOrderDetailBindingModel>()
            };
        }













        // Single ProductId Input
        //[HttpPost("Detail/SI/{_orderNo}/{_logNo}/{_productId}/{_itemNo}")]
        //public async Task<ActionResult> AddEntityAsync(int _orderNo, int _logNo
        //    , string _productId, short _itemNo)
        //{
        //   if (_logNo.IsNullOrDefault())
        //        return StatusCode(ApiStatusCode.NotAcceptable, new ApiErrorMessageResponeEntity("請輸入入庫單號"));

        //    // =====================================================================
        //    var product = await m_ProductBindingService.GetEntityAsync(_productId, _includeDetails: false);
        //    var remark = string.Empty;
        //    var quantity = 1;

        //    if (product == null)
        //    {
        //        //return StatusCode(ApiStatusCode.NotAcceptable, new ApiErrorMessageResponeEntity("查無此貨號"));
        //        remark = $"查無此貨號：{_productId}";
        //        quantity = default(int);
        //    }
        //    var productNo = product?.ProductNo??-1;

        //    // =========================================================================
        //    var inserting = new SaleOrderDetailBindingModel()
        //    {
        //        OrderNo = _orderNo,
        //        LogNo = _logNo,
        //        ProductId = _productId,
        //        ProductNo = productNo,
        //        ItemNo = _itemNo,
        //        Quantity = quantity,
        //        Remark = remark,
        //        LoginActionNo = m_CurrentLoginActionNo
        //    };


        //    var inserted = await
        //        m_SaleOrderBindingService
        //            .AddDetailEntityAsync(inserting);

        //    // ============================================================================
        //    return Ok();
        //}











    }
}
