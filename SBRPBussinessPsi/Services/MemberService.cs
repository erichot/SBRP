using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBussinessPsi.Services
{
    public class MemberService : ISystemIsolationGroupInterface
    {
        private readonly CommonDbContext m_CommonDbContext;
        private readonly PersonService m_PersonService;

        private readonly PsiDbContext m_PsiDbContext;        
        private readonly MemberRepository m_MemberRepository;
        
        public MemberService(PsiDbContext psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
            m_MemberRepository = new MemberRepository(psiDbContext);           
        }

        public MemberService(CommonDbContext commonDbContext, PsiDbContext psiDbContext)
        {
            m_CommonDbContext = commonDbContext;
            m_PersonService = new PersonService(commonDbContext);


            m_PsiDbContext = psiDbContext;
            m_MemberRepository = new MemberRepository(psiDbContext);
        }



        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_MemberRepository.SetSIG(_sIGNo);

            if (m_PersonService != null)
                m_PersonService.SetSIG(_sIGNo);
        }


        
















        #region "Basic based Procedure"
        public Member? GetEntity(int _MemberNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_MemberNo.IsNullOrDefault()) return null;
            return m_MemberRepository.GetEntity(_MemberNo, _enableTracking, _includeDetails);
        }
        public async Task<Member?> GetEntityAsync(int _MemberNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_MemberNo.IsNullOrDefault()) return null;
            return await m_MemberRepository.GetEntityAsync(_MemberNo, _enableTracking, _includeDetails);
            
        }
        public Member? GetEntity(string _MemberId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrWhiteSpace(_MemberId)) return null;
            return m_MemberRepository.GetEntity(_MemberId, _enableTracking, _includeDetails);

        }
        public async Task<Member?> GetEntityAsync(string _MemberId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrWhiteSpace(_MemberId)) return null;
            return await m_MemberRepository.GetEntityAsync(_MemberId, _enableTracking, _includeDetails);
        }
        
        public Member? GetEntity(Member _info, bool _enableTracking, bool _includeDetails = true)
        {
            return m_MemberRepository.GetEntity(_info, _enableTracking, _includeDetails);
        }
        public async Task<Member?> GetEntityAsync(Member _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_MemberRepository.GetEntityAsync(_info, _enableTracking, _includeDetails);
        }
        public List<Member> GetList(Member _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_MemberRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToList();
        }
        public async Task<List<Member>> GetListAsync(Member _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_MemberRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToListAsync();
        }
        public IQueryable<Member> GetQuery(Member? _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            return m_MemberRepository.GetQuery(_info, _enableTracking, _includeDetails);
        }
        #endregion




    



        public async Task<List<Member>> GetListAsync(MemberFilter _filter)
        {
            return await m_MemberRepository
                 .GetQuery(
                    _filter.ToEntity()
                    , _enableTracking:false, _includeDetails:false)
                 .ToListAsync();
        }









        public async Task<bool> IsExistedMemberAsync(string _MemberId)
        {
            if (string.IsNullOrWhiteSpace(_MemberId) == false)
            {
                var info = await
                    m_MemberRepository
                        .GetEntityAsync(_MemberId, _enableTracking: false, _includeDetails: false);

                if (info != null && info.MemberNo.IsNullOrDefault() == false)
                    return true;
            }

            return false;
        }
















        public ValidationResultEntity IsValidEntity(Member _info, byte _submitActionModeNo)
        {
            return IsValidEntity(_info, (SubmitActionModeEnum)Enum.ToObject(typeof(SubmitActionModeEnum), _submitActionModeNo));
        }
        public ValidationResultEntity IsValidEntity(Member _info, SubmitActionModeEnum _formEditMode = default)
        {
            var result = new ValidationResultEntity();
            var MemberNo = _info.MemberNo;

            if (_formEditMode == SubmitActionModeEnum.Remove) {
                if (m_MemberRepository.IsValid_Member_Deleting(MemberNo) == false)
                {
                    result.SetInValid("Member is in used.");
                    return result;
                }
            }

            return result;
        }























        public async Task<Member> AddNewDefaultAsync()
        {   
            var result = new Member()
            {
                ProductPriceNo = 0,
                Person = m_PersonService.AddNewDefault(),
            };

            return result;
        }






        /// <summary>
        /// 
        /// </summary>
        /// <param name="_info"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        public async Task<BusinessProcessResult> ProcessToInsertAsync(Member _info)
        {
            var result = new BusinessProcessResult();
            
            _info.SetSIG(m_SIGNo);
            _info.SyncToPerson();


            var entity = await m_MemberRepository.AddEntityAsync(_info);


            await m_PsiDbContext.SaveChangesAsync();
            result.ResultNo = entity.MemberNo;

            try
            {
                
            }
            catch (Exception ex)
            {
                result.SetErrorMessage(ex.Message);
            }


            return result;
        }









        public async Task<BusinessProcessResult> ProcessToDeleteAsync(Member _info)
        {
            var dataResult = m_MemberRepository.DELETE_Member(_info.MemberNo);
            return new BusinessProcessResult(dataResult);
        }












    }
}
