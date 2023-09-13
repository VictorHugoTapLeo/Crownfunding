using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingDAO.Model
{
    public class SocialMedia
    {
        public int id { get; set; }
        public string name { get; set; }
        public string mediaLink { get; set; }
        public int projectId { get; set; }
    }
}
