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
    public class CategoryImpl : BaseImpl, ICategory
    {
        public int Delete(Category t)
        {
            query = @"UPDATE Category SET status = 0 ,lastUpdate = CURRENT_TIMESTAMP ,userID = @userID WHERE id = @id";
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
        public Category Get(int id)
        {
            Category t = null;
            query = @"SELECT id, name, status, registerDate, ISNULL(lastUpdate,CURRENT_TIMESTAMP),userID
                        FROM Category
                        WHERE id = @id AND status = 1";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    t = new Category(int.Parse(table.Rows[0][0].ToString()),
                        table.Rows[0][1].ToString(),
                        //BASE
                        byte.Parse(table.Rows[0][2].ToString()),
                        DateTime.Parse(table.Rows[0][3].ToString()),
                        DateTime.Parse(table.Rows[0][4].ToString()),
                        int.Parse(table.Rows[0][5].ToString())
                        );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }
        public int Insert(Category t)
        {
            query = @"INSERT INTO Category (name, userID)
                        VALUES (@name, @userID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", t.name);
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
            query = @"SELECT id, name
                        FROM Category
                        WHERE status = 1";
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
        public int Update(Category t)
        {
            query = @"UPDATE Category SET name = @name , lastUpdate = CURRENT_TIMESTAMP , userID = @userID
                        WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t.id);
            command.Parameters.AddWithValue("@name", t.name);
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
        public List<Category> SelectList()
        {
            query = @"SELECT id, name
                FROM Category
                WHERE status = 1";
            SqlCommand command = CreateBasicCommand(query);
            List<Category> categories = new List<Category>();
            try
            {
                DataTable dataTable = ExecuteDataTableCommand(command);

                foreach (DataRow row in dataTable.Rows)
                {
                    Category category = new Category
                    {
                        id = Convert.ToInt32(row["id"]),
                        name = row["name"].ToString()
                    };
                    categories.Add(category);
                }

                return categories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}