using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingDAO.Model
{
    public class Comment : BaseModel
    {
        public int id { get; set; }
        public string description { get; set; }
        public int idUser { get; set; }
        public int projectId { get; set; }
        public Comment(int id, string description, int idUser, int projectId
            , byte status, DateTime registerDate, DateTime lastUpdate, int userID)
            : base(status, registerDate, lastUpdate, userID)
        {
            this.id = id;
            this.description = description;
            this.idUser = idUser;
            this.projectId = projectId;
        }
        public Comment(int id, string description, int idUser, int projectId)
        {
            this.id = id;
            this.description = description;
            this.idUser = idUser;
            this.projectId = projectId;
        }
        public Comment()
        {
        }
    }
}
