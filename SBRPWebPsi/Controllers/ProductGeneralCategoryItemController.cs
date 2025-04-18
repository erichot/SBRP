using Microsoft.AspNetCore.Mvc;

namespace SBRPWebPsi.Controllers
{
    [Route("[controller]")]
    public class ProductGeneralCategoryItemController : Controller
    {
        private string m_PageId;
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
        private readonly ProductGeneralCategoryDefinitionBindingService m_ProductGeneralCategoryDefinitionBindingService;
        private readonly ProductGeneralCategoryItemBindingService m_ProductGeneralCategoryItemBindingService;

        public ProductGeneralCategoryItemController(IOptions<AppSettingsModel> appSetting
            ,IHttpContextAccessor httpContextAccessor, WebSystemService webSystemService, AppUserBindingService appUserBindingService
            , ProductGeneralCategoryDefinitionBindingService productGeneralCategoryDefinitionBindingService
            , ProductGeneralCategoryItemBindingService productGeneralCategoryItemBindingService)
        {
            m_AppSetting = appSetting.Value;

            m_HttpContextAccessor = httpContextAccessor;
            m_WebSystemService = webSystemService;
            m_AppUserBindingService = appUserBindingService;
            m_ProductGeneralCategoryDefinitionBindingService = productGeneralCategoryDefinitionBindingService;
            m_ProductGeneralCategoryItemBindingService = productGeneralCategoryItemBindingService;

            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentSIGNo = m_CurrentLoginClaimInfo.SIGNo;
            m_CurrentUserNo = m_CurrentLoginClaimInfo.UserNo;
            m_CurrentLoginActionNo = m_CurrentLoginClaimInfo.LoginActionNo;
            PG_API_UrlRoot = m_AppSetting.PSI_API_RootUrl;
            PG_API_Token = m_CurrentLoginClaimInfo.ApiToken;

            m_ProductGeneralCategoryDefinitionBindingService.SetSIG(m_CurrentSIGNo);
            m_ProductGeneralCategoryItemBindingService.SetSIG(m_CurrentSIGNo);
        }


        public byte PG_PGCategoryNo { get; set; }
        public short PG_No { get; set; }
        public int PG_DraftNo { get; set; }

        public FormEditModeEnum PG_FormEditMode { get; set; }
        public PageHeaderEntity PG_PageHeaderInfo { get; set; }
        public EntityEditBriefHistory PG_EditBriefInfo { get; set; }

        public ProductGeneralCategoryDefinitionViewModel PG_PGCD { get; set; }
        public ProductGeneralCategoryItemViewModel PG_Info { get; set; }
        public EdFieldOptionsList<ProductGeneralCategoryItem> PG_EdFieldOptions { get; set; }





        public async Task Page_InitialAsync(FormEditModeEnum _formEditModeEnum)
        {
            PG_PGCD = await
               m_ProductGeneralCategoryDefinitionBindingService
                   .GetEntityAsync(PG_PGCategoryNo, _enableTracking: false, _includeDetails: false);

            PG_PageHeaderInfo = await m_WebSystemService.GetPageHeaderAsync(PG_PGCD, _formEditModeEnum);
            ViewData[AppSystem.VD_PageFullTitle] = PG_PageHeaderInfo.FullTitle;


            if (PG_PGCategoryNo.IsNullOrDefault() && PG_Info?.PGCategoryNo.IsNullOrDefault() == false)
                PG_PGCategoryNo = PG_Info.PGCategoryNo;


            
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
            }

            ViewData[AppSystem.VD_API_UrlRoot] = PG_API_UrlRoot;
            ViewData[AppSystem.VD_API_Token] = PG_API_Token;
        }






        public IActionResult Index()
        {
            return View();
        }








        [HttpGet("List")]
        public async Task<IActionResult> ListAsync(byte no)
        {
            PG_PGCategoryNo = no;
            await Page_InitialAsync(FormEditModeEnum.List);


            var list = await 
                m_ProductGeneralCategoryItemBindingService
                    .GetListAsync( 
                        new ProductGeneralCategoryItemFilter() { PGCategoryNo = PG_PGCategoryNo }
                        , _includeDetails:true);



            await Page_LoadAsync(FormEditModeEnum.List);
            var result = (PG_PageHeaderInfo, list, PG_PGCD);            
            return View(result);
        }



