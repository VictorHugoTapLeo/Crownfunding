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
    public class SupportVerificationImpl : BaseImpl, ISupportVerification
    {
        public int Delete(SupportVerification t)
        {
            query = @"UPDATE SupportVerification SET status = 0 ,lastUpdate = CURRENT_TIMESTAMP ,userID = @userID WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t.id);
            command.Parameters.AddWithValue("@userID", t.UserID);
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
            SupportVerification t = null;
            query = @"SELECT id , supportId , verificationDate, verificationDetails, supportStatus , status,registerDate, ISNULL(lastUpdate,CURRENT_TIMESTAMP),userID
                        FROM SupportVerification
                        WHERE id = @id AND status = 1";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    t = new SupportVerification(int.Parse(table.Rows[0][0].ToString()),
                        int.Parse(table.Rows[0][1].ToString()),
                        DateTime.Parse(table.Rows[0][2].ToString()),
                        table.Rows[0][3].ToString(),
                        int.Parse(table.Rows[0][4].ToString()),
                        //BASE
                        byte.Parse(table.Rows[0][5].ToString()),
                        DateTime.Parse(table.Rows[0][6].ToString()),
                        DateTime.Parse(table.Rows[0][7].ToString()),
                        int.Parse(table.Rows[0][8].ToString())
                        );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }
        public int Insert(SupportVerification t)
        {
            query = @"INSERT INTO SupportVerification (supportId, verificationDetails, userID)
                        VALUES(@supportId,@verificationDetails,@userID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@supportId", t.supportId);
            command.Parameters.AddWithValue("@verificationDetails", t.verificationDetails);
            command.Parameters.AddWithValue("@userID", t.UserID);
            //command.Parameters.AddWithValue("@userID", SessionClass.SessionId);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select()
        {
            query = @"SELECT id , supportId , verificationDate, verificationDetails, supportStatus
                        FROM SupportVerification
                        WHERE status = 1 
                        ORDER BY 2";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(SupportVerification t)
        {
            query = @"UPDATE SupportVerification SET verificationDetails= @verificationDetails, supportStatus = @supportStatus,lastUpdate = CURRENT_TIMESTAMP , userID = @userID
                        WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t.id);
            command.Parameters.AddWithValue("@verificationDetails", t.verificationDetails);
            command.Parameters.AddWithValue("@supportStatus", t.supportStatus);
            command.Parameters.AddWithValue("@userID", t.UserID);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
