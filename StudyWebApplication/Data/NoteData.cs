using Oracle.ManagedDataAccess.Client;
using StudyWebApplication.Models;
using StudyWebApplication.ViewModels;
using System.Data;
using System.Text;

namespace StudyWebApplication.DbHelper
{
    public class NoteData
    {
        public static int SelectNoteCount()
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@" SELECT count(*) ");
            strSql.Append(@" FROM TB_NOTES   ");

            return OracleDataContext.ExecuteScalar(strSql);
        }

        public static DataTable SelectNote(NoteIndexView model)
        {
            StringBuilder strSql = new StringBuilder();
            ParameterMember param = new ParameterMember();

            strSql.Append(@" SELECT*                        ");
            strSql.Append(@" FROM(                          ");
            strSql.Append(@"      SELECT ROWNUM AS NUM, A.* ");
            strSql.Append(@"      FROM(                     ");
            strSql.Append(@"            SELECT *            ");
            strSql.Append(@"            FROM TB_NOTES       ");
            strSql.Append(@"            ORDER BY NO DESC    ");
            strSql.Append(@"           ) A                  ");
            strSql.Append(@"      WHERE ROWNUM <= :pEnd     ");
            strSql.Append(@"      )                         ");
            strSql.Append(@" WHERE NUM >= :pStart           ");
            
            param.Add(OracleDbType.Int32, @"pStart", model.Start);
            param.Add(OracleDbType.Int32, @"pEnd", model.End);

            return OracleDataContext.ExecuteDataTable(strSql, param);
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
