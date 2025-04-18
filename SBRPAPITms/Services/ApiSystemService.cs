using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SBRPAPITms.BindingServices.KATES;

namespace SBRPAPITms.Services
{
    public class ApiSystemService
    {
        private IWebHostEnvironment m_Environment;
        private SystemSettingBindingService m_SystemSettingService;
        public readonly string ControllerPWD;


        public ApiSystemService(IWebHostEnvironment environment, SystemSettingBindingService systemSettingService)
        {
            m_Environment = environment;
            m_SystemSettingService = systemSettingService;
            ControllerPWD = systemSettingService.GetControllerPWD();
        }





        






        public string GetTargetFolderForUploadFile(string _subFolder)
        {
            var subfolder = _subFolder;
            var subYearFolder = DateTime.Now.Year.ToString();

            

            return Path.Combine(m_Environment.ContentRootPath, "Uploads", subfolder, subYearFolder);
        }






    }
}
