using CrowdFundingDAO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Avanze_ProjectoWeb.Pages.Projecto
{
    public class InicioPrincipalModel : PageModel
    {
        public void OnGet()
        {
            SessionClass.IsChange = false;
        }
    }
}
