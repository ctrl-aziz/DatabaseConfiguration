using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DatabaseConfiguration
{
    public class Database : Queries
    {
        private SqlConnection dbConnection;
        private SqlCommand sql = null;

        /// <summary>
        /// When you want to insert or update data
        /// you must use this construcot and pass [keys] 
        /// and [values] parameters
        /// </summary>
        /// <param name="keys">this list will contain all fileds names that you want to update it or
        /// add new data to database</param>
        /// <param name="values">this list will contain all data that you want to update with or
        /// add new data to database</param>
        public Database(string databaseSource, string[] keys, string[] values) : base(keys, values)
        {
            dbConnection = new SqlConnection($"Data Source={databaseSource};Initial Catalog=DBLibrary;Integrated Security=True");
        }

        /// <summary>
        /// Use this constructor if you only want to delete or get some data
        /// from the database
        /// </summary>
        public Database(string databaseSource) : base()
        {
            dbConnection = new SqlConnection($"Data Source={databaseSource};Initial Catalog=DBLibrary;Integrated Security=True");
        }
        public int InsertData(string tableName)
        {
            SqlCommand sql = null;
            try
            {
                dbConnection.Open();
                sql = new SqlCommand(GetInsertQuery(tableName), dbConnection);
                return sql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public int UpdateData(string tableName, string where, string isEqual)
        {
            SqlCommand sql = null;
            try
            {
                dbConnection.Open();
                sql = new SqlCommand(GetUpdateQuery(tableName, where, isEqual), dbConnection);
                return sql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int DeleteData(string tableName, string where, string isEqual)
        {
            SqlCommand sql = null;
            try
            {
                dbConnection.Open();
                sql = new SqlCommand(GetDeleteQuery(tableName, where, isEqual), dbConnection);
                return sql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public SqlDataReader GetAllData(string tableName)
        {
            SqlCommand sql = null;
            try
            {
                dbConnection.Open();
                sql = new SqlCommand(GetAllDataQuery(tableName), dbConnection);
                SqlDataReader _reader = sql.ExecuteReader();
                
                return _reader;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SqlDataReader GetData(string tableName, string where, string isEqual)
        {
            SqlCommand sql = null;
            try
            {
                dbConnection.Open();
                sql = new SqlCommand(GetDataQuery(tableName, where, isEqual), dbConnection);
                SqlDataReader _reader = sql.ExecuteReader();
                return _reader;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void CloseConnection()
        {
            if (dbConnection.State == System.Data.ConnectionState.Open)
            {
                dbConnection.Close();
                if (sql != null)
                {
                    sql.Dispose();
                }
            }
        }


        
    }
}
