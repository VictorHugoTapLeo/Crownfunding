using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingDAO.Model
{
    public class Project : BaseModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string projectPng { get; set; }
        public string finalProductPng { get; set; }
        public string productionProcessPng { get; set; }
        public string campaingVideo { get; set; }
        public int userCampaingId { get; set; }
        public int categoryId { get; set; }
        public Project(int id, string title, string projectPng, string finalProductPng, string productionProcessPng, string campaingVideo, int userCampaingId, int categoryId
            , byte status, DateTime registerDate, DateTime lastUpdate, int userID)
            : base(status, registerDate, lastUpdate, userID)
        {
            this.id = id;
            this.title = title;
            this.projectPng = projectPng;
            this.finalProductPng = finalProductPng;
            this.productionProcessPng = productionProcessPng;
            this.campaingVideo = campaingVideo;
            this.userCampaingId = userCampaingId;
            this.categoryId = categoryId;
        }
        public Project(int id, string title, string projectPng, string finalProductPng, string productionProcessPng, string campaingVideo, int userCampaingId, int categoryId)
        {
            this.id = id;
            this.title = title;
            this.projectPng = projectPng;
            this.finalProductPng = finalProductPng;
            this.productionProcessPng = productionProcessPng;
            this.campaingVideo = campaingVideo;
            this.userCampaingId = userCampaingId;
            this.categoryId = categoryId;
        }
        public Project()
        {
        }
    }
}
