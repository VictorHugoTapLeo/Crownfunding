
using System.ComponentModel.DataAnnotations;
namespace Avanze_ProjectoWeb.Models
{
    public class PaginaUnoModeldos
    {
        //seccion inicio
        [Required(ErrorMessage = "Es necesario un titulo")]
        public string? Titulo { get; set; } = "";

        [Required(ErrorMessage = "El campo DescripcionGeneral es obligatorio.")]
        public string? DescripcionGeneral { get; set; }

        [Required(ErrorMessage = "Debes seleccionar al menos un apoyo requerido.")]
        public List<string>? ListaApoyos { get; set; }

        //seccion mission
        [Required(ErrorMessage = "Completa este campo")]
        public string? DescripcionPlanTiempo { get; set; }
        [Required(ErrorMessage = "Completa este campo")]
        public string? DescripcionObjetivo { get; set; }
        [Required(ErrorMessage = "Completa este campo")]
        public string? DescripcionPorque { get; set; }

        //seccion vision
        [Required(ErrorMessage = "Completa este campo")]
        public string? DescripcionQueCrear { get; set; }
        [Required(ErrorMessage = "Completa este campo")]
        public string? DescripcionComoSurgio { get; set; }

        //seccion sobre ti
        [Required(ErrorMessage = "Completa este campo")]
        public string? DescripcionQuienEres{ get; set; }
        [Required(ErrorMessage = "Completa este campo")]
        public string? DescripcionRiesgos { get; set; }

        //seccion de imagenes : Proximamente


        //seccion contactos

        [Required(ErrorMessage = "El campo Link es obligatorio.")]
        [RegularExpression(@"^(https?://)?(www\.)?youtube\.com/embed/[^/\s]+$", ErrorMessage = "El formato del enlace de video no es válido.")]
        public string? Link { get; set; }

        [Required(ErrorMessage = "El campo Redes es obligatorio.")]
        public string? Redes { get; set; }
        public string? Tipo { get; set; }

    }
}
