using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Avanze_ProjectoWeb.Models;
using Microsoft.AspNetCore.Http; 
using System.ComponentModel.DataAnnotations;


using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Model;
namespace Avanze_ProjectoWeb.Pages.Projecto
{
    public class paginaUnoModel : PageModel
    {
        ProjectImpl p;
        Project hs = new Project();
        DescriptionImpl d;

        [BindProperty]
        public PaginaUnoModeldos Projecto { get; set; }
        public List<string> ApoyosRequeridos { get; set; } = new List<string>();

        [BindProperty]
        public List<Patron> ListaPatron { get; set; } = new List<Patron>();
        public string? save { get; set; }

        public string successMessage = "";
        public string errorMessage = "";

        ProjectImpl kj = new ProjectImpl();
        CategoryImpl cat = new CategoryImpl();

        public List<Category> Categorias { get; set; }
        public List<Category> CategoriasInsert { get; set; }

        public string sessionID { get; set; }
        public PaginaUnoModeldos nuevo { get; set; }
        public void OnGet()
        {
            if (SessionClass.SessionRole == "Admin" ||SessionClass.SessionRole == "User")
            {
        
               // vaciado de categorias al select
                Categorias = cat.SelectList();
                sessionID = sessionID +SessionClass.SessionRole;
                ListaPatron = kj.SelectPatron();

            }
            else
            {
                ListaPatron = kj.SelectPatron();
                Categorias = cat.SelectList();
                Response.Redirect("../Index");

            }
        }

        public void OnPost()
        {
            ListaPatron = kj.SelectPatron();
            Categorias = cat.SelectList();
            if (!ModelState.IsValid)
            {
                errorMessage = "Error en los campos,revisa"; 

            }
            else
            {

                p = new ProjectImpl();
                

                Project pro = new Project();

                pro.title = Projecto.Titulo;


                using (var memoryStream = new MemoryStream())
                {
                    Projecto.projectPng.CopyTo(memoryStream);
                    pro.projectPng = memoryStream.ToArray(); // Asignamos los bytes a pro.projectPng
                }

                using (var memoryStreams = new MemoryStream())
                {
                    Projecto.productionProcessPng.CopyTo(memoryStreams);
                    pro.productionProcessPng = memoryStreams.ToArray(); // Asignamos los bytes a pro.projectPng
                }

                using (var memoryStreamp = new MemoryStream())
                {
                    Projecto.finalProductPng.CopyTo(memoryStreamp);
                    pro.finalProductPng = memoryStreamp.ToArray(); // Asignamos los bytes a pro.projectPng
                }
               
                pro.campaingVideo = Projecto.Link;
                pro.userCampaingId = SessionClass.SessionId; //cambio id
                pro.categoryId = int.Parse(Projecto.Tipo);
                p.Insert(pro);

              SocialMedia ca = new SocialMedia();
                SocialMediaImpl ck = new SocialMediaImpl();
                ca.mediaLink= Projecto.Redes;
                ca.projectId = p.ids;
                ck.Insert(ca);

                //idProjecto debe ser el mismo id con el que el projecto de arriba es insertado a tu tabla 
                int idProjecto = p.ids;
               
                List<Description> listaDescripciones = new List<Description>
                    {
                        new Description("DescripcionGeneral", Projecto.DescripcionGeneral,idProjecto),
                      
                        new Description("DescripcionPlanTiempo", Projecto.DescripcionPlanTiempo,idProjecto),
                        new Description("DescripcionObjetivo", Projecto.DescripcionObjetivo,idProjecto),
                        new Description("DescripcionPorque", Projecto.DescripcionPorque,idProjecto),
                        new Description("DescripcionQueCrear", Projecto.DescripcionQueCrear,idProjecto),
                        new Description("DescripcionComoSurgio", Projecto.DescripcionComoSurgio,idProjecto),
                        new Description("DescripcionQuienEres", Projecto.DescripcionQuienEres,idProjecto),
                        new Description("DescripcionRiesgos", Projecto.DescripcionRiesgos,idProjecto)
                    };
                d = new DescriptionImpl();
                foreach (Description item in listaDescripciones)
                {

                    d.Insert(item);

                }

                p = new ProjectImpl();
                string idSinComa = Projecto.ListaApoyos.TrimEnd(',');
                foreach (string apoyoId in idSinComa.Split(','))
                {
                    string idSinCeros = apoyoId;

                    if (apoyoId.Length > 1 && apoyoId[0] == '0')
                    {
                        idSinCeros = apoyoId.TrimStart('0');
                    }

                    int id = int.Parse(idSinCeros);
                    p.InsertPatronProject(id, idProjecto);
                }

                //limpiamos los campos

                successMessage = "Informacion enviada exitosamente";

                save = Projecto.Titulo + Projecto.ListaApoyos;

                Projecto.Titulo = "";
                Projecto.DescripcionGeneral = "";
                Projecto.ListaApoyos = "";

                Projecto.DescripcionPlanTiempo = "";
                Projecto.DescripcionObjetivo = "";
                Projecto.DescripcionPorque = "";
                Projecto.DescripcionQueCrear = "";
                Projecto.DescripcionComoSurgio = "";
                Projecto.DescripcionQuienEres = "";
                Projecto.DescripcionRiesgos = "";

                Projecto.Link = "";
                Projecto.Redes = "";
                Projecto.Tipo = "";

                //post 
                 
                ModelState.Clear();

                Response.Redirect("/Projecto/PerfilInterfaz");


            }
        }
    }

}
