using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Model;

namespace Avanze_ProjectoWeb.Pages.Projecto
{
    public class RestablecimientoContraseñaModel : PageModel
    {
      
        [BindProperty]
        public string NuevaContraseña { get; set; }

        [BindProperty]
        public string ConfirmarContraseña { get; set; }

        public IActionResult OnPost()
        {
           
            // Aquí puedes agregar lógica para verificar si las contraseñas coinciden
            if (NuevaContraseña != ConfirmarContraseña)
            {
                ModelState.AddModelError("ConfirmarContraseña", "Las contraseñas no coinciden.");
                return Page();
            }

            // Si las contraseñas coinciden, puedes realizar la acción de restablecimiento aquí.
            // Por ejemplo, actualizar la contraseña en la base de datos.

            // Redirige a una página de éxito 
            return RedirectToPage("/Projecto/restablecimientoContraseñaCompletado");
        }
    }
}
