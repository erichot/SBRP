

namespace SBRPWebPsi.BindingServices
{
    public class MemberBindingService : ISystemIsolationGroupInterface
    {
        private readonly IMapper m_Mapper;
        private readonly MemberService m_MemberService;
        


        public MemberBindingService( IMapper mapper, MemberService MemberService)
        {
            m_Mapper = mapper;
            m_MemberService = MemberService;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_MemberService.SetSIG(_sIGNo);
        }












        public async Task<MemberViewModel> GetEntityAsync(int _MemberNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<MemberViewModel>(
                await m_MemberService.GetEntityAsync(_MemberNo, _enableTracking, _includeDetails));
        }


        public List<MemberViewModel> GetList(Member _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<MemberViewModel>>(
               m_MemberService.GetList(_info, _enableTracking, _includeDetails));
        }
        public async Task<List<MemberViewModel>> GetListAsync(Member _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<List<MemberViewModel>>(
               await m_MemberService.GetListAsync(_info, _enableTracking, _includeDetails));
        }



        public async Task<List<MemberViewModel>> GetListAsync(MemberFilterViewModel _filter)
        {
            return m_Mapper.Map<List<MemberViewModel>>(
               await m_MemberService.GetListAsync(
                   m_Mapper.Map<MemberFilter>(_filter))
               );
        }




















        // 編輯中
        public async Task<MemberViewModel> AddNewDefaultAsync()
        {
            var result = m_Mapper.Map<MemberViewModel>(
                     await m_MemberService.AddNewDefaultAsync());
            return result;
        }













        public ValidationResultEntity IsValidEntity(MemberViewModel _info, FormEditModeEnum _formEditMode = default)
        {            
            return m_MemberService.IsValidEntity(
                m_Mapper.Map<Member>(_info), (byte)_formEditMode);
        }






        public async Task<BusinessProcessResult> ProcessToInsertAsync(MemberViewModel _info)
        {
            return await 
                m_MemberService
                    .ProcessToInsertAsync(
                        m_Mapper.Map<Member>(_info));
        }


        public async Task<BusinessProcessResult> ProcessToDeleteAsync(MemberViewModel _info)
        {
            return await
                m_MemberService
                    .ProcessToDeleteAsync(
                        m_Mapper.Map<Member>(_info));
        }











    }
}
