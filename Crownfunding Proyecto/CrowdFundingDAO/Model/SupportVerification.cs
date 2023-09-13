using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingDAO.Model
{
    public class SupportVerification
    {
        public int id { get; set; }
        public int supportId { get; set; }
        public DateTime verificationDate { get; set; }
        public string verificationDetails { get; set; }
        public int supportStatus { get; set; }

    }
}
