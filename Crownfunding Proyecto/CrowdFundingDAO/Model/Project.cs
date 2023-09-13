using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingDAO.Model
{
    public class Project : BaseModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string ProjectPng { get; set; }
        public string finalProductPng { get; set; }
        public string video { get; set; }
        public string process { get; set; }
        public int userId { get; set; }
        public int categoryId { get; set; }
    }
}
