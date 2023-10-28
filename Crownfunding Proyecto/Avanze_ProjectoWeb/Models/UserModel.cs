using System.ComponentModel.DataAnnotations;

namespace Avanze_ProjectoWeb.Models
{
    public class UserModel
    {

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es requerido.")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "El campo Apellido es requerido.")]
        public string? SegundoApellido { get; set; }

        [Required(ErrorMessage = "Escribe tu nombre de usuario")]
        public string? NombreUsuario { get; set; }

        //[Required(ErrorMessage = "El campo Correo es requerido.")]
        //[EmailAddress(ErrorMessage = "El campo Correo no es una dirección de correo electrónico válida.")]
        [Required(ErrorMessage = "El campo corre es requerido.")]
        public string? Correo { get; set; }

        //[Required(ErrorMessage = "El campo Contraseña es requerido.")]
        //[DataType(DataType.Password)]
        [Required(ErrorMessage = "El campo contraseña es requerido.")]
        public string? Contraseña { get; set; }

        //[Required(ErrorMessage = "El campo Confirmar Contraseña es requerido.")]
        //[Compare("Contraseña", ErrorMessage = "Las contraseñas no coinciden.")]
        //[DataType(DataType.Password)]
        [Required(ErrorMessage = "serequiere confirmar tu con traseña .")]
        public string? ConfirmarContraseña { get; set; }

        [Required(ErrorMessage = "Escribe tu numero de celular  de usuario")]
        public string? telefono { get; set; }


        //foto

        [Required(ErrorMessage = "Sube una imagen")]
        public IFormFile? fotoUser { get; set; }
        public byte[]? fotoUserBytes { get; set; }

    }
}
