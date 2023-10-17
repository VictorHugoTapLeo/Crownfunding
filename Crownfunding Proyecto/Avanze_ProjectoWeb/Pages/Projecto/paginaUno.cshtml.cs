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
                 //inserto de categorias 
            CategoriasInsert = new List<Category>
        {
           new Category { name = "Asesoría financiera" },
            new Category { name = "Asesoría comercial" },
            new Category { name = "Asesoría en marketing" },
            new Category { name = "Apoyo en valoración de empresas" },
            new Category { name = "Asesoría en gestión impositiva" },
            new Category { name = "Asesoría en desarrollo de marca" },
            new Category { name = "Apoyo en desarrollo de packaging" },
            new Category { name = "Apoyo en procesos de innovación" },
            new Category { name = "Asesoría en investigación de mercados" },
            new Category { name = "Asesoría en procesos de exportación" },
            new Category { name = "Asesoría en procesos de importación" },
            new Category { name = "Asesoría en apertura de mercados internacionales" },
            new Category { name = "Asesoría en gestión de equipos" },
            new Category { name = "Asesoría en elevator pitch" },
            new Category { name = "Asesoría en costos y estructura contable" }

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
                //sessionID = HttpContext.Session.GetInt32("SessionID") ?? 0;
                sessionID = sessionID +SessionClass.SessionRole;
                //preuba para edit 
                //ProjectImpl j = new ProjectImpl();

                //Project k = new Project();

                //k = j.Get(2);

                //nuevo = new PaginaUnoModeldos();
                //nuevo.Titulo = k.title;
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
                 
                pro.projectPng = "Not available";
                pro.productionProcessPng = "Not available";
                pro.finalProductPng = "Not available";
                pro.campaingVideo = Projecto.Link;
                pro.userCampaingId = SessionClass.SessionId; //cambio id
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
                       // new Description("ListaApoyos", Projecto.ListaApoyos,idProjecto),
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
                //insercion de tablas porjecto y patron
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

        // Método para agregar apoyos requeridos desde el frontend

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
