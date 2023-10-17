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
    public class UserImpl : BaseImpl, IUser
    {
        public List<User> SelectAll()
        {
            List<User> users = new List<User>();
            query = @"SELECT id, name, lastName, secondLastName, userName, password, role, email, phoneNumber, status, registerDate, lastUpdate, userID
                    FROM Userr
                    WHERE status = 1
                    ORDER BY 2";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                foreach (DataRow row in table.Rows)
                {
                    users.Add(new User(
                        int.Parse(row["id"].ToString()),
                        row["name"].ToString(),
                        row["lastName"].ToString(),
                        row["secondLastName"].ToString(),
                        row["userName"].ToString(),
                        row["password"].ToString(),
                        row["role"].ToString(),
                        row["email"].ToString(),
                        row["phoneNumber"].ToString()
                    ));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return users;
        }


        public int Delete(User t)
        {
            query = "DELETE FROM Userr WHERE id = @id";
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
            //query = @"UPDATE Userr SET status = 0 ,lastUpdate = CURRENT_TIMESTAMP ,userID = @userID WHERE id = @id";
            //SqlCommand command = CreateBasicCommand(query);
            //command.Parameters.AddWithValue("@id", t.id);
            //command.Parameters.AddWithValue("@userID", t.UserID);
            //try
            //{
            //    return ExecuteBasicCommand(command);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

        }
        public User Get(int id)
        {
            User t = null;
            query = @"SELECT id, name, lastName, secondLastName, userName, password , role , email, phoneNumber, status,registerDate, ISNULL(lastUpdate,CURRENT_TIMESTAMP),userID
                        FROM Userr
                        WHERE status = 1 AND id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    t = new User(int.Parse(table.Rows[0][0].ToString()),
                        table.Rows[0][1].ToString(),
                        table.Rows[0][2].ToString(),
                        table.Rows[0][3].ToString(),
                        table.Rows[0][4].ToString(),
                        table.Rows[0][5].ToString(),
                        table.Rows[0][6].ToString(),
                        table.Rows[0][7].ToString(),
                        table.Rows[0][8].ToString(),
                        //BASE
                        byte.Parse(table.Rows[0][9].ToString()),
                        DateTime.Parse(table.Rows[0][10].ToString()),
                        DateTime.Parse(table.Rows[0][11].ToString()),
                        int.Parse(table.Rows[0][12].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }
        public int Insert(User t)
        {
            query = @"INSERT INTO Userr(name, lastName, secondLastName, userName, password , role , email, phoneNumber,userID) 
                    VALUES (@name, @lastName, @secondLastName, @userName, HASHBYTES('md5',@password), @role, @email, @phoneNumber, @userID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", t.name);
            command.Parameters.AddWithValue("@lastName", t.lastName);
            command.Parameters.AddWithValue("@secondLastName", t.secondLastName);
            command.Parameters.AddWithValue("@userName", t.userName);
            command.Parameters.AddWithValue("@password", t.password).SqlDbType = SqlDbType.VarChar;
            command.Parameters.AddWithValue("@role", t.role);
            command.Parameters.AddWithValue("@email", t.email);
            command.Parameters.AddWithValue("@phoneNumber", t.phoneNumber);
            command.Parameters.AddWithValue("@userID", 1);
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
            query = @"SELECT id, name, lastName, secondLastName, userName, password , role , email, phoneNumber
                        FROM Userr
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
        public int Update(User t)
        {

            query = @"UPDATE Userr SET name = @name , lastName = @lastName, secondLastName = @secondLastName, userName = @userName,
                        role = @role, email = @email, phoneNumber = @phoneNumber, lastUpdate = CURRENT_TIMESTAMP, userID = @UserID
                        WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t.id);
            command.Parameters.AddWithValue("@name", t.name);
            command.Parameters.AddWithValue("@lastName", t.lastName);
            command.Parameters.AddWithValue("@secondLastName", t.secondLastName);
            command.Parameters.AddWithValue("@userName", t.userName);
            command.Parameters.AddWithValue("@role", t.role);
            command.Parameters.AddWithValue("@email", t.email);
            command.Parameters.AddWithValue("@phoneNumber", t.phoneNumber);
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


        public User Login(string email, string password)
        {
            User t = null;
            query = @"SELECT id, name, lastName, secondLastName, userName, password , role , email, phoneNumber, status,registerDate, ISNULL(lastUpdate,CURRENT_TIMESTAMP),userID
                        FROM Userr
                        WHERE status = 1 AND email = @email AND password = HASHBYTES('md5',@password)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    t = new User(int.Parse(table.Rows[0][0].ToString()),
                        table.Rows[0][1].ToString(),
                        table.Rows[0][2].ToString(),
                        table.Rows[0][3].ToString(),
                        table.Rows[0][4].ToString(),
                        table.Rows[0][5].ToString(),
                        table.Rows[0][6].ToString(),
                        table.Rows[0][7].ToString(),
                        table.Rows[0][8].ToString(),
                        //BASE
                        byte.Parse(table.Rows[0][9].ToString()),
                        DateTime.Parse(table.Rows[0][10].ToString()),
                        DateTime.Parse(table.Rows[0][11].ToString()),
                        int.Parse(table.Rows[0][12].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }
    }
}
