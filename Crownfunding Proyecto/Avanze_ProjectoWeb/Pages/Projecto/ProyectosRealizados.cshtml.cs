using CrowdFundingDAO.Implementation;
using CrowdFundingDAO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Avanze_ProjectoWeb.Pages.Projecto
{
    public class ProyectosRealizadosModel : PageModel
    {
        public List<Project> projects = new List<Project>();
        ProjectImpl pImpl;

        public void OnGet()
        {
            pImpl = new ProjectImpl();
            /*foreach (DataRow row in pImpl.Select().Rows)
            {
                Project proyecto = new Project
                (
                    Convert.ToInt32(row["id"]),
                    row["title"].ToString(),
                    row["projectPng"].ToString(),
                    row["finalProductPng"].ToString(),
                    row["productionProcessPng"].ToString(),
                    row["campaingVideo"].ToString(),
                    Convert.ToInt32(row["userCampaingId"]),
                    Convert.ToInt32(row["categoryId"])
                );
                projects.Add(proyecto);
            }*/
            projects.Add(new Project
            {
                id = 1,
                title = "Proyecto 1",
                //projectPng = "imagen1.png",
                //finalProductPng = "producto1.png",
                //productionProcessPng = "proceso1.png",
                campaingVideo = "video1.mp4",
                userCampaingId = 101,
                categoryId = 201
            });
            projects.Add(new Project
            {
                id = 2,
                title = "Proyecto 2sele",
                //projectPng = "imagen2.png",
                //finalProductPng = "producto2.png",
                //productionProcessPng = "proceso2.png",
                campaingVideo = "video2.mp4",
                userCampaingId = 102,
                categoryId = 202
            });
            projects.Add(new Project
            {
                id = 3,
                title = "Proyecto 3",
                //projectPng = "imagen3.png",
                //finalProductPng = "producto3.png",
                //productionProcessPng = "proceso3.png",
                campaingVideo = "video3.mp4",
                userCampaingId = 103,
                categoryId = 203
            });

        }
    }
}
