using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Interfaces;
using CrowdFundingDAO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Avanze_ProjectoWeb.Pages.Projecto.Usuarios
{
    public class DetailsUserModel : PageModel
    {

        public DetailsUserModel()
        {
            UserImpl = new UserImpl();
        }

        public User User { get; set; }

        public UserImpl UserImpl { get; set; }

        [TempData]
        public string NotFoundMessage { get; set; }

        public IActionResult OnGet(int id)
        {
            User = UserImpl.Get(id);

            if (User == null)
            {
                NotFoundMessage = "Usuario no encontrado";
                return Page();
            }

            return Page();
        }
    }
}
