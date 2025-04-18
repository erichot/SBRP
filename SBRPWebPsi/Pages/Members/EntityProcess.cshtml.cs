using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace SBRPWebPsi.Pages.Members
{
    public class EntityProcessModel : PageModel
    {
        private const string m_PageId = "BIMB0105";
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
        private readonly MemberBindingService m_MemberBindingService;
        private readonly ProductPriceBindingService m_ProductPriceBindingService;


        public EntityProcessModel(IOptions<AppSettingsModel> appSetting
         , IHttpContextAccessor httpContextAccessor, WebSystemService webSystemService, AppUserBindingService appUserBindingService
            , MemberBindingService MemberBindingService
            , ProductPriceBindingService productPriceBindingService)
        {
            m_AppSetting = appSetting.Value;

            m_HttpContextAccessor = httpContextAccessor;
            m_WebSystemService = webSystemService;
            m_AppUserBindingService = appUserBindingService;
            m_MemberBindingService = MemberBindingService;
            m_ProductPriceBindingService = productPriceBindingService;


            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentSIGNo = m_CurrentLoginClaimInfo.SIGNo;
            m_CurrentUserNo = m_CurrentLoginClaimInfo.UserNo;
            m_CurrentLoginActionNo = m_CurrentLoginClaimInfo.LoginActionNo;            
            PG_API_UrlRoot = m_AppSetting.PSI_API_RootUrl;
            PG_API_Token = m_CurrentLoginClaimInfo.ApiToken;

            m_MemberBindingService.SetSIG(m_CurrentSIGNo);
        }



        public int PG_No { get; set; }
        public int PG_DraftNo { get; set; }
        public PageHeaderEntity PG_PageHeaderInfo { get; set; }
        public EntityEditBriefHistory PG_EditBriefInfo { get; set; }

        [BindProperty]
        public MemberViewModel PG_Info { get; set; } 















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

                ViewData[AppSystem.VD_Product_Price_Definition_DisplayName_SLI] = await m_ProductPriceBindingService.GetDefinitionSelectListDisplayNameAsync(m_CurrentSIGNo);


                if (_formEditModeEnum != FormEditModeEnum.Add)
                {
                    //PG_EditBriefInfo = PG_Info.ToFormEditHistoryBriefInfo;
                    //PG_EditBriefInfo.FillWithIDAndName(
                    //    await m_UserManagementService.GetOrgUser_ShortListAsync(PG_EditBriefInfo.ToUserEnumerator()));
                }

               
            }
        }


        private async Task PG_Info_ReloadAsync(int? _no, OperationEntityLoadingPolicyEnum _loadingPolicy = default(byte))
        {
            // 考量從其他頁面直接呼叫此程序，或者HTML(disabled)無法POST回正確的db value ，故強制Reload
            if (PG_Info != null && PG_Info.MemberNo.IsNullOrDefault() == false)
            {
                PG_No = PG_Info.MemberNo;
            }
            else
            {
                PG_No = _no.ToInt();                
            }

            if (PG_Info == null)
                PG_Info = await m_MemberBindingService.GetEntityAsync(PG_No, _enableTracking: false, _includeDetails: true);

        }














        public async Task OnGetAsync(int _no, OperationEntityLoadingPolicyEnum _loadingPolicy = default(byte))
        {
            var currentFormEditMode = FormEditModeEnum.Read;
            await Page_InitialAsync(currentFormEditMode);

            PG_Info = await m_MemberBindingService.GetEntityAsync(_no, _enableTracking: false, _includeDetails: true);
            PG_No = PG_Info.MemberNo;

            await Page_LoadAsync(currentFormEditMode);
        }




        public async Task OnGetAddAsync()
        {
            await Page_InitialAsync(FormEditModeEnum.Add);

            PG_Info = await m_MemberBindingService.AddNewDefaultAsync();
            TempData[AppSystem.TD_UI_OnPageLoad_TriggerFunction] = "fnTxtPhoneNumber_Initial(0, null);";

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

            PG_Info.SetMonthDay(PG_Info.Birthday_MonthDay);







            if (!ModelState.IsValid)
            {
                //ModelState.AddModelError(string.Empty, WebBaseUI.Form_Msg_ModelStateInValid);
                //TempData[AppSystem.TD_UI_OnPageLoad_Message_Notification] = WebBaseUI.Form_Msg_ModelStateInValid;
                //await Page_LoadAsync(currentFormEditMode);
                //return Page();
            }


            // -------------------------------------------------------
           


            // ================================================================
            var result = await m_MemberBindingService.ProcessToInsertAsync(PG_Info);
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
            var validation = m_MemberBindingService.IsValidEntity(PG_Info, currentFormEditMode);
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
            var result = await m_MemberBindingService.ProcessToDeleteAsync(PG_Info);
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
