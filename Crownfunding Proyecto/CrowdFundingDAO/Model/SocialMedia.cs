using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingDAO.Model
{
    public class SocialMedia : BaseModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string mediaLink { get; set; }
        public int projectId { get; set; }
        public SocialMedia(int id, string name, string mediaLink, int projectId
            , byte status, DateTime registerDate, DateTime lastUpdate, int userID)
            : base(status, registerDate, lastUpdate, userID)
        {
            this.id = id;
            this.name = name;
            this.mediaLink = mediaLink;
            this.projectId = projectId;
        }
        public SocialMedia(int id, string name, string mediaLink, int projectId)
        {
            this.id = id;
            this.name = name;
            this.mediaLink = mediaLink;
            this.projectId = projectId;
        }
        public SocialMedia()
        {
        }
    }
}
