using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace SBRPWebPsi.Pages.Products.PriceDefinitions
{
    [Authorize]
    public class ListEntityProcessModel : PageModel
    {
        private const string m_PageId = "PTPD0107";
        private readonly byte m_CurrentSIGNo;
        private readonly short m_CurrentUserNo;
        private readonly int m_CurrentLoginActionNo;
       


        private readonly AppSettingsModel m_AppSetting;
        private readonly IdentityClaimEntity m_CurrentLoginClaimInfo;
        private IHttpContextAccessor m_HttpContextAccessor;
        private readonly WebSystemService m_WebSystemService;
        private readonly AppUserBindingService m_AppUserBindingService;
        private readonly ProductPriceBindingService m_ProductPriceBindingService;

        public ListEntityProcessModel(IOptions<AppSettingsModel> appSetting
            , IHttpContextAccessor httpContextAccessor, WebSystemService webSystemService, AppUserBindingService appUserBindingService
            , ProductPriceBindingService productPriceBindingService)
        {
            m_AppSetting = appSetting.Value;

            m_HttpContextAccessor = httpContextAccessor;
            m_WebSystemService = webSystemService;
            m_AppUserBindingService = appUserBindingService;
            m_ProductPriceBindingService = productPriceBindingService;


            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentSIGNo = m_CurrentLoginClaimInfo.SIGNo;
            m_CurrentUserNo = m_CurrentLoginClaimInfo.UserNo;
            m_CurrentLoginActionNo = m_CurrentLoginClaimInfo.LoginActionNo;
            m_ProductPriceBindingService.SetSIG(m_CurrentSIGNo);
        }



        public FormEditModeEnum PG_FormEditModeEnum { get; set; }
        public bool PG_FormEditModeIsReadonly;

        public PageHeaderEntity PG_PageHeaderInfo { get; set; }
        public EntityEditBriefHistory PG_EditBriefInfo { get; set; }


        [BindProperty]
        public List<ProductPriceDefinition> PG_List { get; set; }

       
        






        public async Task Page_InitialAsync(FormEditModeEnum _formEditModeEnum)
        {
            if (_formEditModeEnum == FormEditModeEnum.Add || _formEditModeEnum == FormEditModeEnum.Edit)
            {
                PG_FormEditModeIsReadonly = false;
            }
            else
            {
                PG_FormEditModeIsReadonly = true;
            }

            PG_PageHeaderInfo = await m_WebSystemService.GetPageHeaderAsync(m_PageId, _formEditModeEnum);
            ViewData[AppSystem.VD_PageFullTitle] = PG_PageHeaderInfo.FullTitle;
        }

        public async Task Page_LoadAsync(FormEditModeEnum _formEditModeEnum)
        {

            
        }













        public async Task OnGetAsync(OperationEntityLoadingPolicyEnum _loadingPolicy = default(byte))
        {
            PG_FormEditModeEnum = FormEditModeEnum.Read;
            await Page_InitialAsync(PG_FormEditModeEnum);

           
            PG_List = await
                m_ProductPriceBindingService
                    .GetDefinitionListAsync(m_CurrentSIGNo);

            if (PG_List == null || PG_List.Any() == false)
                await OnGetAddAsync();

            await Page_LoadAsync(PG_FormEditModeEnum);
        }





        public async Task OnGetAddAsync()
        {
            PG_FormEditModeEnum = FormEditModeEnum.Add;
            await Page_InitialAsync(PG_FormEditModeEnum);

            PG_List = await
                m_ProductPriceBindingService
                    .AddNewDefinitionDefaultAsync(m_CurrentSIGNo, 3);

            await Page_LoadAsync(PG_FormEditModeEnum);
        }




        public async Task OnGetEditsync()
        {
            PG_FormEditModeEnum = FormEditModeEnum.Edit;
            await Page_InitialAsync(PG_FormEditModeEnum);

            PG_List = await
                m_ProductPriceBindingService
                    .GetDefinitionListAsync(m_CurrentSIGNo);

            await Page_LoadAsync(PG_FormEditModeEnum);
        }













        public async Task<IActionResult> OnPostPushElementAsync()
        {
            PG_FormEditModeEnum = FormEditModeEnum.Add;
            await Page_InitialAsync(PG_FormEditModeEnum);

            var newPriceNo = (byte)(PG_List.Count);

            PG_List.Add(
                m_ProductPriceBindingService.AddNewDefinitionDefault(m_CurrentSIGNo, newPriceNo));

            await Page_LoadAsync(PG_FormEditModeEnum);
            return Page();
        }



        public async Task<IActionResult> OnPostPopElementAsync()
        {
            PG_FormEditModeEnum = FormEditModeEnum.Add;
            await Page_InitialAsync(PG_FormEditModeEnum);

            // 至少 Count = 2 才能 Pop
            if (PG_List.Count > 1)
            {
                PG_List.RemoveAt(PG_List.Count - 1);
            }
            
            await Page_LoadAsync(PG_FormEditModeEnum);
            return Page();
        }






        public async Task<IActionResult> OnPostInsertAsync()
        {
            PG_FormEditModeEnum = FormEditModeEnum.Add;
            await Page_InitialAsync(PG_FormEditModeEnum);



            // =========================================================================
            // 指派初始值或預設值
                     


            if (!ModelState.IsValid)
            {
                //ModelState.AddModelError(string.Empty, WebBaseUI.Form_Msg_ModelStateInValid);
                //TempData[AppSystem.TD_UI_OnPageLoad_Message_Notification] = WebBaseUI.Form_Msg_ModelStateInValid;
                //await Page_LoadAsync(currentFormEditMode);
                //return Page();
            }

            
            if (PG_List == null || PG_List.Any() == false)
            {
                await Page_LoadAsync(PG_FormEditModeEnum);
                return Page();
            }


            // ==============================================================================
            var createdDate = DateTime.Now; 
            //PG_List.ForEach(r => r.SetCreatePerson(m_CurrentUserNo, createdDate));


            var result = await 
                m_ProductPriceBindingService
                    .ProcessToInsertDefinitionAsync(PG_List);

            if (result.ResultValue > 0)
            {
                TempData[AppSystem.TD_UI_OnPageLoad_Message_Notification] = WebBaseUI.Form_Msg_NTF_OperationInserted;
                return RedirectToPage("ListEntityProcess");
            }


            await Page_LoadAsync(PG_FormEditModeEnum);
            return Page();
        }











        public async Task<IActionResult> OnPostUpdateAsync()
        {
            PG_FormEditModeEnum = FormEditModeEnum.Edit;
            await Page_InitialAsync(PG_FormEditModeEnum);



            // =========================================================================
            // 指派初始值或預設值



            if (!ModelState.IsValid)
            {
                //ModelState.AddModelError(string.Empty, WebBaseUI.Form_Msg_ModelStateInValid);
                //TempData[AppSystem.TD_UI_OnPageLoad_Message_Notification] = WebBaseUI.Form_Msg_ModelStateInValid;
                //await Page_LoadAsync(currentFormEditMode);
                //return Page();
            }


            if (PG_List == null || PG_List.Any() == false)
            {
                await Page_LoadAsync(PG_FormEditModeEnum);
                return Page();
            }


            // ==============================================================================
            var createdDate = DateTime.Now;
            //PG_List.ForEach(r => r.SetCreatePerson(m_CurrentUserNo, createdDate));


            var result = await
                m_ProductPriceBindingService
                    .ProcessToInsertDefinitionAsync(PG_List);

            if (result.ResultValue > 0)
            {
                TempData[AppSystem.TD_UI_OnPageLoad_Message_Notification] = WebBaseUI.Form_Msg_NTF_OperationInserted;
                return RedirectToPage("ListEntityProcess");
            }


            await Page_LoadAsync(PG_FormEditModeEnum);
            return Page();
        }







    }
}
