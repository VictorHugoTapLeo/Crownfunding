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
    public class DescriptionImpl : BaseImpl, IDescription
    {
        public int Delete(Description t)
        {
            query = @"UPDATE Description SET status = 0 ,lastUpdate = CURRENT_TIMESTAMP ,userID = @userID WHERE id = @id";
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

        public Description Get(int id)
        {
            Description t = null;
            query = @"SELECT id, type, description, projectId,
                        status,registerDate, ISNULL(lastUpdate,CURRENT_TIMESTAMP),userID
                        FROM Description
                        WHERE id = @id AND status = 1";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    t = new Description(int.Parse(table.Rows[0][0].ToString()),
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

        public List<Description> GetAll(int id)
        {
            List<Description> descriptions = new List<Description>();
            query = @"SELECT id, type, description, projectId,
                status,registerDate, ISNULL(lastUpdate,CURRENT_TIMESTAMP),userID
                FROM Description
                WHERE projectId = @id AND status = 1";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                foreach (DataRow row in table.Rows)
                {
                    Description t = new Description(
                        int.Parse(row[0].ToString()),
                        row[1].ToString(),
                        row[2].ToString(),
                        int.Parse(row[3].ToString()),
                        byte.Parse(row[4].ToString()),
                        DateTime.Parse(row[5].ToString()),
                        DateTime.Parse(row[6].ToString()),
                        int.Parse(row[7].ToString())
                    );
                    descriptions.Add(t);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return descriptions;
        }

        public int Insert(Description t)
        {
            query = @"INSERT INTO Description (  type, description, projectId, userID)
                        VALUES ( @type, @description, @projectId, @userID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@type", t.type);
            command.Parameters.AddWithValue("@description", t.description);
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
            query = @"SELECT id, type, description, projectId
                        FROM Description
                        WHERE projectId = @id AND status = 1 ";
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

        public DataTable Selectdes(int id)
        {
            query = @"SELECT id, type, description, projectId
                        FROM Description
                        WHERE projectId = @id AND status = 1 ";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(Description t)
        {
            query = @"UPDATE Description SET  description = @description , lastUpdate = CURRENT_TIMESTAMP , userID = @userID
                        WHERE type = @type AND projectId = @projectID";


            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t.id);
            command.Parameters.AddWithValue("@type", t.type);
            command.Parameters.AddWithValue("@description", t.description);
            command.Parameters.AddWithValue("@projectID", t.projectId);
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
