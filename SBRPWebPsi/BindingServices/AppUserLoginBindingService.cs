using SBRPData.Models;

namespace SBRPWebPsi.BindingServices
{
    public class AppUserLoginBindingService
    {
        private readonly AppUserLoginService m_AppUserLoginService;

        public AppUserLoginBindingService(AppUserLoginService appUserLoginService)
        {
            m_AppUserLoginService = appUserLoginService;
        }




        public async Task<SBRPData.Models.UserLoginHistory> WriteLoginFailureEventAsync(string _loginID
           , ClientHttpContext _clientHttpContext
           , bool _isAccountDisabled = false
           , bool _hasBeenLocked = false)
        {

            var userLoginHistory = new SBRPData.Models.UserLoginHistory
            {
                LoginId = _loginID,
                IsLoginSuccessful = false,
                IsAccountDisabled = _isAccountDisabled,
                HasBeenLocked = _hasBeenLocked,
                RemoteIpAddress = _clientHttpContext.RemoteIpAddress
            };


            return await m_AppUserLoginService.WriteLoginFailureEventAsync(userLoginHistory);
        }













        public UserLoginToken GeneralUserLoginToken(User _userInfo
           , ClientHttpContext _clientHttpContext)
        {
            var userNo = _userInfo.UserNo;
            var issuedDate = DateTime.Now;
            // 違反 PRIMARY KEY 條件約束 'PK_UserLoginToken'。無法在物件 'dbo.UserLoginToken' 中插入重複的索引鍵。重複的索引鍵值是 (2023-02-16, 3005, 2)
            var serialNo = m_AppUserLoginService.GetTokenNewSerialNo(issuedDate, userNo);
            var webToken = Guid.NewGuid().ToString().ToUpper().Replace("-", String.Empty);


            var userLoginTokenInfo = new UserLoginToken
            {
                IssuedDate = DateTime.Now.ToDateOnly(),
                UserNo = userNo,
                SerialNo = serialNo,
                WebToken = webToken,
                RemoteIpAddress = _clientHttpContext.RemoteIpAddress
            };

            return m_AppUserLoginService.GeneralUserLoginToken(userLoginTokenInfo);
        }
        public async Task<UserLoginToken> GeneralUserLoginTokenAsync(User _userInfo
           , ClientHttpContext _clientHttpContext)
        {
            var userNo = _userInfo.UserNo;
            var issuedDate = DateTime.Now;
            // 違反 PRIMARY KEY 條件約束 'PK_UserLoginToken'。無法在物件 'dbo.UserLoginToken' 中插入重複的索引鍵。重複的索引鍵值是 (2023-02-16, 3005, 2)
            var serialNo = m_AppUserLoginService.GetTokenNewSerialNo(issuedDate, userNo);
            var webToken = Guid.NewGuid().ToString().ToUpper().Replace("-", String.Empty);


            var userLoginTokenInfo = new UserLoginToken
            {
                IssuedDate = DateTime.Now.ToDateOnly(),
                UserNo = userNo,
                SerialNo = serialNo,
                WebToken = webToken,
                RemoteIpAddress = _clientHttpContext.RemoteIpAddress
            };

            return await m_AppUserLoginService.GeneralUserLoginTokenAsync(userLoginTokenInfo);
        }






        public async Task<UserLoginToken> GetUserLoginTokenEntityAsync(UserLoginToken _info, bool _enableTracking, bool _includeDetails = true)
        {
            return await m_AppUserLoginService
                .GetUserLoginTokenEntityAsync(_info, _enableTracking, _includeDetails);
        }






    }
}
