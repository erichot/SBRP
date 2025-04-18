namespace SBRPAPIPsi.Services
{
    public class ApiSystemService
    {
        private IWebHostEnvironment m_Environment;

        public ApiSystemService(IWebHostEnvironment environment)
        {
            m_Environment = environment;
        }













        //public string GetTargetFolderForUploadFile(OperationClassEnum _operationClass)
        //{
        //    var subfolder = "generalfile";
        //    var subYearFolder = DateTime.Now.Year.ToString();

        //    switch (_operationClass)
        //    {
        //        case OperationClassEnum.Abandon:
        //            subfolder = "Abandon";
        //            break;

        //        case OperationClassEnum.Exchange:
        //            subfolder = "Exchange";
        //            break;

        //        case OperationClassEnum.Invent:
        //            subfolder = "InventCouponDetail";
        //            break;

        //        case OperationClassEnum.ProjectCouponAbandon:
        //            subfolder = "ProjectCouponAbandon";
        //            break;
        //    }

        //    return Path.Combine(m_Environment.ContentRootPath, "Uploads", subfolder, subYearFolder);
        //}






    }
}
