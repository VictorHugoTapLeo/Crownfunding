﻿using CrowdFundingDAO.Interfaces;
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
    public class SupportVerificationImpl : BaseImpl, ISupportVerification
    {
        public int Delete(SupportVerification t)
        {
            query = @"UPDATE SupportVerification SET status = 0 ,lastUpdate = CURRENT_TIMESTAMP ,userID = @userID WHERE id = @id";
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

        public SupportVerification Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(SupportVerification t)
        {
            throw new NotImplementedException();
        }

        public DataTable Select()
        {
            throw new NotImplementedException();
        }

        public int Update(SupportVerification t)
        {
            throw new NotImplementedException();
        }
    }
}