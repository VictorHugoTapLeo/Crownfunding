using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace CrowdFundingDAO.Implementation
{
    public class BaseImpl
    {

        string connectionString = @"Server=;Database=preuba;User Id=;Password=;";
        internal string query;
        public SqlCommand CreateBasicCommand()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            return command;
        }
        public SqlCommand CreateBasicCommand(string sql)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);

            return command;
        }
        public int ExecuteBasicCommand(SqlCommand command)
        {
            try
            {
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
        }
        public DataTable ExecuteDataTableCommand(SqlCommand command)
        {
            DataTable table = new DataTable();
            try
            {
                command.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
            return table;
        }


        //sacar ultima ID

        public string GetGenerateIDTable(string table)
        {

            query = "  SELECT IDENT_CURRENT('" + table + "') +IDENT_INCR('" + table + "')";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                command.Connection.Open();
                return command.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }


            //version chatgtp
            //query = "SELECT SCOPE_IDENTITY()";
            //       SqlCommand command = CreateBasicCommand(query);
            //       try
            //       {
            //           command.Connection.Open();
            //           return command.ExecuteScalar().ToString();
            //       }
            //       catch (Exception ex)
            //       {
            //           throw ex;
            //       }
            //       finally
            //       {
            //           command.Connection.Close();
            //       }

        }

    }
}
