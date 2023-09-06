using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Avanze_ProjectoWeb.Models;
using System.ComponentModel.DataAnnotations;
namespace Avanze_ProjectoWeb.Pages.Projecto
{
    public class paginaUnoModel : PageModel
    {
        [BindProperty] //
        public PaginaUnoModeldos In { get; set; }
        public List<string> ApoyosRequeridos { get; set; } = new List<string>();

        public string save { get; set; }
        public void OnGet()
        {
        }

        public void OnPost(PaginaUnoModeldos obj)
        {
            if (!ModelState.IsValid)
            {
                save =
                obj.Titulo;
                // El modelo no es v�lido, muestra los mensajes de error y vuelve a cargar la p�gina
                Page(); // Corregido
                return;
            }


        }

        // M�todo para agregar apoyos requeridos desde el frontend

    }
}
