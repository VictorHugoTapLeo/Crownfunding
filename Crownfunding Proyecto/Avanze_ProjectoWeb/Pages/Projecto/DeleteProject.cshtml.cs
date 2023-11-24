using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Avanze_ProjectoWeb.Pages.Projecto
{
    public class DeleteProjectModel : PageModel
    {
        [BindProperty]
        public int ProjectId { get; set; }

        //referencias
        ProjectImpl pr;
        Project pm; 
        
        public void OnGet(int id )
        {
            ProjectId = id;

        }

        public void OnPost()
        {
            pr = new ProjectImpl();
            pm = new Project();
            pm.id = ProjectId;
            pm.UserID = SessionClass.SessionId;
            pr.Delete(pm);

            Response.Redirect("/Projecto/editProjectLista");
        }
    }
}
