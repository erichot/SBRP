using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace SBRPDataRmshq.Services
{
    public class SaleOrderService
    {
        private readonly RmshqDbContext m_RmshqDbContext;
        private readonly RmshqDapperContext m_DapperContext;
        private readonly RmshqSqlConnection m_RmshqSqlConnection;

        public SaleOrderService(RmshqDbContext rmshqDbContext, RmshqDapperContext dapperContext, RmshqSqlConnection rmshqSqlConnection)
        {
            m_RmshqDbContext = rmshqDbContext;
            m_DapperContext = dapperContext;
            m_RmshqSqlConnection = rmshqSqlConnection;
        }








        public DataTable SP_GET_OR_SaleOrder_Pivot_SaleQty(string _userID
            , string _searchKeywordArray, DateOnly? _date1, DateOnly? _date2
            , string _storeSelectionArray
            , bool _isGroupByColor, bool _isGroupBySize)
        {
            var returnValue = default(int);
            var param = new SqlParameter[8];
            param[0] = new SqlParameter("@UserID", SqlDbType.Char, 8) { Value = _userID };
            param[1] = new SqlParameter("@SearchKeywordArray", SqlDbType.VarChar, 500) { Value = _searchKeywordArray };
            param[2] = new SqlParameter("@Date1", SqlDbType.Date) { Value = _date1 };
            param[3] = new SqlParameter("@Date2", SqlDbType.Date) { Value = _date2 };
            param[4] = new SqlParameter("@StoreSelectionArray", SqlDbType.VarChar, 100) { Value = _storeSelectionArray };
            param[5] = new SqlParameter("@IsGroupByColor", SqlDbType.Bit) { Value = _isGroupByColor };
            param[6] = new SqlParameter("@IsGroupBySize", SqlDbType.Bit) { Value = _isGroupBySize };
            
            param[7] = new SqlParameter("@ReturnValue", SqlDbType.Int);
            param[7].Direction = ParameterDirection.ReturnValue;

            if (_date1.IsNullOrDefault())
            {
                param[2].IsNullable = true;
                param[2].Value = DBNull.Value;
            }

            if (_date2.IsNullOrDefault())
            {
                param[3].IsNullable = true;
                param[3].Value = DBNull.Value;
            }

            
            var result = m_RmshqSqlConnection.ExecuteStoredProcedure(DbSystemModel.SP_GET_OR_SaleOrder_Pivot_SaleQty, param);
            if (param[7].Value != DBNull.Value) 
                int.TryParse(param[7].Value.ToString(), out returnValue);

            return result;
        }



      


    }
}
