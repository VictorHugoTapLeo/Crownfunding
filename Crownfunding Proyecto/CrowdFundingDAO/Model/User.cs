using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingDAO.Model
{
    public class User : BaseModel
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
        public User(int id, string name, string lastName, string secondLastName, string userName, string password, string role, string email, string phoneNumber
            , byte status, DateTime registerDate, DateTime lastUpdate, int userID)
            : base(status, registerDate, lastUpdate, userID)
        {
            this.id = id;
            this.name = name;
            this.lastName = lastName;
            this.secondLastName = secondLastName;
            this.userName = userName;
            this.password = password;
            this.role = role;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }
        public User(int id, string name, string lastName, string secondLastName, string userName, string password, string role, string email, string phoneNumber)
        {
            this.id = id;
            this.name = name;
            this.lastName = lastName;
            this.secondLastName = secondLastName;
            this.userName = userName;
            this.password = password;
            this.role = role;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }
        public User()
        { 
        }
    }
}
