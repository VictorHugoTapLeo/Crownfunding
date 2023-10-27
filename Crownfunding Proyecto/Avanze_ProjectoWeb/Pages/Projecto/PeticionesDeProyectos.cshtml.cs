using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Avanze_ProjectoWeb.Pages.Projecto
{
    public class PeticionesDeProyectosModel : PageModel
    {
        public List<Project> projects = new List<Project>();
        ProjectImpl pImpl;
        public void OnGet()
        {
            pImpl = new ProjectImpl();
            projects = pImpl.SelectToAcept();
        }

        public IActionResult OnPost(int proyectoId, string handler)
        {
            pImpl = new ProjectImpl();
            switch (handler)
            {
                case "Aceptar":
                    pImpl.Acept(pImpl.Get(proyectoId));
                    break;
                case "Rechazar":
                    pImpl.Delete(pImpl.Get(proyectoId));
                    break;
                default:
                    // Manejar otros casos
                    break;
            }

            return RedirectToPage("");
        }
    }
}
