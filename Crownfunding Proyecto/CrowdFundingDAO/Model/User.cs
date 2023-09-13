using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingDAO.Model
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string secondLastName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
    }
}
