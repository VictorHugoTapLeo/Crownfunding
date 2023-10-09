using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Avanze_ProjectoWeb.Pages
{
    public class ModalesRevisarModel : PageModel
    {
        public void OnGet()
        {

            //para activar un modal desde aqui
            ViewData["Script"] = "displayAlerth();";
        }


    }
}
