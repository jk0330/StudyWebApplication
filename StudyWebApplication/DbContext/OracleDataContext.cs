using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using OracleInternal.SqlAndPlsqlParser.LocalParsing;

namespace StudyWebApplication.DbContext
{
    public class OracleDataContext
    {
        public static string ConnectionString { get; set; }
        private static OracleConnection connection;
        private static object lockObject = new object();

        /// <summary>
        /// 오라클 데이터베이스 연결
        /// </summary>
        /// <returns></returns>
        private static OracleConnection GetConnection()
        {
            connection = new OracleConnection(ConnectionString);

            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                connection.Close();
            }

            return connection;
        }

        /// <summary>
        /// 쿼리문
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(StringBuilder strSql, ParameterMember param = null)
        {
            bool lockToken = false;
            using DataSet ds = new DataSet();

            try
            {
                Monitor.Enter(lockObject, ref lockToken);
                WeakReference weakConnection = new WeakReference(GetConnection());
                
                using OracleConnection connection = weakConnection.Target as OracleConnection;
                using OracleCommand command = connection.CreateCommand();
                using OracleDataAdapter adapter = new OracleDataAdapter(strSql.ToString(), connection);

                command.CommandText = strSql.ToString();

                if (param != null)
                {
                    adapter.SelectCommand = command;
                    BindParameter(strSql, command, param);
                }

                adapter.Fill(ds);

                connection.Close();
            }
            catch (Exception)
            {
            }
            finally
            {
                if (lockToken)
                {
                    Monitor.Exit(lockObject);
                }
            }

            return ds;
        }

        /// <summary>
        /// Insert, Update, Delete
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int ExcuteNonQuery(StringBuilder strSql, ParameterMember param = null)
        {
            int result = 0;
            bool lockToken = false;

            try
            {
                Monitor.Enter(lockObject, ref lockToken);
                WeakReference weakConnection = new WeakReference(GetConnection());

                using OracleConnection connection = weakConnection.Target as OracleConnection;
                using OracleCommand command = connection.CreateCommand();

                command.CommandText = strSql.ToString();

                if (param != null)
                {
                    BindParameter(strSql, command, param);
                }

                result = command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception)
            {
            }
            finally
            {
                if (lockToken)
                {
                    Monitor.Exit(lockObject);
                }
            }

            return result;
        }

        /// <summary>
        /// 오라클 파라미터 바인딩 메소드
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="command"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        private static void BindParameter(StringBuilder strSql, OracleCommand command, ParameterMember param = null)
        {
            command.BindByName = true;

            foreach (var item in param)
            {
                using OracleParameter parameter = command.CreateParameter();
                parameter.ParameterName = item.ParameterName;
                parameter.OracleDbType = item.DbType;
                parameter.Value = item.Value;

                command.Parameters.Add(parameter);
            }
        }
    }
}
