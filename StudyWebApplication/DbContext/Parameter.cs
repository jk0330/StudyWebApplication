using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace StudyWebApplication.DbContext
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
