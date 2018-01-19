using InkeServer.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Inke.Common.Helpers;

namespace InkeServer.DataMapping
{
    public static class DatabaseExtensions
    {
        /// <summary>
        /// 执行存储过程返回DataSet
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sql">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static DataSet SqlQueryForDynamic(this Database db,
               string sql,
               params object[] parameters)
        {
            SqlConnection defaultConn = new System.Data.SqlClient.SqlConnection();

            return SqlQueryForDynamicOtherDB(db, sql, defaultConn, parameters);
        }

        public static DataSet SqlQueryForDynamicOtherDB(this Database db,
                      string sql,
                      SqlConnection conn,
                      params object[] parameters)
        {
            conn.ConnectionString = db.Connection.ConnectionString;

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
            cmd.CommandText = sql;
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds);

            if (ds == null)
                return null;

            cmd.Parameters.Clear();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            adp.Dispose();

            return ds;
        }
    }
}
