using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class MemberRepository : EFCoreRepository<Member>, ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;
        public MemberRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
        }

















        #region "Basic based Procedure"
        public Member? GetEntity(int _MemberNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new Member() { MemberNo =  _MemberNo }, _enableTracking, _includeDetails);
        }
        public async Task<Member?> GetEntityAsync(int _MemberNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new Member() { MemberNo =  _MemberNo }, _enableTracking, _includeDetails);
        }
        public Member? GetEntity(string _MemberId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new Member() { MemberId = _MemberId }, _enableTracking, _includeDetails);
        }
        public async Task<Member?> GetEntityAsync(string _MemberId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new Member() { MemberId = _MemberId }, _enableTracking, _includeDetails);
        }    
        public Member? GetEntity(Member _info, bool _enableTracking, bool _includeDetails = true)
        {            
            return GetQuery(_info, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<Member?> GetEntityAsync(Member _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_info, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }


        public IQueryable<Member?> GetQuery(Member? _info = null, bool _enableTracking = false, bool _includeDetails = false)
        {

            var SIGNo = m_SIGNo;
            var MemberNo =  _info?.MemberNo;
            var MemberId = _info?.MemberId;


            IQueryable<Member?> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_PsiDbContext
                    .Members
                    .Include(f => f.Person)
                        .ThenInclude(ff => ff.PersonContactPhones)
                    ;
            }
            else
            {
                basedQuery = m_PsiDbContext
                    .Members;
            }



            var result = basedQuery
                .Where(c =>
                    (MemberNo.IsNullOrDefault() || c.MemberNo == MemberNo)
                    &&
                    (string.IsNullOrWhiteSpace(MemberId) || c.MemberId == MemberId)
                    &&
                    (SIGNo.IsNullOrDefault() || c.SIGNo == SIGNo)
                );
                
                
            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion


























        public bool IsValid_Member_Deleting(int _MemberNo)
        {
            var result = false;
            var returnValue = default(int);
            var connectionString = m_PsiDbContext.Database.GetConnectionString();

            using (var conn = new SqlConnection(connectionString))
            {
                var dparams = new DynamicParameters();
                dparams.Add("@MemberNo", _MemberNo, dbType: DbType.Int32);
                dparams.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                conn.Execute("psi.uspIsValid_Member_Deleting", dparams, commandType: CommandType.StoredProcedure);
                returnValue = dparams.Get<int>("@ReturnValue");
                if (returnValue == 1) result = true;
            }

            return result;
        }

        public DataProcessResult DELETE_Member(int _MemberNo)
        {
            var result = new DataProcessResult();
            var returnValue = default(int);
            var connectionString = m_PsiDbContext.Database.GetConnectionString();

            using (var conn = new SqlConnection(connectionString))
            {
                var dparams = new DynamicParameters();
                dparams.Add("@MemberNo", _MemberNo, dbType: DbType.Int32);
                dparams.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                conn.Execute("psi.uspDELETE_Member_ByMemberNo", dparams, commandType: CommandType.StoredProcedure);
                returnValue = dparams.Get<int>("@ReturnValue");
                if (returnValue <= 0)
                {
                    result.ResultValue = returnValue;
                    result.Message = "刪除失敗";
                }
            }

            return result;
        }




    }
}
