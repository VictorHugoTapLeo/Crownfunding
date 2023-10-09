using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingDAO.Model
{
    public class Support : BaseModel
    {
        public int id { get; set; }
        public int supporterId { get; set; }
        public int projectId { get; set; }
        public string supportType { get; set; }
        public string supportVerification { get; set; }
        public Support(int id, int supporterId, int projectId, string supportType, string supportVerification
            , byte status, DateTime registerDate, DateTime lastUpdate, int userID)
            : base(status, registerDate, lastUpdate, userID)
        {
            this.id = id;
            this.supporterId = supporterId;
            this.projectId = projectId;
            this.supportType = supportType;
            this.supportVerification = supportVerification;
        }
        public Support(int id, int supporterId, int projectId, string supportType, string supportVerification)
        {
            this.id = id;
            this.supporterId = supporterId;
            this.projectId = projectId;
            this.supportType = supportType;
            this.supportVerification = supportVerification;
        }
        public Support(int id)
        {
            this.id = id;
           
        }
        public Support()
        {
        }
    }
}
