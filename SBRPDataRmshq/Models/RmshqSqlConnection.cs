using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SBRPDataRmshq.Models
{
    public class RmshqSqlConnection:IDisposable
    {
        
        private readonly string m_ConnectionString;

        public int m_ConnectionTimeout = 30;

        private SqlConnection m_Conn;
        public RmshqSqlConnection(string connectionString)
        {
            m_ConnectionString = connectionString;
        }
        public RmshqSqlConnection(string connectionString, int connectionTimeout)
        {
            m_ConnectionString = connectionString;
            m_ConnectionTimeout = connectionTimeout;
        }


        public void Dispose()
        {
            m_Conn.Dispose();
        }




        public bool OpenConnection()
        {
            if (m_Conn == null)
                m_Conn = new SqlConnection(m_ConnectionString);

            if (m_Conn.State == ConnectionState.Closed)
                m_Conn.Open();

            if (m_Conn.State == ConnectionState.Open)
                return true;

            return false;
        }


        public void CloseConnection()
        {
            if (m_Conn != null && m_Conn.State == ConnectionState.Open)
                m_Conn.Close();
        }









        public DataTable ExecuteStoredProcedure(string _spName, SqlParameter[] _inputParas)
        {
            var result = new DataTable();

            OpenConnection();

            using (var cmd = new SqlCommand(_spName,m_Conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = m_ConnectionTimeout;

                foreach (var par in _inputParas ?? Enumerable.Empty<SqlParameter>())
                {
                    cmd.Parameters.Add(par);
                }

                using (var reader = cmd.ExecuteReader()) 
                {
                    result.Load(reader);
                    reader.Close();
                }
            
            }

            CloseConnection();
            return result;
        }





    }
}
