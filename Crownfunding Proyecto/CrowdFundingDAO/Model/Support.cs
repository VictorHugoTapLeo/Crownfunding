using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingDAO.Model
{
    public class Support
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int projectId { get; set; }
        public string supportType { get; set; }
        public DateTime supportDate { get; set; }
        public string supportVerification { get; set; }
    }
}
