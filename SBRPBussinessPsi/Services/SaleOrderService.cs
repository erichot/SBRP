using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBussinessPsi.Services
{
    public class SaleOrderService : ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;        
        private readonly LogDbContext m_LogDbContext;

        private readonly ProductRepository m_ProductRepository;
        private readonly ProductStockRepository m_ProductStockRepository;
        private readonly StockRepository m_StockRepository;

 
        private readonly SaleOrderRepository m_SaleOrderRepository;
        private readonly SaleOrderDetailRepository m_SaleOrderDetailRepository;

        private readonly SaleOrderLogRepository m_SaleOrderLogRepository;
        private readonly SaleOrderDetailLogRepository m_SaleOrderDetailLogRepository;

        public SaleOrderService(PsiDbContext psiDbContext
            , SaleOrderLogRepository SaleOrderLogRepository
            , SaleOrderDetailLogRepository SaleOrderDetailLogRepository)
        {
            m_PsiDbContext = psiDbContext;

            m_ProductRepository = new ProductRepository(psiDbContext);
            m_ProductStockRepository = new ProductStockRepository(psiDbContext);
            m_StockRepository = new StockRepository(psiDbContext);
       

            m_SaleOrderRepository = new SaleOrderRepository(psiDbContext);
            m_SaleOrderDetailRepository = new SaleOrderDetailRepository(psiDbContext);

            m_SaleOrderLogRepository = SaleOrderLogRepository;
            m_SaleOrderDetailLogRepository = SaleOrderDetailLogRepository;
        }



        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;

            m_ProductRepository.SetSIG(_sIGNo);
            m_StockRepository.SetSIG(_sIGNo);            
            m_SaleOrderRepository.SetSIG(_sIGNo);
        }


        
















        #region "Basic based Procedure"
        public SaleOrder? GetEntity(int _orderNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_orderNo.IsNullOrDefault()) return null;
            return m_SaleOrderRepository.GetEntity(_orderNo, _enableTracking, _includeDetails);
        }
        public async Task<SaleOrder?> GetEntityAsync(int _orderNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_orderNo.IsNullOrDefault()) return null;
            return await m_SaleOrderRepository.GetEntityAsync(_orderNo, _enableTracking, _includeDetails);
        }
        public SaleOrder? GetEntity(string _SaleOrderId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_SaleOrderId)) return null;
            return GetEntity(_SaleOrderId, _enableTracking, _includeDetails);
        }
        public async Task<SaleOrder?> GetEntityAsync(string _SaleOrderId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_SaleOrderId)) return null;
            return await GetEntityAsync(_SaleOrderId, _enableTracking, _includeDetails);
        }
        public SaleOrder? GetEntity(SaleOrder _info, bool _enableTracking, bool _includeDetails = true)
        {
            return m_SaleOrderRepository.GetEntity(_info, _enableTracking, _includeDetails);
        }
        public async Task<SaleOrder?> GetEntityAsync(SaleOrder _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_SaleOrderRepository.GetEntityAsync(_info, _enableTracking, _includeDetails);
        }
        public List<SaleOrder> GetList(SaleOrder _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_SaleOrderRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToList();
        }
        public async Task<List<SaleOrder>> GetListAsync(SaleOrder _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_SaleOrderRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToListAsync();
        }
        public IQueryable<SaleOrder> GetQuery(SaleOrder? _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            return m_SaleOrderRepository.GetQuery(_info, _enableTracking, _includeDetails);
        }
        #endregion




        public async Task<List<SaleOrder>> GetListAsync(SaleOrderFilter _filter)
        {
            var aaa = await 
                m_SaleOrderRepository
                    .GetQuery(
                        _filter.ToEntity()
                        , _enableTracking:false, _includeDetails:true)
                    .ToListAsync();
            return aaa;
        }






        public async Task<string> GetNewOrderIdAsync(DateOnly _orderDate, short _StockNo)
        {
            var dateRowNo = await m_SaleOrderRepository.GetRowCountAsync(m_SIGNo, _StockNo) + 1;
            var StockRowNo = await m_StockRepository.GetRowCountAsync(m_SIGNo, _StockNo);
            return OperationTypePrefix.InboundStork
                + StockRowNo.ToString("0000")
                + dateRowNo.ToString("0000")
                ;
                
        }








        public async Task<SaleOrder> AddNewDefaultAsync(SaleOrder _info)
        {
            var result = _info;
            var StockNo = _info.StockNo;

         

            result.OrderId = await 
                GetNewOrderIdAsync(DateOnly.FromDateTime(DateTime.Now), StockNo);

            return result;
        }





      





















        #region "Detail"
        public async Task<List<SaleOrderDetail?>> GetDetailListAsync(int _orderNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                m_SaleOrderDetailRepository
                    .GetQuery(
                        new SaleOrderDetail() { OrderNo = _orderNo }
                        , _enableTracking: _enableTracking, _includeDetails: _includeDetails
                    )
                    .ToListAsync();
        }
        #endregion











        #region "Log Draft Head"
        public async Task<SaleOrder> AddDraftAsync(SaleOrder _info)
        {
            var result = await
                m_SaleOrderLogRepository
                    .AddEntityAsync(_info, SBRPLogPsi.LogTypeEnum.Add);

            return result;
        }
        #endregion




        #region "Log Draft Detail"
        public async Task<List<SaleOrderDetail>> GetDetailLogListAsync(int _logNo)
        {
            var details = await
                m_SaleOrderDetailLogRepository
                    .GetDetailListAsync(_logNo: _logNo);

            var productNoEnum = details.Select(x => x.ProductNo).Distinct();
            var products = await
                m_ProductRepository
                    .GetQuery(productNoEnum)
                    .ToListAsync();

            if (products == null || products.Any() == false) return details;

            //var result = details.Join(
            //    products
            //    , detail => detail.ProductNo
            //    , product => product.ProductNo
            //    , (detail, product) => { detail.Product = product; return detail; }
            //    )
            //    .ToList();

            var result = from detail in details
                         join product in products
                         on detail.ProductNo equals product.ProductNo into detail_product
                         from subProduct in detail_product.DefaultIfEmpty()
                         select new SaleOrderDetail()
                         {
                             LogNo = _logNo,
                             OrderNo = detail.OrderNo,
                             ItemNo = detail.ItemNo,
                             ProductNo = detail.ProductNo,
                             Product = subProduct,
                             UnitPrice = detail.UnitPrice,
                             ActualSellingPrice = detail.ActualSellingPrice,
                             Quantity = detail.Quantity,                             
                             SubAmount = detail.SubAmount,
                             Remark = detail.Remark,
                             LoginActionNo = detail.LoginActionNo
                         };

            return result.ToList();
        }

        public async Task<SaleOrderDetail?> InsertDetailLogAsync(SaleOrderDetail _info)
        {
            var result = 
                await 
                    m_SaleOrderDetailLogRepository
                        .AddEntityAsync(_info);

            return result;
        }




        public async Task<SaleOrderDetail?> UpdateDetailLogAsync(SaleOrderDetail _info)
        {
            return
                await 
                    m_SaleOrderDetailLogRepository
                    .UpdateEntityAsync(_info);
        }

        public async Task DeleteDetailLogAsync(SaleOrderDetail _info)
        {
            var logNo = _info.LogNo;
            var itemNo = _info.ItemNo;
            
            if (logNo.IsNullOrDefault() || itemNo.IsNullOrDefault()) return;
             
            await
                    m_SaleOrderDetailLogRepository
                        .DeleteEntityAsync(logNo, itemNo);
        }
        #endregion




        /// <summary>
        /// 
        /// </summary>
        /// <param name="_info"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        public async Task<BusinessProcessResult> ProcessToInsertAsync(SaleOrder _info)
        {
            var result = new BusinessProcessResult();
            var inserting = _info;

            //var daySerialNo = m_SaleOrderRepository.GetDaySerialNo_NewDefault(_info.OrderDateNo);
            //inserting.SetDaySerialNo(daySerialNo);
            inserting.OrderId = await
                GetNewOrderIdAsync(DateOnly.FromDateTime(DateTime.Now), _info.StockNo);

            var logInfo = await
                m_SaleOrderLogRepository
                    .UpdateEntityAsync(inserting, SBRPLogPsi.LogTypeEnum.Add);
            if (logInfo == null)
            {
                result.SetErrorMessage("Log Error");
                return result;
            }

            var dataProcessResult = m_SaleOrderRepository.INSERT_SaleOrder_ByLogNo(logInfo.LogNo);
            result = new BusinessProcessResult(dataProcessResult);

            //m_PsiDbContext.Entry(inserting).Reference(r => r.Stock).IsModified = false;
            //inserting.SaleOrderDetails.ToList().ForEach(r => r.Product = null);

            //var entity = await 
            //    m_SaleOrderRepository
            //        .AddEntityAsync(inserting);


            //var details = inserting
            //    .SaleOrderDetails
            //    .GroupBy(x => x.ProductNo)
            //    .Select(g => new SaleOrderDetail()
            //    {
            //        ProductNo = g.Key,
            //        Quantity = g.Sum(x => x.Quantity)
            //    })
            //    .ToList();

            //var productStocks = m_ProductStockRepository.GetQuery(new ProductStock(), _enableTracking: true);
            //var SaleOrderDetails = m_SaleOrderDetailRepository
            //    .GetQuery(new SaleOrderDetail() { OrderNo = entity.OrderNo }, _enableTracking: false);

            //var query = from detail in SaleOrderDetails
            //            join productStock in productStocks
            //            on detail.ProductNo equals productStock.ProductNo
            //            select new { detail, productStock };
            //foreach (var item in query)
            //{
            //    item.productStock.StockQty += item.detail.Quantity;
            //    m_PsiDbContext.Entry(item.productStock).State = EntityState.Modified;
            //}

           
           

            try
            {
                
            }
            catch (Exception ex)
            {
                result.SetErrorMessage(ex.Message);
            }


            return result;
        }


















       








    }
}
