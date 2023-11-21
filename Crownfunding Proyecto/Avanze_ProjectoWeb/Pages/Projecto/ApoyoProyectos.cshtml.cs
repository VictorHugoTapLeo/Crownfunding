using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Model;

using System.ComponentModel.DataAnnotations;
using System.IO.Pipelines;

namespace Avanze_ProjectoWeb.Pages.Projecto
{
    public class ApoyoProyectosModel : PageModel
    {

        SupportImpl? si;

        //pagina de apoyos ,recibe id de proyecto al que debe apoyar para hacer la referencia
        Project mp = new Project();
        ProjectImpl pi = new ProjectImpl();
        [BindProperty]
        public int idA { get; set; }
        [BindProperty]
        public string? Titulo { get; set; }
        //atributos para apoyo
        [BindProperty]
        public string? TypoApoyo { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Este campo es necesario")]
        public string? DescriApoyo { get; set; }
        [BindProperty]
        public List<string>? MyPatronList { get; set; }
        public bool checkFollow { get; set; }
        public bool checkPatreon { get; set; }
        public int idproaux { get; set; }
        public byte[]? photo { get; set; }
        public byte[]? photo2 { get; set; }
        Support? sup;
        public void OnGet(int id )  
        {
            idproaux = id;
            if (SessionClass.SessionRole == "Admin" || SessionClass.SessionRole == "User")
            {
                 

                mp = pi.Get(id); 
                idA = mp.id;
                Titulo = mp.title;
                photo = mp.projectPng;
                photo2 = mp.productionProcessPng;
                si = new SupportImpl();
                sup = si.GetPatron(id);
                if(sup == null)
                {
                    checkPatreon = false;
                }
                else
                {
                    checkPatreon=true;
                }

                checkFollow = pi.CheckFollow(idA);
                MyPatronList = si.GetPatronProvidedNames(mp.userCampaingId,mp.id);
            }
            else
            {

                Response.Redirect("../Index");

            }

        }
        public void OnPost(string handler)
        {
            
            var buttonValue = Request.Form["handler"];
            
            switch (buttonValue)
            {
                case "Aplicar":
                    if (ModelState.IsValid)
                    {
                        si = new SupportImpl();
                        Support sm = new Support();
                        sm.projectId = idA;
                        sm.supporterId = SessionClass.SessionId; 
                        sm.UserID = SessionClass.SessionId; 
                        sm.supportType = TypoApoyo;
                        sm.supportVerification = DescriApoyo;

                        si.Insert(sm);
                    }
                    break;
                case "Seguir":
                    ProjectImpl projectImpl = new ProjectImpl();

                    projectImpl.Follow(idA);
                    
                    break;
            }
            
            Response.Redirect("/Projecto/ApoyoProyectos?id=" + idA );
        }
    }
}
