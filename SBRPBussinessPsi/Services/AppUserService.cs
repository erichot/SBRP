using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBussinessPsi.Services
{
    public class AppUserService
    {
        private readonly CommonDbContext m_CommonDbContext;
        private readonly UserService m_UserService;

        private readonly PsiDbContext m_PsiDbContext;
        private readonly AppUserRepository m_AppUserRepository;

        public AppUserService(CommonDbContext commonDbContext, PsiDbContext psiDbContext)
        {
            m_CommonDbContext = commonDbContext;
            m_UserService = new UserService(commonDbContext);

            m_PsiDbContext = psiDbContext;
            m_AppUserRepository = new AppUserRepository(psiDbContext);
        }







        #region "Basic based Procedure"
        public AppUser? GetEntity(short _userNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_userNo.IsNullOrDefault()) return null;
            return m_AppUserRepository.GetEntity(_userNo, _enableTracking, _includeDetails);
        }
        public async Task<AppUser?> GetEntityAsync(short _userNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_userNo.IsNullOrDefault()) return null;
            return await m_AppUserRepository.GetEntityAsync(_userNo, _enableTracking, _includeDetails);
        }
        public AppUser? GetEntity(string _AppUserId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_AppUserId)) return null;
            return GetEntity(_AppUserId, _enableTracking, _includeDetails);
        }
        public async Task<AppUser?> GetEntityAsync(string _AppUserId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_AppUserId)) return null;
            return await GetEntityAsync(_AppUserId, _enableTracking, _includeDetails);
        }
        public AppUser? GetEntity(AppUser _info, bool _enableTracking, bool _includeDetails = true)
        {
            return m_AppUserRepository.GetEntity(_info, _enableTracking, _includeDetails);
        }
        public async Task<AppUser?> GetEntityAsync(AppUser _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_AppUserRepository.GetEntityAsync(_info, _enableTracking, _includeDetails);
        }
        public List<AppUser> GetList(AppUser _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_AppUserRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToList();
        }
        public async Task<List<AppUser>> GetListAsync(AppUser _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_AppUserRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToListAsync();
        }
        public IQueryable<AppUser> GetQuery(AppUser? _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            return m_AppUserRepository.GetQuery(_info, _enableTracking, _includeDetails);
        }
        #endregion



        public IQueryable<AppUser> GetQuery(IEnumerable<short> _userNoEnumer)
        {
            return m_AppUserRepository.GetQuery(_userNoEnumer);
        }






        public AppUser? GetEntity(string _loginId, string _passwordHash, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_loginId)) return null;
            return GetEntity(
                new AppUser() { LoginId = _loginId, PasswordHash = _passwordHash },
                    _includeDetails);
        }
        public async Task<AppUser?> GetEntityAsync(string _loginId, string _passwordHash, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_loginId)) return null;
            return await GetEntityAsync(
                new AppUser() { LoginId = _loginId, PasswordHash = _passwordHash }
                , _enableTracking: false
                , _includeDetails: _includeDetails);
        }




        public AppUser? GetEntity(User _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_info == null || _info.UserNo.IsNullOrDefault()) return null;
            return GetEntity(
                new AppUser() { UserNo = _info.UserNo}
                , _enableTracking, _includeDetails);
        }
        public async Task<AppUser?> GetEntityAsync(User _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_info == null || _info.UserNo.IsNullOrDefault()) return null;
            return await GetEntityAsync(
                new AppUser() { UserNo = _info.UserNo }
                , _enableTracking, _includeDetails);
        }






        //public async Task<AppUser?> LogForPasswordFailureAsync(string _loginID)
        //{
        //    var user = await m_UserService.LogForPasswordFailureAsync(_loginID, null);
        //    return await GetEntityAsync(user);
        //}

        //public async Task<AppUser?> LogForPasswordFailureAsync(string _loginID, short? _passwordFailureAttemptMaxCount = default(short))
        //{
        //    var user = await m_UserService.LogForPasswordFailureAsync(_loginID, _passwordFailureAttemptMaxCount);
        //    return await GetEntityAsync(user);
        //}
        public async Task<SBRPData.Models.User?> LogForPasswordFailureAsync(string _loginID)
        {
            return await LogForPasswordFailureAsync(_loginID, null);
        }
        public async Task<SBRPData.Models.User?> LogForPasswordFailureAsync(string _loginID, short? _passwordFailureAttemptMaxCount = default(short))
        {
            return await m_UserService.LogForPasswordFailureAsync(_loginID, _passwordFailureAttemptMaxCount);
        }







        public async Task LogForLogonAsync(UserLoginToken _info)
        {
            await m_UserService.LogForLogonAsync(_info);
        }








        public async Task ProcessToLogoutAsync(short _userNo)
        {
            await m_UserService.ProcessToLogoutAsync(_userNo);
        }








    }
}
