using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBussinessPsi.Services
{
    public class AppUserLoginService
    {
        private readonly CommonDbContext m_CommonDbContext;
        private readonly UserService m_UserService;
        private readonly UserLoginService m_UserLoginService;
        

        private readonly PsiDbContext m_PsiDbContext;        
        private readonly AppUserRepository m_AppUserRepository;

        public AppUserLoginService(CommonDbContext commonDbContext, PsiDbContext psiDbContext)
        {
            m_CommonDbContext = commonDbContext;
            m_UserService = new UserService(commonDbContext);
            m_UserLoginService = new UserLoginService(commonDbContext);


            m_PsiDbContext = psiDbContext;
            m_AppUserRepository = new AppUserRepository(psiDbContext);
        }







        public async Task<SBRPData.Models.UserLoginHistory> WriteLoginFailureEventAsync(SBRPData.Models.UserLoginHistory _info)
        {
            return await m_UserLoginService.WriteLoginFailureEventAsync(_info);
        }







        public byte GetTokenNewSerialNo(DateTime _issuedDate, short _userNo)
        {
            return m_UserLoginService.GetTokenNewSerialNo(_issuedDate, _userNo);
        }
        public byte GetTokenNewSerialNo(DateOnly _issuedDate, short _userNo)
        {
            return  m_UserLoginService.GetTokenNewSerialNo(_issuedDate, _userNo);
        }








        public SBRPData.Models.UserLoginToken GeneralUserLoginToken(SBRPData.Models.UserLoginToken _info)
        {
            return m_UserLoginService.GeneralUserLoginToken(_info);
        }
        public async Task<SBRPData.Models.UserLoginToken> GeneralUserLoginTokenAsync(SBRPData.Models.UserLoginToken _info)
        {
           return await m_UserLoginService.GeneralUserLoginTokenAsync(_info);
        }






        public async Task<UserLoginToken?> GetUserLoginTokenEntityAsync(UserLoginToken _info, bool _enableTracking, bool _includeDetails = true)
        {
            return await 
                m_UserLoginService
                    .GetEntityAsync(_info, _enableTracking, _includeDetails);
        }











        public async Task LogForLogonAsync(SBRPData.Models.UserLoginToken _info)
        {
            await m_UserService.LogForLogonAsync(_info);
        }








        public async Task ProcessToLogoutAsync(short _userNo)
        {
            await m_UserService.ProcessToLogoutAsync(_userNo);
        }














    }
}
