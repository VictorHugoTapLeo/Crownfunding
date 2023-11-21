
using System.ComponentModel.DataAnnotations;
namespace Avanze_ProjectoWeb.Models
{
    public class PaginaUnoModeldos
    {
        //seccion inicio

        public int id { get; set; }
        [Required(ErrorMessage = "Es necesario un titulo")]
        [StringLength(200, ErrorMessage = "{0} La descripcion no debe superar los {1} caracteres", MinimumLength = 1)]
        public string? Titulo { get; set; } = "";

        [Required(ErrorMessage = "El campo DescripcionGeneral es obligatorio.")]
        [StringLength(1000, ErrorMessage = "{0} La descripcion no debe superar los {1} caracteres", MinimumLength = 1)]
        public string? DescripcionGeneral { get; set; }

        [Required(ErrorMessage = "Debes seleccionar al menos un apoyo requerido.")]
        [StringLength(maximumLength: 200, MinimumLength = 14, ErrorMessage = "Selecciona al menos 5 apoyos")]
        public string? ListaApoyos { get; set; }

     
        //seccion Descripciones
        [Required(ErrorMessage = "Completa este campo")]
        [StringLength(1000, ErrorMessage = "{0} La descripcion no debe superar los {1} caracteres", MinimumLength = 1)]
        public string? DescripcionPlanTiempo { get; set; }
        [StringLength(1000, ErrorMessage = "{0} La descripcion no debe superar los {1} caracteres", MinimumLength = 1)]
        [Required(ErrorMessage = "Completa este campo")]
        public string? DescripcionObjetivo { get; set; }
        [StringLength(1000, ErrorMessage = "{0} La descripcion no debe superar los {1} caracteres", MinimumLength = 1)]
        [Required(ErrorMessage = "Completa este campo")]
        public string? DescripcionPorque { get; set; }

        ////seccion vision
        [Required(ErrorMessage = "Completa este campo")]
        [StringLength(1000, ErrorMessage = "{0} La descripcion no debe superar los {1} caracteres", MinimumLength = 1)]
        public string? DescripcionQueCrear { get; set; }
        [Required(ErrorMessage = "Completa este campo")]
        [StringLength(1000, ErrorMessage = "{0} La descripcion no debe superar los {1} caracteres", MinimumLength = 1)]
        public string? DescripcionComoSurgio { get; set; }

        ////seccion sobre ti
        [Required(ErrorMessage = "Completa este campo")]
        [StringLength(1000, ErrorMessage = "{0} La descripcion no debe superar los {1} caracteres", MinimumLength = 1)]
        public string? DescripcionQuienEres { get; set; }
        [Required(ErrorMessage = "Completa este campo")]
        [StringLength(1000, ErrorMessage = "{0} La descripcion no debe superar los {1} caracteres", MinimumLength = 1)]
        public string? DescripcionRiesgos { get; set; }

        //seccion de imagenes : Proximamente


        //seccion contactos

        [Required(ErrorMessage = "El campo Link es obligatorio.")]


        [RegularExpression(@"^(https://youtu\.be/|https://www\.youtube\.com/).+$",
            ErrorMessage = "Este enlace no parece ser de facebook,instagram o twitter")]
        [MinLength(4, ErrorMessage = "El link proporcionado parece demasiado corto")]
        [MaxLength(100, ErrorMessage = "Este link es demasiado largo")]
        public string? Link { get; set; }

        [RegularExpression(@"^(?=.*(?:facebook|twitter|instagram)).*",
          ErrorMessage = "El enlace no parece ser de una red social.")]

        [Required(ErrorMessage = "El campo Redes es obligatorio.")]
        [StringLength(50, ErrorMessage = "{0} el texto no debe superar los {1} caracteres", MinimumLength = 1)]
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
