using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Avanze_ProjectoWeb.Pages.Projecto.Proyectos
{
    public class BusquedaModel : PageModel
    {
        ProjectImpl project = new ProjectImpl();
        public List<(string, string, byte[])> Projects = new List<(string, string, byte[])>();
        public void OnGet()
        {
            int count = 0;
            List<string> cat = new List<string>();
            string palabra = "";
            foreach (var parametro in Request.Query)
            {
                if (count < 25)
                {
                    string nombreParametro = parametro.Key;
                    string valorParametro = parametro.Value;

                    if (nombreParametro != "Busqueda")
                    {
                        cat.Add(parametro.Value);
                        count++;
                    }
                    else
                    {
                        palabra = parametro.Value;
                    }
                }
            }
            Projects = project.Serch(cat, palabra);
        }
    }
}
