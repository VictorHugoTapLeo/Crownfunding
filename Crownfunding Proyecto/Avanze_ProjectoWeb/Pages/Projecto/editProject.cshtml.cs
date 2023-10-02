using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Avanze_ProjectoWeb.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Model;
namespace Avanze_ProjectoWeb.Pages.Projecto
{
    public class editProjectModel : PageModel
    {
        ProjectImpl p;
        DescriptionImpl d;

        [BindProperty]
        public PaginaUnoModeldos Projecto { get; set; }
        public List<string> ApoyosRequeridos { get; set; } = new List<string>();

        
        public List<Project> listaDeProyectos { get; set; } = new List<Project>();

       
        public string? save { get; set; }

        public string successMessage = "";
        public string errorMessage = "";


        public int idrecu { get; set; }

        public int sessionID { get; set; }
        public List<Category> Categorias { get; set; }
        CategoryImpl cat = new CategoryImpl();
        SocialMedia ca = new SocialMedia();
        SocialMediaImpl ck = new SocialMediaImpl();
        public void OnGet(int id)
        {

            idrecu = id;
            Categorias = cat.SelectList();

            // Mostrar el nombre del usuario en la vista

            HttpContext.Session.SetInt32("SessionID", 0);
            sessionID = HttpContext.Session.GetInt32("SessionID") ?? 0;

            //preuba para edit 
            ProjectImpl j = new ProjectImpl();

            Project k = new Project();

            listaDeProyectos = j.Selectpros() ;
            DescriptionImpl hi = new DescriptionImpl();
            Description gd = new Description();



           
           
            k = j.Get(id);

            Projecto = new PaginaUnoModeldos();
            Projecto.id = id;
            Projecto.Titulo = k.title;
            Projecto.Link = k.campaingVideo;
            Projecto.Redes = ck.Get(id).mediaLink;
            Projecto.Tipo = Convert.ToString(k.categoryId);



            foreach (Description item in hi.GetAll(id))
            {
                if (item.type == "DescripcionGeneral")
                {
                    Projecto.DescripcionGeneral = item.description;
                }
                else if (item.type == "ListaApoyos")
                {
                    Projecto.ListaApoyos = item.description;
                }
                else if (item.type == "DescripcionPlanTiempo")
                {
                    Projecto.DescripcionPlanTiempo = item.description;
                }
                else if (item.type == "DescripcionObjetivo")
                {
                    Projecto.DescripcionObjetivo = item.description;
                }
                else if (item.type == "DescripcionPorque")
                {
                    Projecto.DescripcionPorque = item.description;
                }
                else if (item.type == "DescripcionQueCrear")
                {
                    Projecto.DescripcionQueCrear = item.description;
                }
                else if (item.type == "DescripcionComoSurgio")
                {
                    Projecto.DescripcionComoSurgio = item.description;
                }
                else if (item.type == "DescripcionQuienEres")
                {
                    Projecto.DescripcionQuienEres = item.description;
                }
                else if (item.type == "DescripcionRiesgos")
                {
                    Projecto.DescripcionRiesgos = item.description;
                }
            }

        }

        public void OnPost()
        {
            
            if (!ModelState.IsValid)
            {
                errorMessage = "Error en los campos,revisa";
                Categorias = cat.SelectList();

            }
            else
            {

                p = new ProjectImpl();


                Project pro = new Project();

              pro.id= Projecto.id;
                pro.title = Projecto.Titulo;

                pro.projectPng = "Not available";
                pro.productionProcessPng = "Not available";
                pro.finalProductPng = "Not available";

                pro.campaingVideo = Projecto.Link;
                pro.categoryId = int.Parse(Projecto.Tipo);

                ca.mediaLink = Projecto.Redes;
                ca.projectId = Projecto.id;
                ck.Update(ca);

                p.Update(pro);



                int idProjecto = Projecto.id;
                //idProjecto debe ser el mismo id con el que el projecto de arriba es insertado a tu tabla 
                //descripciones :
                List<Description> listaDescripciones = new List<Description>
                    {
                        new Description("DescripcionGeneral", Projecto.DescripcionGeneral,idProjecto),
                        new Description("ListaApoyos", Projecto.ListaApoyos,idProjecto),
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

                    d.Update(item);

                }

             







                //limpiamos casillas

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

                ModelState.Clear();



                Categorias = cat.SelectList();
            }












        }
    }
}