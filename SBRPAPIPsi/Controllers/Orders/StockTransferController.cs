using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SBRPAPIPsi.Controllers.Orders
{
    [Route("api/Orders/[controller]")]
    [ApiController]
    public class StockTransferController : ControllerBase
    {
        private readonly short m_CurrentUserNo;
        private readonly byte m_CurrentSIGNo;
        private readonly int m_CurrentLoginActionNo;

        private readonly IHttpContextAccessor m_HttpContextAccessor;
        private readonly AppUserBindingService m_AppUserBindingService;
        private readonly IdentityClaimEntity m_CurrentLoginClaimInfo;

        private readonly ProductBindingService m_ProductBindingService;
        private readonly StockTransferOrderBindingService m_StockTransferOrderBindingService;

        public StockTransferController(IHttpContextAccessor httpContextAccessor, AppUserBindingService appUserBindingService
            , ProductBindingService productBindingService
            , StockTransferOrderBindingService stockTransferOrderBindingService)
        {
            m_HttpContextAccessor = httpContextAccessor;
            m_AppUserBindingService = appUserBindingService;
            m_ProductBindingService = productBindingService;
            m_StockTransferOrderBindingService = stockTransferOrderBindingService;

            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentSIGNo = m_CurrentLoginClaimInfo.SIGNo;
            m_CurrentLoginActionNo = m_CurrentLoginClaimInfo.LoginActionNo;

            m_ProductBindingService.SetSIG(m_CurrentSIGNo);
            m_StockTransferOrderBindingService.SetSIG(m_CurrentSIGNo);
        }
















        [HttpPost("Detail/DT/{_orderNo}/{_draftNo?}")]
        public async Task<EdItemResponseEntity<StockTransferOrderDetailBindingModel>> GetDetailListDtAsync(
            int _orderNo, int? _draftNo)
        {
            var result = new EdItemResponseEntity<StockTransferOrderDetailBindingModel>();

            var list = await
                m_StockTransferOrderBindingService
                    .GetDetailListAsync(_orderNo, _draftNo);

            result.data = list;

            return result;
        }











        [HttpPost("Detail/ED")]
        public async Task<ActionResult<EdItemResponseEntity<StockTransferOrderDetailBindingModel>>> AddEntityAsync(
            EdItemRequestEntity<StockTransferOrderDetailBindingModel> _request)
        {
            var inserting = _request.data;
            var productId = _request.data.ProductId?.Trim()?.ToUpper();

            inserting.ProductId = productId;
            inserting.LoginActionNo = m_CurrentLoginActionNo;
            // =====================================================================
            var product = await m_ProductBindingService.GetEntityAsync(productId, _includeDetails: false);
            if (product == null)
                return StatusCode(ApiStatusCode.NotAcceptable, new ApiErrorMessageResponeEntity("查無此貨號"));


            // =====================================================================
            inserting.ProductNo = product.ProductNo;
            

            var inserted = await
                m_StockTransferOrderBindingService
                    .AddDetailEntityAsync(inserting);

            inserted.Product = product;
            // ============================================================================
            return new EdItemResponseEntity<StockTransferOrderDetailBindingModel>()
            {
                data = new List<StockTransferOrderDetailBindingModel>() { inserted }
            };
        }


















        // Single ProductId Input
        [HttpPost("Detail/SI/{_orderNo}/{_logNo}/{_productId}/{_itemNo}")]
        public async Task<ActionResult> AddEntityAsync(int _orderNo, int _logNo
            , string _productId, short _itemNo)
        {
           if (_logNo.IsNullOrDefault())
                return StatusCode(ApiStatusCode.NotAcceptable, new ApiErrorMessageResponeEntity("請輸入入庫單號"));

            // =====================================================================
            var product = await m_ProductBindingService.GetEntityAsync(_productId, _includeDetails: false);
            var remark = string.Empty;
            var quantity = 1;

            if (product == null)
            {
                //return StatusCode(ApiStatusCode.NotAcceptable, new ApiErrorMessageResponeEntity("查無此貨號"));
                remark = $"查無此貨號：{_productId}";
                quantity = default(int);
            }
            var productNo = product?.ProductNo??-1;

            // =========================================================================
            var inserting = new StockTransferOrderDetailBindingModel()
            {
                OrderNo = _orderNo,
                LogNo = _logNo,
                ProductId = _productId,
                ProductNo = productNo,
                ItemNo = _itemNo,
                Quantity = quantity,
                Remark = remark,
                LoginActionNo = m_CurrentLoginActionNo
            };


            var inserted = await
                m_StockTransferOrderBindingService
                    .AddDetailEntityAsync(inserting);

            // ============================================================================
            return Ok();
        }











    }
}
