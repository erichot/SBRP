using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace SBRPWebPsi.Pages.Orders.Sales
{
    [Authorize]
    public class EntityProcessModel : PageModel
    {
        private const string m_PageId = "ORIS0105";
        private const OperationClassEnum m_OperationClassNo = OperationClassEnum.Sale;
        private const OperationTypeEnum m_OperationTypeNo = OperationTypeEnum.Sale;
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
        private readonly SaleOrderBindingService m_SaleOrderBindingService;
        private readonly ProductGeneralCategoryDefinitionBindingService m_ProductGeneralCategoryDefinitionBindingService;
        private readonly ProductIdStructureDefinitionBindingService m_ProductIdStructureDefinitionBindingService;
        private readonly StockBindingService m_StockBindingService;
        private readonly StoreBindingService m_StoreBindingService;
        private readonly MemberBindingService m_MemberBindingService;

        public EntityProcessModel(IOptions<AppSettingsModel> appSetting
         , IHttpContextAccessor httpContextAccessor, WebSystemService webSystemService, AppUserBindingService appUserBindingService
            , SaleOrderBindingService SaleOrderBindingService
            , ProductGeneralCategoryDefinitionBindingService productGeneralCategoryDefinitionBindingService
            , ProductIdStructureDefinitionBindingService productIdStructureDefinitionBindingService
            , StockBindingService stockBindingService
            , StoreBindingService storeBindingService
            , MemberBindingService memberBindingService)
        {
            m_AppSetting = appSetting.Value;

            m_HttpContextAccessor = httpContextAccessor;
            m_WebSystemService = webSystemService;
            m_AppUserBindingService = appUserBindingService;
            m_SaleOrderBindingService = SaleOrderBindingService;
            m_ProductGeneralCategoryDefinitionBindingService = productGeneralCategoryDefinitionBindingService;
            m_ProductIdStructureDefinitionBindingService = productIdStructureDefinitionBindingService;
            m_StockBindingService = stockBindingService;
            m_StoreBindingService = storeBindingService;
            m_MemberBindingService = memberBindingService;

            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentSIGNo = m_CurrentLoginClaimInfo.SIGNo;
            m_CurrentUserNo = m_CurrentLoginClaimInfo.UserNo;
            m_CurrentLoginActionNo = m_CurrentLoginClaimInfo.LoginActionNo;            
            PG_API_UrlRoot = m_AppSetting.PSI_API_RootUrl;
            PG_API_Token = m_CurrentLoginClaimInfo.ApiToken;

            m_SaleOrderBindingService.SetSIG(m_CurrentSIGNo);
            m_ProductGeneralCategoryDefinitionBindingService.SetSIG(m_CurrentSIGNo);
            m_ProductIdStructureDefinitionBindingService.SetSIG(m_CurrentSIGNo);
            m_StockBindingService.SetSIG(m_CurrentSIGNo);
            m_StoreBindingService.SetSIG(m_CurrentSIGNo);
            m_MemberBindingService.SetSIG(m_CurrentSIGNo);
        }



        public int PG_No { get; set; }
        public int PG_DraftNo { get; set; }

        public byte PG_PriceNo { get; set; } = 0;

        public PageHeaderEntity PG_PageHeaderInfo { get; set; }

        public EntityEditBriefHistory<SaleOrderViewModel> PG_EditBriefInfo { get; set; }

        public EdFieldOptionsList<SaleOrderDetailViewModel> PG_EdFieldOptionsList { get; set; }


        [BindProperty]
        public SaleOrderViewModel PG_Info { get; set; }

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
                if (PG_Info.Store == null && PG_Info.StockNo.IsNullOrDefault() == false)
                    PG_Info.Store = await m_StoreBindingService.GetEntityByStockAsync(PG_Info.StockNo, _includeDetails: false);

                //SBRPData.Attributes.DisplayNameFromAttribute.SetDisplayNames(PG_Info);

                PG_EdFieldOptionsList = new EdFieldOptionsList<SaleOrderDetailViewModel>();
                //PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<SaleOrderDetailViewModel>(c => c.OrderNo) { def = default(int) });
                PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<SaleOrderDetailViewModel>(c => c.ItemNo) { IsReadonly = true });
                PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<SaleOrderDetailViewModel>(c => c.ProductNo) { attr = new EdFieldOptionsAttr("d-none"), def = default(int) });

                var index_ProductId = PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<SaleOrderDetailViewModel>(c => c.ProductId, new EdFieldOptionsAttr(productIdMaxLength, AppSystem.CSS_Form_Field_Id)) { required = true});
                var index_ProductName = PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<SaleOrderDetailViewModel>(c => c.ProductName, new EdFieldOptionsAttr()) { IsReadonly = true});
                PG_EdFieldOptionsList.FieldsList[index_ProductId].label = Product.GetDisplayName(p => p.ProductId);
                PG_EdFieldOptionsList.FieldsList[index_ProductName].label = Product.GetDisplayName(p => p.ProductName);

                PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<SaleOrderDetailViewModel>(c => c.UnitPrice, new EdFieldOptionsAttr() { typeName = "number"}, _def:default(int)) { IsReadonly = true});
                PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<SaleOrderDetailViewModel>(c => c.DiscountPercentage, new EdFieldOptionsAttr() { typeName = "number" }, _def: default(int)));
                PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<SaleOrderDetailViewModel>(c => c.ActualSellingPrice, new EdFieldOptionsAttr() { typeName = "number" }, _def: default(int)));
                PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<SaleOrderDetailViewModel>(c => c.UnitPrice, new EdFieldOptionsAttr() { typeName = "number" }, _def: default(int)) { IsReadonly = true });
                PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<SaleOrderDetailViewModel>(c => c.Quantity, new EdFieldOptionsAttr() { typeName = "number" }, _def:1, _required: true));
                PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<SaleOrderDetailViewModel>(c => c.SubAmount, new EdFieldOptionsAttr() { typeName = "number" }, _def: default(int)) { IsReadonly = true });
                PG_EdFieldOptionsList.AddElement(new EdFieldOptionsEntity<SaleOrderDetailViewModel>(c => c.Remark
                    , new EdFieldOptionsAttr() { maxLength = 
                        ModelPropertyHelper.GetMaxLength<SaleOrderDetailViewModel>(c => c.Remark)
                    }));

                

                PG_Info.FormEditMode = _formEditModeEnum;
                
                if (_formEditModeEnum != FormEditModeEnum.Add)
                {
                    PG_EditBriefInfo = new EntityEditBriefHistory<SaleOrderViewModel>(PG_Info);
                }
            }
        }









        public async Task OnGetAsync(int _no, OperationEntityLoadingPolicyEnum _loadingPolicy = default(byte))
        {
            var currentFormEditMode = FormEditModeEnum.Read;
            await Page_InitialAsync(currentFormEditMode);

            PG_Info = await m_SaleOrderBindingService.GetEntityAsync(_no, _enableTracking: false, _includeDetails: true);
            PG_No = PG_Info.OrderNo;

            await Page_LoadAsync(currentFormEditMode);
        }




        //public async Task OnGetAddAsync()
        //{
        //    await Page_InitialAsync(FormEditModeEnum.Add);

        //    PG_Info = await m_SaleOrderBindingService.AddNewDefaultAsync();

        //    await Page_LoadAsync(FormEditModeEnum.Add);
        //}








        public async Task OnGetAddByStoreAsync(short _no)
        {
            await Page_InitialAsync(FormEditModeEnum.Add);

            if (_no.IsNullOrDefault())
            {
                PG_ClientMessage = "no store";
                TempData[AppSystem.TD_UI_OnPageLoad_Message_Notification] = PG_ClientMessage;
                await Page_LoadAsync(FormEditModeEnum.Read);
                return;
            }

        



            // ============================================================
            // 初始化草稿
            var draftInserting = await 
                m_SaleOrderBindingService
                    .AddNewDefaultAsync(
                        new SBRPDataPsi.Models.SaleOrder(
                            m_CurrentSIGNo, _no, m_CurrentUserNo, m_CurrentLoginActionNo) 
                    );

            PG_Info = await 
                m_SaleOrderBindingService
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
            PG_Info.SaleOrderDetails = await 
                m_SaleOrderBindingService
                    .GetDetailLogListAsync(PG_Info.LogNo);

            // ======================================================
           



            // ================================================================
            var result = await 
                m_SaleOrderBindingService
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
