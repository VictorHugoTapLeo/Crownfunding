using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Model;

namespace Avanze_ProjectoWeb.Pages.Projecto.Usuarios
{
    public class ReceivedSupportModel : PageModel
    {

        public int idreci { get; set; }

        public List<Support> SupportsLista { get; set; }

        public SupportVerificationImpl hh { get; set; }
        public List<SupportVerification> gg { get; set; } 

        public void OnGet(int id)
        {
            hh = new SupportVerificationImpl();
            

            SupportImpl su = new SupportImpl();
            //vaciado de los apoyos de x projecto
            idreci = id;
            SupportsLista= su.SelectMySupport(id);


            //gg =hh.GetLista();
        }





    }
}
