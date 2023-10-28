using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Avanze_ProjectoWeb.Models;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System;
using System.Text.RegularExpressions;
using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Model;

namespace Avanze_ProjectoWeb.Pages.Projecto
{
    public class formRegistroModel : PageModel
    {
        //[BindProperty]
        //public InputModel Input { get; set; }

        //public class InputModel
        //{
        //    //[Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        //    //[RegularExpression(@"^(?:[^\s]+(\s[^\s]+)*)$|^[a-zA-ZáéíóúüñÁÉÍÓÚÜÑ\s]+$", ErrorMessage = "El campo Nombre contiene caracteres no permitidos o espacios en blanco múltiples.")]

        //    //public string Nombre { get; set; }
        //    [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        //    [CustomValidation(typeof(InputModel), "ValidarNombre")]
        //    public string Nombre { get; set; }

        //    public static ValidationResult ValidarNombre(string nombre, ValidationContext context)
        //    {
        //        if (string.IsNullOrWhiteSpace(nombre))
        //        {
        //            return ValidationResult.Success; // La validación requerida manejará el campo vacío.
        //        }

        //        // Verificar caracteres no permitidos
        //        if (!Regex.IsMatch(nombre, @"^[a-zA-ZáéíóúüñÁÉÍÓÚÜÑ\s]+$"))
        //        {
        //            return new ValidationResult("El campo contiene caracteres no permitidos.");
        //        }

        //        // Verificar espacios en blanco múltiples
        //        if (nombre.Contains("  "))
        //        {
        //            return new ValidationResult("El campo contiene espacios en blanco múltiples.");
        //        }

        //        return ValidationResult.Success;
        //    }

        //    [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        //    [CustomValidation(typeof(InputModel), "ValidarNombre")]
        //    public string? Apellido { get; set; }

        //    [Required(ErrorMessage = "El campo Correo es obligatorio.")]
        //    [EmailAddress]

        //    public string? Correo { get; set; }

        //    [Required]
        //    [DataType(DataType.Password)]
        //    public string? Contraseña { get; set; }

        //    [Required]
        //    [DataType(DataType.Password)]
        //    [Compare("Contraseña", ErrorMessage = "Las contraseñas no coinciden.")]
        //    public string ConfirmarContraseña { get; set; }

        //    [Display(Name = "Envíenme una combinación semanal de proyectos seleccionados exclusivamente para mí, además de noticias ocasionales de Crowdfunding")]
        //    public bool EnviarProyectos { get; set; }

        //    [Display(Name = "Acepto la Política de privacidad, Política de cookies y los Términos de uso")]
        //    [Range(typeof(bool), "true", "true", ErrorMessage = "Debe aceptar las políticas y términos.")]
        //    public bool AceptarPoliticas { get; set; }
        //}

        User us;
        UserImpl usImpl = new UserImpl();


        [BindProperty]
        public UserModel usarioModeloVeri { get; set; }


        public void OnPost()
        {
            us = new User();
            if (ModelState.IsValid)
            {
                us.name = usarioModeloVeri.Nombre;
                us.lastName = usarioModeloVeri.Apellido;
                us.secondLastName = usarioModeloVeri.SegundoApellido;
                us.userName = usarioModeloVeri.NombreUsuario;

                us.role = "User";
                us.email = usarioModeloVeri.Correo;
                us.password = usarioModeloVeri.Contraseña;
                us.phoneNumber = usarioModeloVeri.telefono;

                using (var memoryStreamp = new MemoryStream())
                {
                    usarioModeloVeri.fotoUser.CopyTo(memoryStreamp);
                    us.userPicture = memoryStreamp.ToArray(); // Asignamos los bytes a pro.projectPng
                }
                //us.userPicture = 0;

                usImpl.Insert(us);

                Response.Redirect("../Index");
            }
            else
            {

            }



            //Response.Redirect("../Index");


        }
        //public async Task<IActionResult> OnPost()
        //{


        //    if (!ModelState.IsValid)
        //    {
        //        return Page(); // Devuelve la página actual con mensajes de error.
        //    }

        //    // Genera un token de validación único (puedes usar Guid.NewGuid() por simplicidad).
        //    var validationToken = Guid.NewGuid().ToString();

        //    // Envía el enlace de validación por correo electrónico.
        //    await SendValidationEmail(Input.Correo, validationToken);

        //    // Aquí puedes realizar acciones adicionales, como guardar la cuenta en la base de datos.

        //    // Redirige a una página de éxito o realiza alguna otra acción después de registrar la cuenta.
        //    return RedirectToPage("/Exito");
        //}

        private async Task SendValidationEmail(string email, string validationToken)
        {
            var smtpClient = new SmtpClient("tu-servidor-smtp.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("crowdfundingoficialpage@gmail.com", "crowdfundingOficialPage"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("crowdfundingoficialpage@gmail.com"),
                Subject = "Validación de cuenta",
                Body = $"Para validar su cuenta, haga clic en el siguiente enlace: " +
                       $"<a href='https://tudominio.com/validar?token={validationToken}'>Validar cuenta</a>",
                IsBodyHtml = true,
            };

            mailMessage.To.Add(email);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}