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
        public int tipe ;
        public void OnGet()
        {
            /*string rol = HttpContext.Session.GetString("rol");
            if (rol != "Admin")
            {
                return RedirectToPage("/Index");
            }
            return Page();*/


            pImpl = new ProjectImpl();
            projects = pImpl.SelectToRestore();
            
        }
        public IActionResult OnPost(int proyectoId, string handler)
        {
            pImpl = new ProjectImpl();
            switch (handler)
            {
                case "Restaurar":
                    pImpl.Acept(pImpl.Get(proyectoId));
                    break;
                case "Eliminar":
                    pImpl.PermaDelete(pImpl.Get(proyectoId));
                    break;
                default:
                    // Manejar otros casos
                    break;
            }

            return RedirectToPage("/Index");
        }

    }
}
