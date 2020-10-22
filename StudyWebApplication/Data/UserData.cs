using Oracle.ManagedDataAccess.Client;
using StudyWebApplication.Models;
using StudyWebApplication.ViewModels;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace StudyWebApplication.DbHelper
{
    public class UserData
    {
        public static int InsertUser(Users model)
        {
            StringBuilder strSql = new StringBuilder();
            ParameterMember param = new ParameterMember();
            HMACSHA512 hash = new HMACSHA512()
            {
                Key = Encoding.Default.GetBytes(model.UserId)
            };

            param.Add(OracleDbType.Varchar2, @"UserId", model.UserId);
            param.Add(OracleDbType.Varchar2, @"UserName", model.UserName);
            param.Add(OracleDbType.Varchar2, @"UserPassword", Convert.ToBase64String(hash.ComputeHash(hash.ComputeHash(Encoding.Default.GetBytes(model.UserPassword)))));

            strSql.Append(@" INSERT INTO TB_USERS                      ");
            strSql.Append(@" VALUES(:UserId, :UserName, :UserPassword) ");

            return OracleDataContext.ExcuteNonQuery(strSql, param);
        }

        public static DataTable SelectUser(UserViewModel model)
        {
            StringBuilder strSql = new StringBuilder();
            ParameterMember param = new ParameterMember();
            HMACSHA512 hash = new HMACSHA512()
            {
                Key = Encoding.Default.GetBytes(model.UserId)
            };

            param.Add(OracleDbType.Varchar2, @"UserId", model.UserId);
            param.Add(OracleDbType.Varchar2, @"UserPassword", Convert.ToBase64String(hash.ComputeHash(hash.ComputeHash(Encoding.Default.GetBytes(model.UserPassword)))));

            strSql.Append(@" SELECT *                         ");
            strSql.Append(@" FROM TB_USERS                    ");
            strSql.Append(@" WHERE USERID = :UserId           ");
            strSql.Append(@" AND USERPASSWORD = :UserPassword ");

            return OracleDataContext.ExecuteDataTable(strSql, param);
        }
    }
}
