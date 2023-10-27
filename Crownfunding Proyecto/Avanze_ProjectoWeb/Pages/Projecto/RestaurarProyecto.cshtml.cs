using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Avanze_ProjectoWeb.Pages.Projecto
{
    public class RestaurarProyectoModel : PageModel
    {
        public List<Project> projects = new List<Project>();
        ProjectImpl pImpl;
        public void OnGet()
        {
            pImpl = new ProjectImpl();
            projects = pImpl.SelectToRestore();
            
         }
        public IActionResult OnPost(int proyectoId, string handler)
        {
                pImpl = new ProjectImpl();
                switch (handler)
                {
                    case "Restaurar":
                        Project p = pImpl.Get(proyectoId);
                        pImpl.Acept(p);
                        break;
                    case "Eliminar":
                        Project c = pImpl.Get(proyectoId);
                        pImpl.PermaDelete(c);
                        break;
                    default:
                        
                        break;
                }
            return RedirectToPage("");
        }

    }
}
