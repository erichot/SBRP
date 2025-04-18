using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class StockTransferOrderRepository : EFCoreRepository<StockTransferOrder>, ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;
        public StockTransferOrderRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
        }

















        #region "Basic based Procedure"
        public StockTransferOrder? GetEntity(int _orderNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new StockTransferOrder() { OrderNo =  _orderNo }, _enableTracking, _includeDetails);
        }
        public async Task<StockTransferOrder?> GetEntityAsync(int _orderNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new StockTransferOrder() { OrderNo =  _orderNo }, _enableTracking, _includeDetails);
        }
        public StockTransferOrder? GetEntity(string _orderId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new StockTransferOrder() { OrderId = _orderId }, _enableTracking, _includeDetails);
        }
        public async Task<StockTransferOrder?> GetEntityAsync(string _orderId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new StockTransferOrder() { OrderId = _orderId }, _enableTracking, _includeDetails);
        }    
        public StockTransferOrder? GetEntity(StockTransferOrder _info, bool _enableTracking, bool _includeDetails = true)
        {
            return GetQuery(_info, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<StockTransferOrder?> GetEntityAsync(StockTransferOrder _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_info, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }


        public IQueryable<StockTransferOrder?> GetQuery(StockTransferOrder? _info = null, bool _enableTracking = false, bool _includeDetails = false)
        {

            var SIGNo = m_SIGNo;
            var OrderNo =  _info?.OrderNo;
            var OrderId = _info?.OrderId;


            IQueryable<StockTransferOrder?> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_PsiDbContext
                    .StockTransferOrders
                    .Include(f => f.FromStock)
                    .Include(f => f.ToStock)
                    .Include(f => f.StockTransferOrderDetails)
                        .ThenInclude(ff => ff.Product);
            }
            else
            {
                basedQuery = m_PsiDbContext
                    .StockTransferOrders;
            }



            var result = basedQuery
                .Where(c => 
                    (OrderNo.IsNullOrDefault() || c.OrderNo == OrderNo)
                    &&
                    (string.IsNullOrWhiteSpace(OrderId) || c.OrderId == OrderId)
                    &&
                    (SIGNo.IsNullOrDefault() || c.SIGNo == SIGNo)
                );

            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion












        public short GetRowCount(byte _sIGNo, DateOnly _orderDate)
        {
            return (short)
                m_PsiDbContext
                    .StockTransferOrders
                    .IgnoreQueryFilters()
                    .Where(c =>
                        c.OrderDate == _orderDate
                        &&
                        (_sIGNo.IsNullOrDefault() == true || c.SIGNo == _sIGNo))
                    .Count();
        }




        public async Task<short> GetRowCountAsync(byte _sIGNo, DateOnly _orderDate)
        {
            return (short)
                await
                    m_PsiDbContext
                    .StockTransferOrders
                    .IgnoreQueryFilters()
                    .Where(c =>
                        c.OrderDate == _orderDate
                        &&
                        (_sIGNo.IsNullOrDefault() == true || c.SIGNo == _sIGNo))
                    .CountAsync();
        }



        public short GetDaySerialNo_NewDefault(short _orderDateNo)
        {
            var result = default(short);
            using (var transaction = 
                m_PsiDbContext
                    .Database
                        .BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
            {
                result = 
                    m_PsiDbContext
                        .StockTransferOrders
                        .IgnoreQueryFilters()
                            .Where(c => c.OrderDateNo == _orderDateNo)
                            .Select(c => c.DaySerialNo)
                            .DefaultIfEmpty()
                            .Max();
                transaction.Commit();
            }

            return result++;
        }








        public DataProcessResult INSERT_StockTransferOrder_ByLogNo(int _logNo)
        {
            var result = new DataProcessResult();
            var connectionString = m_PsiDbContext.Database.GetConnectionString();

            using (var conn = new SqlConnection(connectionString))
            {
                var dparams = new DynamicParameters();
                dparams.Add("@LogNo", _logNo, dbType: DbType.Int32);
                dparams.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                conn.Execute("psi.uspINSERT_StockTransferOrder_ByLogNo", dparams, commandType: CommandType.StoredProcedure);
                result.ResultNo = dparams.Get<int>("@ReturnValue");
            }

            return result;
        }




    }
}
