using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace SBRPWebPsi.Pages.Orders.StockTransfers
{
    [Authorize]
    public class EntityProcessModel : PageModel
    {
        private const string m_PageId = "ORST0105";
        private const OperationClassEnum m_OperationClassNo = OperationClassEnum.StockTransfer;
        private readonly byte m_CurrentSIGNo;
        private readonly short m_CurrentUserNo;
        private readonly int m_CurrentLoginActionNo;
        public readonly string PG_API_UrlRoot;
        public readonly string PG_API_Token;
        public readonly bool PG_IsEditableOperationDate;

        private readonly AppSettingsModel m_AppSetting;
        private readonly IdentityClaimEntity m_CurrentLoginClaimInfo;
        private IHttpContextAccessor m_HttpContextAccessor;
        private readonly WebSystemService m_WebSystemService;
        private readonly AppUserBindingService m_AppUserBindingService;
        private readonly StockTransferOrderBindingService m_StockTransferOrderBindingService;
        private readonly ProductGeneralCategoryDefinitionBindingService m_ProductGeneralCategoryDefinitionBindingService;
        private readonly ProductIdStructureDefinitionBindingService m_ProductIdStructureDefinitionBindingService;
        private readonly StockBindingService m_StockBindingService;

        public EntityProcessModel(IOptions<AppSettingsModel> appSetting
         , IHttpContextAccessor httpContextAccessor, WebSystemService webSystemService, AppUserBindingService appUserBindingService
            , StockTransferOrderBindingService stockTransferOrderBindingService
            , ProductGeneralCategoryDefinitionBindingService productGeneralCategoryDefinitionBindingService
            , ProductIdStructureDefinitionBindingService productIdStructureDefinitionBindingService
            , StockBindingService stockBindingService)
        {
            m_AppSetting = appSetting.Value;

            m_HttpContextAccessor = httpContextAccessor;
            m_WebSystemService = webSystemService;
            m_AppUserBindingService = appUserBindingService;
            m_StockTransferOrderBindingService = stockTransferOrderBindingService;
            m_ProductGeneralCategoryDefinitionBindingService = productGeneralCategoryDefinitionBindingService;
            m_ProductIdStructureDefinitionBindingService = productIdStructureDefinitionBindingService;
            m_StockBindingService = stockBindingService;

            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentSIGNo = m_CurrentLoginClaimInfo.SIGNo;
            m_CurrentUserNo = m_CurrentLoginClaimInfo.UserNo;
            m_CurrentLoginActionNo = m_CurrentLoginClaimInfo.LoginActionNo;            
            PG_API_UrlRoot = m_AppSetting.PSI_API_RootUrl;
            PG_API_Token = m_CurrentLoginClaimInfo.ApiToken;

            m_StockTransferOrderBindingService.SetSIG(m_CurrentSIGNo);
            m_ProductGeneralCategoryDefinitionBindingService.SetSIG(m_CurrentSIGNo);
            m_ProductIdStructureDefinitionBindingService.SetSIG(m_CurrentSIGNo);
            m_StockBindingService.SetSIG(m_CurrentSIGNo);
        }



        public int PG_No { get; set; }
        public int PG_DraftNo { get; set; }
        public PageHeaderEntity PG_PageHeaderInfo { get; set; }

        public EntityEditBriefHistory<StockTransferOrderViewModel> PG_EditBriefInfo { get; set; }

        public EdFieldOptionsList<StockTransferOrderDetailViewModel> PG_EdFieldOptionsList { get; set; }


        [BindProperty]
        public StockTransferOrderViewModel PG_Info { get; set; }

        public List<ProductIdStructureDefinitionViewModel> PG_PISDs { get; set; }



        [TempData]
        public string PG_ClientMessage { get; set; }










        public async Task Page_InitialAsync(FormEditModeEnum _formEditModeEnum)
        {
            PG_PISDs = await m_ProductIdStructureDefinitionBindingService.GetListAsync(_includeDetails:true);
            PG_PageHeaderInfo = await m_WebSystemService.GetPageHeaderAsync(m_PageId, _formEditModeEnum);
            ViewData[AppSystem.VD_PageFullTitle] = PG_PageHeaderInfo.FullTitle;
        }

        public async Task Page_LoadAsync(FormEditModeEnum _formEditModeEnum)
        {
            var productIdMaxLength = PG_PISDs.Sum(c => c.ProductGeneralCategoryDefinition.ItemIdMaxLength);
            ViewData[AppSystem.VD_Stock_SLI] = await m_StockBindingService.GetSelectItemListAsync(m_OperationClassNo);

            if (PG_Info != null)
            {
                if (PG_Info.FromStock == null && PG_Info.FromStockNo.IsNullOrDefault() == false)
                    PG_Info.FromStock = await m_StockBindingService.GetEntityAsync(PG_Info.FromStockNo, _includeDetails: false);

                
                PG_EdFieldOptionsList = new EdFieldOptionsList<StockTransferOrderDetailViewModel>();
                PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<StockTransferOrderDetailViewModel>(c => c.ItemNo) { def = default(short) });
                PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<StockTransferOrderDetailViewModel>(c => c.ProductNo) { def = default(int) });
                
                var index_ProductId = PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<StockTransferOrderDetailViewModel>(c => c.ProductId, new EdFieldOptionsAttr(productIdMaxLength, AppSystem.CSS_Form_Field_Id)));
                var index_ProductName = PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<StockTransferOrderDetailViewModel>(c => c.ProductName, new EdFieldOptionsAttr()));
                PG_EdFieldOptionsList.FieldsList[index_ProductId].label = Product.GetDisplayName(p => p.ProductId);
                PG_EdFieldOptionsList.FieldsList[index_ProductName].label = Product.GetDisplayName(p => p.ProductName);

                PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<StockTransferOrderDetailViewModel>(c => c.Quantity, new EdFieldOptionsAttr() { typeName = "number" }));
                PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<StockTransferOrderDetailViewModel>(c => c.Remark
                    , new EdFieldOptionsAttr() { maxLength = 
                        ModelPropertyHelper.GetMaxLength<StockTransferOrderDetailViewModel>(c => c.Remark)
                    }));

                

                PG_Info.FormEditMode = _formEditModeEnum;
                
                if (_formEditModeEnum != FormEditModeEnum.Add)
                {
                    PG_EditBriefInfo = new EntityEditBriefHistory<StockTransferOrderViewModel>(PG_Info);
                }
            }
        }









        public async Task OnGetAsync(int _no, OperationEntityLoadingPolicyEnum _loadingPolicy = default(byte))
        {
            var currentFormEditMode = FormEditModeEnum.Read;
            await Page_InitialAsync(currentFormEditMode);

            PG_Info = await m_StockTransferOrderBindingService.GetEntityAsync(_no, _enableTracking: false, _includeDetails: true);
            PG_No = PG_Info.OrderNo;

            await Page_LoadAsync(currentFormEditMode);
        }




        //public async Task OnGetAddAsync()
        //{
        //    await Page_InitialAsync(FormEditModeEnum.Add);

        //    PG_Info = await m_StockTransferOrderBindingService.AddNewDefaultAsync();

        //    await Page_LoadAsync(FormEditModeEnum.Add);
        //}








        public async Task OnGetAddByFromStockAsync(short _no)
        {
            await Page_InitialAsync(FormEditModeEnum.Add);

            if (_no.IsNullOrDefault())
            {
                PG_ClientMessage = "no stock";
                TempData[AppSystem.TD_UI_OnPageLoad_Message_Notification] = PG_ClientMessage;
                await Page_LoadAsync(FormEditModeEnum.Read);
                return;
            }

            // Isvalid 



            // =======================================================================
            // 初始化草稿
            var draftInserting = await 
                m_StockTransferOrderBindingService
                    .AddNewDefaultAsync(
                        new SBRPDataPsi.Models.StockTransferOrder(
                            m_CurrentSIGNo, _no, m_CurrentUserNo, m_CurrentLoginActionNo) 
                    );


            PG_Info = await 
                m_StockTransferOrderBindingService
                    .AddDraftAsync(draftInserting);


            if (PG_Info == null)
            {
                PG_ClientMessage = "no draft data inserted";
                TempData[AppSystem.TD_UI_OnPageLoad_Message_Notification] = PG_ClientMessage;
                await Page_LoadAsync(FormEditModeEnum.Read);
                return;
            }
            PG_DraftNo = PG_Info.LogNo;
            
            await Page_LoadAsync(FormEditModeEnum.Add);
        }













        public async Task<IActionResult> OnPostInsertAsync()
        {
            var currentFormEditMode = FormEditModeEnum.Add;
            await Page_InitialAsync(currentFormEditMode);


            if (!ModelState.IsValid)
            {

            }

            // =========================================================================
            // 指派初始值或預設值
            PG_Info.SetOrderDateNo();
            PG_Info.SetCreatePerson(m_CurrentUserNo);
            PG_Info.SetSIG(m_CurrentSIGNo);
            PG_Info.LoginActionNo = m_CurrentLoginActionNo;



            // 將草稿明細載入
            PG_Info.StockTransferOrderDetails = await 
                m_StockTransferOrderBindingService
                    .GetDetailLogListAsync(PG_Info.LogNo);

            // ======================================================
           



            // ================================================================
            var result = await 
                m_StockTransferOrderBindingService
                    .ProcessToInsertAsync(PG_Info);


            if (result.HasError)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                TempData[AppSystem.TD_UI_OnPageLoad_Message_Notification] = result.Message;
                await Page_LoadAsync(currentFormEditMode);
                return Page();
            }


            if (result.ResultNo.IsNullOrDefault() == false)
            {
                TempData[AppSystem.TD_UI_OnPageLoad_Message_Notification] = WebBaseUI.Form_Msg_NTF_OperationInserted;
                return RedirectToPage("EntityProcess", new { _no = result.ResultNo });
            }


            await Page_LoadAsync(currentFormEditMode);
            return Page();
        }






    }
}
