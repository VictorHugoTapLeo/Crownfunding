using System;
using CrowdFundingDAO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Interfaces;

namespace Avanze_ProjectoWeb.Pages.Projecto.Usuarios
{
    public class CreateUserModel : PageModel
    {
        public void OnGet()
        {
        }

        public User User { get; set; }

        public UserImpl UserImpl;

        public IActionResult OnPost(User user)
        {
            UserImpl = new UserImpl();
            if (ModelState.IsValid)
            {

                if (user.name != null)
                {
                    User = user;
                    user.role = "Admin";

                    UserImpl.Insert(User);

                    return RedirectToPage("Index");
                }

            }

            return Page();
        }
    }
}
