using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

using Avanze_ProjectoWeb.Models;
using System.Data;
using Microsoft.AspNetCore.Http;

using System.Text.RegularExpressions;
namespace Avanze_ProjectoWeb.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;

        }

        public string Username { get; set; }
        public string Rol { get; set; }

       
        public void OnGet()
        {
          

             
        }
    }
}