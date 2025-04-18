using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Repositories
{
    public class UserRepository : EFCoreRepository<User>
    {
        private readonly CommonDbContext m_CommonDbContext;
        public UserRepository(CommonDbContext commonDbContext) : base(commonDbContext)
        {
            m_CommonDbContext = commonDbContext;
        }












        #region "Basic based Procedure"
        public User? GetEntity(short _userNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new User() { UserNo = _userNo }, _enableTracking, _includeDetails);
        }
        public async Task<User?> GetEntityAsync(short _userNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new User() { UserNo = _userNo }, _enableTracking, _includeDetails);
        }
        public User? GetEntity(string _loginId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new User() { LoginId = _loginId }, _enableTracking, _includeDetails);
        }
        public async Task<User?> GetEntityAsync(string _loginId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new User() { LoginId = _loginId }, _enableTracking, _includeDetails);
        }
        //public User? GetEntity(string _userId, bool _enableTracking = false, bool _includeDetails = true)
        //{
        //    return GetEntity(
        //        new User() { UserId = _userId }, _enableTracking, _includeDetails);
        //}
        //public async Task<User?> GetEntityAsync(string _userId, bool _enableTracking = false, bool _includeDetails = true)
        //{
        //    return await
        //        GetEntityAsync(
        //            new User() { UserId = _userId }, _enableTracking, _includeDetails);
        //}
        public User? GetEntity(User _info, bool _enableTracking, bool _includeDetails = true)
        {
            return GetQuery(_info, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<User?> GetEntityAsync(User _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_info, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }


        public IQueryable<User> GetQuery(User? _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            var UserNo = _info?.UserNo;
            var UserId = _info?.UserId;
            var LoginId = _info?.LoginId;
            var PasswordHash = _info?.PasswordHash;


            var result = m_CommonDbContext
               .Users
               .Where(c =>
                    (UserNo.IsNullOrDefault() || c.UserNo == UserNo)
                    &&
                    (string.IsNullOrEmpty(UserId) || c.UserId == UserId)
                    &&
                    (string.IsNullOrEmpty(LoginId) || c.LoginId == LoginId)
                    &&
                    (string.IsNullOrEmpty(PasswordHash) || c.PasswordHash == PasswordHash)
               )
               ;


            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion




       





    }
}
