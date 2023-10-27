using System.ComponentModel.DataAnnotations;

namespace Avanze_ProjectoWeb.Models
{
    public class UserModel
    {

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es requerido.")]
        public string? Apellido { get; set; }

        //[Required(ErrorMessage = "El campo Correo es requerido.")]
        //[EmailAddress(ErrorMessage = "El campo Correo no es una dirección de correo electrónico válida.")]
        public string? Correo { get; set; }

        //[Required(ErrorMessage = "El campo Contraseña es requerido.")]
        //[DataType(DataType.Password)]
        public string? Contraseña { get; set; }

        //[Required(ErrorMessage = "El campo Confirmar Contraseña es requerido.")]
        //[Compare("Contraseña", ErrorMessage = "Las contraseñas no coinciden.")]
        //[DataType(DataType.Password)]
        public string? ConfirmarContraseña { get; set; }
    }
}
