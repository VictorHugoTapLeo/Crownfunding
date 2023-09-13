using CrowdFundingDAO.Interfaces;
using CrowdFundingDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingDAO.Implementation
{
    public class SocialMediaImpl : BaseImpl, ISocialMedia
    {
        public int Delete(SocialMedia t)
        {
            query = @"UPDATE [NombreDeLaTabla] SET status = 0 ,lastUpdate = CURRENT_TIMESTAMP ,userID = @userID WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t.id);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SocialMedia Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(SocialMedia t)
        {
            throw new NotImplementedException();
        }

        public DataTable Select()
        {
            throw new NotImplementedException();
        }

        public int Update(SocialMedia t)
        {
            throw new NotImplementedException();
        }
    }
}
