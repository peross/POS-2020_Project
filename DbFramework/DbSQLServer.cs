using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFramework
{
    public class DbSQLServer
    {
        //ExecuteReader, ExecuteScalar, ExecuteNoQuery

        private string _connstring;

        public DbSQLServer(string connstring)
        {
            _connstring = connstring;
        }

        //Overloading Function
        public object GetScalarValue(string storedProcedureName, DbParameter parameter)
        {
            object value = null;
            
            using(SqlConnection conn = new SqlConnection(_connstring))
            {
                using(SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();

                    cmd.Parameters.AddWithValue(parameter.Parameter, parameter.Value);

                    value = cmd.ExecuteScalar();
                }
            }
            return value;
        }

        public object GetScalarValue(string storedProcedureName, DbParameter[] parameters)
        {
            object value = null;

            using (SqlConnection conn = new SqlConnection(_connstring))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();

                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Parameter, param.Value); 
                    }

                    value = cmd.ExecuteScalar();
                }
            }
            return value;
        }
    }
}
