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
        DescriptionImpl d;

        [BindProperty] 
        public PaginaUnoModeldos Projecto { get; set; }
        public List<string> ApoyosRequeridos { get; set; } = new List<string>();


        

        public string? save { get; set; }

        public string successMessage = "";
        public string errorMessage = "";


        CategoryImpl cat = new CategoryImpl();
        
        public List<Category> Categorias { get; set; }
        public List<Category> CategoriasInsert { get; set; }

        public int sessionID { get; set; }
        public PaginaUnoModeldos nuevo { get; set; }
        public void OnGet()
        {
            //inserto de categorias 
            CategoriasInsert = new List<Category>
        {
           new Category { name = "Asesor�a financiera" },
            new Category { name = "Asesor�a comercial" },
            new Category { name = "Asesor�a en marketing" },
            new Category { name = "Apoyo en valoraci�n de empresas" },
            new Category { name = "Asesor�a en gesti�n impositiva" },
            new Category { name = "Asesor�a en desarrollo de marca" },
            new Category { name = "Apoyo en desarrollo de packaging" },
            new Category { name = "Apoyo en procesos de innovaci�n" },
            new Category { name = "Asesor�a en investigaci�n de mercados" },
            new Category { name = "Asesor�a en procesos de exportaci�n" },
            new Category { name = "Asesor�a en procesos de importaci�n" },
            new Category { name = "Asesor�a en apertura de mercados internacionales" },
            new Category { name = "Asesor�a en gesti�n de equipos" },
            new Category { name = "Asesor�a en elevator pitch" },
            new Category { name = "Asesor�a en costos y estructura contable" }

        };

            //insertar categorias ,solo una vez

            //foreach (var categoria in CategoriasInsert)
            //{
            //    cat.Insert(categoria);
            //}
           // vaciado de categorias al select

            Categorias = cat.SelectList();
            // Mostrar el nombre del usuario en la vista

            HttpContext.Session.SetInt32("SessionID", 0);
            sessionID = HttpContext.Session.GetInt32("SessionID") ?? 0;

            //preuba para edit 
            ProjectImpl j = new ProjectImpl();

            Project k = new Project();

            k = j.Get(2);

            nuevo = new PaginaUnoModeldos();
            nuevo.Titulo = k.title;

            
        }

        public void OnPost()
        {
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
                 
                pro.projectPng = "Not available";
                pro.productionProcessPng = "Not available";
                pro.finalProductPng = "Not available";
                pro.campaingVideo = Projecto.Link;
                pro.categoryId = int.Parse(Projecto.Tipo);
                p.Insert(pro);

              SocialMedia ca = new SocialMedia();
                SocialMediaImpl ck = new SocialMediaImpl();
                ca.mediaLink= Projecto.Redes;
                ca.projectId = p.ids;
                ck.Insert(ca);


                int idProjecto = p.ids;
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

                    d.Insert(item);

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

                //post 
                 
                ModelState.Clear();



                
            }

            










        }

        // M�todo para agregar apoyos requeridos desde el frontend

    }


    public class DescriptionL
    {
        public string Type { get; set; }
        public string Descripcion { get; set; }
        public int IdProyect { get; set; }

        public DescriptionL(string type, string descripcion,int idProyect)
        {
            Type = type;
            Descripcion = descripcion;
            IdProyect = idProyect;
        }
    }
}
