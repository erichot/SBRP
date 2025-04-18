
namespace SBRPWebPsi.BindingServices
{
    public class MenuitemBindingService
    {
        private readonly IMapper m_Mapper;
        private MenuitemService m_MenuitemService;

        public MenuitemBindingService(IMapper mapper, MenuitemService menuitemService)
        {
            m_Mapper = mapper;
            m_MenuitemService = menuitemService;
        }

        public async Task<List<MenuitemViewModel>> GetMenuitemWithPGCDByUserWithPermissionAsync(byte _sIGNo, short _userNo)
        {
            var list = await
               m_MenuitemService
                .GetMenuitemWithPGCDByUserWithPermissionAsync(_sIGNo, _userNo);

            return m_Mapper.Map<List<MenuitemViewModel>>(list);
        }

    }
}
