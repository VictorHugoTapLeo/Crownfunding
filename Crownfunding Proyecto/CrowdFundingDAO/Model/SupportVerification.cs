using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingDAO.Model
{
    public class SupportVerification : BaseModel
    {
        public int id { get; set; }
        public int supportId { get; set; }
        public DateTime verificationDate { get; set; }
        public string verificationDetails { get; set; }
        public int supportStatus { get; set; }
        public int supportVisible { get; set; }
        public SupportVerification(int id, int supportId, DateTime verificationDate, string verificationDetails, int supportStatus, int supportVisible
            , byte status, DateTime registerDate, DateTime lastUpdate, int userID)
            : base(status, registerDate, lastUpdate, userID)
        {
            this.id = id;
            this.supportId = supportId;
            this.verificationDate = verificationDate;
            this.verificationDetails = verificationDetails;
            this.supportStatus = supportStatus;
            this.supportVisible = supportVisible;
        }
        public SupportVerification(int id, int supportId, DateTime verificationDate, string verificationDetails, int supportStatus,int supportVisible)
        {
            this.id = id;
            this.supportId = supportId;
            this.verificationDate = verificationDate;
            this.verificationDetails = verificationDetails;
            this.supportStatus = supportStatus;
            this.supportVisible= supportVisible;
        }
        public SupportVerification()
        {
        }
    }
}
