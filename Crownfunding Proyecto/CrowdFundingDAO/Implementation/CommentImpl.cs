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
    public class CommentImpl : BaseImpl, IComment
    {
        public int Delete(Comment t)
        {
            query = @"UPDATE Comment SET status = 0 ,lastUpdate = CURRENT_TIMESTAMP ,userID = @userID WHERE id = @id";
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
        public Comment Get(int id)
        {
            Comment t = null;
            query = @"SELECT id, description,idUser, projectId,
                        status,registerDate, ISNULL(lastUpdate,CURRENT_TIMESTAMP),userID
                        FROM Comment
                        WHERE id = @id AND status = 1";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    t = new Comment(int.Parse(table.Rows[0][0].ToString()),  
                        table.Rows[0][1].ToString(),
                        int.Parse(table.Rows[0][2].ToString()),
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
        public int Insert(Comment t)
        {
            query = @"INSERT INTO Comment ( description,idUser, projectId, userID)
                        VALUES (@description, @idUser, @projectId, @userID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@description", t.description);
            command.Parameters.AddWithValue("@idUser", t.idUser);
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
            query = @"SELECT id, description, idUser, projectId
                        FROM Comment
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
        public int Update(Comment t)
        {
            query = @"UPDATE Comment SET description = @description , lastUpdate = CURRENT_TIMESTAMP , userID = @userID
                        WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t.id);
            command.Parameters.AddWithValue("@description", t.description);
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
