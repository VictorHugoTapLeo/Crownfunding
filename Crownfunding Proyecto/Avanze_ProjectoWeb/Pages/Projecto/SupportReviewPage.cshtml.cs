using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;


using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Model;
namespace Avanze_ProjectoWeb.Pages.Projecto
{
    public class SupportReviewPageModel : PageModel
    {

        [BindProperty]
        public int idSupport { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Este campo es necesario")]
        public string? reviewDescripction { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Este campo es necesario")]
        public int verificationStatus { get; set; }
        public void OnGet(int id)
        {
            idSupport=id;
        }

        public void OnPost()
        {
            SupportImpl supportImpl = new SupportImpl();
            Support support = new Support();
            SupportVerificationImpl sp=new SupportVerificationImpl();
            SupportVerification h = new SupportVerification();
          if(ModelState.IsValid)
            {

                h.supportId = idSupport;
                h.verificationDate = DateTime.Now;
                h.verificationDetails = reviewDescripction;
                h.supportStatus = verificationStatus;
                h.supportVisible = 1;

                sp.Insert(h);

                support.id= idSupport;
                supportImpl.Delete(support);

            }

            
        }
    }
}
