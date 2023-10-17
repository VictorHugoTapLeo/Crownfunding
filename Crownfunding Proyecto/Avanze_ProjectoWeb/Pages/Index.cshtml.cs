using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Avanze_ProjectoWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
           
        }

        public IActionResult OnPost(string userName, string password)
        {
            UserImpl userImpl = new UserImpl();
            User user = userImpl.Login(userName, password);
            SessionClass.SessionUserId = user.UserID.ToString();
            SessionClass.SessionName = user.name;
            SessionClass.SessionLastName = user.lastName;
            SessionClass.SessionUserName = user.userName;
            SessionClass.SessionPassword = user.password;
            SessionClass.SessionRole = user.role;
            SessionClass.SessionEmail = user.email;
            SessionClass.registerDate = user.RegisterDate;

            return RedirectToPage("/Index"); //no se cual pagina sigue de eso xdxd
            
        }
    
    }
}