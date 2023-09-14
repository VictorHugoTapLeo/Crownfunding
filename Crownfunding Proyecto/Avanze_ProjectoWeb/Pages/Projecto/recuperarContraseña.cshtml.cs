using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System;


namespace Avanze_ProjectoWeb.Pages.Projecto
{
    public class RecuperarContraseñaModel : PageModel
    {
        [BindProperty]
        public string Correo { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Enviar el correo de recuperación de contraseña
                EnviarCorreoRecuperacionContraseña(Correo);

                // Redirige a otra página después de enviar el correo
                return RedirectToPage("/CorreoEnviado");
            }

            // Si el modelo no es válido, vuelve a mostrar el formulario
            return Page();
        }

        private void EnviarCorreoRecuperacionContraseña(string destinatario)
        {
            // Configura el cliente SMTP para enviar el correo
            using (var client = new SmtpClient())
            {
                // Configura las credenciales del servidor SMTP y otros detalles
                client.Host = "tu.servidor.smtp.com";
                client.Port = 587;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("crowdfundingoficialpage@gmail.com", "crowdfundingOficialPage");
                client.EnableSsl = true;

                // Crea el mensaje de correo
                var mensaje = new MailMessage
                {
                    From = new MailAddress("crowdfundingoficialpage@gmail.com", "Crowdfunding"),
                    Subject = "Recuperación de Contraseña",
                    Body = "Haz clic en el siguiente enlace para restablecer tu contraseña: [Enlace]",
                };
                mensaje.To.Add(destinatario);

                // Envía el correo
                client.Send(mensaje);
            }
        }
    }
}