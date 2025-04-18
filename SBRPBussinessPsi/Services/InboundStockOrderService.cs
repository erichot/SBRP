using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBussinessPsi.Services
{
    public class InboundStockOrderService : ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;        
        private readonly LogDbContext m_LogDbContext;

        private readonly ProductRepository m_ProductRepository;
        private readonly ProductStockRepository m_ProductStockRepository;
        private readonly SupplierRepository m_SupplierRepository;

        private readonly SupplierGroupRepository m_SupplierGroupRepository;
        private readonly SupplierGroupService m_SupplierGroupService;

        private readonly InboundStockOrderRepository m_InboundStockOrderRepository;
        private readonly InboundStockOrderDetailRepository m_InboundStockOrderDetailRepository;

        private readonly InboundStockOrderLogRepository m_InboundStockOrderLogRepository;
        private readonly InboundStockOrderDetailLogRepository m_InboundStockOrderDetailLogRepository;

        public InboundStockOrderService(PsiDbContext psiDbContext
            , InboundStockOrderLogRepository inboundStockOrderLogRepository
            , InboundStockOrderDetailLogRepository inboundStockOrderDetailLogRepository)
        {
            m_PsiDbContext = psiDbContext;

            m_ProductRepository = new ProductRepository(psiDbContext);
            m_ProductStockRepository = new ProductStockRepository(psiDbContext);
            m_SupplierRepository = new SupplierRepository(psiDbContext);
            m_SupplierGroupRepository = new SupplierGroupRepository(psiDbContext);
            m_SupplierGroupService = new SupplierGroupService(psiDbContext);

            m_InboundStockOrderRepository = new InboundStockOrderRepository(psiDbContext);
            m_InboundStockOrderDetailRepository = new InboundStockOrderDetailRepository(psiDbContext);

            m_InboundStockOrderLogRepository = inboundStockOrderLogRepository;
            m_InboundStockOrderDetailLogRepository = inboundStockOrderDetailLogRepository;
        }



        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;

            m_ProductRepository.SetSIG(_sIGNo);
            m_SupplierRepository.SetSIG(_sIGNo);
            m_SupplierGroupRepository.SetSIG(_sIGNo);
            m_SupplierGroupService.SetSIG(_sIGNo);
            m_InboundStockOrderRepository.SetSIG(_sIGNo);
        }


        
















        #region "Basic based Procedure"
        public InboundStockOrder? GetEntity(int _orderNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_orderNo.IsNullOrDefault()) return null;
            return m_InboundStockOrderRepository.GetEntity(_orderNo, _enableTracking, _includeDetails);
        }
        public async Task<InboundStockOrder?> GetEntityAsync(int _orderNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_orderNo.IsNullOrDefault()) return null;
            return await m_InboundStockOrderRepository.GetEntityAsync(_orderNo, _enableTracking, _includeDetails);
        }
        public InboundStockOrder? GetEntity(string _InboundStockOrderId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_InboundStockOrderId)) return null;
            return GetEntity(_InboundStockOrderId, _enableTracking, _includeDetails);
        }
        public async Task<InboundStockOrder?> GetEntityAsync(string _InboundStockOrderId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_InboundStockOrderId)) return null;
            return await GetEntityAsync(_InboundStockOrderId, _enableTracking, _includeDetails);
        }
        public InboundStockOrder? GetEntity(InboundStockOrder _info, bool _enableTracking, bool _includeDetails = true)
        {
            return m_InboundStockOrderRepository.GetEntity(_info, _enableTracking, _includeDetails);
        }
        public async Task<InboundStockOrder?> GetEntityAsync(InboundStockOrder _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_InboundStockOrderRepository.GetEntityAsync(_info, _enableTracking, _includeDetails);
        }
        public List<InboundStockOrder> GetList(InboundStockOrder _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_InboundStockOrderRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToList();
        }
        public async Task<List<InboundStockOrder>> GetListAsync(InboundStockOrder _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_InboundStockOrderRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToListAsync();
        }
        public IQueryable<InboundStockOrder> GetQuery(InboundStockOrder? _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            return m_InboundStockOrderRepository.GetQuery(_info, _enableTracking, _includeDetails);
        }
        #endregion




        public async Task<List<InboundStockOrder>> GetListAsync(InboundStockOrderFilter _filter)
        {
            var aaa = await 
                m_InboundStockOrderRepository
                    .GetQuery(
                        _filter.ToEntity()
                        , _enableTracking:false, _includeDetails:true)
                    .ToListAsync();
            return aaa;
        }






        public async Task<string> GetNewOrderIdAsync(DateOnly _orderDate, short _supplierNo)
        {
            var dateRowNo = await m_InboundStockOrderRepository.GetRowCountAsync(m_SIGNo, _supplierNo) + 1;
            var supplierRowNo = await m_SupplierRepository.GetRowCountAsync(m_SIGNo, _supplierNo);
            return OperationTypePrefix.InboundStork
                + supplierRowNo.ToString("0000")
                + dateRowNo.ToString("0000")
                ;
                
        }








        public async Task<InboundStockOrder> AddNewDefaultAsync(InboundStockOrder _info)
        {
            var result = _info;
            var supplierNo = _info.SupplierNo;

            result.StockNo = m_SupplierGroupService
                .GetStock_BySupplierDefault(supplierNo)?
                    .StockNo_Default ?? default(short);

            result.OrderId = await 
                GetNewOrderIdAsync(DateOnly.FromDateTime(DateTime.Now), supplierNo);

            return result;
        }





      





















        #region "Detail"
        public async Task<List<InboundStockOrderDetail?>> GetDetailListAsync(int _orderNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                m_InboundStockOrderDetailRepository
                    .GetQuery(
                        new InboundStockOrderDetail() { OrderNo = _orderNo }
                        , _enableTracking: _enableTracking, _includeDetails: _includeDetails
                    )
                    .ToListAsync();
        }
        #endregion











        #region "Log Draft Head"
        public async Task<InboundStockOrder> AddDraftAsync(InboundStockOrder _info)
        {
            var result = await
                m_InboundStockOrderLogRepository
                    .AddEntityAsync(_info, SBRPLogPsi.LogTypeEnum.Add);

            return result;
        }
        #endregion




        #region "Log Draft Detail"
        public async Task<List<InboundStockOrderDetail>> GetDetailLogListAsync(int _logNo)
        {
            var details = await
                m_InboundStockOrderDetailLogRepository
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
                         select new InboundStockOrderDetail()
                         {
                             LogNo = _logNo,
                             OrderNo = detail.OrderNo,
                             ItemNo = detail.ItemNo,
                             ProductNo = detail.ProductNo,
                             Product = subProduct,
                             Quantity = detail.Quantity,
                             UnitCost = detail.UnitCost,
                             SubAmount = detail.SubAmount,
                             Remark = detail.Remark,
                             LoginActionNo = detail.LoginActionNo
                         };

            return result.ToList();
        }

        public async Task<InboundStockOrderDetail?> InsertDetailLogAsync(InboundStockOrderDetail _info)
        {
            var result = 
                await 
                    m_InboundStockOrderDetailLogRepository
                        .AddEntityAsync(_info);

            return result;
        }




        public async Task<InboundStockOrderDetail?> UpdateDetailLogAsync(InboundStockOrderDetail _info)
        {
            return
                await 
                    m_InboundStockOrderDetailLogRepository
                    .UpdateEntityAsync(_info);
        }

        public async Task DeleteDetailLogAsync(InboundStockOrderDetail _info)
        {
            var logNo = _info.LogNo;
            var itemNo = _info.ItemNo;
            
            if (logNo.IsNullOrDefault() || itemNo.IsNullOrDefault()) return;
             
            await
                    m_InboundStockOrderDetailLogRepository
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
        public async Task<BusinessProcessResult> ProcessToInsertAsync(InboundStockOrder _info)
        {
            var result = new BusinessProcessResult();
            var inserting = _info;

            //var daySerialNo = m_InboundStockOrderRepository.GetDaySerialNo_NewDefault(_info.OrderDateNo);
            //inserting.SetDaySerialNo(daySerialNo);
            inserting.OrderId = await
                GetNewOrderIdAsync(DateOnly.FromDateTime(DateTime.Now), _info.SupplierNo);

            var logInfo = await
                m_InboundStockOrderLogRepository
                    .UpdateEntityAsync(inserting, SBRPLogPsi.LogTypeEnum.Add);
            if (logInfo == null)
            {
                result.SetErrorMessage("Log Error");
                return result;
            }

            var dataProcessResult = m_InboundStockOrderRepository.INSERT_InboundStockOrder_ByLogNo(logInfo.LogNo);
            result = new BusinessProcessResult(dataProcessResult);

            //m_PsiDbContext.Entry(inserting).Reference(r => r.Supplier).IsModified = false;
            //inserting.InboundStockOrderDetails.ToList().ForEach(r => r.Product = null);

            //var entity = await 
            //    m_InboundStockOrderRepository
            //        .AddEntityAsync(inserting);


            //var details = inserting
            //    .InboundStockOrderDetails
            //    .GroupBy(x => x.ProductNo)
            //    .Select(g => new InboundStockOrderDetail()
            //    {
            //        ProductNo = g.Key,
            //        Quantity = g.Sum(x => x.Quantity)
            //    })
            //    .ToList();

            //var productStocks = m_ProductStockRepository.GetQuery(new ProductStock(), _enableTracking: true);
            //var inboundStockOrderDetails = m_InboundStockOrderDetailRepository
            //    .GetQuery(new InboundStockOrderDetail() { OrderNo = entity.OrderNo }, _enableTracking: false);

            //var query = from detail in inboundStockOrderDetails
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
