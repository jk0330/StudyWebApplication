using Oracle.ManagedDataAccess.Client;
using StudyWebApplication.Models;
using StudyWebApplication.ViewModels;
using System.Data;
using System.Text;

namespace StudyWebApplication.DbContext
{
    public class NoteData
    {
        public static DataSet SelectNote(NoteIndexView model)
        {
            StringBuilder strSql = new StringBuilder();
            
            
            strSql.Append(@" SELECT NO, TO_CHAR(CREATE_DATE, 'yyyy-mm-dd HH24:mi:ss') AS CREATE_DATE, TITLE, CONTENTS ");
            strSql.Append(@" FROM TB_NOTES                                                                            ");

            if (model.Start > 0 && model.End > 0)
            {
                ParameterMember param = new ParameterMember();

                param.Add(OracleDbType.Int32, @"pStart", model.Start);
                param.Add(OracleDbType.Int32, @"pEnd", model.End);

                strSql.Append("WHERE ROWNUM >= :pStart");
                strSql.Append("AND ROWNUM <= :pEnd");

                return OracleDataContext.ExecuteDataSet(strSql, param);
            }

            return OracleDataContext.ExecuteDataSet(strSql);
        }

        public static int InsertNote(NoteIndexCreate model)
        {
            StringBuilder strSql = new StringBuilder();
            ParameterMember param = new ParameterMember();

            param.Add(OracleDbType.Varchar2, @"pTitle", model.Title);
            param.Add(OracleDbType.Varchar2, @"pContents", model.Contents);

            strSql.Append(@" INSERT INTO TB_NOTES(NO, TITLE, CONTENTS)   ");
            strSql.Append(@" VALUES(NO_SEQ.NEXTVAL, :pTitle, :pContents) ");

            return OracleDataContext.ExcuteNonQuery(strSql, param);
        }
    }
}
