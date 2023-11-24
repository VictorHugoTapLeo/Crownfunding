using System.ComponentModel.DataAnnotations;

namespace Avanze_ProjectoWeb.Models
{
    public class UserModel
    {
        [MinLength(1, ErrorMessage = "Demasiado corto!")]
        [MaxLength(50, ErrorMessage = "Demasiado largo!")]
        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        public string? Nombre { get; set; }

        [MinLength(1, ErrorMessage = "Demasiado corto!")]
        [MaxLength(60, ErrorMessage = "Demasiado largo!")]
        [Required(ErrorMessage = "El campo Apellido es requerido.")]
        public string? Apellido { get; set; }
        [MinLength(1, ErrorMessage = "Demasiado corto!")]
        [MaxLength(60, ErrorMessage = "Demasiado largo!")]

        [Required(ErrorMessage = "El campo Apellido es requerido.")]
        public string? SegundoApellido { get; set; }
        [MinLength(1, ErrorMessage = "Demasiado corto!")]
        [MaxLength(12, ErrorMessage = "Demasiado largo!")]

        [Required(ErrorMessage = "Escribe tu nombre de usuario")]
        public string? NombreUsuario { get; set; }

      
        [EmailAddress(ErrorMessage = "Este correo no parece ser una dirección de correo electrónico válida.")]
        [Required(ErrorMessage = "El campo correo es requerido.")]
        public string? Correo { get; set; }

       
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "El campo contraseña es requerido.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,20}$", 
            ErrorMessage = "Escriba una contraseña (min 8,max 20)usando minusculas,mayusculas ,numeros y caracteres especiales (@_-#$)")]
       
        public string? Contraseña { get; set; }

      
        [Compare("Contraseña", ErrorMessage = "Las contraseñas no coinciden.")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Se requiere confirmar tu contraseña .")]
        public string? ConfirmarContraseña { get; set; }

        [Required(ErrorMessage = "Escribe tu numero de celular  de usuario")]
        [RegularExpression(@"^[0-9+\s]*[0-9]$", 
            ErrorMessage = "Ingresa un nro de telefono valido")]

        public string? telefono { get; set; }


        //foto

        [Required(ErrorMessage = "Sube una imagen")]
        public IFormFile? fotoUser { get; set; }
        public byte[]? fotoUserBytes { get; set; }

    }
}
