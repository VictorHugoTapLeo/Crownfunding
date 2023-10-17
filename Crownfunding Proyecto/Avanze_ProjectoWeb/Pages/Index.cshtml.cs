using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Avanze_ProjectoWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public string email { get; set; }

        [BindProperty]
        public string contraseña { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
             
        }
        public void OnPost()
        {

            UserImpl userImpl = new UserImpl();
            User user = userImpl.Login(email, contraseña);

            SessionClass.SessionId = user.id;
            SessionClass.SessionRole = user.role;
            //luego es redirecionarw
            Response.Redirect("/Projecto/InicioPrincipal");

            //para impedir acceso segun rol,se lo pone en cada Onget de cada pagina :
            //if (SessionClass.SessionRole == "Admin" || SessionClass.SessionRole == "User")
            //{
            //   aqui se coloca todo lo que onget debe hacer en caso de tener el rol requerido
            //}
            //else
            //{ lo expulsas
            
            //    Categorias = cat.SelectList();
            //    Response.Redirect("../Index");

            //}



        }

        //public IActionResult OnPost(string userName, string password)
        //{


        //    UserImpl userImpl = new UserImpl();
        //    User user = userImpl.Login(userName, password);
        //    SessionClass.SessionUserId = user.UserID.ToString();
        //    SessionClass.SessionName = user.name;
        //    SessionClass.SessionLastName = user.lastName;
        //    SessionClass.SessionUserName = user.userName;
        //    SessionClass.SessionPassword = user.password;
        //    SessionClass.SessionRole = user.role;
        //    SessionClass.SessionEmail = user.email;
        //    SessionClass.registerDate = user.RegisterDate;

        //    return RedirectToPage("/Index"); //no se cual pagina sigue de eso xdxd

        //}

    }
}