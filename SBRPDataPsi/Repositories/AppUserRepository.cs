using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class AppUserRepository : EFCoreRepository<AppUser>
    {
        private readonly PsiDbContext m_PsiDbContext;
        public AppUserRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }







        #region "Basic based Procedure"
        public AppUser? GetEntity(short _userNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new AppUser() { UserNo = _userNo }, _enableTracking, _includeDetails);
        }
        public async Task<AppUser?> GetEntityAsync(short _userNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new AppUser() { UserNo = _userNo }, _enableTracking, _includeDetails);
        }
        public AppUser? GetEntity(string _userId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new AppUser() { UserId = _userId }, _enableTracking, _includeDetails);
        }
        public async Task<AppUser?> GetEntityAsync(string _userId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new AppUser() { UserId = _userId }, _enableTracking, _includeDetails);
        }    
        public AppUser? GetEntity(AppUser _info, bool _enableTracking, bool _includeDetails = true)
        {
            return GetQuery(_info, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<AppUser?> GetEntityAsync(AppUser _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_info, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }


        public IQueryable<AppUser> GetQuery(AppUser? _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            var user = _info?.User;

            var UserNo = user?.UserNo;
            var UserId = user?.UserId;
            var LoginId = user?.LoginId;
            var PasswordHash = user?.PasswordHash;

            var result = m_PsiDbContext
               .AppUsers
               .Include(f => f.User)
               .Where(c =>
                    (UserNo.IsNullOrDefault() || c.User.UserNo == UserNo)
                    &&
                    (string.IsNullOrWhiteSpace(UserId) || c.User.UserId == UserId)
                    &&
                    (string.IsNullOrWhiteSpace(LoginId) || c.User.LoginId == LoginId)
                    &&
                    (string.IsNullOrWhiteSpace(PasswordHash) || c.User.PasswordHash == PasswordHash)
               );


            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion




        public IQueryable<AppUser> GetQuery(IEnumerable<short> _userNoEnumer)
        {
            return m_PsiDbContext
                .AppUsers
                .AsNoTracking()
                .Where(c => _userNoEnumer.Contains(c.UserNo));
        }





    }
}
