
using System.ComponentModel.DataAnnotations;
namespace Avanze_ProjectoWeb.Models
{
    public class PaginaUnoModeldos
    {
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "El campo DescripcionGeneral es obligatorio.")]
        public string? DescripcionGeneral { get; set; }

        [Required(ErrorMessage = "Debes seleccionar al menos un apoyo requerido.")]
        public List<string> ListaApoyos { get; set; }

        public string? ComentarioMision { get; set; }
        public string? ComentarioVision { get; set; }
        public string ComentarioSobre { get; set; }

        [Required(ErrorMessage = "Debes cargar una imagen para el proyecto.")]
        public byte[] ImagenProyecto { get; set; }

        [Required(ErrorMessage = "Debes cargar una imagen del producto final.")]
        public byte[] ImagenProductoFinal { get; set; }

        [Required(ErrorMessage = "Debes cargar una imagen del proceso de producción.")]
        public byte[] ImagenProcesoProduccion { get; set; }

        [Required(ErrorMessage = "El campo Link es obligatorio.")]
        [RegularExpression(@"^(https?://)?(www\.)?youtube\.com/embed/[^/\s]+$", ErrorMessage = "El formato del enlace de video no es válido.")]
        public string Link { get; set; }

        [Required(ErrorMessage = "El campo Redes es obligatorio.")]
        public string Redes { get; set; }

        [Required(ErrorMessage = "Debes seleccionar una categoría.")]
        public string Tipo { get; set; }

    }
}
