using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;

namespace StudyWebApplication.DbHelper
{
    public class ParameterMember : List<Parameter>
    {
        public void Add(OracleDbType dbType, string parameterName, object value)
        {
            this.Add(new Parameter(dbType, parameterName, value));
        }
    }
}
