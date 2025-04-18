
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SBRPDataKates.Models;
using SBRPAPITms.BindingServices.KATES;
using System.Globalization;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using Microsoft.Extensions.Primitives;
//using DocumentFormat.OpenXml.Vml;




namespace SBRPAPITms.Controllers.KATES
{
    [Route("api/KATES/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private const string m_HeaderApiKey = "ChowApiKey";
        private readonly TransactionBindingService m_TransactionService;

        private readonly IHttpContextAccessor m_HttpContextAccessor;
        private readonly ApiSystemService m_ApiSystemService;
        private readonly FileManagementService m_FileManagementService;

        public TransactionController(TransactionBindingService transactionService, IHttpContextAccessor httpContextAccessor, ApiSystemService apiSystemService, FileManagementService fileManagementService)
        {
            m_TransactionService = transactionService;
            m_HttpContextAccessor = httpContextAccessor;
            m_ApiSystemService = apiSystemService;
            m_FileManagementService = fileManagementService;
        }







        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("TransactionImport/ChowFace")]
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
            var uploadPath = m_ApiSystemService.GetTargetFolderForUploadFile("Tran");
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
            string fileContent = string.Empty;
            short itemNo = default(short);
            var transactionExportList = new List<ChowFaceTransactionExportEntity>();
            try
            {

                using (StreamReader reader = new StreamReader(pathFileName))
                {
                    var lineText = string.Empty;
                    while ((lineText = reader.ReadLine()) != null)
                    {
                        itemNo++;
                        //var lineText = reader.ReadLine();
                        if (string.IsNullOrEmpty(lineText) == false)
                        {
                            var lineInfo = new ChowFaceTransactionExportEntity(lineText);
                            lineInfo.ItemNo = itemNo;

                            transactionExportList.Add(lineInfo);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                return StatusCode(ApiStatusCode.InternalServerError, "IOExp_" + ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(ApiStatusCode.InternalServerError, ex.Message);
            }



            // ==================================================================================
            // 建立表頭
            var transactionImportDetail = (
               from item in transactionExportList
               select item.ToTransactionImportDetail(0)
               )
               .ToList();

            var tranImportHeadInfo = await m_TransactionService.AddNewEntityAsync(uploadFileName, default(int), transactionImportDetail);
            var importOperationNo = tranImportHeadInfo.ImportOperationNo;

           

            //tranImportHeadInfo.CF_TransactionImportDetails = transactionImportDetail;
            //await m_TransactionService.UploadWithDetailAsync(tranImportHeadInfo);


            retResponse.responseNo = importOperationNo;
            // Return an empty string to signify success
            //return Ok(userImportHeadInfo.ImportOperationNo.ToString());
            return Ok(retResponse);
            //return Content("");
        }










        /// <summary>
        /// 取得資料庫中最後一筆（依據流水號排序）刷卡紀錄系統流水號
        /// </summary>
        /// <returns>
        /// 刷卡紀錄系統流水號（文字型態）
        /// </returns>
        /// <response code="200">
        /// API呼叫完成
        /// </response>
        /// <response code="403">
        /// ApiKey驗證失敗，拒絕存取
        /// </response>
        [HttpGet("LastTranSID")]
        [Produces("text/plain")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(ApiStatusCode.ForbidOnGeneralAccess)]
        public async Task<ActionResult<string>> GetLastTranSID()
        {
            StringValues _apiKeyValue;
            Request.Headers.TryGetValue(m_HeaderApiKey, out _apiKeyValue);
            if (AuthenticateApiKey(_apiKeyValue) == false)
            {
                return StatusCode(ApiStatusCode.ForbidOnGeneralAccess);
            }





            var info = await m_TransactionService.GetLastEntityAsync();
            var result = info?.TranSID ?? default(int);
            return Ok(result.ToString());
        }












        /// <summary>
        /// 傳入卡號及裝置別，並依據系統時間建立刷卡紀錄
        /// </summary>
        /// <param name="_info">
        /// 傳入參數。JSON格式， 包含：<br/><br/>
        /// [卡號]固定長度10位數值，且符合Integer數值型態。實際儲存將轉換為10碼長度字串，若不足10位則由API往左補0<br/>
        /// [設備代碼]2位數值<br/>
        /// </param>
        /// <param name="cardID">
        /// [卡號]固定長度10位數值，且符合Integer數值型態。實際儲存將轉換為10碼長度字串，若不足10位則由API往左補0
        /// </param>
        /// <param name="deviceID">
        /// [設備代碼]2位數值
        /// </param>        
        /// <returns></returns>
        /// <response code="200">
        /// 刷卡紀錄新增完成，回傳該筆紀錄之系統流水號（文字型態）
        /// </response>
        /// <response code="403">
        /// ApiKey驗證失敗，拒絕存取
        /// </response>       
        [HttpPost("ClockIn")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(ApiStatusCode.ForbidOnGeneralAccess)]
        public async Task<ActionResult<string>> AddEntityWithCurrentTimeAsync(TransactionSimpleBindingModel _info)

        {
            StringValues _apiKeyValue;
            Request.Headers.TryGetValue(m_HeaderApiKey, out _apiKeyValue);
            if (AuthenticateApiKey(_apiKeyValue) == false)
            {
                return StatusCode(ApiStatusCode.ForbidOnGeneralAccess);
            }


            var msg = string.Empty;

         


            // ================================================================
            var clientIP = m_HttpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "[empty]";

            var cardID = ConvertToCardID(_info.cardID);
            var tranDateTime = DateTime.Now;
            var tranType = default(byte);
            var dataType = default(byte);
            var weekdayNo = default(byte);            
            var note = "[KATESAPI_AC]";
            var isByTranType = false;
            var slaveID = _info.deviceID;
            int clientTranSID = default(int);


            var inserting = new OR_Transaction()
            {
                CardID = cardID,
                TranDateTime = tranDateTime,
                TranType = tranType,

                SlaveIP_Public = clientIP,
                IsReplicated = false,
                WorkShiftNo = 0,
                InActive = false,

                SyncTime = DateTime.Now,

                UserAddNewSID = 91,
                Note = note,

                Original_CardID = cardID,
                Original_TranDateTime = tranDateTime,
                Original_DataType = tranType,

                WeekdayNo = weekdayNo,
                DataType = dataType,

                IsByTranType = isByTranType,
                Original_TranType = dataType,

                SlaveID = slaveID,
                SlaveSID = slaveID,
                ClientTranSID = clientTranSID
            };


            var inserted = await m_TransactionService.AddEntityAsync(inserting);
            var tranSID = inserted.TranSID;

            return Ok(tranSID);
        }








        /// <summary>
        /// 依據詳細刷卡資料建立刷卡紀錄
        /// </summary>
        /// <param name="_info">
        /// 傳入參數。JSON格式， 包含：<br/><br/>
        /// [卡號]固定長度10位數值，且符合Integer數值型態。實際儲存將轉換為10碼長度字串，若不足10位則由API往左補0<br/>
        /// [刷卡日期]固定長度8位數值，格式為yyyyMMdd<br/>
        /// [刷卡時間]固定長度4位數值 ，格式hhss<br/>
        /// [設備代碼]2位數值<br/>
        /// [裝置端刷卡紀錄識別碼]選擇欄位，用於內部識別該筆刷卡紀錄在卡鐘內的唯一識別碼（可忽略此欄位）<br/>
        /// </param>
        /// <param name="cardID">
        /// [卡號]固定長度10位數值，且符合Integer數值型態。實際儲存將轉換為10碼長度字串，若不足10位則由API往左補0
        /// </param>
        /// <param name="tranDate">
        /// [刷卡日期]固定長度8位數值，格式為yyyyMMdd
        /// </param>
        /// <param name="tranTime">
        /// [刷卡時間]固定長度4位數值 ，格式hhss
        /// </param>
        /// <param name="deviceID">
        /// [設備代碼]2位數值
        /// </param>
        /// <param name="clientTranSID">
        /// [裝置端刷卡紀錄識別碼]選擇欄位，用於內部識別該筆刷卡紀錄在卡鐘內的唯一識別碼（可忽略此欄位）
        /// </param>
        /// <returns></returns>
        /// <response code="200">
        /// 刷卡紀錄新增完成，回傳該筆紀錄之系統流水號（文字型態）
        /// </response>
        /// <response code="403">
        /// ApiKey驗證失敗，拒絕存取
        /// </response>
        /// <response code="406">
        /// 傳入參數有誤，拒絕操作
        /// </response>
        [HttpPost("AddEntity")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(ApiStatusCode.ForbidOnGeneralAccess)]
        [ProducesResponseType(typeof(string), ApiStatusCode.NotAcceptable)]
        public async Task<ActionResult<string>> AddEntityAsync(TransactionBindingModel _info)

        {
            StringValues _apiKeyValue;
            Request.Headers.TryGetValue(m_HeaderApiKey, out _apiKeyValue);
            if (AuthenticateApiKey(_apiKeyValue) == false)
            {
                return StatusCode(ApiStatusCode.ForbidOnGeneralAccess);
            }

            int _cardID = _info.cardID;
            int _tranDate = _info.tranDate;
            short _tranTime = _info.tranTime;
            byte _deviceID = _info.deviceID;
            int? _clientTranSID = _info.clientTranSID??default(int);

            var msg = string.Empty;

            if (_tranDate > 2_100_12_31)
            {
                return StatusCode(ApiStatusCode.NotAcceptable, "[_tranDate]參數數值超出限制");
            }

            if (_tranTime > 2459)
            {
                return StatusCode(ApiStatusCode.NotAcceptable, "[_tranTime]參數數值超出限制");
            }


            // ================================================================
            var clientIP = m_HttpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString()??"[empty]";

            var cardID = ConvertToCardID(_cardID);
            var tranDateTime = ConvertToTranDateTime(_tranDate, _tranTime);
            var tranType = default(byte);
            var dataType = default(byte);
            var weekdayNo = default(byte);
            var note = "[KATESAPI_A]";
            var isByTranType = false;
            var slaveID = _deviceID;
            var clientTranSID = _clientTranSID??default(int);


            var inserting = new OR_Transaction()
            {
                CardID = cardID,
                TranDateTime = tranDateTime,
                TranType = tranType,

                SlaveIP_Public = clientIP,
                IsReplicated = false,
                WorkShiftNo = 0,
                InActive = false,

                SyncTime = DateTime.Now,

                UserAddNewSID = 91,
                Note = note,

                Original_CardID = cardID,
                Original_TranDateTime = tranDateTime,
                Original_DataType = tranType,

                WeekdayNo = weekdayNo,
                DataType = dataType,

                IsByTranType = isByTranType,
                Original_TranType = dataType,

                SlaveID = slaveID,
                SlaveSID = slaveID,
                ClientTranSID = clientTranSID
            };


            var inserted = await m_TransactionService.AddEntityAsync(inserting);
            var tranSID = inserted.TranSID;

            return Ok(tranSID);
        }
























        private bool AuthenticateApiKey(StringValues _keyValues)
        {
            if (_keyValues.ToString() == m_ApiSystemService.ControllerPWD)
            {
                return true;
            }

            return false;
        }






        private string ConvertToCardID(int _cardID)
        {
            var result = _cardID.ToString();

            if (result.Length < 10)
                result = new string('0', 10 - result.Length) + result;

            return result;
        }





        private DateTime ConvertToTranDateTime(int _tranDate, int _tranTime)
        {
            var result = DateTime.MinValue;
            var dateString = _tranDate.ToString() + " " + _tranTime.ToString();


            //if (DateTime.TryParseExact(dateString, "yyyyMMdd HHmm", CultureInfo.InvariantCulture, out result))
            try
            {
                result = DateTime.ParseExact(dateString, "yyyyMMdd HHmm", CultureInfo.InvariantCulture);
            }
            catch
            {

            }
            

            return result;
        }







    }
}
