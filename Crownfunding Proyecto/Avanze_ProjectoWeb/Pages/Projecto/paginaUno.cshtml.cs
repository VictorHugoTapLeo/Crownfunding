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

        public void OnPost(PaginaUnoModeldos obj)
        {
            if (!ModelState.IsValid)
            {
                errorMessage = "Error de validación. Por favor revisa los campos.";
                return;
            }



            successMessage = "Informacion enviada exitosamente";





            ModelState.Clear();
           


        }

        // Método para agregar apoyos requeridos desde el frontend

    }
}
