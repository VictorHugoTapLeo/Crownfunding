using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Model;

using System.ComponentModel.DataAnnotations;

namespace Avanze_ProjectoWeb.Pages.Projecto
{
    public class ApoyoProyectosModel : PageModel
    {
         
        SupportImpl si;

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
        
        
        public void OnGet()  //public void OnGet(int id)
        {
            mp= pi.Get(4); //el id deberiaser recibido en elonget 
            //mp = pi.Get(id);
            idA = mp.id;
            Titulo = mp.title;

        }
        public void OnPost()
        {

            if (ModelState.IsValid)
            { 

            si = new SupportImpl();
            Support sm = new Support();
            sm.projectId= idA;
            sm.supporterId = 1; //se necesita connectar usurios para esto //cuando este listoo hacer fk con suaruio
            sm.UserID = 1;
            sm.supportType = TypoApoyo;
            sm.supportVerification = DescriApoyo;

            si.Insert(sm);

            }

        }


    }
}
