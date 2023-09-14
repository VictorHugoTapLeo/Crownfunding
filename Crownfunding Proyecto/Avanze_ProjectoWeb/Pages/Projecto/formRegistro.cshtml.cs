using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Avanze_ProjectoWeb.Models;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System;


namespace Avanze_ProjectoWeb.Pages.Projecto
{
    public class formRegistroModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public string Nombre { get; set; }

            [Required]
            public string Apellido { get; set; }

            [Required]
            [EmailAddress]
            public string Correo { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Contraseña { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Contraseña", ErrorMessage = "Las contraseñas no coinciden.")]
            public string ConfirmarContraseña { get; set; }

            [Display(Name = "Envíenme una combinación semanal de proyectos seleccionados exclusivamente para mí, además de noticias ocasionales de Crowdfunding")]
            public bool EnviarProyectos { get; set; }

            [Display(Name = "Acepto la Política de privacidad, Política de cookies y los Términos de uso")]
            [Range(typeof(bool), "true", "true", ErrorMessage = "Debe aceptar las políticas y términos.")]
            public bool AceptarPoliticas { get; set; }
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Genera un token de validación único (puedes usar Guid.NewGuid() por simplicidad).
            var validationToken = Guid.NewGuid().ToString();

            // Envía el enlace de validación por correo electrónico.
            await SendValidationEmail(Input.Correo, validationToken);

            // Aquí puedes realizar acciones adicionales, como guardar la cuenta en la base de datos.

            // Redirige a una página de éxito o realiza alguna otra acción después de registrar la cuenta.
            return RedirectToPage("/Exito");
        }

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