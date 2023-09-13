using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingDAO.Model
{
    public class Comment
    {
        public int id { get; set; }
        public string description { get; set; }
        public int userId { get; set; }
        public int projectId { get; set; }
    }
}
