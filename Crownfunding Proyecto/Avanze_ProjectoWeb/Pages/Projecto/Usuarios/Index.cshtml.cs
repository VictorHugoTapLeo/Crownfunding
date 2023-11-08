using CrowdFundingDAO.Interfaces;
using CrowdFundingDAO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrowdFundingDAO.Implementation;

namespace Avanze_ProjectoWeb.Pages.Projecto.Usuarios
{
    public class IndexModel : PageModel
    {
        public UserImpl userDAO;
        public List<User> Users { get; set; }

        public void OnGet()
        {
            SessionClass.IsChange = false;
            userDAO = new UserImpl();
            Users = userDAO.SelectAll();
        }

        public IActionResult OnPostDelete(int id)
        {
            if (id > 0)
            {
                User userToDelete = userDAO.Get(id);

                if (userToDelete != null)
                {
                    userDAO.Delete(userToDelete);
                }
            }

            return RedirectToPage("Index");
        }

    }
}