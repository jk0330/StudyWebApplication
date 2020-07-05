using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;

namespace StudyWebApplication.DbContext
{
    public class ParameterMember : List<OracleParameter>
    {
        public void Add(OracleDbType dbType, string parameterName , object value)
        {
            this.Add(new OracleParameter(dbType, parameterName, value));
        }
    }
}
