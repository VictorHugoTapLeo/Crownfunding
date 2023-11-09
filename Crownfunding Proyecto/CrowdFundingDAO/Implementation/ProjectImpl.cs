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
                        WHERE id = @id AND status >= 0";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    t = new Project(int.Parse(table.Rows[0][0].ToString()),
                        table.Rows[0][1].ToString(),
                        (byte[])table.Rows[0][2],
                        (byte[])table.Rows[0][3],
                        (byte[])table.Rows[0][4],
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
                return t;
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
                        WHERE status > 0 ";
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
                WHERE status > 0 ";
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
                        WHERE P.status > 0 AND P.userCampaingId = @id AND D.type = 'DescripcionGeneral'";
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
                        WHERE P.status = 2 AND S.supporterId = @id AND D.type = 'DescripcionGeneral'";
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
        public List<(int, string, string)> GetMyFollows(int id)
        {
            List<(int, string, string)> projects = new List<(int, string, string)>();

            query = @"SELECT P.id, P.title , D.description
                        FROM FollowedProject F
                        INNER JOIN Project P ON P.id = F.idProject
                        INNER JOIN Description D ON D.projectId = P.id
                        WHERE P.status > 0 AND F.status = 1 AND F.idUser = @id AND D.type = 'DescripcionGeneral'";
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

        public List<(int ,string, string, byte[])> Serch(List<string> cat, string palabra)
        {
            List<(int,string, string, byte[])> Proyects = new List<(int,string, string, byte[])>();
            query = @"SELECT P.id, P.title,P.projectPng,ISNULL(
                               STUFF((SELECT '/ ' + PV.name
                                      FROM Project P2
                                      INNER JOIN PatronProject PP2 ON P2.id = PP2.idProject
                                      INNER JOIN PatronProvided PV ON PP2.idPatron = PV.id
                                      WHERE P2.id = P.id
                                      FOR XML PATH('')), 1, 2, ''),'N/A' )AS concatenated_names
                        FROM Project P
                        INNER JOIN Category C ON C.id = P.categoryId
                        WHERE P.status = 2 AND P.userCampaingId !=@idusuarioactual ";
            if(palabra != "")
            {
                query += " AND P.title LIKE '%' + @palabra + '%'";
            }
            string categorys = "AND (";
            int count = 0;
            foreach (string i in cat)
            {
                count++;  
                categorys += "C.id = '" + i + "'";  

                
                if (cat.Count > 1 && count != cat.Count )
                {
                    categorys += " OR ";
                }
            }
            categorys += ")";
            if (count > 0)
            {
                query += categorys;
            }
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idusuarioactual", SessionClass.SessionId);
            if (palabra != "")
            {
                command.Parameters.AddWithValue("@palabra", palabra);
            }
            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                foreach (DataRow row in table.Rows)
                {
                    byte[] projectPngBytes = (byte[])row["projectPng"];
                    Proyects.Add((int.Parse(row["id"].ToString()), row["title"].ToString(), row["concatenated_names"].ToString(), projectPngBytes));
                }

                return Proyects;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Project> SelectToAcept()
        {
            List<Project> projects = new List<Project>();

            query = @"SELECT id, title, projectPng, finalProductPng, productionProcessPng, campaingVideo, userCampaingId, categoryId
                        FROM Project
                        WHERE status = 1";
            SqlCommand command = CreateBasicCommand(query);

            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                foreach (DataRow row in table.Rows)
                {
                    byte[] projectPngBytes = (byte[])row["projectPng"]; // Convirtiendo a arreglo de bytes

                    Project project = new Project
                    {
                        id = Convert.ToInt32(row["id"]),
                        title = row["title"].ToString(),
                        projectPng = projectPngBytes // Asignando el arreglo de bytes a tu propiedad projectPng
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

        public List<Project> SelectToRestore()
        {
            List<Project> projects = new List<Project>();

            query = @"SELECT id, title, projectPng, finalProductPng, productionProcessPng, campaingVideo, userCampaingId, categoryId
                        FROM Project
                        WHERE status = 0";
            SqlCommand command = CreateBasicCommand(query);

            try
            {
                DataTable table = ExecuteDataTableCommand(command);

                foreach (DataRow row in table.Rows)
                {
                    byte[] projectPngBytes = (byte[])row["projectPng"];
                    Project project = new Project
                    {
                        id = Convert.ToInt32(row["id"]),
                        title = row["title"].ToString(),
                        projectPng = projectPngBytes
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

        public int PermaDelete(Project t)
        {
            query = @"UPDATE Project SET status = -1 ,lastUpdate = CURRENT_TIMESTAMP ,userID = @userID WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            
            command.Parameters.AddWithValue("@userID", t.UserID);
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

        public int Acept(Project t)
        {
            query = @"UPDATE Project SET status = 2 ,lastUpdate = CURRENT_TIMESTAMP ,userID = @userID WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t.id);
            command.Parameters.AddWithValue("@userID", t.UserID);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex ;
            }
        }

        //metodo para apoyos 
        public List<Patron> SelectPatron()
        {
            query = @"SELECT id, name
                FROM PatronProvided
                WHERE status = 1";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                DataTable dataTable = ExecuteDataTableCommand(command);
                List<Patron> patronList = new List<Patron>();

                foreach (DataRow row in dataTable.Rows)
                {
                    Patron patron = new Patron
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Name = row["name"].ToString()
                    };
                    patronList.Add(patron);
                }

                return patronList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertPatronProject(int idPatron, int idProject)
        {
            query = @"INSERT INTO PatronProject (idPatron, idProject)
              VALUES (@idPatron, @idProject)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idPatron", idPatron);
            command.Parameters.AddWithValue("@idProject", idProject);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //select de apoyos 
        public List<Patron> GetPatronsForProject(int idProjecto)
        {
            List<Patron> patrons = new List<Patron>();

            // Tu código de conexión y configuración de SqlCommand aquí
            string query = @"SELECT idPatron
                    FROM PatronProject
                    WHERE idProjecto = @idProjecto AND status = 1";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idProjecto", idProjecto);

            try
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idPatron = Convert.ToInt32(reader["idPatron"]);
                        Patron patron = new Patron { Id = idPatron };
                        patrons.Add(patron);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return patrons;
        }

        //lll
        public List<Patron> SelectPatronSoloIds(int idProjecto)
        {
            query = @"SELECT idPatron
                    FROM PatronProject
                    WHERE idProject = @idProject AND status = 1";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idProject", idProjecto);
            try
            {
                DataTable dataTable = ExecuteDataTableCommand(command);
                List<Patron> patronList = new List<Patron>();

                foreach (DataRow row in dataTable.Rows)
                {
                    Patron patron = new Patron
                    {
                        Id = Convert.ToInt32(row["idPatron"]),

                    };
                    patronList.Add(patron);
                }

                return patronList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int DeletePatronProjectByProjectId(int idProject)
        {
            query = @"DELETE FROM PatronProject WHERE idProject = @idProject";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idProject", idProject);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Follow(int idProject)
        {
            query = @"EXEC Follow @idUser , @idProject";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idProject", idProject);
            command.Parameters.AddWithValue("@idUser", SessionClass.SessionId);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckFollow(int idProject)
        {
            query = @"SELECT * FROM FollowedProject WHERE idProject = @idProject AND idUser = @idUser AND status = 1";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idProject", idProject);
            command.Parameters.AddWithValue("@idUser", SessionClass.SessionId);
            try
            {
                DataTable dataTable = ExecuteDataTableCommand(command);
                if(dataTable.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
