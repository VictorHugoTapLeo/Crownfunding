
using System.ComponentModel.DataAnnotations;
namespace Avanze_ProjectoWeb.Models
{
    public class PaginaUnoModeldos
    {
        //seccion inicio

        public int id { get; set; }
        [Required(ErrorMessage = "Es necesario un titulo")]
        public string? Titulo { get; set; } = "";

        [Required(ErrorMessage = "El campo DescripcionGeneral es obligatorio.")]
        public string? DescripcionGeneral { get; set; }

        [Required(ErrorMessage = "Debes seleccionar al menos un apoyo requerido.")]
        [StringLength(maximumLength: 100, MinimumLength = 14, ErrorMessage = "Selecciona al menos 5 apoyos")]
        public string? ListaApoyos { get; set; }

     
        //seccion Descripciones
        [Required(ErrorMessage = "Completa este campo")]
        public string? DescripcionPlanTiempo { get; set; }
        [Required(ErrorMessage = "Completa este campo")]
        public string? DescripcionObjetivo { get; set; }
        [Required(ErrorMessage = "Completa este campo")]
        public string? DescripcionPorque { get; set; }

        ////seccion vision
        [Required(ErrorMessage = "Completa este campo")]
        public string? DescripcionQueCrear { get; set; }
        [Required(ErrorMessage = "Completa este campo")]
        public string? DescripcionComoSurgio { get; set; }

        ////seccion sobre ti
        [Required(ErrorMessage = "Completa este campo")]
        public string? DescripcionQuienEres { get; set; }
        [Required(ErrorMessage = "Completa este campo")]
        public string? DescripcionRiesgos { get; set; }

        //seccion de imagenes : Proximamente


        //seccion contactos

        [Required(ErrorMessage = "El campo Link es obligatorio.")]

        [RegularExpression(@"^(https?://)?(www\.)?youtube\.com/watch\?v=[\w-]+$", ErrorMessage = "El formato del enlace de video no es válido.")]

        public string? Link { get; set; }

        [Required(ErrorMessage = "El campo Redes es obligatorio.")]
        public string? Redes { get; set; }
        [Required(ErrorMessage = "Agreges categorias.")]
        public string? Tipo { get; set; }

        [Required(ErrorMessage = "Sube una imagen")]
        public IFormFile? projectPng { get; set; }
        public byte[]? projectPngbytes { get; set; }



        [Required(ErrorMessage = "Sube una imagen")]
        public IFormFile? productionProcessPng { get; set; }
        public byte[]? productionProcessPngbytes { get; set; }


        [Required(ErrorMessage = "Sube una imagen")]
        public IFormFile? finalProductPng { get; set; }
        public byte[]? finalProductPngbytes { get; set; }




    }
}
