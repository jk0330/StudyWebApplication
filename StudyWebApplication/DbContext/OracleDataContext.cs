using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace StudyWebApplication.DbContext
{
    public class OracleDataContext
    {
        private static OracleConnection Conn { get; set; } = new OracleConnection("Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.26)(PORT = MyPort))(CONNECT_DATA = (SERVICE_NAME = ORCL))); User Id = myUsername; Password=myPassword;");

        private static void OracleConnect()
        {
            try
            {
                Conn.Open();
            }
            catch (Exception)
            {
                Conn.Close();
            }
        }

        public static DataTable ExecuteDataSet(StringBuilder strSql, ParameterMember param = null)
        {
            OracleConnect();
            
            using OracleDataAdapter adapter = new OracleDataAdapter()
            {
                SelectCommand = new OracleCommand(strSql.ToString(), Conn)
            };

            if (param != null)
            {
                adapter.SelectCommand.BindByName = true;

                foreach (var item in param)
                {
                    adapter.SelectCommand.Parameters.Add(item.ParameterName, item.DbType, item.Value, ParameterDirection.Input);
                }
            }

            Conn.Close();

            return adapter.SelectCommand.ExecuteReaderAsync().Result.GetSchemaTable();
        }

        public static void ExcuteNonQuery(StringBuilder strSql)
        {

        }
    }
}
