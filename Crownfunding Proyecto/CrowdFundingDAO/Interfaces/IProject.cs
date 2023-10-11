using CrowdFundingDAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingDAO.Interfaces
{
    internal interface IProject : IBase<Project>
    {
        Project Get(int id);
        int GetLastInsertedProjectId();
        List<(int, string, string)> GetMyProjects(int id);
        List<(int, string, string)> GetMySupports(int id);
        List<string> Serch(List<string> cat, string palabra );
    }
}
