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
            //seguridad // se debe acer conel login,rescatar datos de la tabla
            HttpContext.Session.SetString("username", "Cesar");
            HttpContext.Session.SetString("rol", "Admin");
            HttpContext.Session.SetInt32("userId", 4);



        }
    }
}