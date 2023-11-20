using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Avanze_ProjectoWeb.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        [Required(ErrorMessage = "Ingrese su Correo")]
        public string email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Ingrese su contraseña")]
        public string contraseña { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

            SessionClass.SessionUserId = "";
            SessionClass.SessionName = "";
            SessionClass.SessionLastName = "";
            SessionClass.SessionUserName = "";
            SessionClass.SessionPassword = "";
            SessionClass.SessionRole = "";
            SessionClass.SessionEmail = "";
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                SessionClass.SessionStart = true;
                UserImpl userImpl = new UserImpl();
                User user = userImpl.Login(email, contraseña);
                if (user != null)
                {

                    SessionClass.SessionId = user.id;
                    SessionClass.SessionRole = user.role;
                }

                //para impedir acceso segun rol,se lo pone en cada Onget de cada pagina :
                if (SessionClass.SessionRole == "Admin" || SessionClass.SessionRole == "User")
                {
                    SessionClass.SessionUserId = user.UserID.ToString();
                    SessionClass.SessionName = user.name;
                    SessionClass.SessionLastName = user.lastName;
                    SessionClass.SessionUserName = user.userName;
                    SessionClass.SessionPassword = user.password;
                    SessionClass.SessionRole = user.role;
                    SessionClass.SessionEmail = user.email;
                    SessionClass.registerDate = user.RegisterDate;
                    Response.Redirect("/Projecto/InicioPrincipal");
                }
                else
                {

                    
                    Response.Redirect("../Index");

                }
            }
            else
            {

                //si no ha escrito contrasña

            }



        }

    }
}