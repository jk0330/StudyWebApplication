using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace StudyWebApplication.DbContext
{
    public class Data
    {
        public static void InsertUser(string userId, string userPassword)
        {
            StringBuilder strSql = new StringBuilder();
            ParameterMember param = new ParameterMember();

            param.Add(OracleDbType.Varchar2, "UserId", userId);
            param.Add(OracleDbType.Varchar2, "UserPassword", userPassword);

            strSql.Append(@" INSERT INTO TB_USER            ");
            strSql.Append(@" VALUES(:UserId, :UserPassword) ");

            OracleDataContext.ExcuteNonQuery(strSql);
        }

        public static DataTable SelectUser(string userId, string userPassword)
        {
            StringBuilder strSql = new StringBuilder();
            ParameterMember param = new ParameterMember();

            param.Add(OracleDbType.Varchar2, "UserId", userId);
            param.Add(OracleDbType.Varchar2, "UserPassword", userPassword);

            strSql.Append(@" SELECT *      ");
            strSql.Append(@" FROM TB_USERS ");

            return OracleDataContext.ExecuteDataSet(strSql, param);
        }
    }
}
