using CrowdFundingDAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingDAO.Interfaces
{
    internal interface ISocialMedia : IBase<SocialMedia>
    {
        SocialMedia Get(int id);
    }
}
