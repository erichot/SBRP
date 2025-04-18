using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SBRPBussinessPsi.Services
{
    public class StockService : ISystemIsolationGroupInterface
    {
        private readonly CommonDbContext m_CommonDbContext;
        private readonly CompanyService m_CompanyService;

        private readonly PsiDbContext m_PsiDbContext;
        private readonly OperationClassStockRepository m_OperationClassStockRepository;
        private readonly StockRepository m_StockRepository;

        public StockService(PsiDbContext psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
            m_OperationClassStockRepository = new OperationClassStockRepository(psiDbContext);
            m_StockRepository = new StockRepository(psiDbContext);
        }

        public StockService(CommonDbContext commonDbContext, PsiDbContext psiDbContext)
        {
            m_CommonDbContext = commonDbContext;
            m_CompanyService = new CompanyService(commonDbContext);


            m_PsiDbContext = psiDbContext;
            m_OperationClassStockRepository = new OperationClassStockRepository(psiDbContext);
            m_StockRepository = new StockRepository(psiDbContext);
        }


        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_OperationClassStockRepository.SetSIG(_sIGNo);
            m_StockRepository.SetSIG(_sIGNo);
        }


        
















        #region "Basic based Procedure"
        public Stock? GetEntity(short _stockNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_stockNo.IsNullOrDefault()) return null;
            return m_StockRepository.GetEntity(_stockNo, _enableTracking, _includeDetails);
        }
        public async Task<Stock?> GetEntityAsync(short _stockNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_stockNo.IsNullOrDefault()) return null;
            return await m_StockRepository.GetEntityAsync(_stockNo, _enableTracking, _includeDetails);
        }
        public Stock? GetEntity(string _stockId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_stockId)) return null;
            return GetEntity(_stockId, _enableTracking, _includeDetails);
        }
        public async Task<Stock?> GetEntityAsync(string _stockId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_stockId)) return null;
            return await GetEntityAsync(_stockId, _enableTracking, _includeDetails);
        }
        public Stock? GetEntity(Stock _info, bool _enableTracking, bool _includeDetails = true)
        {
            return m_StockRepository.GetEntity(_info, _enableTracking, _includeDetails);
        }
        public async Task<Stock?> GetEntityAsync(Stock _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_StockRepository.GetEntityAsync(_info, _enableTracking, _includeDetails);
        }
        public List<Stock> GetList(Stock _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_StockRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToList();
        }
        public async Task<List<Stock>> GetListAsync(Stock _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_StockRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToListAsync();
        }
        public IQueryable<Stock> GetQuery(Stock? _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            return m_StockRepository.GetQuery(_info, _enableTracking, _includeDetails);
        }
        #endregion





        public async Task<List<Stock>> GetListAsync(StockFilter _filter, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_StockRepository
                 .GetQuery(_filter.ToEntity(), _enableTracking, _includeDetails)
                 .ToListAsync();
        }




        public async Task<List<Stock>> GetListAsync(OperationClassEnum _operationClass)
        {
            var stocks = m_StockRepository.GetQuery(new StockFilter());
            var operationClassStocks = m_OperationClassStockRepository.GetQuery(new OperationClassStockFilter(_operationClass));

            var result = await 
                (from stock in stocks
                 join operationClassStock in operationClassStocks
                         on stock.StockNo equals operationClassStock.StockNo
                         select stock                         
                         ).ToListAsync();

            //var stocks = await m_StockRepository
            //     .GetQuery(null)
            //     .ToListAsync();

            //var operationClassStocks = await m_OperationClassStockRepository
            //     .GetQuery(new OperationClassStock() { OperationClassNo= _operationClass })
            //     .ToListAsync();

            //var result = stocks.Join(
            //    operationClassStocks,
            //    stock => stock.StockNo,
            //    operationClassStock => operationClassStock.StockNo,
            //    (stock, operationClassStock) => stock
            //    ).ToList();

            return result;
        }






        // After AddNew & Before editing
        public Stock AddNewDefault()
        {
            var result = new Stock();
            result.SetSIG(m_SIGNo);
            return result;
        }












        /// <summary>
        /// 
        /// </summary>
        /// <param name="_info"></param>
        /// <returns></returns>
        /// <remarks>
        /// 前端頁面表單已有具備[Company]、[CompanyContactPersons]欄位
        /// </remarks>
        public async Task<BusinessProcessResult<Stock>> ProcessToInsertAsync(Stock _info)
        {
            var result = new BusinessProcessResult<Stock>();

            _info.SetSIG(m_SIGNo);

            // ================================================================
            
            result.ResultInfo = _info;
            result.ResultNo = _info.StockNo;



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
