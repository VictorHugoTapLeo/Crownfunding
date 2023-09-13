using CrowdFundingDAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingDAO.Interfaces
{
    internal interface ICategory : IBase<Category>
    {
        Category Get(int id);
    }
}
