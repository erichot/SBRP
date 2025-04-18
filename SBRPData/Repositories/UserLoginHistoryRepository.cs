using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Repositories
{
    public class UserLoginHistoryRepository : EFCoreRepository<UserLoginHistory>
    {
        private readonly CommonDbContext m_CommonDbContext;

        public UserLoginHistoryRepository(CommonDbContext commonDbContext) : base(commonDbContext)
        {
            m_CommonDbContext = commonDbContext;
        }












        #region "Basic based Procedure"
        public UserLoginHistory? GetEntity(int _UserLoginHistoryNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new UserLoginHistory() { UserLoginHistoryNo = _UserLoginHistoryNo }, _enableTracking, _includeDetails);
        }
        public async Task<UserLoginHistory?> GetEntityAsync(int _UserLoginHistoryNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new UserLoginHistory() { UserLoginHistoryNo = _UserLoginHistoryNo }, _enableTracking, _includeDetails);
        }
        public UserLoginHistory? GetEntity(UserLoginHistory _info, bool _enableTracking, bool _includeDetails = true)
        {
            return GetQuery(_info, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<UserLoginHistory?> GetEntityAsync(UserLoginHistory _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_info, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }


        public IQueryable<UserLoginHistory> GetQuery(UserLoginHistory? _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            //var UserLoginHistoryNo = _info?.UserLoginHistoryNo;
            //var UserLoginHistoryId = _info?.UserLoginHistoryId;
            //var LoginId = _info?.LoginId;


            //var result = m_CommonDbContext
            //   .UserLoginHistorys
            //   .Where(c =>
            //        (UserLoginHistoryNo.IsNullOrDefault() || c.UserLoginHistoryNo == UserLoginHistoryNo)
            //        &&
            //        (string.IsNullOrEmpty(UserLoginHistoryId) || c.UserLoginHistoryId == UserLoginHistoryId)
            //        &&
            //        (string.IsNullOrEmpty(LoginId) || c.LoginId == LoginId)
            //   )
            //   ;


            //if (_enableTracking == false) return result.AsNoTracking();

            return null;
        }

        #endregion







    }
}
