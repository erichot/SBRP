using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SBRPDataKates.Repositories;
using SBRPDataKates.Models;


namespace SBRPBusinessTms.Services.KATES
{
    public class SystemSettingService
    {
        private S_SystemSettingRepository m_S_SystemSettingRepository;
        private S_ControllerRepository m_S_ControllerRepository;






        public SystemSettingService(S_SystemSettingRepository systemSettingRepository, S_ControllerRepository controllerRepository)
        {
            m_S_SystemSettingRepository = systemSettingRepository;
            m_S_ControllerRepository = controllerRepository;
        }









        public async Task<S_SystemSetting> GetEntityAsync(bool _enableTracking = false)
        {
            return await m_S_SystemSettingRepository.GetEntityAsync(default(byte), _enableTracking);
        }







        public string GetControllerPWD()
        {
            var result = string.Empty;
            var info = m_S_ControllerRepository.GetEntity();

            if (info != null && string.IsNullOrEmpty(info.PWD) == false)
            {
                result = info.PWD;
            }

            return result;
        }
        public async Task<string> GetControllerPWDAsync()
        {
            var result = string.Empty;
            var info = await  m_S_ControllerRepository.GetEntityAsync();

            if (info != null && string.IsNullOrEmpty(info.PWD) == false)
            {
                result = info.PWD;
            }

            return result;
        }










    }
}
