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
            public string Contrase�a { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Contrase�a", ErrorMessage = "Las contrase�as no coinciden.")]
            public string ConfirmarContrase�a { get; set; }

            [Display(Name = "Env�enme una combinaci�n semanal de proyectos seleccionados exclusivamente para m�, adem�s de noticias ocasionales de Crowdfunding")]
            public bool EnviarProyectos { get; set; }

            [Display(Name = "Acepto la Pol�tica de privacidad, Pol�tica de cookies y los T�rminos de uso")]
            [Range(typeof(bool), "true", "true", ErrorMessage = "Debe aceptar las pol�ticas y t�rminos.")]
            public bool AceptarPoliticas { get; set; }
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Genera un token de validaci�n �nico (puedes usar Guid.NewGuid() por simplicidad).
            var validationToken = Guid.NewGuid().ToString();

            // Env�a el enlace de validaci�n por correo electr�nico.
            await SendValidationEmail(Input.Correo, validationToken);

            // Aqu� puedes realizar acciones adicionales, como guardar la cuenta en la base de datos.

            // Redirige a una p�gina de �xito o realiza alguna otra acci�n despu�s de registrar la cuenta.
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
                Subject = "Validaci�n de cuenta",
                Body = $"Para validar su cuenta, haga clic en el siguiente enlace: " +
                       $"<a href='https://tudominio.com/validar?token={validationToken}'>Validar cuenta</a>",
                IsBodyHtml = true,
            };

            mailMessage.To.Add(email);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}