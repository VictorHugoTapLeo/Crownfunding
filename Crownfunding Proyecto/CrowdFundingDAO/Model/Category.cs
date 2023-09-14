using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingDAO.Model
{
    public class Category : BaseModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public Category(int id, string name
            , byte status, DateTime registerDate, DateTime lastUpdate, int userID)
            : base(status, registerDate, lastUpdate, userID)
        {
            this.id = id;
            this.name = name;
        }
        public Category(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public Category()
        {
        }
    }
}
