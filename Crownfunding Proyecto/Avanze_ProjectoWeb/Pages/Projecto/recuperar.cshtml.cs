using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Mail;

namespace Avanze_ProjectoWeb.Pages.Projecto
{
    public class recuperarModel : PageModel
    {
        [BindProperty]
        public string Correo { get; set; }
        public int sessionID { get; set; }

        public IActionResult OnGet()
        {
            //string username = HttpContext.Session.GetString("username");
            string rol = HttpContext.Session.GetString("rol");
            //int userId = HttpContext.Session.GetInt32("userId") ?? 0;
            //HttpContext.Session.Clear();
            sessionID = HttpContext.Session.GetInt32("SessionID") ?? 0;

            //if (rol != "Admin")
            //{
            //    return RedirectToPage("/Index");
            //}
            return Page();

            // IActionResult
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
