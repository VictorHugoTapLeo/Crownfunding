using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


using Avanze_ProjectoWeb.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Model;

namespace Avanze_ProjectoWeb.Pages.Projecto
{
    public class editProjectListaModel : PageModel
    {

        ProjectImpl p = new ProjectImpl();

        public List<Project> ProjectsLista { get; set; }
        public void OnGet()
        {
            ProjectsLista= p.Selectpros();

        }
    }
}
