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
            query = @"UPDATE SocialMedia SET status = 0 ,lastUpdate = CURRENT_TIMESTAMP ,userID = @userID WHERE id = @id";
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
        public SocialMedia Get(int id)
        {
            SocialMedia t = null;
            query = @"SELECT id ,name , mediaLink ,projectId, status,registerDate, ISNULL(lastUpdate,CURRENT_TIMESTAMP),userID
                        FROM SocialMedia
                        WHERE id = id AND status = 1";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    t = new SocialMedia(int.Parse(table.Rows[0][0].ToString()),
                        table.Rows[0][1].ToString(),
                        table.Rows[0][2].ToString(),
                        int.Parse(table.Rows[0][3].ToString()),
                        //BASE
                        byte.Parse(table.Rows[0][4].ToString()),
                        DateTime.Parse(table.Rows[0][5].ToString()),
                        DateTime.Parse(table.Rows[0][6].ToString()),
                        int.Parse(table.Rows[0][7].ToString())
                        );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }
        public int Insert(SocialMedia t)
        {
            query = @"INSERT INTO SocialMedia (name, mediaLink, projectId, userID)
                        VALUES (@name, @mediaLink,@projectId, @userID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", t.name);
            command.Parameters.AddWithValue("@mediaLink", t.mediaLink);
            command.Parameters.AddWithValue("@projectId", t.projectId);
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
            query = @"SELECT id ,name , mediaLink ,projectId
                        FROM SocialMedia
                        WHERE status = 1 ";
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
        public int Update(SocialMedia t)
        {
            query = @"UPDATE SocialMedia SET name = @name, mediaLink = @mediaLink , lastUpdate = CURRENT_TIMESTAMP , userID = @userID
                        WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t.id);
            command.Parameters.AddWithValue("@name", t.name);
            command.Parameters.AddWithValue("@mediaLink", t.mediaLink);
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
