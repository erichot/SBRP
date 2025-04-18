using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBusiness.Services
{
    public class UserLoginService
    {
        private readonly CommonDbContext m_CommonDbContext;
        private readonly UserRepository m_UserRepository;
        private readonly UserLoginHistoryRepository m_UserLoginHistoryRepository;
        private readonly UserLoginTokenRepository m_UserLoginTokenRepository;



        public UserLoginService(CommonDbContext commonDbContext)
        {
            m_CommonDbContext = commonDbContext;
            m_UserRepository = new UserRepository(commonDbContext);
            m_UserLoginHistoryRepository = new UserLoginHistoryRepository(commonDbContext);
            m_UserLoginTokenRepository = new UserLoginTokenRepository(commonDbContext);
        }












        public async Task<UserLoginHistory> WriteLoginFailureEventAsync(UserLoginHistory _info)
        {
            var result = await m_UserLoginHistoryRepository.AddEntityAsync(_info);
            await m_CommonDbContext.SaveChangesAsync();
            return result;
        }















        #region "UserLoginToken"


        public byte GetTokenNewSerialNo(DateTime _issuedDate, short _userNo)
        {
            return m_UserLoginTokenRepository.GetNewSerialNo(_issuedDate.ToDateOnly(), _userNo);
        }
        public byte GetTokenNewSerialNo(DateOnly _issuedDate, short _userNo)
        {
            return m_UserLoginTokenRepository.GetNewSerialNo(_issuedDate, _userNo);
        }








        public UserLoginToken GeneralUserLoginToken(UserLoginToken _info)
        {
            var result = m_UserLoginTokenRepository.AddEntity(_info);
            m_CommonDbContext.SaveChanges();
            return result;
        }
        public async Task<UserLoginToken> GeneralUserLoginTokenAsync(UserLoginToken _info)
        {
            var result = await m_UserLoginTokenRepository.AddEntityAsync(_info);
            await m_CommonDbContext.SaveChangesAsync();
            return result;
        }




        public UserLoginToken? GetEntity(UserLoginToken _info, bool _enableTracking, bool _includeDetails = true)
        {
            return m_UserLoginTokenRepository.GetEntity(_info, _enableTracking, _includeDetails);
        }
        public async Task<UserLoginToken?> GetEntityAsync(UserLoginToken _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await 
                m_UserLoginTokenRepository
                    .GetEntityAsync(_info, _enableTracking, _includeDetails);
        }
        #endregion







    }
}

