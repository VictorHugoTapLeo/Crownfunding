using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Interfaces;
using CrowdFundingDAO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace Avanze_ProjectoWeb.Pages.Projecto.Usuarios
{
    public class DeleteUserModel : PageModel
    {
        public void OnGet(int id)
        {
            UserImpl = new UserImpl();
            User = UserImpl.Get(id);

            if (User == null)
            {
                // Si el usuario no se encuentra, puedes redirigir a una página de error o realizar otra acción apropiada.
                // En este ejemplo, simplemente se muestra un mensaje de error en la vista.
                NotFoundMessage = "Usuario no encontrado";
            }
        }

        public User User { get; set; }
        public string NotFoundMessage { get; set; }

        public UserImpl UserImpl;

        public IActionResult OnPost(int id)
        {
            UserImpl = new UserImpl();
            User = UserImpl.Get(id);

            if (User != null)
            {
                // Llama a la función Delete del DAO para eliminar el usuario
                UserImpl.Delete(User);

                return RedirectToPage("Index");
            }
            NotFoundMessage = "Usuario no encontrado";

            return Page();
        }

    }
}
