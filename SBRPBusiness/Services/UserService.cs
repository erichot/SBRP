using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBusiness.Services
{
    public class UserService
    {
        private readonly CommonDbContext m_CommonDbContext;
        private readonly UserRepository m_UserRepository;


        public UserService(CommonDbContext commonDbContext)
        {
            m_CommonDbContext = commonDbContext;

            m_UserRepository = new UserRepository(commonDbContext);
        }










        #region "Basic based Procedure"
        public User? GetEntity(short _userNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_userNo.IsNullOrDefault()) return null;
            return m_UserRepository.GetEntity(_userNo, _enableTracking, _includeDetails);
        }
        public async Task<User?> GetEntityAsync(short _userNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_userNo.IsNullOrDefault()) return null;
            return await m_UserRepository.GetEntityAsync(_userNo, _enableTracking, _includeDetails);
        }
        public User? GetEntity(string _loginId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_loginId)) return null;
            return GetEntity(_loginId, _enableTracking, _includeDetails);
        }
        public async Task<User?> GetEntityAsync(string _loginId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_loginId)) return null;
            return await GetEntityAsync(_loginId, _enableTracking, _includeDetails);
        }
        public User? GetEntity(User _info, bool _enableTracking, bool _includeDetails = true)
        {
            return m_UserRepository.GetEntity(_info, _enableTracking, _includeDetails);
        }
        public async Task<User?> GetEntityAsync(User _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_UserRepository.GetEntityAsync(_info, _enableTracking, _includeDetails);
        }
        public List<User> GetList(User _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_UserRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToList();
        }
        public async Task<List<User>> GetListAsync(User _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_UserRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToListAsync();
        }
        public IQueryable<User> GetQuery(User? _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            return m_UserRepository.GetQuery(_info, _enableTracking, _includeDetails);
        }
        #endregion





        public User? GetEntity(string _loginId, string _passwordHash, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_loginId)) return null;
            return GetEntity(
                new User() { LoginId = _loginId, PasswordHash = _passwordHash },
                    _includeDetails);
        }

        public async Task<User?> GetEntityAsync(string _loginId, string _passwordHash, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_loginId)) return null;
            return await GetEntityAsync(
                new User() { LoginId = _loginId, PasswordHash = _passwordHash }
                ,_enableTracking: false
                ,_includeDetails: _includeDetails);
        }













        public async Task<SBRPData.Models.User?> LogForPasswordFailureAsync(string _loginID)
        {
            return await LogForPasswordFailureAsync(_loginID, null);
        }

        public async Task<SBRPData.Models.User?> LogForPasswordFailureAsync(string _loginID, short? _passwordFailureAttemptMaxCount = default(short))
        {
            var info = await m_UserRepository.GetEntityAsync(_loginID, _enableTracking: true, _includeDetails: false);

            // 確認_loginID 有存在的使用者。並非隨意亂打帳號
            if (info != null)
            {
                info.SetForPasswordFailure();

                if (_passwordFailureAttemptMaxCount > 0 && info.PasswordFailureAttemptCount >= _passwordFailureAttemptMaxCount)
                {
                    info.ExceedPasswordFailureMaxCount();
                }

                m_UserRepository.UpdateEntity(info);
                await m_CommonDbContext.SaveChangesAsync();
            }

            return info;
        }












        public async Task LogForLogonAsync(SBRPData.Models.UserLoginToken _info)
        {
            var info = await m_UserRepository.GetEntityAsync(_info.UserNo, _enableTracking: true, _includeDetails: false);
            info.SetToLogon(_info);

            m_UserRepository.UpdateEntity(info);

            await m_CommonDbContext.SaveChangesAsync();
        }








        public async Task ProcessToLogoutAsync(short _userNo)
        {
            var info = await m_UserRepository.GetEntityAsync(_userNo, _enableTracking: true, _includeDetails: false);
            info.SetToLogout();


            m_UserRepository.UpdateEntity(info);


            try
            {
                await m_CommonDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                info = null;
            }
        }






    }
}
