using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Interfaces;
using CrowdFundingDAO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Avanze_ProjectoWeb.Pages.Projecto.Usuarios
{
    public class EditUserModel : PageModel
    {
        public EditUserModel()
        {
            UserImpl = new UserImpl();
        }

        [BindProperty]
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
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            UserImpl.Update(User);

            return RedirectToPage("Index");
        }


    }
}