using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SBRPWebPsi.Pages.BasicInfo.Suppliers
{
    [Authorize]
    public class EntityProcessModel : PageModel
    {
        private const string m_PageId = "BISP0105";
        private readonly byte m_CurrentSIGNo;
        private readonly short m_CurrentUserNo;
        private readonly int m_CurrentLoginActionNo;
        public readonly string PG_API_UrlRoot;
        public readonly string PG_API_Token;



        private readonly AppSettingsModel m_AppSetting;
        private readonly IdentityClaimEntity m_CurrentLoginClaimInfo;
        private IHttpContextAccessor m_HttpContextAccessor;
        private readonly WebSystemService m_WebSystemService;
        private readonly AppUserBindingService m_AppUserBindingService;
        private readonly SupplierBindingService m_SupplierBindingService;

        public EntityProcessModel(IOptions<AppSettingsModel> appSetting
            , IHttpContextAccessor httpContextAccessor, WebSystemService webSystemService, AppUserBindingService appUserBindingService, SupplierBindingService supplierBindingService)
        {
            m_AppSetting = appSetting.Value;

            m_HttpContextAccessor = httpContextAccessor;
            m_WebSystemService = webSystemService;
            m_AppUserBindingService = appUserBindingService;
            m_SupplierBindingService = supplierBindingService;

            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentSIGNo = m_CurrentLoginClaimInfo.SIGNo;
            m_CurrentUserNo = m_CurrentLoginClaimInfo.UserNo;
            m_CurrentLoginActionNo = m_CurrentLoginClaimInfo.LoginActionNo;
            PG_API_UrlRoot = m_AppSetting.PSI_API_RootUrl;
            PG_API_Token = m_CurrentLoginClaimInfo.ApiToken;

            m_SupplierBindingService.SetSIG(m_CurrentSIGNo);
        }



        public short PG_No { get; set; }
        public int PG_DraftNo { get; set; }
        public PageHeaderEntity PG_PageHeaderInfo { get; set; }
        public EntityEditBriefHistory PG_EditBriefInfo { get; set; }

        [BindProperty]
        public SupplierViewModel PG_Info { get; set; }

        [BindProperty]
        public CompanyViewModel PG_Company { get; set; }

        






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
                if (PG_Info.Company != null) PG_Info.Company.FormEditMode = _formEditModeEnum;

                if (_formEditModeEnum != FormEditModeEnum.Add)
                {
                    //PG_EditBriefInfo = PG_Info.ToFormEditHistoryBriefInfo;
                    //PG_EditBriefInfo.FillWithIDAndName(
                    //    await m_UserManagementService.GetOrgUser_ShortListAsync(PG_EditBriefInfo.ToUserEnumerator()));
                }
            }
        }













        public async Task OnGetAsync(short _no, OperationEntityLoadingPolicyEnum _loadingPolicy = default(byte))
        {
            var currentFormEditMode = FormEditModeEnum.Read;
            await Page_InitialAsync(currentFormEditMode);

            PG_Info = await m_SupplierBindingService.GetEntityAsync(_no, _enableTracking:false, _includeDetails:true);
            PG_No = PG_Info.SupplierNo;

            await Page_LoadAsync(currentFormEditMode);
        }





        public async Task OnGetAddAsync()
        {
            await Page_InitialAsync(FormEditModeEnum.Add);

            PG_Info = m_SupplierBindingService.AddNewDefault(m_CurrentSIGNo,m_CurrentUserNo);
            PG_Company = PG_Info.Company;
  
            await Page_LoadAsync(FormEditModeEnum.Add);
        }




















        public async Task<IActionResult> OnPostInsertAsync()
        {
            var currentFormEditMode = FormEditModeEnum.Add;
            await Page_InitialAsync(currentFormEditMode);



            // =========================================================================
            // 指派初始值或預設值
            var companyId = PG_Company.TaxId;
            PG_Company.CompanyId = companyId;
            PG_Info.SupplierId = companyId;
            

            // PSI以 [Supplier]資料為主，僅在Insert時只是copy to [common].[Company] 無須刻意維持兩邊同步
            PG_Info.SupplierName = PG_Company.CompanyName;
            PG_Info.SupplierNameAbbr = PG_Company.CompanyNameAbbr;
            PG_Info.Company = PG_Company;
            

            PG_Info.SetCreatedPerson(m_CurrentUserNo);

            //if (PG_Info.BillingPeriodDay != null)
            //    PG_Info.BillingPeriodType = SBRPData.DateRangeTypeEnum.Monthly;
            //else
            //    PG_Info.BillingPeriodType = null;

            //if (PG_Info.PaymentPeriodDay != null)
            //    PG_Info.PaymentPeriodType = SBRPData.DateRangeTypeEnum.Monthly;
            //else
            //    PG_Info.PaymentPeriodType = null;


            if (!ModelState.IsValid)
            {
                //ModelState.AddModelError(string.Empty, WebBaseUI.Form_Msg_ModelStateInValid);
                //TempData[AppSystem.TD_UI_OnPageLoad_Message_Notification] = WebBaseUI.Form_Msg_ModelStateInValid;
                //await Page_LoadAsync(currentFormEditMode);
                //return Page();
            }


            

            var result = await m_SupplierBindingService.ProcessToInsertAsync(PG_Info);
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
