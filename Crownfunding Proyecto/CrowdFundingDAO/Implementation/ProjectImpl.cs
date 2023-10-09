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
    public class ProjectImpl : BaseImpl, IProject
    {
        public int Delete(Project t)
        {
            query = @"UPDATE Project SET status = 0 ,lastUpdate = CURRENT_TIMESTAMP ,userID = @userID WHERE id = @id";
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
        public Project Get(int id)
        {
            Project t = null;
            query = @"SELECT id, title, projectPng, finalProductPng, productionProcessPng, campaingVideo, userCampaingId, categoryId,
                        status,registerDate, ISNULL(lastUpdate,CURRENT_TIMESTAMP),userID
                        FROM Project
                        WHERE id = @id AND status = 1";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    t = new Project(int.Parse(table.Rows[0][0].ToString()),
                        table.Rows[0][1].ToString(),
                        table.Rows[0][2].ToString(),
                        table.Rows[0][3].ToString(),
                        table.Rows[0][4].ToString(),
                        table.Rows[0][5].ToString(),
                        int.Parse(table.Rows[0][6].ToString()),
                        int.Parse(table.Rows[0][7].ToString()),
                        //BASE
                        byte.Parse(table.Rows[0][8].ToString()),
                        DateTime.Parse(table.Rows[0][9].ToString()),
                        DateTime.Parse(table.Rows[0][10].ToString()),
                        int.Parse(table.Rows[0][11].ToString())
                        );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }
        public int ids { get; set; }
        public int idsUp { get; set; }
        public int Insert(Project t)
        {
            query = @"INSERT INTO Project (title, projectPng, finalProductPng, productionProcessPng, campaingVideo, userCampaingId, categoryId, userID)
                VALUES (@title, @projectPng, @finalProductPng, @productionProcessPng, @campaingVideo, @userCampaingId, @categoryId, @userID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@title", t.title);
            command.Parameters.AddWithValue("@projectPng", t.projectPng);
            command.Parameters.AddWithValue("@finalProductPng", t.finalProductPng);
            command.Parameters.AddWithValue("@productionProcessPng", t.productionProcessPng);
            command.Parameters.AddWithValue("@campaingVideo", t.campaingVideo);
            command.Parameters.AddWithValue("@userCampaingId", t.userCampaingId);
            command.Parameters.AddWithValue("@categoryId", t.categoryId);
            command.Parameters.AddWithValue("@userID", t.UserID);

             ids = int.Parse(GetGenerateIDTable("Project"));
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
            query = @"SELECT id, title, projectPng, finalProductPng, productionProcessPng, campaingVideo, userCampaingId, categoryId
                        FROM Project
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
        public int Update(Project t)
        {
            query = @"UPDATE Project SET title = @title, projectPng = @projectPng, finalProductPng = @finalProductPng, productionProcessPng = @productionProcessPng, campaingVideo = @campaingVideo , lastUpdate = CURRENT_TIMESTAMP ,categoryId =@categoryID, userID = @userID
                        WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t.id);
            command.Parameters.AddWithValue("@title", t.title);
            command.Parameters.AddWithValue("@projectPng", t.projectPng);
            command.Parameters.AddWithValue("@finalProductPng", t.finalProductPng);
            command.Parameters.AddWithValue("@productionProcessPng", t.productionProcessPng);
            command.Parameters.AddWithValue("@campaingVideo", t.campaingVideo);
            command.Parameters.AddWithValue("@categoryID", t.categoryId);
            command.Parameters.AddWithValue("@userID", t.UserID);
            idsUp = int.Parse(GetGenerateIDTable("Project"));
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //metodo para id de proyecto
        public int GetLastInsertedProjectId()
        {
            query = @"SELECT IDENT_CURRENT('Project')";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                object result = ExecuteBasicCommand(command);
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //mis metodos 
        public List<Project> Selectpros()
        {
            List<Project> projects = new List<Project>();

            query = @"SELECT id, title
                FROM Project
                WHERE status = 1 ";
            SqlCommand command = CreateBasicCommand(query);

            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                foreach (DataRow row in table.Rows)
                {
                    Project project = new Project
                    {
                        id = Convert.ToInt32(row["id"]),
                        title = row["title"].ToString(),
                     
                    };

                    projects.Add(project);
                }

                return projects;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<(int,string, string)> GetMyProjects(int id)
        {
            List<(int,string, string)> projects = new List<(int,string, string)>();

            query = @"SELECT P.id, P.title , D.description
                        FROM Project P
                        INNER JOIN Description D ON D.projectId = P.id
                        WHERE P.status = 1 AND P.userCampaingId = @id AND D.type = 'Description'";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                foreach (DataRow row in table.Rows)
                {
                    int i = Convert.ToInt32(row["id"]);
                    string title = row["title"].ToString();
                    string description = row["description"].ToString();

                    projects.Add((i,title, description));
                }

                return projects;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<(int, string, string)> GetMySupports(int id)
        {
            List<(int, string, string)> projects = new List<(int, string, string)>();

            query = @"SELECT P.id, P.title , D.description
                        FROM Project P
                        INNER JOIN Support S ON P.id = S.projectId
                        INNER JOIN Description D ON D.projectId = P.id
                        WHERE P.status = 1 AND S.supporterId = @id AND D.type = 'Description'";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                foreach (DataRow row in table.Rows)
                {
                    int i = Convert.ToInt32(row["id"]);
                    string title = row["title"].ToString();
                    string description = row["description"].ToString();

                    projects.Add((i, title, description));
                }

                return projects;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //metodo para projectos propios ,solo mios 
        public List<Project> SelectMyPro(int iduser)
        {
            List<Project> projects = new List<Project>();

            query = @"SELECT id, title
                FROM Project
                WHERE status = 1 AND userCampaingId=@id ";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", iduser);

            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                foreach (DataRow row in table.Rows)
                {
                    Project project = new Project
                    {
                        id = Convert.ToInt32(row["id"]),
                        title = row["title"].ToString(),

                    };

                    projects.Add(project);
                }

                return projects;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Project> SupportedProByMe(int myid)
        {
            List<Project> projects = new List<Project>();

            query = @"SELECT id,title
                    FROM Project
                    WHERE id IN (SELECT projectId
                    FROM Support
                    WHERE supporterId = @id) ";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", myid);

            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                foreach (DataRow row in table.Rows)
                {
                    Project project = new Project
                    {
                        id = Convert.ToInt32(row["id"]),
                        title = row["title"].ToString(),

                    };

                    projects.Add(project);
                }

                return projects;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
