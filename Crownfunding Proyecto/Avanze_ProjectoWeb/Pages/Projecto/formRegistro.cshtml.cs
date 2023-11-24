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
                    us.userPicture = memoryStreamp.ToArray(); // convertimos imagen a bytes
                }
                usImpl.Insert(us);

                Response.Redirect("../Index");
            }
            else
            {

            }

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