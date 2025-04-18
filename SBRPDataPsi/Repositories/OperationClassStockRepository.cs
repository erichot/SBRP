using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class OperationClassStockRepository : EFCoreRepository<OperationClassStock>, ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;
        public OperationClassStockRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
        }









        #region "Basic based Procedure"
        public OperationClassStock? GetEntity(OperationClassEnum _operationClassNo, short _stockNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new OperationClassStock() {OperationClassNo = _operationClassNo, StockNo = _stockNo }, _enableTracking, _includeDetails);
        }
        public async Task<OperationClassStock?> GetEntityAsync(OperationClassEnum _operationClassNo, short _stockNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new OperationClassStock() { OperationClassNo = _operationClassNo, StockNo = _stockNo }, _enableTracking, _includeDetails);
        }
       
        public OperationClassStock? GetEntity(OperationClassStock _info, bool _enableTracking, bool _includeDetails = true)
        {
            return GetQuery(_info, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<OperationClassStock?> GetEntityAsync(OperationClassStock _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_info, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }



        public IQueryable<OperationClassStock> GetQuery(OperationClassStockFilter _filter, bool _enableTracking = false, bool _includeDetails = false)
        {
            var IsDisabled_Filter = _filter.IsDisabled_Filter;
            return GetQuery(_filter.ToEntity(), _enableTracking, _includeDetails)
                .Where(c =>
                    (IsDisabled_Filter == null || c.IsDisabled == IsDisabled_Filter)
                );
        }

        public IQueryable<OperationClassStock> GetQuery(OperationClassStock _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            var SIGNo = m_SIGNo;
            var StockNo = _info.StockNo;
            var OperationClassNo = _info.OperationClassNo;

            IQueryable<OperationClassStock> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_PsiDbContext
                 .OperationClassStocks
                 .Include(f => f.Stock);
            }
            else
            {
                basedQuery = m_PsiDbContext
                    .OperationClassStocks;
            }



            var result = basedQuery
                .Where(c => 
                    (StockNo.IsNullOrDefault() || c.StockNo == StockNo)
                    &&
                    (OperationClassNo == default(byte) || c.OperationClassNo == OperationClassNo)
                      &&
                    (SIGNo.IsNullOrDefault() || _includeDetails == false || c.Stock.SIGNo == SIGNo)
                );

            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion







    }
}
