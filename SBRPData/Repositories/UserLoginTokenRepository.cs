using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Repositories
{
    public class UserLoginTokenRepository : EFCoreRepository<UserLoginToken>
    {
        private readonly CommonDbContext m_CommonDbContext;
        public UserLoginTokenRepository(CommonDbContext commonDbContext) : base(commonDbContext)
        {
            m_CommonDbContext = commonDbContext;
        }









        #region "Basic based Procedure"
        //public UserLoginToken? GetEntity(short _UserLoginTokenNo, bool _enableTracking = false, bool _includeDetails = true)
        //{
        //    return GetEntity(
        //        new UserLoginToken() { UserLoginTokenNo = _UserLoginTokenNo }, _enableTracking, _includeDetails);
        //}
        //public async Task<UserLoginToken?> GetEntityAsync(short _UserLoginTokenNo, bool _enableTracking = false, bool _includeDetails = true)
        //{
        //    return await
        //        GetEntityAsync(
        //            new UserLoginToken() { UserLoginTokenNo = _UserLoginTokenNo }, _enableTracking, _includeDetails);
        //}
        //public UserLoginToken? GetEntity(string _loginId, bool _enableTracking = false, bool _includeDetails = true)
        //{
        //    return GetEntity(
        //        new UserLoginToken() { LoginId = _loginId }, _enableTracking, _includeDetails);
        //}
        //public async Task<UserLoginToken?> GetEntityAsync(string _loginId, bool _enableTracking = false, bool _includeDetails = true)
        //{
        //    return await
        //        GetEntityAsync(
        //            new UserLoginToken() { LoginId = _loginId }, _enableTracking, _includeDetails);
        //}

        public UserLoginToken? GetEntity(UserLoginToken _info, bool _enableTracking, bool _includeDetails = true)
        {
            return GetQuery(_info, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<UserLoginToken?> GetEntityAsync(UserLoginToken _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_info, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }


        public IQueryable<UserLoginToken> GetQuery(UserLoginToken? _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            var IssuedDate = _info?.IssuedDate??DateOnly.MinValue;
            var WebToken = _info?.WebToken;
            var LoginId = _info?.LoginId;
            var InValid_Filter = _info?.InValid_Filter;


            IQueryable<UserLoginToken> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_CommonDbContext
                    .UserLoginTokens
                    .Include(f => f.User)
                        .ThenInclude(ff => ff.Person);

            }
            else
            {
                basedQuery = m_CommonDbContext
                    .UserLoginTokens;
            }


            var result = basedQuery
               .Where(c =>
                    (IssuedDate == DateOnly.MinValue || c.IssuedDate == IssuedDate)
                    &&
                    (string.IsNullOrEmpty(WebToken) || c.WebToken == WebToken)
                    &&
                    (InValid_Filter == null || c.InValid == InValid_Filter)
                    &&
                    (_includeDetails == false || string.IsNullOrEmpty(LoginId) || c.User.LoginId == LoginId)
               )
               ;


            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion










        public string? GetWebToken(short _userNo, int _loginActionNo)
        {
            return m_CommonDbContext
                .UserLoginTokens
                .Where(c =>
                    c.UserNo == _userNo && c.LoginActionNo == _loginActionNo)
                .Select(c => c.WebToken)
                .FirstOrDefault();
        }
        public async Task<string?> GetWebTokenAsync(short _userNo, int _loginActionNo)
        {
            return await m_CommonDbContext
                .UserLoginTokens
                .Where(c =>
                    c.UserNo == _userNo && c.LoginActionNo == _loginActionNo)
                .Select(c => c.WebToken)
                .FirstOrDefaultAsync();
        }



        public byte GetNewSerialNo(DateOnly _issuedDate, short _userNo)
        {
            byte serialNo = m_CommonDbContext
                .UserLoginTokens
                .Where(x => x.IssuedDate == _issuedDate && x.UserNo == _userNo)
                .DefaultIfEmpty()
                .Max(x => (byte?)x.SerialNo ?? 0);

            return (byte)(serialNo + 1);
        }






        //public User? Getaaa(UserLoginToken _filter)
        //{
        //    var IssuedDate = _filter.IssuedDate;
        //    var LoginId = _filter.User?.LoginId;
        //    var WebToken = _filter.WebToken;


        //    return m_CommonDbContext
        //        .UserLoginTokens
        //        .Include(f => f.User)
        //        .Where(c => 
        //            c.InValid == false
        //            &&
        //            c.WebToken == WebToken
        //        )
        //        .FirstOrDefault();
        //}




    }
}
