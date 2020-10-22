using Oracle.ManagedDataAccess.Client;

namespace StudyWebApplication.DbHelper
{
    public class Parameter
    {
        public OracleDbType DbType { get; set; }

        public string ParameterName { get; set; }

        public object Value { get; set; }

        public Parameter(OracleDbType dbType, string parameterName, object value)
        {
            ParameterName = parameterName;
            DbType = dbType;
            Value = value;
        }
    }
}
