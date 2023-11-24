using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingDAO.Model
{
    public class Description : BaseModel
    {
        public int id { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public int projectId { get; set; }
        public Description(int id, string type, string description, int projectId
            , byte status, DateTime registerDate, DateTime lastUpdate, int userID)
            : base(status, registerDate, lastUpdate, userID)
        {
            this.id = id;
            this.type = type;
            this.description = description;
            this.projectId = projectId;
        }
        public Description(int id, string type, string description, int projectId)
        {
            this.id = id;
            this.type = type;
            this.description = description;
            this.projectId = projectId;
        }
        //metodo description 
        public Description( string type, string description, int projectId)
        {
            this.id = id;
            this.type = type;
            this.description = description;
            this.projectId = projectId;
        }
        public Description()
        {

        }
    }
}
