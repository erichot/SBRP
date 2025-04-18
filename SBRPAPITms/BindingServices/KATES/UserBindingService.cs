using DocumentFormat.OpenXml;
using SBRPBusinessTms.Services.KATES;
using SBRPDataKates.Models;
using System.Text.RegularExpressions;

namespace SBRPAPITms.BindingServices.KATES
{
    public class UserBindingService
    {
        private IMapper m_Mapper;
        private UserService m_UserService;

        public UserBindingService(IMapper mapper, UserService userService)
        {
            m_Mapper = mapper;
            m_UserService = userService;
        }




        public async Task<CF_UserImportHead> AddNewEntityAsync(string _fileName, int _createdBy)
        {
            return await m_UserService.AddNewEntityAsync(_fileName, _createdBy);
        }




        public async Task<CF_UserImportHead> UploadWithDetailAsync(CF_UserImportHead _importHeadInfo, List<ChowFaceUserExportEntity> _details)
        {
            var importOperationNo = _importHeadInfo.ImportOperationNo;

            var importDetails = (
                from item in _details
                select m_Mapper.Map<CF_UserImportDetail>(item)
                )
                .ToList();

            importDetails.ForEach(
                r => r.ImportOperationNo = importOperationNo);


            // Phase 1 基本檢查
            importDetails
                .Where(c => 
                    (c.UserID == null || c.UserID == string.Empty)
                    ||
                    (c.UserID.Trim().Length > 12)
                )
                .ToList()
                .ForEach(r => {
                    r.InValid = true; r.Remark = "[UserID]異常";
                });


            importDetails
                .Where(c => c.InValid == false &&
                    (c.CardID == null || c.CardID == string.Empty)
                //||
                //(Regex.IsMatch(c.CardID, @"^\d+$") == false)
                )
                .ToList()
                .ForEach(r => {
                    r.InValid = true; r.Remark = "[CardID]異常";
                });


            importDetails
                .Where(c => c.InValid == false &&
                    (c.CardID.Trim().Length > 14)
                )
                .ToList()
                .ForEach(r => {
                    r.InValid = true; r.Remark = "[CardID]超出欄位長度";
                });


            importDetails
                 .Where(c => c.InValid == false &&
                     (c.UserName == null || c.UserName == string.Empty)
                 )
                 .ToList()
                 .ForEach(r => {
                     r.InValid = true; r.Remark = "[UserName]異常";
                 });


            // ----------------------------------------------
            // Phase 2 基本檢查：自身重複
            var enumUserID =
                importDetails
                    .Where(c => c.InValid == false)
                    .GroupBy(c => c.UserID)
                    .Where(c => c.Count() > 1)
                    .Select(c => c.Key);

           
            importDetails
                .Where(c => 
                    c.InValid == false
                    &&
                    enumUserID.Contains(c.UserID)
                    )
                .ToList()
                .ForEach(r => {
                    r.Remark = "[UserID]自身重複";
                    r.InValid = true; r.IsDuplicated = true;
                    });


            // ----------------------------------------------
            // Phase 3 基本檢查：自身重複
            var enumCardID =
                importDetails
                    .Where(c => c.InValid == false)
                    .GroupBy(c => c.CardID)
                    .Where(c => c.Count() > 1)
                    .Select(c => c.Key);

            importDetails
                .Where(c =>
                    c.InValid == false 
                    &&
                    enumCardID.Contains(c.CardID)
                    )
                .ToList()
                .ForEach(r => {
                    r.Remark = "[CardID]自身重複";
                    r.InValid = true; r.IsDuplicated = true;
                });


            // CardID 前置補0
            importDetails
               .Where(c =>
                   c.InValid == false && c.IsDuplicated == false
                   &&
                   c.CardID.Trim().Length < 10
                   )
               .ToList()
               .ForEach(r =>
                    r.CardID =
                        new string('0',
                            (10 - r.CardID.Trim().Length)
                            )
                        + r.CardID.Trim()
                    );


            var validRecord =
                importDetails
                    .Where(c => c.InValid == false && c.IsDuplicated == false)
                    .Count();


            _importHeadInfo.ValidRecord = Convert.ToInt16(validRecord);
            _importHeadInfo.CF_UserImportDetails = importDetails;

            return await m_UserService.UploadWithDetailAsync(_importHeadInfo);
        }

    }
}
