﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MedusaSQLServer
{

    /// <summary> Abstracts Database connectivity and provides SQL Injection Prevention Mechanism </summary>
    public class DBUtilsServer
    {

        public static string GetConnectionString(string connName)
        {
            string strReturn = string.Empty;
            if (!(string.IsNullOrEmpty(connName)))
            {
                strReturn = ConfigurationManager.ConnectionStrings[connName].ConnectionString;
            }
            else
            {
                strReturn = ConfigurationManager.ConnectionStrings[connName].ConnectionString;
            }
            return strReturn;
        }
        private SqlConnection Connection { get; set; }

        private SqlCommand Command { get; set; }

        public List<DbParameter> OutParameters { get; private set; }

        private void Open()
        {
            try
            {
                Connection = new SqlConnection(GetConnectionString("SQLConnection"));

                Connection.Open();
            }
            catch (Exception ex)
            {

                Close();
            }
        }

        private void Close()
        {
            if (Connection != null)
            {
                Connection.Close();
            }
        }


        public DataSet DataSelect(SqlCommand cmdSQLQuery)
        {
            string conConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            SqlConnection SQLDatabaseConnection = new SqlConnection(conConnectionString);

            //Perform Command
            cmdSQLQuery.Connection = SQLDatabaseConnection;
            DataSet dsPageInfo = new DataSet();
            SqlDataAdapter daPageInfo = new SqlDataAdapter(cmdSQLQuery);
            SQLDatabaseConnection.Open();
            daPageInfo.Fill(dsPageInfo);
            SQLDatabaseConnection.Close();
            return dsPageInfo;

        }


        /// <summary> Returns the results of a SQL Query in the form of a DataTable </summary>
        public DataTable SQLSelect(SqlCommand cmdSQLQuery)
        {
            //Get connection string
            string conConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            SqlConnection SQLDatabaseConnection = new SqlConnection(conConnectionString);

            //Perform Command
            cmdSQLQuery.Connection = SQLDatabaseConnection;
            DataSet dsPageInfo = new DataSet();
            SqlDataAdapter daPageInfo = new SqlDataAdapter(cmdSQLQuery);
            SQLDatabaseConnection.Open();
            daPageInfo.Fill(dsPageInfo);
            SQLDatabaseConnection.Close();
            return dsPageInfo.Tables[0];
        }

        public DataTable ProcedureSelect2(string procedureName, List<DbParameter> parameters)
        {
            //Get connection string
            string conConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            SqlConnection SQLDatabaseConnection = new SqlConnection(conConnectionString);

            //Perform Command
            SqlCommand Command = new SqlCommand();
            Command.Connection = SQLDatabaseConnection;
            Command.CommandType = CommandType.Text;

            DataSet dsPageInfo = new DataSet();
            SqlDataAdapter daPageInfo = new SqlDataAdapter();

            if (parameters != null)
            {
                Command.Parameters.Clear();

                foreach (DbParameter dbParameter in parameters)
                {
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = dbParameter.Name;
                    parameter.Direction = (ParameterDirection)dbParameter.Direction;
                    parameter.Value = dbParameter.Value;
                    Command.Parameters.Add(parameter);
                }
            }
            Command.CommandText = procedureName;
            daPageInfo.SelectCommand = Command;
            SQLDatabaseConnection.Open();
            daPageInfo.Fill(dsPageInfo);
            SQLDatabaseConnection.Close();
            return dsPageInfo.Tables[0];

        }

        public DataTable ProcedureSelect(string procedureName, List<DbParameter> parameters)
        {
            //Get connection string
            string conConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            SqlConnection SQLDatabaseConnection = new SqlConnection(conConnectionString);

            //Perform Command
            SqlCommand Command = new SqlCommand();
            Command.Connection = SQLDatabaseConnection;
            Command.CommandType = CommandType.StoredProcedure;

            DataSet dsPageInfo = new DataSet();
            SqlDataAdapter daPageInfo = new SqlDataAdapter();

            if (parameters != null)
            {
                Command.Parameters.Clear();

                foreach (DbParameter dbParameter in parameters)
                {
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = dbParameter.Name;
                    parameter.Direction = (ParameterDirection)dbParameter.Direction;
                    parameter.Value = dbParameter.Value;
                    Command.Parameters.Add(parameter);
                }
            }
            Command.CommandText = procedureName;
            daPageInfo.SelectCommand = Command;
            
            SQLDatabaseConnection.Open();
            
            daPageInfo.Fill(dsPageInfo);
            SQLDatabaseConnection.Close();
               
            return dsPageInfo.Tables[0];
             
        }

        public DataTable ProcedureSelect(string conection,string procedureName, List<DbParameter> parameters)
        {
            //Get connection string
            string conConnectionString = ConfigurationManager.ConnectionStrings[conection].ConnectionString;
            SqlConnection SQLDatabaseConnection = new SqlConnection(conConnectionString);

            //Perform Command
            SqlCommand Command = new SqlCommand();
            Command.Connection = SQLDatabaseConnection;
            Command.CommandType = CommandType.StoredProcedure;

            DataSet dsPageInfo = new DataSet();
            SqlDataAdapter daPageInfo = new SqlDataAdapter();

            if (parameters != null)
            {
                Command.Parameters.Clear();

                foreach (DbParameter dbParameter in parameters)
                {
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = dbParameter.Name;
                    parameter.Direction = (ParameterDirection)dbParameter.Direction;
                    parameter.Value = dbParameter.Value;
                    Command.Parameters.Add(parameter);
                }
            }
            Command.CommandText = procedureName;
            daPageInfo.SelectCommand = Command;

            SQLDatabaseConnection.Open();

            daPageInfo.Fill(dsPageInfo);
            SQLDatabaseConnection.Close();

            return dsPageInfo.Tables[0];

        }



        public DataSet ProcedureDataSet(string procedureName, List<DbParameter> parameters)
        {
            //Get connection string
            string conConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            SqlConnection SQLDatabaseConnection = new SqlConnection(conConnectionString);

            //Perform Command
            SqlCommand Command = new SqlCommand();
            Command.Connection = SQLDatabaseConnection;
            Command.CommandType = CommandType.StoredProcedure;

            DataSet dsPageInfo = new DataSet();
            SqlDataAdapter daPageInfo = new SqlDataAdapter();

            if (parameters != null)
            {
                Command.Parameters.Clear();

                foreach (DbParameter dbParameter in parameters)
                {
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = dbParameter.Name;
                    parameter.Direction = (ParameterDirection)dbParameter.Direction;
                    parameter.Value = dbParameter.Value;
                    Command.Parameters.Add(parameter);
                }
            }
            Command.CommandText = procedureName;
            daPageInfo.SelectCommand = Command;
            SQLDatabaseConnection.Open();
            daPageInfo.Fill(dsPageInfo);
            SQLDatabaseConnection.Close();
            return dsPageInfo;

        }


        public object Escalar(string procedureName, List<DbParameter> parameters)
        {
            object respuesta;
            //Get connection string
            string conConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            SqlConnection SQLDatabaseConnection = new SqlConnection(conConnectionString);

            //Perform Command
            SqlCommand Command = new SqlCommand();
            Command.Connection = SQLDatabaseConnection;
            Command.CommandType = CommandType.StoredProcedure;

            DataSet dsPageInfo = new DataSet();
            SqlDataAdapter daPageInfo = new SqlDataAdapter();

            if (parameters != null)
            {
                Command.Parameters.Clear();

                foreach (DbParameter dbParameter in parameters)
                {
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = dbParameter.Name;
                    parameter.Direction = (ParameterDirection)dbParameter.Direction;
                    parameter.Value = dbParameter.Value;
                    Command.Parameters.Add(parameter);
                }
            }
            Command.CommandText = procedureName;
            SQLDatabaseConnection.Open();
            respuesta = Command.ExecuteScalar();
            SQLDatabaseConnection.Close();
            return respuesta;

        }

        /// <summary> Executes a SQL Command </summary>
        public void ExecuteSQLCommand(SqlCommand CommandToExecute)
        {
            //get connection sring
            string conConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            SqlConnection SQLDatabaseConnection = new SqlConnection(conConnectionString);

            //execute command
            CommandToExecute.Connection = SQLDatabaseConnection;
            SQLDatabaseConnection.Open();
            CommandToExecute.ExecuteNonQuery();
            SQLDatabaseConnection.Close();

        }


        public object Escalar(string sqlString)
        {
            object respuesta;
            //Get connection string
            string conConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            SqlConnection SQLDatabaseConnection = new SqlConnection(conConnectionString);

            SqlCommand cmdSQLQuery = new SqlCommand();
            cmdSQLQuery.Connection = SQLDatabaseConnection;
            SQLDatabaseConnection.Open();
            cmdSQLQuery.CommandType = CommandType.Text;
            cmdSQLQuery.CommandText = sqlString;
            //execute command

            respuesta = cmdSQLQuery.ExecuteScalar();
            SQLDatabaseConnection.Close();
            return respuesta;

        }

        public object EscalarText(string procedureName, List<DbParameter> parameters)
        {
            object respuesta;
            //Get connection string
            string conConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            SqlConnection SQLDatabaseConnection = new SqlConnection(conConnectionString);

            //Perform Command
            SqlCommand Command = new SqlCommand();
            Command.Connection = SQLDatabaseConnection;
            Command.CommandType = CommandType.Text;

            DataSet dsPageInfo = new DataSet();
            SqlDataAdapter daPageInfo = new SqlDataAdapter();

            if (parameters != null)
            {
                Command.Parameters.Clear();

                foreach (DbParameter dbParameter in parameters)
                {
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = dbParameter.Name;
                    parameter.Direction = (ParameterDirection)dbParameter.Direction;
                    parameter.Value = dbParameter.Value;
                    Command.Parameters.Add(parameter);
                }
            }
            Command.CommandText = procedureName;
            SQLDatabaseConnection.Open();
            respuesta = Command.ExecuteScalar();

            SQLDatabaseConnection.Close();
            return respuesta;

        }
        public DataTable SQLSelect(string sqlProcedure)
        {
            //Get connection string
            string conConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            SqlConnection SQLDatabaseConnection = new SqlConnection(conConnectionString);

            //Perform Command
            SqlCommand cmdSQLQuery = new SqlCommand();
            cmdSQLQuery.Connection = SQLDatabaseConnection;
            cmdSQLQuery.CommandType = CommandType.StoredProcedure;
            cmdSQLQuery.CommandText = sqlProcedure;

            DataSet dsPageInfo = new DataSet();
            SqlDataAdapter daPageInfo = new SqlDataAdapter();
            daPageInfo.SelectCommand = cmdSQLQuery;
            SQLDatabaseConnection.Open();
            daPageInfo.Fill(dsPageInfo);
            SQLDatabaseConnection.Close();
            return dsPageInfo.Tables[0];
        }


        // executes stored procedure with DB parameteres if they are passed
        private object ExecuteProcedure(string procedureName, ExecuteType executeType, List<DbParameter> parameters)
        {
            object returnObject = null;

            if (Connection != null)
            {
                if (Connection.State == ConnectionState.Open)
                {
                    Command = new SqlCommand(procedureName, Connection);
                    Command.CommandType = CommandType.StoredProcedure;

                    // pass stored procedure parameters to command
                    if (parameters != null)
                    {
                        Command.Parameters.Clear();

                        foreach (DbParameter dbParameter in parameters)
                        {
                            SqlParameter parameter = new SqlParameter();
                            parameter.ParameterName = dbParameter.Name;
                            parameter.Direction = (ParameterDirection)dbParameter.Direction;
                            parameter.Value = dbParameter.Value;
                            Command.Parameters.Add(parameter);
                        }
                    }

                    switch (executeType)
                    {
                        case ExecuteType.ExecuteReader:
                            returnObject = Command.ExecuteReader();
                            break;
                        case ExecuteType.ExecuteNonQuery:
                            returnObject = Command.ExecuteNonQuery();
                            break;
                        case ExecuteType.ExecuteScalar:
                            returnObject = Command.ExecuteScalar();
                            break;
                        default:
                            break;
                    }
                }
            }

            return returnObject;
        }

        // updates output parameters from stored procedure
        private void UpdateOutParameters()
        {
            if (Command.Parameters.Count > 0)
            {
                OutParameters = new List<DbParameter>();
                OutParameters.Clear();

                for (int i = 0; i < Command.Parameters.Count; i++)
                {
                    if (Command.Parameters[i].Direction == ParameterDirection.Output || Command.Parameters[i].Direction == ParameterDirection.InputOutput)
                    {
                        OutParameters.Add(new DbParameter(Command.Parameters[i].ParameterName,
                                                          DbDirection.Output,
                                                          Command.Parameters[i].Value));
                    }
                }
            }
        }



        // executes scalar query stored procedure without parameters
        public T ExecuteSingle<T>(string procedureName) where T : new()
        {
            return ExecuteSingle<T>(procedureName, null);
        }

        // executes scalar query stored procedure and maps result to single object
        public T ExecuteSingle<T>(string procedureName, List<DbParameter> parameters) where T : new()
        {
            Open();
            IDataReader reader = (IDataReader)ExecuteProcedure(procedureName, ExecuteType.ExecuteReader, parameters);
            T tempObject = new T();

            if (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    PropertyInfo propertyInfo = typeof(T).GetProperty(reader.GetName(i));
                    propertyInfo.SetValue(tempObject, reader.GetValue(i), null);
                }
            }

            reader.Close();

            UpdateOutParameters();

            Close();

            return tempObject;
        }

        // executes list query stored procedure without parameters
        public List<T> ExecuteList<T>(string procedureName) where T : new()
        {
            return ExecuteList<T>(procedureName, null);
        }

        // executes list query stored procedure and maps result generic list of objects
        public List<T> ExecuteList<T>(string procedureName, List<DbParameter> parameters) where T : new()
        {
            List<T> objects = new List<T>();

            Open();
            IDataReader reader = (IDataReader)ExecuteProcedure(procedureName, ExecuteType.ExecuteReader, parameters);

            while (reader.Read())
            {
                T tempObject = new T();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (reader.GetValue(i) != DBNull.Value)
                    {
                        PropertyInfo propertyInfo = typeof(T).GetProperty(reader.GetName(i));
                        propertyInfo.SetValue(tempObject, reader.GetValue(i), null);
                    }
                }

                objects.Add(tempObject);
            }

            reader.Close();

            UpdateOutParameters();

            Close();

            return objects;
        }

        // executes non query stored procedure with parameters
        public int ExecuteNonQuery(string procedureName, List<DbParameter> parameters)
        {
            int returnValue;

            Open();

            returnValue = (int)ExecuteProcedure(procedureName, ExecuteType.ExecuteNonQuery, parameters);

            UpdateOutParameters();

            Close();

            return returnValue;
        }

        




    }

    public enum ExecuteType
    {
        ExecuteReader,
        ExecuteNonQuery,
        ExecuteScalar
    };

    public enum DbDirection
    {
        Input,
        InputOutput,
        Output,
        ReturnValue
    };
    public class DbParameter
    {
        public string Name { get; set; }
        public DbDirection Direction { get; set; }
        public object Value { get; set; }

        public DbParameter() { }

        public DbParameter(string parameterName, DbDirection parameterDirection, object parameterValue)
        {
            Name = parameterName;
            Direction = parameterDirection;
            Value = parameterValue;
        }
    }

   
}