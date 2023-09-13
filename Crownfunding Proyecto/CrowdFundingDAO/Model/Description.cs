using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingDAO.Model
{
    public class Description
    {
        public int id { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public int projectId { get; set; }
    }
}
