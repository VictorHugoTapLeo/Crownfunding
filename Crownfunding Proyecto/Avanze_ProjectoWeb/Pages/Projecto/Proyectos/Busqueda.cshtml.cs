using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Metrics;

namespace Avanze_ProjectoWeb.Pages.Projecto.Proyectos
{
    public class BusquedaModel : PageModel
    {
        ProjectImpl project = new ProjectImpl();
        CategoryImpl cateImpl = new CategoryImpl();
        public List<(int,string, string, byte[])> Projects = new List<(int, string, string, byte[])>();
        public List<string> cat = new List<string> ();
        public List<Category> categories = new List<Category>();
        public void OnGet()
        {
            categories = cateImpl.SelectToSerch();
            cat = new List<string>();
            string palabra = "";
            foreach (var parametro in Request.Query)
            {
                string nombreParametro = parametro.Key;

                if (nombreParametro == "category")
                {
                    // Recorre los valores de "category" si hay varios
                    foreach (var valor in parametro.Value)
                    {
                        cat.Add(valor);
                    }
                }
                else if (nombreParametro == "Busqueda")
                {
                    palabra = parametro.Value;
                }
            }
            Projects = project.Serch(cat, palabra);
        }
    }
}
