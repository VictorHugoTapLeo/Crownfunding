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
        public List<(int, string, string)>? myFollows;
        public int NCampañas = 0;
        public int NSeguidas = 0;
        public int NApoyadas = 0;
        ProjectImpl p;

        //Codigo Cristian
    
        public List<Project> ProjectsLista { get; set; }
        public List<Project> SupportedByMe { get; set; }
        [BindProperty]
        public byte[] fotorwecuperar { get; set; }

        UserImpl uuserImpl;
        User user;
        //
        public void OnGet()
        {
            uuserImpl = new UserImpl();
            user = new User();

            user = uuserImpl.Get(SessionClass.SessionId);
            fotorwecuperar =user.userPicture;

            
            p = new ProjectImpl();
            myProjects = p.GetMyProjects(SessionClass.SessionId);
            mySupports = p.GetMySupports(SessionClass.SessionId);
            myFollows = p.GetMyFollows(SessionClass.SessionId);
            NCampañas = myProjects.Count;
            NSeguidas = myFollows.Count;
            NApoyadas = mySupports.Count;

            //Codigo Cristian--Muestra los proyectos correspondiwentes al usuario logeado
            ProjectsLista = p.SelectMyPro(SessionClass.SessionId); //envez de uno tiene que ser el sessionUserID -Pendiente
            SupportedByMe = p.SupportedProByMe(SessionClass.SessionId);//porjectos a losque yo di apoyo-SessionUserID,igual
        }



    }
}
