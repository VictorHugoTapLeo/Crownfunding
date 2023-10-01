using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Avanze_ProjectoWeb.Pages.Projecto
{
    public class TModel : PageModel
    {
        public List<(int,string, string)>? myProjects;
        public List<(int, string, string)>? mySupports;
        public int NCampañas = 0;
        public int NSeguidas = 0;
        public int NApoyadas = 0;
        ProjectImpl p;
        public void OnGet()
        {
            p = new ProjectImpl();
            myProjects = p.GetMyProjects(SessionClass.SessionId);
            mySupports = p.GetMySupports(SessionClass.SessionId);
            NCampañas = myProjects.Count;
            NSeguidas = 2;
            NApoyadas = mySupports.Count;
        }
    }
}
