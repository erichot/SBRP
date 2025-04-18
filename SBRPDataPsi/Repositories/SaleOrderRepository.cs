using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class SaleOrderRepository : EFCoreRepository<SaleOrder>, ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;
        public SaleOrderRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
        }

















        #region "Basic based Procedure"
        public SaleOrder? GetEntity(int _orderNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new SaleOrder() { OrderNo =  _orderNo }, _enableTracking, _includeDetails);
        }
        public async Task<SaleOrder?> GetEntityAsync(int _orderNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new SaleOrder() { OrderNo =  _orderNo }, _enableTracking, _includeDetails);
        }
        public SaleOrder? GetEntity(string _orderId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new SaleOrder() { OrderId = _orderId }, _enableTracking, _includeDetails);
        }
        public async Task<SaleOrder?> GetEntityAsync(string _orderId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new SaleOrder() { OrderId = _orderId }, _enableTracking, _includeDetails);
        }    
        public SaleOrder? GetEntity(SaleOrder _info, bool _enableTracking, bool _includeDetails = true)
        {
            return GetQuery(_info, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<SaleOrder?> GetEntityAsync(SaleOrder _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_info, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }


        public IQueryable<SaleOrder?> GetQuery(SaleOrder? _info = null, bool _enableTracking = false, bool _includeDetails = false)
        {

            var SIGNo = m_SIGNo;
            var OrderNo =  _info?.OrderNo;
            var OrderId = _info?.OrderId;
            var StockNo = _info?.StockNo;
            var MemberNo = _info?.MemberNo;


            IQueryable<SaleOrder?> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_PsiDbContext
                    .SaleOrders
                    .Include(f => f.Stock)
                    .Include(f => f.Member)
                    .Include(f => f.SaleOrderDetails)
                        .ThenInclude(ff => ff.Product);
            }
            else
            {
                basedQuery = m_PsiDbContext
                    .SaleOrders;
            }



            var result = basedQuery
                .Where(c => 
                    (OrderNo.IsNullOrDefault() || c.OrderNo == OrderNo)
                    &&
                    (string.IsNullOrWhiteSpace(OrderId) || c.OrderId == OrderId)
                    &&
                    (SIGNo.IsNullOrDefault() || c.SIGNo == SIGNo)
                    &&
                    (StockNo.IsNullOrDefault() || c.StockNo == StockNo)
                );

            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion












        public short GetRowCount(byte _sIGNo, DateOnly _orderDate)
        {
            return (short)
                m_PsiDbContext
                    .SaleOrders
                    .IgnoreQueryFilters()
                    .Where(c =>
                        c.OrderDate == _orderDate
                        &&
                        (_sIGNo.IsNullOrDefault() == true || c.SIGNo == _sIGNo))
                    .Count();
        }
        public async Task<short> GetRowCountAsync(byte _sIGNo, short _stockNo)
        {
            return (short)
                await
                    m_PsiDbContext
                    .SaleOrders
                    .IgnoreQueryFilters()
                    .Where(c =>  
                        (_stockNo.IsNullOrDefault() || c.StockNo == _stockNo)
                        &&
                        (_sIGNo.IsNullOrDefault() || c.SIGNo == _sIGNo))
                    .CountAsync();
        }


        public short GetDaySerialNo_NewDefault(short _orderDateNo)
        {
            //return m_PsiDbContext.Database.SqlQueryRaw<short>("SELECT psi.udfGET_SaleOrder_DaySerialNo_NewDefault(@p0) AS [value] ", _orderDateNo).Single();
            var result = default(short);
            using (var transaction =
                m_PsiDbContext
                    .Database
                        .BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
            {
                result =
                    m_PsiDbContext
                        .SaleOrders
                        .IgnoreQueryFilters()
                            .Where(c => c.OrderDateNo == _orderDateNo)
                            .Select(c => c.DaySerialNo)
                            .DefaultIfEmpty()
                            .Max();
                transaction.Commit();
            }

            return ++result;
        }











        public DataProcessResult INSERT_SaleOrder_ByLogNo(int _logNo)
        {
            var result = new DataProcessResult();
            var connectionString = m_PsiDbContext.Database.GetConnectionString();

            using (var conn = new SqlConnection(connectionString))
            {
                var dparams = new DynamicParameters();
                dparams.Add("@LogNo", _logNo, dbType: DbType.Int32);
                dparams.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                conn.Execute("psi.uspINSERT_SaleOrder_ByLogNo", dparams, commandType: CommandType.StoredProcedure);
                result.ResultNo = dparams.Get<int>("@ReturnValue");
            }

            return result;
        }







    }
}
