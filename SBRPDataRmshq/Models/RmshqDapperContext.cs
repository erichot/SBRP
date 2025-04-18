using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using Microsoft.Data;
using Microsoft.Data.SqlClient;



namespace SBRPDataRmshq.Models
{
    public class RmshqDapperContext:IDisposable
    {
        private readonly IDbConnection m_Conn;
        private readonly string m_ConnectionString;

        public RmshqDapperContext(string _connectionString)
        {
            m_ConnectionString = _connectionString;
        }

        public IDbConnection CreateConnection() => new SqlConnection(m_ConnectionString);


        public void Dispose()
        {   
            m_Conn.Dispose();
        }













    }
}
