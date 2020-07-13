using System;
using System.Data;
using System.Text;
using System.Threading;
using Oracle.ManagedDataAccess.Client;

namespace StudyWebApplication.DbHelper
{
    public class OracleDataContext
    {
        public static string ConnectionString { get; set; }
        private static OracleConnection connection;
        private static readonly object lockObject = new object();

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
        /// 결과값의 첫 행의 값을 가져오는 메소드
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int ExecuteScalar(StringBuilder strSql, ParameterMember param = null)
        {
            bool lockToken = false;
            int count = 0;

            try
            {
                Monitor.Enter(lockObject, ref lockToken);

                using OracleConnection connection = GetConnection();
                using OracleCommand command = connection.CreateCommand();

                command.CommandText = strSql.ToString();

                if (param != null)
                {
                    BindParameter(command, param);
                }

                count = Convert.ToInt32(command.ExecuteScalar());

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

            return count;
        }

        /// <summary>
        /// 쿼리문
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(StringBuilder strSql, ParameterMember param = null)
        {
            bool lockToken = false;
            using DataTable dt = new DataTable();

            try
            {
                Monitor.Enter(lockObject, ref lockToken);

                using OracleConnection connection = GetConnection();
                using OracleCommand command = connection.CreateCommand();
                using OracleDataAdapter adapter = new OracleDataAdapter(command);

                command.CommandText = strSql.ToString();

                if (param != null)
                {
                    BindParameter(command, param);
                }

                adapter.Fill(dt);

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

            return dt;
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

                using OracleConnection connection = GetConnection();
                using OracleCommand command = connection.CreateCommand();

                command.CommandText = strSql.ToString();

                if (param != null)
                {
                    BindParameter(command, param);
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
        private static void BindParameter(OracleCommand command, ParameterMember param = null)
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
