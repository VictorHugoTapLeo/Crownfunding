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
        public int Insert(Project t)
        {
            query = @"INSERT INTO Project ( title, projectPng, finalProductPng, productionProcessPng, campaingVideo, userCampaingId,categoryId, userID)
                        VALUES ( @title, @projectPng, @finalProductPng, @productionProcessPng, @campaingVideo, @userCampaingId, @categoryId, ,@userID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@title", t.title);
            command.Parameters.AddWithValue("@projectPng", t.projectPng);
            command.Parameters.AddWithValue("@finalProductPng", t.finalProductPng);
            command.Parameters.AddWithValue("@productionProcessPng", t.productionProcessPng);
            command.Parameters.AddWithValue("@campaingVideo", t.campaingVideo);
            command.Parameters.AddWithValue("@userCampaingId", t.userCampaingId);
            command.Parameters.AddWithValue("@categoryId", t.categoryId);
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
            query = @"UPDATE Project SET title = @title, projectPng = @projectPng, finalProductPng = @finalProductPng, productionProcessPng = @productionProcessPng, campaingVideo = @campaingVideo , lastUpdate = CURRENT_TIMESTAMP , userID = @userID
                        WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", t.id);
            command.Parameters.AddWithValue("@title", t.title);
            command.Parameters.AddWithValue("@projectPng", t.projectPng);
            command.Parameters.AddWithValue("@finalProductPng", t.finalProductPng);
            command.Parameters.AddWithValue("@productionProcessPng", t.productionProcessPng);
            command.Parameters.AddWithValue("@campaingVideo", t.campaingVideo);
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