        [HttpGet("ListEdit")]
        public async Task<IActionResult> ListEditAsync(byte no)
        {
            PG_PGCategoryNo = no;
            await Page_InitialAsync(FormEditModeEnum.ListEdit);


            var list = await
                m_ProductGeneralCategoryItemBindingService
                    .GetListAsync(
                        new ProductGeneralCategoryItemFilter() { PGCategoryNo = PG_PGCategoryNo }
                        , _includeDetails: true);


            PG_EdFieldOptions = new EdFieldOptionsList<ProductGeneralCategoryItem>();
            PG_EdFieldOptions.AddElement(new EdFieldOptionsEntity<ProductGeneralCategoryItem>(c => c.PGCItemNo) { def=default(int)});
            PG_EdFieldOptions.AddElement(new EdFieldOptionsEntity<ProductGeneralCategoryItem>(c => c.PGCategoryNo) { def = PG_PGCategoryNo });
            PG_EdFieldOptions.AddElement(new EdFieldOptionsEntity<ProductGeneralCategoryItem>(c => c.PGCItemId, new EdFieldOptionsAttr(PG_PGCD.ItemIdMaxLength, AppSystem.CSS_Form_Field_Id)));
            PG_EdFieldOptions.AddElement(new EdFieldOptionsEntity<ProductGeneralCategoryItem>(c => c.PGCItemName, new EdFieldOptionsAttr()));
            //PG_EdFieldOptions.AddElement(new EdFieldOptionsEntity<ProductGeneralCategoryItem>(c => c.PGCItemOrderNo) { def = 100});


            await Page_LoadAsync(FormEditModeEnum.ListEdit);
            var result = (PG_PageHeaderInfo, list, PG_PGCD, PG_EdFieldOptions);
            return View(result);
        }














        [HttpGet("{_pGCItemNo}")]
        public async Task<IActionResult> EntityProcessAsync(short _pGCItemNo, FormEditModeEnum? _formEditModeEnum = null)
        {
            if (_formEditModeEnum == null || _formEditModeEnum == default)
            {
                PG_FormEditMode = FormEditModeEnum.Read;
            }
            else
            {
                //PG_FormEditMode = (FormEditModeEnum)Enum.Parse(typeof(FormEditModeEnum), _formEditModeEnum);
                PG_FormEditMode = (FormEditModeEnum)_formEditModeEnum;
            }
            


            

            if (PG_FormEditMode == FormEditModeEnum.Add)
            {
                PG_PGCategoryNo = (byte)_pGCItemNo;
                PG_Info = m_ProductGeneralCategoryItemBindingService.AddNewDefault(PG_PGCategoryNo);
            }
            else
            {
                PG_Info = await m_ProductGeneralCategoryItemBindingService.GetEntityAsync(_pGCItemNo, _includeDetails: true);
                if (PG_Info == null)
                {
                    return NotFound();
                }
                PG_PGCategoryNo = PG_Info.PGCategoryNo;
            }
            
            
            // --------------------------------------------------
            await Page_InitialAsync(PG_FormEditMode);
            await Page_LoadAsync(PG_FormEditMode);
            var result = (PG_PageHeaderInfo, PG_Info, PG_PGCD);
            // Note: 2024/12/31 從別的 procedure 轉call過來時，所預設尋找的View filename，仍為 parent precedure，而不是EntityProcess
            //return View(result);
            return View("~/Views/ProductGeneralCategoryItem/EntityProcess.cshtml",result);
        }







        //[HttpGet("Read")]
        //public async Task<IActionResult> EntityProcessAsync(short _pGCItemNo)
        //{
        //    PG_Info = await m_ProductGeneralCategoryItemBindingService.GetEntityAsync(_pGCItemNo, _includeDetails: true);
        //    await Page_InitialAsync(FormEditModeEnum.Read);



        //    await Page_LoadAsync(FormEditModeEnum.Read);
        //    var result = (PG_PageHeaderInfo, PG_Info, PG_PGCD);
        //    return View("~/Views/ProductGeneralCategoryItem/EntityProcess.cshtml", result);
        //}
        //[HttpGet("Add")]
        //public async Task<IActionResult> EntityProcessAsync(byte no)
        //{
        //    PG_PGCategoryNo = no;
        //    PG_Info = m_ProductGeneralCategoryItemBindingService.AddNewDefault(PG_PGCategoryNo);
        //    await Page_InitialAsync(FormEditModeEnum.Add);



