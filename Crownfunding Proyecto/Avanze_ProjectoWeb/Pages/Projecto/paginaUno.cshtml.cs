using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Avanze_ProjectoWeb.Models;
using System.ComponentModel.DataAnnotations;
namespace Avanze_ProjectoWeb.Pages.Projecto
{
    public class paginaUnoModel : PageModel
    {
        [BindProperty] 
        public PaginaUnoModeldos Projecto { get; set; }
        public List<string> ApoyosRequeridos { get; set; } = new List<string>();


        

        public string? save { get; set; }

        public string successMessage = "";
        public string errorMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                errorMessage = "Error en los campos,revisa"; 

            }
            else
            {
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




            }

            










        }

        // Método para agregar apoyos requeridos desde el frontend

    }
}
