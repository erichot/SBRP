using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace SBRPWebPsi.Pages.Products
{
    public class EntityProcessModel : PageModel
    {
        private const string m_PageId = "PT__0105";
        private readonly byte m_CurrentSIGNo;
        private readonly short m_CurrentUserNo;
        private readonly int m_CurrentLoginActionNo;
        public readonly string PG_API_UrlRoot;
        public readonly string PG_API_Token;


        private readonly AppSettingsModel m_AppSetting;
        private readonly IdentityClaimEntity m_CurrentLoginClaimInfo;
        private readonly IHttpContextAccessor m_HttpContextAccessor;
        private readonly WebSystemService m_WebSystemService;
        private readonly AppUserBindingService m_AppUserBindingService;
        private readonly ProductBindingService m_ProductBindingService;
        private readonly ProductCostBindingService m_ProductCostBindingService;
        private readonly ProductPriceBindingService m_ProductPriceBindingService;
        private readonly ProductGeneralCategoryDefinitionBindingService m_ProductGeneralCategoryDefinitionBindingService;
        private readonly ProductGeneralCategoryItemBindingService m_ProductGeneralCategoryItemBindingService;
        private readonly ProductIdStructureDefinitionBindingService m_ProductIdStructureDefinitionBindingService;
        private readonly SupplierBindingService m_SupplierBindingService;


        public EntityProcessModel(IOptions<AppSettingsModel> appSetting
         , IHttpContextAccessor httpContextAccessor, WebSystemService webSystemService, AppUserBindingService appUserBindingService
            , ProductBindingService productBindingService
            , ProductCostBindingService productCostBindingService
            , ProductPriceBindingService productPriceBindingService
            , ProductGeneralCategoryDefinitionBindingService productGeneralCategoryDefinitionBindingService
            , ProductGeneralCategoryItemBindingService productGeneralCategoryItemBindingService
            , ProductIdStructureDefinitionBindingService productIdStructureDefinitionBindingService
            , SupplierBindingService supplierBindingService)
        {
            m_AppSetting = appSetting.Value;

            m_HttpContextAccessor = httpContextAccessor;
            m_WebSystemService = webSystemService;
            m_AppUserBindingService = appUserBindingService;
            m_ProductBindingService = productBindingService;
            m_ProductCostBindingService = productCostBindingService;
            m_ProductPriceBindingService = productPriceBindingService;
            m_ProductGeneralCategoryDefinitionBindingService = productGeneralCategoryDefinitionBindingService;
            m_ProductGeneralCategoryItemBindingService = productGeneralCategoryItemBindingService;
            m_ProductIdStructureDefinitionBindingService = productIdStructureDefinitionBindingService;
            m_SupplierBindingService = supplierBindingService;

            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentSIGNo = m_CurrentLoginClaimInfo.SIGNo;
            m_CurrentUserNo = m_CurrentLoginClaimInfo.UserNo;
            m_CurrentLoginActionNo = m_CurrentLoginClaimInfo.LoginActionNo;            
            PG_API_UrlRoot = m_AppSetting.PSI_API_RootUrl;
            PG_API_Token = m_CurrentLoginClaimInfo.ApiToken;

            m_ProductBindingService.SetSIG(m_CurrentSIGNo);
            m_ProductCostBindingService.SetSIG(m_CurrentSIGNo);
            m_ProductPriceBindingService.SetSIG(m_CurrentSIGNo);
            m_ProductGeneralCategoryItemBindingService.SetSIG(m_CurrentSIGNo);
            m_ProductGeneralCategoryDefinitionBindingService.SetSIG(m_CurrentSIGNo);
            m_ProductIdStructureDefinitionBindingService.SetSIG(m_CurrentSIGNo);
            m_SupplierBindingService.SetSIG(m_CurrentSIGNo);
        }



        public int PG_No { get; set; }
        public int PG_DraftNo { get; set; }
        public PageHeaderEntity PG_PageHeaderInfo { get; set; }
        public EntityEditBriefHistory PG_EditBriefInfo { get; set; }

        [BindProperty]
        public ProductViewModel PG_Info { get; set; }













        public async Task Page_InitialAsync(FormEditModeEnum _formEditModeEnum)
        {
            PG_PageHeaderInfo = await m_WebSystemService.GetPageHeaderAsync(m_PageId, _formEditModeEnum);
            ViewData[AppSystem.VD_PageFullTitle] = PG_PageHeaderInfo.FullTitle;
        }

        public async Task Page_LoadAsync(FormEditModeEnum _formEditModeEnum)
        {

            if (PG_Info != null)
            {

                PG_Info.FormEditMode = _formEditModeEnum;
                
                if (_formEditModeEnum != FormEditModeEnum.Add)
                {
                    //PG_EditBriefInfo = PG_Info.ToFormEditHistoryBriefInfo;
                    //PG_EditBriefInfo.FillWithIDAndName(
                    //    await m_UserManagementService.GetOrgUser_ShortListAsync(PG_EditBriefInfo.ToUserEnumerator()));
                }

                // for _ProductGeneralCategoryEntitiesPartial.cshtml usage
                // 撈出該SIGNo所有PCGItem的全部清單項目
                ViewData[AppSystem.VD_ProductGeneralCategoryItem_List] = await m_ProductGeneralCategoryItemBindingService.GetListAsync();

                ViewData[AppSystem.VD_ProductCostDefinition_List] = await m_ProductCostBindingService.GetDefinitionListAsync(m_CurrentSIGNo);

                ViewData[AppSystem.VD_ProductPriceDefinition_List] = await m_ProductPriceBindingService.GetDefinitionListAsync(m_CurrentSIGNo);

                ViewData[AppSystem.VD_Supplier_SLI] = await m_SupplierBindingService.GetSelectListItemAsync();
                // 載入商品類別項目定義清單，以Razor頁面相關使用
                //PG_Info.ProductGeneralCategoryDefinitions = await m_ProductGeneralCategoryDefinitionBindingService.GetGeneralListAsync();

                //PG_Info.ProductGeneralCategoryItems = await m_ProductGeneralCategoryItemBindingService.GetGeneralListAsync();

                PG_Info.ProductIdStructureDefinitions = await m_ProductIdStructureDefinitionBindingService.GetGeneralListAsync();

                //PG_Info.ProductPriceDefinitions = await m_ProductPriceBindingService.GetDefinitionListAsync(m_CurrentSIGNo);
            }
        }


        private async Task PG_Info_ReloadAsync(int? _no, OperationEntityLoadingPolicyEnum _loadingPolicy = default(byte))
        {
            // 考量從其他頁面直接呼叫此程序，或者HTML(disabled)無法POST回正確的db value ，故強制Reload
            if (PG_Info != null && PG_Info.ProductNo.IsNullOrDefault() == false)
            {
                PG_No = PG_Info.ProductNo;
            }
            else
            {
                PG_No = _no.ToInt();                
            }

            if (PG_Info == null 
                || PG_Info?.ProductGeneralCategories.Any() == false
                || PG_Info.ProductGeneralCategories.FirstOrDefault().ProductGeneralCategoryDefinition == null)
                PG_Info = await m_ProductBindingService.GetEntityAsync(PG_No, _enableTracking: false, _includeDetails: true);

        }














        public async Task OnGetAsync(int _no, OperationEntityLoadingPolicyEnum _loadingPolicy = default(byte))
        {
            var currentFormEditMode = FormEditModeEnum.Read;
            await Page_InitialAsync(currentFormEditMode);

            PG_Info = await m_ProductBindingService.GetEntityAsync(_no, _enableTracking: false, _includeDetails: true);
            PG_No = PG_Info.ProductNo;

            await Page_LoadAsync(currentFormEditMode);
        }




        public async Task OnGetAddAsync()
        {
            await Page_InitialAsync(FormEditModeEnum.Add);

            PG_Info = await m_ProductBindingService.AddNewDefaultAsync();

            await Page_LoadAsync(FormEditModeEnum.Add);
        }




        public async Task OnGetRemoveAsync(int _no)
        {
            await OnGetAsync(_no);
            TempData[AppSystem.TD_UI_OnPageLoad_TriggerFunction] = "fnSwalBtnConfirmDelete_OnClick('btnDelete');";
        }











        public async Task<IActionResult> OnPostInsertAsync()
        {
            var currentFormEditMode = FormEditModeEnum.Add;
            await Page_InitialAsync(currentFormEditMode);



            // =========================================================================
            // 指派初始值或預設值            
            PG_Info.SetCreatePerson(m_CurrentUserNo);




            if (!ModelState.IsValid)
            {
                //ModelState.AddModelError(string.Empty, WebBaseUI.Form_Msg_ModelStateInValid);
                //TempData[AppSystem.TD_UI_OnPageLoad_Message_Notification] = WebBaseUI.Form_Msg_ModelStateInValid;
                //await Page_LoadAsync(currentFormEditMode);
                //return Page();
            }


            // -------------------------------------------------------
           


            // ================================================================
            var result = await m_ProductBindingService.ProcessToInsertAsync(PG_Info);
            if (result.ResultNo.IsNullOrDefault() == false)
            {
                TempData[AppSystem.TD_UI_OnPageLoad_Message_Notification] = WebBaseUI.Form_Msg_NTF_OperationInserted;
                return RedirectToPage("EntityProcess", new { _no = result.ResultNo });
            }


            await Page_LoadAsync(currentFormEditMode);
            return Page();
        }










        public async Task<IActionResult> OnPostDeleteAsync(int _no)
        {
            var currentFormEditMode = FormEditModeEnum.Remove;
            await Page_InitialAsync(currentFormEditMode);


            // 考量從其他頁面直接呼叫此程序，沒有經過正常的Get   
            await PG_Info_ReloadAsync(_no);



            // ========================================================================================
            // 須以POST後的資料做Validation，不包含 coding 中異動資料
            var validation = m_ProductBindingService.IsValidEntity(PG_Info, currentFormEditMode);
            if (validation.InValid)
            {
                ModelState.AddModelError(string.Empty, validation.Message);
                TempData[AppSystem.TD_UI_OnPageLoad_Message_Notification] = validation.Message;
                await Page_LoadAsync(currentFormEditMode);
                TempData[AppSystem.TD_UI_OnPageLoad_TriggerFunction] = WebBaseScript.JS_fnBtnBackFromEntityProcess_Hide;
                return Page();
            }


            // ==========================================================================
            // Submit process 在表單Level 不處理 SignAction
            //PG_Info.SubmitForRemove(m_CurrentUserNo, PG_SignInfo.SignDate);


            ////  ========================================================================
            var result = await m_ProductBindingService.ProcessToDeleteAsync(PG_Info);
            if (result.HasError)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                TempData[AppSystem.TD_UI_OnPageLoad_Message_Notification] = result.Message;
                await Page_LoadAsync(currentFormEditMode);
                TempData[AppSystem.TD_UI_OnPageLoad_TriggerFunction] = WebBaseScript.JS_fnBtnBackFromEntityProcess_Hide;
                return Page();
            }



            TempData[AppSystem.TD_UI_OnPageLoad_Message_Notification] = WebBaseUI.Form_Msg_NTF_SubmitCompleted;
            TempData.Put<PagePromptSwalEntity>(AppSystem.TD_UI_PagePrompt_Swal
                , new PagePromptSwalEntity()
                {
                    Title = WebBaseUI.Form_Alt_Submitted_Title,
                    Message = WebBaseUI.Form_Alt_Submitted_Msg,
                    RedirectURL = Url.PageLink("List")
                });

            await Page_LoadAsync(currentFormEditMode);
            return Page();
        }





    }
}
