using Oracle.ManagedDataAccess.Client;
using StudyWebApplication.Models;
using System.Data;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace StudyWebApplication.DbHelper
{
    public class UserData
    {
        public static int InsertUser(string userId, string userPassword)
        {
            StringBuilder strSql = new StringBuilder();
            ParameterMember param = new ParameterMember();

            param.Add(OracleDbType.Varchar2, @"UserId", userId);
            param.Add(OracleDbType.Varchar2, @"UserPassword", userPassword);

            strSql.Append(@" INSERT INTO TB_USERS            ");
            strSql.Append(@" VALUES(:UserId, :UserPassword) ");

            return OracleDataContext.ExcuteNonQuery(strSql, param);
        }

        public static DataTable SelectUser(Users model)
        {
            StringBuilder strSql = new StringBuilder();
            ParameterMember param = new ParameterMember();

            param.Add(OracleDbType.Varchar2, @"UserId", model.UserId);
            param.Add(OracleDbType.Varchar2, @"UserPassword", model.UserPassword);

            strSql.Append(@" SELECT *                         ");
            strSql.Append(@" FROM TB_USERS                    ");
            strSql.Append(@" WHERE USERID = :UserId           ");
            strSql.Append(@" AND USERPASSWORD = :UserPassword ");

            return OracleDataContext.ExecuteDataTable(strSql, param);
        }
    }
}
