using SBRPData;
using SBRPData.Repositories;

namespace SBRPWebPortal.BindingServices
{
    public class UserLoginBindingService
    {
        private readonly IMapper m_Mapper;
        private readonly UserLoginService m_UserLoginService;

        public UserLoginBindingService(IMapper mapper, UserLoginService userLoginService)
        {
            m_Mapper = mapper;
            m_UserLoginService = userLoginService;
        }







        public async Task<UserLoginHistory> WriteLoginFailureEventAsync(SBRP_AppIdEnum _appId
           , string _loginID            
           , ClientHttpContext _clientHttpContext
           , bool _isAccountDisabled = false
           , bool _hasBeenLocked = false)
        {

            var userLoginHistory = new UserLoginHistory
            {
                AppId = _appId,
                LoginId = _loginID,
                IsLoginSuccessful = false,
                IsAccountDisabled = _isAccountDisabled,
                HasBeenLocked = _hasBeenLocked,
                RemoteIpAddress = _clientHttpContext.RemoteIpAddress
            };


            return await m_UserLoginService.WriteLoginFailureEventAsync(userLoginHistory);
        }











        public UserLoginToken GeneralUserLoginToken(User _userInfo
           , ClientHttpContext _clientHttpContext)
        {
            var userNo = _userInfo.UserNo;
            var issuedDate = DateTime.Now;
            // 違反 PRIMARY KEY 條件約束 'PK_UserLoginToken'。無法在物件 'dbo.UserLoginToken' 中插入重複的索引鍵。重複的索引鍵值是 (2023-02-16, 3005, 2)
            var serialNo = m_UserLoginService.GetTokenNewSerialNo(issuedDate, userNo);
            var webToken = Guid.NewGuid().ToString().ToUpper().Replace("-", String.Empty);


            var userLoginTokenInfo = new UserLoginToken
            {
                IssuedDate = DateTime.Now.ToDateOnly(),
                UserNo = userNo,
                SerialNo = serialNo,
                WebToken = webToken,
                RemoteIpAddress = _clientHttpContext.RemoteIpAddress
            };

            return m_UserLoginService.GeneralUserLoginToken(userLoginTokenInfo);
        }
        public async Task<UserLoginToken> GeneralUserLoginTokenAsync(SBRP_AppIdEnum _appId
           , User _userInfo
           , ClientHttpContext _clientHttpContext)
        {
            var userNo = _userInfo.UserNo;
            var issuedDate = DateTime.Now;
            // 違反 PRIMARY KEY 條件約束 'PK_UserLoginToken'。無法在物件 'dbo.UserLoginToken' 中插入重複的索引鍵。重複的索引鍵值是 (2023-02-16, 3005, 2)
            var serialNo = m_UserLoginService.GetTokenNewSerialNo(issuedDate, userNo);
            var webToken = Guid.NewGuid().ToString().ToUpper().Replace("-", String.Empty);


            var userLoginTokenInfo = new UserLoginToken
            {
                IssuedDate = DateTime.Now.ToDateOnly(),
                UserNo = userNo,
                SerialNo = serialNo,
                AppId = _appId,
                WebToken = webToken,
                RemoteIpAddress = _clientHttpContext.RemoteIpAddress
            };

            return await m_UserLoginService.GeneralUserLoginTokenAsync(userLoginTokenInfo);
        }














    }
}
