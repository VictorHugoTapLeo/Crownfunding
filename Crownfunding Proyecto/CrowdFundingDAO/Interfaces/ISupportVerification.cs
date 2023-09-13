using CrowdFundingDAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingDAO.Interfaces
{
    internal interface ISupportVerification : IBase<SupportVerification>
    {
        SupportVerification Get(int id);
    }
}
