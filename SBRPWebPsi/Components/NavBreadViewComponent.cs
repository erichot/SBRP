using Microsoft.AspNetCore.Mvc;

namespace SBRPWebPsi.Components
{
    public class NavBreadViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor m_HttpContextAccessor;
       

        public NavBreadViewComponent(IHttpContextAccessor httpContextAccessor)
        {
            m_HttpContextAccessor = httpContextAccessor;
           
        }


        public IViewComponentResult Invoke(string pageID = null, string formID = null)
        {
            ViewData["id"] = pageID;
            
           
            return View();
        }



    }
}
