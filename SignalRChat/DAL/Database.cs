using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SignalRChat.DAL
{
    public static class Database
    {
        /// <summary>
        /// Singleton Database instance
        /// </summary>
        public static string DbInstance
        {
            get
            {
                if (_DbInstance == null)
                {
                    _DbInstance = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                }
                return _DbInstance;
            }
        }
        private static string _DbInstance;

        /// <summary>
        /// Execute procedure with given parameters
        /// </summary>
        /// <param name="storedProcedure">The procedure name.</param>
        /// <param name="storedProcedureParameters">The sql parameters for the procedure.</param>
        /// <returns></returns>
        public static DataSet ExecuteProcedureDataSet(string storedProcedure, List<SqlParameter> storedProcedureParameters)
        {
            var dataSet = new DataSet();

            using (var command = new SqlCommand(storedProcedure, new SqlConnection(DbInstance)) { CommandType = CommandType.StoredProcedure })
            {
                try
                {
                    if (storedProcedureParameters != null)
                    {
                        foreach (var param in storedProcedureParameters)
                        {
                            command.Parameters.Add(param);
                        }
                    }
                    if (command.Connection.State != ConnectionState.Open)
                        command.Connection.Open();
                    using (var dataReader = command.ExecuteReader())
                    {
                        var dataTable = new DataTable();
                        dataTable.Load(dataReader);
                        
                        dataSet.Tables.Add(dataTable);
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                 finally
                 {
                    command.Connection.Close();
                }
                command.Connection.Close();

            }

            return dataSet;
        }

        /// <summary>
        /// Execute a procedure "Non-query" nothing to wait in return.
        /// </summary>
        /// <param name="storedProcedure"> Name of the procedure to be executed.</param>
        /// <param name="sqlParameters">Sql parameters List</param>
        public static void ExecuteProcedure(string storedProcedure, List<SqlParameter> sqlParameters)
        {
            using (var command = new SqlCommand(storedProcedure, new SqlConnection(DbInstance)) { CommandType = CommandType.StoredProcedure })
            {
                if (sqlParameters != null)
                {
                    foreach (var param in sqlParameters)
                    {
                        command.Parameters.Add(param);
                    }
                }
                
                if(command.Connection.State != ConnectionState.Open)
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
        }
    }
}
