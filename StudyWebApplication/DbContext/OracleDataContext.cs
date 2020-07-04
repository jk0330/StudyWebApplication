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
        private static OracleConnection Conn { get; set; } = new OracleConnection("Data Source = orcl; User Id = cjk; Password = nvr9rud9");

        private static bool OracleConnect()
        {
            try
            {
                Conn.Open();
            }
            catch (Exception)
            {
                Conn.Close();
                
                return false;
            }
            
            return true;
        }

        public static DataSet ExecuteDataSet(StringBuilder strSql)
        {
            if (OracleConnect() == false)
            {
                return null;
            }
            
            using DataSet dataSet = new DataSet();
            using OracleDataAdapter adapter = new OracleDataAdapter()
            {
                SelectCommand = new OracleCommand(strSql.ToString(), Conn)
            };

            adapter.Fill(dataSet);

            Conn.Close();

            return dataSet;
        }
    }
}
