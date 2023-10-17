using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingDAO.Model
{
    public class Patron
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public Patron(int Id)
        {
            this.Id = Id;

        }
        public Patron(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;

        }
        public Patron()
        {


        }
    }
}
