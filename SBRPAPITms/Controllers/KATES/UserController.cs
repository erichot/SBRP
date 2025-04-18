
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SBRPDataKates.Models;
using SBRPAPITms.BindingServices.KATES;




namespace SBRPAPITms.Controllers.KATES
{
    [Route("api/KATES/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserBindingService m_UserBindingService;

        private readonly IHttpContextAccessor m_HttpContextAccessor;
        private readonly ApiSystemService m_ApiSystemService;
        private readonly FileManagementService m_FileManagementService;
        private readonly ExcelBookService m_ExcelBookService;

        public UserController(UserBindingService userBindingService, IHttpContextAccessor httpContextAccessor, ApiSystemService apiSystemService, FileManagementService fileManagementService, ExcelBookService excelBookService)
        {
            m_UserBindingService = userBindingService;
            m_HttpContextAccessor = httpContextAccessor;
            m_ApiSystemService = apiSystemService;
            m_FileManagementService = fileManagementService;
            m_ExcelBookService = excelBookService;
        }









        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("UserImport/ChowFace")]
        public async Task<ActionResult<KendoChunkMetaDataResponse>> UploadFile(
             [FromForm] Dictionary<string, string> _kendoUploadMetaData
            , IFormFile files)
        {

            if (_kendoUploadMetaData == null)
            {
                //return Save(files);
            }


            var uploadDataValue = _kendoUploadMetaData.FirstOrDefault(c => c.Key == "metadata").Value;
            var kendoMetadataInfo = JsonSerializer.Deserialize<KendoMetadataRequest>(uploadDataValue);
            

            if (_kendoUploadMetaData.Count == 0)
            {
                return BadRequest(null);
            }


            // ========================================================================
            var uploadFileName = kendoMetadataInfo.fileName;
            var uploadPath = m_ApiSystemService.GetTargetFolderForUploadFile("User");
            var saveToFileName = DateTime.Now.ToString("MMddHHmm") + uploadFileName;
            var pathFileName = Path.Combine(uploadPath, saveToFileName);


            var processResult = await m_FileManagementService.SaveFileAsync(files, uploadPath, saveToFileName);
            if (processResult.HasError)
            {
                return StatusCode(ApiStatusCode.InternalServerError, processResult.Message);
            }



            // ===============================================================================
            // 續傳／分段
            var retResponse = new KendoChunkMetaDataResponse(kendoMetadataInfo.uploadUid);
            if (kendoMetadataInfo.totalChunks >= kendoMetadataInfo.chunkIndex + 1)
            {
                return retResponse;
            }
            else
            {
                retResponse.uploaded = true;
            }



            // ===============================================================================
            // 檔案上傳完成 
            var userImportHeadInfo = await m_UserBindingService.AddNewEntityAsync(uploadFileName, default(int));
            List<ChowFaceUserExportEntity> chowUserList;
            try
            {
                chowUserList = m_ExcelBookService.UploadToUserList(pathFileName);
            }
            catch (Exception ex)
            {
                return StatusCode(ApiStatusCode.InternalServerError, ex.Message);
            }

            userImportHeadInfo.TotalRecord = Convert.ToInt16(chowUserList.Count);
            await m_UserBindingService.UploadWithDetailAsync(userImportHeadInfo, chowUserList);


            retResponse.responseNo = userImportHeadInfo.ImportOperationNo;
            // Return an empty string to signify success
            //return Ok(userImportHeadInfo.ImportOperationNo.ToString());
            return Ok(retResponse);
            //return Content("");
        }





    }
}
