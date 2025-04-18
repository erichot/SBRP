using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace SBRPWebPsi.Pages
{
    public class TestModel : PageModel
    {

        public DataTable TableHeader;

        public void OnGet()
        {
        }
    }
}
