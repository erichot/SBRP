using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SBRPBussinessPsi.Services
{
    public class ProductStockService : ISystemIsolationGroupInterface
    {
       
        private readonly PsiDbContext m_PsiDbContext;
        private readonly ProductStockRepository m_ProductStockRepository;

        public ProductStockService(PsiDbContext psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
            m_ProductStockRepository = new ProductStockRepository(psiDbContext);
        }



        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;


            m_ProductStockRepository.SetSIG(_sIGNo);
        }


















        #region "Basic based Procedure"
        public ProductStock? GetEntity(short _ProductStockNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_ProductStockNo.IsNullOrDefault()) return null;
            return m_ProductStockRepository.GetEntity(_ProductStockNo, _enableTracking, _includeDetails);
        }
        public async Task<ProductStock?> GetEntityAsync(short _ProductStockNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_ProductStockNo.IsNullOrDefault()) return null;
            return await m_ProductStockRepository.GetEntityAsync(_ProductStockNo, _enableTracking, _includeDetails);
        }
        public ProductStock? GetEntity(string _ProductStockId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_ProductStockId)) return null;
            return GetEntity(_ProductStockId, _enableTracking, _includeDetails);
        }
        public async Task<ProductStock?> GetEntityAsync(string _ProductStockId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_ProductStockId)) return null;
            return await GetEntityAsync(_ProductStockId, _enableTracking, _includeDetails);
        }
        public ProductStock? GetEntity(ProductStock _info, bool _enableTracking, bool _includeDetails = true)
        {
            return m_ProductStockRepository.GetEntity(_info, _enableTracking, _includeDetails);
        }
        public async Task<ProductStock?> GetEntityAsync(ProductStock _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_ProductStockRepository.GetEntityAsync(_info, _enableTracking, _includeDetails);
        }
        public List<ProductStock> GetList(ProductStock _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_ProductStockRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToList();
        }
        public async Task<List<ProductStock>> GetListAsync(ProductStock _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_ProductStockRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToListAsync();
        }
        public IQueryable<ProductStock> GetQuery(ProductStock? _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            return m_ProductStockRepository.GetQuery(_info, _enableTracking, _includeDetails);
        }
        #endregion








        public StringBuilder GET_ProductStock_PivotReport(ProductStockPivotReportFilter _filter)
        {
            return m_ProductStockRepository.GET_ProductStock_PivotReport(_filter);
        }







    }
}