        //    await Page_LoadAsync(FormEditModeEnum.Add);
        //    var result = (PG_PageHeaderInfo, PG_Info, PG_PGCD);
        //    return View("~/Views/ProductGeneralCategoryItem/EntityProcess.cshtml", result);
        //}




        //[HttpGet("Edit")]
        //public async Task<IActionResult> EntityProcessAsync(short _pGCItemNo)
        //{
        //    await Page_InitialAsync(FormEditModeEnum.Edit);

        //    PG_Info = await m_ProductGeneralCategoryItemBindingService.GetEntityAsync(_pGCItemNo, _includeDetails:true);

        //    await Page_LoadAsync(FormEditModeEnum.Edit);
        //    var result = (PG_PageHeaderInfo, PG_Info, PG_PGCD);
        //    return View("~/Views/ProductGeneralCategoryItem/EntityProcess.cshtml", result);
        //}


        //[HttpGet("Remove")]
        //public async Task<IActionResult> EntityProcessAsync(short _pGCItemNo)
        //{
        //    await Page_InitialAsync(FormEditModeEnum.Remove);

        //    PG_Info = await m_ProductGeneralCategoryItemBindingService.GetEntityAsync(_pGCItemNo, _includeDetails:true);

        //    await Page_LoadAsync(FormEditModeEnum.Remove);
        //    var result = (PG_PageHeaderInfo, PG_Info, PG_PGCD);
        //    return View("~/Views/ProductGeneralCategoryItem/EntityProcess.cshtml", result);
        //}























        [HttpPost("Insert")]
        public async Task<IActionResult> ProcessInsertAsync(ProductGeneralCategoryItemViewModel _info)
        {
            await Page_InitialAsync(FormEditModeEnum.Add);
            
            PG_PGCategoryNo = _info.PGCategoryNo;

            if (ModelState.IsValid == false)
            {
                await Page_LoadAsync(FormEditModeEnum.Add);
                return View("~/Views/ProductGeneralCategoryItem/EntityProcess.cshtml"
                    , (PG_PageHeaderInfo, _info, PG_PGCD));
            }

            
            _info.SetCreatePerson(m_CurrentUserNo);


            await Page_LoadAsync(FormEditModeEnum.Add);
            var result = await m_ProductGeneralCategoryItemBindingService.ProcessToInsertAsync(_info);
            //return RedirectToAction("Read", new { _pGCItemNo = result.ResultNo });
            return await EntityProcessAsync(Convert.ToInt16(result.ResultNo));
        }







        [HttpPost("Update")]
        public async Task<IActionResult> ProcessUpdateAsync(ProductGeneralCategoryItemViewModel _info)
        {
            await Page_InitialAsync(FormEditModeEnum.Edit);

            PG_PGCategoryNo = _info.PGCategoryNo;

            if (ModelState.IsValid == false)
            {
                await Page_LoadAsync(FormEditModeEnum.Edit);
                return View("~/Views/ProductGeneralCategoryItem/EntityProcess.cshtml"
                    , (PG_PageHeaderInfo, _info, PG_PGCD));
            }

            
            _info.SetUpdatePerson(m_CurrentUserNo);


            await Page_LoadAsync(FormEditModeEnum.Edit);
            var result = await m_ProductGeneralCategoryItemBindingService.ProcessToUpdateAsync(_info);
            return await EntityProcessAsync(Convert.ToInt16(result.ResultNo));
            //return RedirectToAction("Read", new { _pGCItemNo = result.ResultNo });
        }





        [HttpPost("Delete")]
        public async Task<IActionResult> ProcessDeleteAsync(ProductGeneralCategoryItemViewModel _info)
        {
            await Page_InitialAsync(FormEditModeEnum.Remove);

                        


            await Page_LoadAsync(FormEditModeEnum.Remove);
            var result = await m_ProductGeneralCategoryItemBindingService.ProcessToDeleteAsync(_info);
            return await ListAsync(_info.PGCategoryNo);
            //return RedirectToAction("List", new { no = _info.PGCategoryNo });
        }








    }
}
