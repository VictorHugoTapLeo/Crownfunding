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
                        WHERE supportId = @id AND status = 1";
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
                         int.Parse(table.Rows[0][5].ToString()),
                        //BASE
                        byte.Parse(table.Rows[0][6].ToString()),
                        DateTime.Parse(table.Rows[0][7].ToString()),
                        DateTime.Parse(table.Rows[0][8].ToString()),
                        int.Parse(table.Rows[0][9].ToString())
                        
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
            query = @"INSERT INTO SupportVerification (supportId, verificationDetails, userID,supportStatus,supportVisible)
                        VALUES(@supportId,@verificationDetails,@userID,@supportStatus,@supportVisible)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@supportId", t.supportId);
            command.Parameters.AddWithValue("@verificationDetails", t.verificationDetails);
          

            command.Parameters.AddWithValue("@supportStatus", t.supportStatus);
            command.Parameters.AddWithValue("@supportVisible", t.supportVisible);
            command.Parameters.AddWithValue("@userID", SessionClass.SessionId); 
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
        public DataTable SSVVGG(int projectId)//descartado,no sirve
        {
            query = @"SELECT s.id , s.supporterId, s.projectId, s.supportType, s.supportVerification,
                    sv.id AS verificationId, sv.verificationDate, sv.verificationDetails, sv.supportStatus, sv.supportVisible
              FROM Support s
              JOIN SupportVerification sv ON s.id = sv.supportId
              WHERE s.status = 1 AND sv.status = 1 AND s.projectId = @projectId";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@projectId", projectId);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SupportVerification SelectSolo(int id)
        {
            query = @"SELECT id, supportId, verificationDate, verificationDetails, supportStatus, supportVisible
              FROM SupportVerification
              WHERE status = 1 AND supportId=@id
              ORDER BY supportId";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    SupportVerification verification = new SupportVerification
                    {
                        id = Convert.ToInt32(row["id"]),
                        supportId = Convert.ToInt32(row["supportId"]),
                        verificationDate = Convert.ToDateTime(row["verificationDate"]),
                        verificationDetails = row["verificationDetails"].ToString(),
                        supportStatus = Convert.ToInt32(row["supportStatus"]),
                        supportVisible = Convert.ToInt32(row["supportVisible"])
                    };
                    return verification;
                }
                else
                {
                    return null; // O puedes tomar alguna otra acción si no hay resultados
                }
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

        //mio
        public List<SupportVerification> GetLista()
        {
            List<SupportVerification> verificationList = new List<SupportVerification>();

            query = @"SELECT id, supportId, verificationDate, verificationDetails, supportStatus, status, registerDate, ISNULL(lastUpdate, CURRENT_TIMESTAMP), userID
              FROM SupportVerification
              WHERE  status = 1";
            SqlCommand command = CreateBasicCommand(query);
           // command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                foreach (DataRow row in table.Rows)
                {
                    SupportVerification verification = new SupportVerification(
                        int.Parse(row[0].ToString()),
                        int.Parse(row[1].ToString()),
                        DateTime.Parse(row[2].ToString()),
                        row[3].ToString(),
                        int.Parse(row[4].ToString()),
                        int.Parse(row[5].ToString()),
                        byte.Parse(row[6].ToString()),
                        DateTime.Parse(row[7].ToString()),
                        DateTime.Parse(row[8].ToString()),
                        int.Parse(row[9].ToString())
                    );

                    verificationList.Add(verification);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return verificationList;
        }

    }
}
