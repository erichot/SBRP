using SBRPBusinessTms.Services.KATES;
using SBRPDataKates.Models;
using SBRPDataKates.Repositories;


namespace SBRPAPITms.BindingServices.KATES
{
    public class SystemSettingBindingService
    {
        private IMapper m_Mapper;
        private SystemSettingService m_SystemSettingService;

        public SystemSettingBindingService(IMapper mapper, SystemSettingService SystemSettingService)
        {
            m_Mapper = mapper;
            m_SystemSettingService = SystemSettingService;
        }





        public async Task<S_SystemSetting> GetEntityAsync(bool _enableTracking = false)
        {
            return await m_SystemSettingService.GetEntityAsync(_enableTracking);
        }




        public string GetControllerPWD()
        {
            return m_SystemSettingService.GetControllerPWD();
        }
        public async Task<string> GetControllerPWDAsync()
        {
            return await m_SystemSettingService.GetControllerPWDAsync();
        }



    }
}
