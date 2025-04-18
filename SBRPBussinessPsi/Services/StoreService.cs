using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SBRPBussinessPsi.Services
{
    public class StoreService : ISystemIsolationGroupInterface
    {
        private readonly CommonDbContext m_CommonDbContext;
        private readonly CompanyService m_CompanyService;

        private readonly PsiDbContext m_PsiDbContext;
        private readonly StockRepository m_StockRepository;
        private readonly StoreRepository m_StoreRepository;
        //private readonly OperationClassStockRepository m_OperationClassStockRepository;
        private readonly OperationClassStockService m_OperationClassStockService;


        public StoreService(PsiDbContext psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
            m_StockRepository = new StockRepository(psiDbContext);
            m_StoreRepository = new StoreRepository(psiDbContext);
            //m_OperationClassStockRepository = new OperationClassStockRepository(psiDbContext);
            m_OperationClassStockService = new OperationClassStockService(psiDbContext);
        }

        public StoreService(CommonDbContext commonDbContext, PsiDbContext psiDbContext)
        {
            m_CommonDbContext = commonDbContext;
            m_CompanyService = new CompanyService(commonDbContext);


            m_PsiDbContext = psiDbContext;
            m_StockRepository = new StockRepository(psiDbContext);
            m_StoreRepository = new StoreRepository(psiDbContext);
            //m_OperationClassStockRepository = new OperationClassStockRepository(psiDbContext);
            m_OperationClassStockService = new OperationClassStockService(psiDbContext);
        }


        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_StockRepository.SetSIG(_sIGNo);
            m_StoreRepository.SetSIG(_sIGNo);
            
        }


        
















        #region "Basic based Procedure"
        public Store? GetEntity(short _storeNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_storeNo.IsNullOrDefault()) return null;
            return m_StoreRepository.GetEntity(_storeNo, _enableTracking, _includeDetails);
        }
        public async Task<Store?> GetEntityAsync(short _storeNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_storeNo.IsNullOrDefault()) return null;
            return await m_StoreRepository.GetEntityAsync(_storeNo, _enableTracking, _includeDetails);
        }
        public Store? GetEntity(string _StoreId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_StoreId)) return null;
            return GetEntity(_StoreId, _enableTracking, _includeDetails);
        }
        public async Task<Store?> GetEntityAsync(string _StoreId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_StoreId)) return null;
            return await GetEntityAsync(_StoreId, _enableTracking, _includeDetails);
        }
        public Store? GetEntity(Store _info, bool _enableTracking, bool _includeDetails = true)
        {
            return m_StoreRepository.GetEntity(_info, _enableTracking, _includeDetails);
        }
        public async Task<Store?> GetEntityAsync(Store _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_StoreRepository.GetEntityAsync(_info, _enableTracking, _includeDetails);
        }
        public List<Store> GetList(Store _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_StoreRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToList();
        }
        public async Task<List<Store>> GetListAsync(Store _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_StoreRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToListAsync();
        }
        public IQueryable<Store> GetQuery(Store? _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            return m_StoreRepository.GetQuery(_info, _enableTracking, _includeDetails);
        }
        #endregion





        public async Task<List<Store>> GetListAsync(StoreFilter _filter, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_StoreRepository
                 .GetQuery(_filter.ToEntity(), _enableTracking, _includeDetails)
                 .ToListAsync();
        }





        public async Task<Store?> GetEntityByStockAsync(short _stockNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_StoreRepository.GetEntityAsync(_stockNo, _enableTracking, _includeDetails);
        }





        // After AddNew & Before editing
        public Store AddNewDefault()
        {
            var result = new Store();
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
        public async Task<BusinessProcessResult<Store>> ProcessToInsertAsync(Store _info
            , List<OperationClassStock> _operationClassStockList)
        {
            var result = new BusinessProcessResult<Store>();

            _info.SetSIG(m_SIGNo);

            // ================================================================
            m_PsiDbContext.Database.EnsureCreated();
            using (var transaction = new TransactionScope())
            {
                m_PsiDbContext.Stores.Add(_info);
                m_PsiDbContext.SaveChanges();

                var stock = new Stock(_info);
                m_PsiDbContext.Stocks.Add(stock);
                m_PsiDbContext.SaveChanges();

                _operationClassStockList.ForEach(c => c.SetStock(stock));
                m_PsiDbContext.OperationClassStocks.AddRange(_operationClassStockList);
                m_PsiDbContext.SaveChanges();

                transaction.Complete();
            }
             
            result.ResultInfo = _info;
            result.ResultNo = _info.StoreNo;



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
