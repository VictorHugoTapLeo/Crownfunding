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
    public class SupportImpl : BaseImpl, ISupport
    {
        public int Delete(Support t)
        {
            query = @"UPDATE Support SET status = 0 ,lastUpdate = CURRENT_TIMESTAMP ,userID = @userID WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t.id);
            //command.Parameters.AddWithValue("@userID", t.UserID);
            command.Parameters.AddWithValue("@userID", 1);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Support Get(int id)
        {
            Support t = null;
            query = @"SELECT id , supporterId, projectId, supportType, supportVerification , status,registerDate, ISNULL(lastUpdate,CURRENT_TIMESTAMP),userID
                        FROM Support
                        WHERE id = @id AND status = 1";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    t = new Support(int.Parse(table.Rows[0][0].ToString()),
                        int.Parse(table.Rows[0][1].ToString()),
                        int.Parse(table.Rows[0][2].ToString()),
                        table.Rows[0][3].ToString(),
                        table.Rows[0][4].ToString(),
                        //BASE
                        byte.Parse(table.Rows[0][5].ToString()),
                        DateTime.Parse(table.Rows[0][6].ToString()),
                        DateTime.Parse(table.Rows[0][7].ToString()),
                        int.Parse(table.Rows[0][8].ToString())
                        );
                    return t;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }
        public int Insert(Support t)
        {
            query = @"INSERT INTO Support (supporterId, projectId, supportType, supportVerification ,userID)
                        VALUES (@supporterId, @projectId, @supportType, @supportVerification ,@userID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@supporterId", t.supporterId);
            command.Parameters.AddWithValue("@projectId", t.projectId);
            command.Parameters.AddWithValue("@supportType", t.supportType);
            command.Parameters.AddWithValue("@supportVerification", t.supportVerification);
            command.Parameters.AddWithValue("@userID", SessionClass.SessionId);
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
            query = @"SELECT id , supporterId, projectId, supportType, supportVerification 
                        FROM Support
                        WHERE  status = 1 ";
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
        public int Update(Support t)
        {
            query = @"UPDATE Support SET supportType = @supportType, supportVerification = @supportVerification , lastUpdate = CURRENT_TIMESTAMP , userID = @userID
                        WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t.id);
            command.Parameters.AddWithValue("@supportType", t.supportType);
            command.Parameters.AddWithValue("@supportVerification", t.supportVerification);
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
        //Mis metodos 
        public List<Support> SelectMySupport(int idPro)
        {
         
            query = @" SELECT id , supporterId,projectId, supportType, supportVerification,status,(SELECT CONCAT(name, ' ', lastName, ' ',secondLastName) AS nameD FROM Userr WHERE id= supporterId) AS nameD
              FROM Support 
              WHERE status = 1 AND projectId=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", idPro);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                List<Support> supports = new List<Support>();
                foreach (DataRow row in table.Rows)
                {
                    Support support = new Support
                    {
                        id = Convert.ToInt32(row["id"]),
                        supporterId = Convert.ToInt32(row["supporterId"]),
                        projectId = Convert.ToInt32(row["projectId"]),
                        supportType = row["supportType"].ToString(),
                        supportVerification = row["supportVerification"].ToString(),
                        Status = Convert.ToByte(row["status"]),
                        name = row["nameD"].ToString(),
                    };

                    supports.Add(support);
                }

                return supports;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Support GetPatron(int id)
        {
            Support t = null;
            query = @"SELECT id , supporterId, projectId, supportType, supportVerification , status,registerDate, ISNULL(lastUpdate,CURRENT_TIMESTAMP),userID
                        FROM Support
                        WHERE supporterId = @idSupporter AND projectId = @id AND status = 1";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@idSupporter", SessionClass.SessionId);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    t = new Support(int.Parse(table.Rows[0][0].ToString()),
                        int.Parse(table.Rows[0][1].ToString()),
                        int.Parse(table.Rows[0][2].ToString()),
                        table.Rows[0][3].ToString(),
                        table.Rows[0][4].ToString(),
                        //BASE
                        byte.Parse(table.Rows[0][5].ToString()),
                        DateTime.Parse(table.Rows[0][6].ToString()),
                        DateTime.Parse(table.Rows[0][7].ToString()),
                        int.Parse(table.Rows[0][8].ToString())
                        );
                    return t;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }

        public List<string> GetPatronProvidedNames(int idUser,int idProject)
        {
            List<string> patronProvidedNames = new List<string>();
            string query = @"SELECT D.name AS PatronProvidedName
                    FROM PatronProject P
                    JOIN PatronProvided D ON P.idPatron = D.id
					JOIN Project K ON P.idProject = K.id
                    WHERE K.userCampaingId = @idUser AND k.id = @idProject";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idUser", idUser);
            command.Parameters.AddWithValue("@idProject", idProject);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                foreach (DataRow row in table.Rows)
                {
                    patronProvidedNames.Add(row["PatronProvidedName"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return patronProvidedNames;
        }
    }
}
