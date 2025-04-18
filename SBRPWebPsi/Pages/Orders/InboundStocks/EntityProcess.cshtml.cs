using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace SBRPWebPsi.Pages.Orders.InboundStocks
{
    [Authorize]
    public class EntityProcessModel : PageModel
    {
        private const string m_PageId = "ORIS0105";
        private const OperationClassEnum m_OperationClassNo = OperationClassEnum.InboundStock;
        private const OperationTypeEnum m_OperationTypeNo = OperationTypeEnum.InboundStock;
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
        private readonly InboundStockOrderBindingService m_InboundStockOrderBindingService;
        private readonly ProductGeneralCategoryDefinitionBindingService m_ProductGeneralCategoryDefinitionBindingService;
        private readonly ProductIdStructureDefinitionBindingService m_ProductIdStructureDefinitionBindingService;
        private readonly StockBindingService m_StockBindingService;
        private readonly SupplierBindingService m_SupplierBindingService;

        public EntityProcessModel(IOptions<AppSettingsModel> appSetting
         , IHttpContextAccessor httpContextAccessor, WebSystemService webSystemService, AppUserBindingService appUserBindingService
            , InboundStockOrderBindingService InboundStockOrderBindingService
            , ProductGeneralCategoryDefinitionBindingService productGeneralCategoryDefinitionBindingService
            , ProductIdStructureDefinitionBindingService productIdStructureDefinitionBindingService
            , StockBindingService stockBindingService
            , SupplierBindingService supplierBindingService)
        {
            m_AppSetting = appSetting.Value;

            m_HttpContextAccessor = httpContextAccessor;
            m_WebSystemService = webSystemService;
            m_AppUserBindingService = appUserBindingService;
            m_InboundStockOrderBindingService = InboundStockOrderBindingService;
            m_ProductGeneralCategoryDefinitionBindingService = productGeneralCategoryDefinitionBindingService;
            m_ProductIdStructureDefinitionBindingService = productIdStructureDefinitionBindingService;
            m_StockBindingService = stockBindingService;
            m_SupplierBindingService = supplierBindingService;

            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentSIGNo = m_CurrentLoginClaimInfo.SIGNo;
            m_CurrentUserNo = m_CurrentLoginClaimInfo.UserNo;
            m_CurrentLoginActionNo = m_CurrentLoginClaimInfo.LoginActionNo;            
            PG_API_UrlRoot = m_AppSetting.PSI_API_RootUrl;
            PG_API_Token = m_CurrentLoginClaimInfo.ApiToken;

            m_InboundStockOrderBindingService.SetSIG(m_CurrentSIGNo);
            m_ProductGeneralCategoryDefinitionBindingService.SetSIG(m_CurrentSIGNo);
            m_ProductIdStructureDefinitionBindingService.SetSIG(m_CurrentSIGNo);
            m_StockBindingService.SetSIG(m_CurrentSIGNo);
            m_SupplierBindingService.SetSIG(m_CurrentSIGNo);
        }



        public int PG_No { get; set; }
        public int PG_DraftNo { get; set; }

        public byte PG_CostNo { get; set; } = 0;

        public PageHeaderEntity PG_PageHeaderInfo { get; set; }

        public EntityEditBriefHistory<InboundStockOrderViewModel> PG_EditBriefInfo { get; set; }

        public EdFieldOptionsList<InboundStockOrderDetailViewModel> PG_EdFieldOptionsList { get; set; }


        [BindProperty]
        public InboundStockOrderViewModel PG_Info { get; set; }

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
                if (PG_Info.Supplier == null && PG_Info.SupplierNo.IsNullOrDefault() == false)
                    PG_Info.Supplier = await m_SupplierBindingService.GetEntityAsync(PG_Info.SupplierNo, _includeDetails: false);

                //SBRPData.Attributes.DisplayNameFromAttribute.SetDisplayNames(PG_Info);

                PG_EdFieldOptionsList = new EdFieldOptionsList<InboundStockOrderDetailViewModel>();
                //PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<InboundStockOrderDetailViewModel>(c => c.OrderNo) { def = default(int) });
                PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<InboundStockOrderDetailViewModel>(c => c.ItemNo) { IsReadonly = true });
                PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<InboundStockOrderDetailViewModel>(c => c.ProductNo) { attr = new EdFieldOptionsAttr("d-none"), def = default(int) });

                var index_ProductId = PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<InboundStockOrderDetailViewModel>(c => c.ProductId, new EdFieldOptionsAttr(productIdMaxLength, AppSystem.CSS_Form_Field_Id)) { required = true});
                var index_ProductName = PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<InboundStockOrderDetailViewModel>(c => c.ProductName, new EdFieldOptionsAttr()) { IsReadonly = true});
                PG_EdFieldOptionsList.FieldsList[index_ProductId].label = Product.GetDisplayName(p => p.ProductId);
                PG_EdFieldOptionsList.FieldsList[index_ProductName].label = Product.GetDisplayName(p => p.ProductName);

                PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<InboundStockOrderDetailViewModel>(c => c.UnitCost, new EdFieldOptionsAttr() { typeName = "number"}, _def:default(int)) { IsReadonly = true});
                PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<InboundStockOrderDetailViewModel>(c => c.Quantity, new EdFieldOptionsAttr() { typeName = "number" }, _def:1, _required: true));
                PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<InboundStockOrderDetailViewModel>(c => c.SubAmount, new EdFieldOptionsAttr() { typeName = "number" }, _def: default(int)) { IsReadonly = true });
                PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<InboundStockOrderDetailViewModel>(c => c.Remark
                    , new EdFieldOptionsAttr() { maxLength = 
                        ModelPropertyHelper.GetMaxLength<InboundStockOrderDetailViewModel>(c => c.Remark)
                    }));

                

                PG_Info.FormEditMode = _formEditModeEnum;
                
                if (_formEditModeEnum != FormEditModeEnum.Add)
                {
                    PG_EditBriefInfo = new EntityEditBriefHistory<InboundStockOrderViewModel>(PG_Info);
                }
            }
        }









        public async Task OnGetAsync(int _no, OperationEntityLoadingPolicyEnum _loadingPolicy = default(byte))
        {
            var currentFormEditMode = FormEditModeEnum.Read;
            await Page_InitialAsync(currentFormEditMode);

            PG_Info = await m_InboundStockOrderBindingService.GetEntityAsync(_no, _enableTracking: false, _includeDetails: true);
            PG_No = PG_Info.OrderNo;

            await Page_LoadAsync(currentFormEditMode);
        }




        //public async Task OnGetAddAsync()
        //{
        //    await Page_InitialAsync(FormEditModeEnum.Add);

        //    PG_Info = await m_InboundStockOrderBindingService.AddNewDefaultAsync();

        //    await Page_LoadAsync(FormEditModeEnum.Add);
        //}








        public async Task OnGetAddBySupplierAsync(short _no)
        {
            await Page_InitialAsync(FormEditModeEnum.Add);

            if (_no.IsNullOrDefault())
            {
                PG_ClientMessage = "no supplier";
                TempData[AppSystem.TD_UI_OnPageLoad_Message_Notification] = PG_ClientMessage;
                await Page_LoadAsync(FormEditModeEnum.Read);
                return;
            }

            // Isvalid supplierNo



            // ============================================================
            // 初始化草稿
            var draftInserting = await 
                m_InboundStockOrderBindingService
                    .AddNewDefaultAsync(
                        new SBRPDataPsi.Models.InboundStockOrder(
                            m_CurrentSIGNo, _no, m_CurrentUserNo, m_CurrentLoginActionNo) 
                    );

            PG_Info = await 
                m_InboundStockOrderBindingService
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
            PG_Info.InboundStockOrderDetails = await 
                m_InboundStockOrderBindingService
                    .GetDetailLogListAsync(PG_Info.LogNo);

            // ======================================================
           



            // ================================================================
            var result = await 
                m_InboundStockOrderBindingService
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
