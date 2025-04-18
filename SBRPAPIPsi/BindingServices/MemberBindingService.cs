
namespace SBRPAPIPsi.BindingServices
{
    public class MemberBindingService
    {
        private IMapper m_Mapper;
        private readonly MemberService m_MemberService;

        public MemberBindingService(MemberService memberService, IMapper mapper)
        {
            m_MemberService = memberService;
            m_Mapper = mapper;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_MemberService.SetSIG(_sIGNo);
        }






        public async Task<MemberBindingModel> GetEntityAsync(int _MemberNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<MemberBindingModel>(
                    await m_MemberService.GetEntityAsync(_MemberNo: _MemberNo, _enableTracking, _includeDetails));
        }
        public async Task<MemberBindingModel> GetEntityAsync(string _MemberId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<MemberBindingModel>(
                    await m_MemberService.GetEntityAsync(_MemberId: _MemberId, _enableTracking, _includeDetails)); 
        }
       





    }
}
