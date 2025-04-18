using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBussinessPsi.Services
{
    public class StockTransferOrderService : ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;        
        private readonly LogDbContext m_LogDbContext;

        private readonly StockRepository m_StockRepository;

        private readonly SupplierGroupRepository m_SupplierGroupRepository;
        private readonly SupplierGroupService m_SupplierGroupService;

        private readonly StockTransferOrderRepository m_StockTransferOrderRepository;
        private readonly StockTransferOrderDetailRepository m_StockTransferOrderDetailRepository;

        private readonly StockTransferOrderLogRepository m_StockTransferOrderLogRepository;
        private readonly StockTransferOrderDetailLogRepository m_StockTransferOrderDetailLogRepository;

        public StockTransferOrderService(PsiDbContext psiDbContext
            , StockTransferOrderLogRepository inboundStockOrderLogRepository
            , StockTransferOrderDetailLogRepository inboundStockOrderDetailLogRepository)
        {
            m_PsiDbContext = psiDbContext;

            m_StockRepository = new StockRepository(psiDbContext);
            m_SupplierGroupRepository = new SupplierGroupRepository(psiDbContext);
            m_SupplierGroupService = new SupplierGroupService(psiDbContext);

            m_StockTransferOrderRepository = new StockTransferOrderRepository(psiDbContext);
            m_StockTransferOrderDetailRepository = new StockTransferOrderDetailRepository(psiDbContext);

            m_StockTransferOrderLogRepository = inboundStockOrderLogRepository;
            m_StockTransferOrderDetailLogRepository = inboundStockOrderDetailLogRepository;
        }



        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_StockRepository.SetSIG(_sIGNo);
            m_StockTransferOrderRepository.SetSIG(_sIGNo);
        }


        
















        #region "Basic based Procedure"
        public StockTransferOrder? GetEntity(int _orderNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_orderNo.IsNullOrDefault()) return null;
            return m_StockTransferOrderRepository.GetEntity(_orderNo, _enableTracking, _includeDetails);
        }
        public async Task<StockTransferOrder?> GetEntityAsync(int _orderNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_orderNo.IsNullOrDefault()) return null;
            return await m_StockTransferOrderRepository.GetEntityAsync(_orderNo, _enableTracking, _includeDetails);
        }
        public StockTransferOrder? GetEntity(string _StockTransferOrderId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_StockTransferOrderId)) return null;
            return GetEntity(_StockTransferOrderId, _enableTracking, _includeDetails);
        }
        public async Task<StockTransferOrder?> GetEntityAsync(string _StockTransferOrderId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_StockTransferOrderId)) return null;
            return await GetEntityAsync(_StockTransferOrderId, _enableTracking, _includeDetails);
        }
        public StockTransferOrder? GetEntity(StockTransferOrder _info, bool _enableTracking, bool _includeDetails = true)
        {
            return m_StockTransferOrderRepository.GetEntity(_info, _enableTracking, _includeDetails);
        }
        public async Task<StockTransferOrder?> GetEntityAsync(StockTransferOrder _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_StockTransferOrderRepository.GetEntityAsync(_info, _enableTracking, _includeDetails);
        }
        public List<StockTransferOrder> GetList(StockTransferOrder _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_StockTransferOrderRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToList();
        }
        public async Task<List<StockTransferOrder>> GetListAsync(StockTransferOrder _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_StockTransferOrderRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToListAsync();
        }
        public IQueryable<StockTransferOrder> GetQuery(StockTransferOrder? _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            return m_StockTransferOrderRepository.GetQuery(_info, _enableTracking, _includeDetails);
        }
        #endregion




        public async Task<List<StockTransferOrder>> GetListAsync(StockTransferOrderFilter _filter)
        {
            return await m_StockTransferOrderRepository
                 .GetQuery(
                    _filter.ToEntity()
                    , _enableTracking:false, _includeDetails:true)
                 .ToListAsync();
        }






        public async Task<string> GetNewOrderIdAsync(DateOnly _orderDate, short _fromStockNo)
        {
            var dateRowNo = await m_StockTransferOrderRepository.GetRowCountAsync(m_SIGNo, _orderDate) + 1;
            return OperationTypePrefix.StoreTransfer
                + dateRowNo.ToString("0000")
                + _fromStockNo.ToString("0000");
                
        }








        public async Task<StockTransferOrder> AddNewDefaultAsync(StockTransferOrder _info)
        {
            var result = _info;
            var fromStockNo = _info.FromStockNo;

           

            result.OrderId = await 
                GetNewOrderIdAsync(DateOnly.FromDateTime(DateTime.Now), fromStockNo);

            return result;
        }





      





















        #region "Detail"
        public async Task<List<StockTransferOrderDetail?>> GetDetailListAsync(int _orderNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                m_StockTransferOrderDetailRepository
                    .GetQuery(
                        new StockTransferOrderDetail() { OrderNo = _orderNo }
                        , _enableTracking: _enableTracking, _includeDetails: _includeDetails
                    )
                    .ToListAsync();
        }
        #endregion











        #region "Log Draft Head"
        public async Task<StockTransferOrder> AddDraftAsync(StockTransferOrder _info)
        {
            var result = await
                m_StockTransferOrderLogRepository
                    .AddEntityAsync(_info);
            
            if (_info.FromStockNo.IsNullOrDefault() == false)
            {
                result.FromStock = await
                    m_StockRepository.GetEntityAsync(result.FromStockNo);
            }
                

            return result;
        }
        #endregion




        #region "Log Draft Detail"
        public async Task<List<StockTransferOrderDetail>> GetDetailLogListAsync(int _logNo)
        {
            return await
                m_StockTransferOrderDetailLogRepository
                    .GetDetailListAsync(_logNo: _logNo);
        }

        public async Task<StockTransferOrderDetail?> InsertDetailLogAsync(StockTransferOrderDetail _info)
        {
            var result = 
                await 
                    m_StockTransferOrderDetailLogRepository
                        .AddEntityAsync(_info);

            return result;
        }

        #endregion




        /// <summary>
        /// 
        /// </summary>
        /// <param name="_info"></param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        public async Task<BusinessProcessResult> ProcessToInsertAsync(StockTransferOrder _info)
        {
            var result = new BusinessProcessResult();
            var inserting = _info;

            //_info.SetDaySerialNo(m_StockTransferOrderRepository.GetDaySerialNo_NewDefault(_info.OrderDateNo));
            inserting.OrderId = await
               GetNewOrderIdAsync(DateOnly.FromDateTime(DateTime.Now), _info.FromStockNo);


            var logInfo = await 
                m_StockTransferOrderLogRepository
                    .UpdateEntityAsync(inserting, SBRPLogPsi.LogTypeEnum.Add);
            if (logInfo == null)
            {
                result.SetErrorMessage("Log Error");
                return result;
            }

            var dataProcessResult = m_StockTransferOrderRepository.INSERT_StockTransferOrder_ByLogNo(logInfo.LogNo);
            result = new BusinessProcessResult(dataProcessResult);



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
