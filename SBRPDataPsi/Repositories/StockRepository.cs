using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class StockRepository : EFCoreRepository<Stock>, ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;
        public StockRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
        }

















        #region "Basic based Procedure"
        public Stock? GetEntity(short _stockNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new Stock() { StockNo = _stockNo }, _enableTracking, _includeDetails);
        }
        public async Task<Stock?> GetEntityAsync(short _stockNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new Stock() { StockNo = _stockNo }, _enableTracking, _includeDetails);
        }
        public Stock? GetEntity(string _stockId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new Stock() { StockId = _stockId }, _enableTracking, _includeDetails);
        }
        public async Task<Stock?> GetEntityAsync(string _stockId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new Stock() { StockId = _stockId }, _enableTracking, _includeDetails);
        }    
        public Stock? GetEntity(Stock _info, bool _enableTracking, bool _includeDetails = true)
        {
            return GetQuery(_info, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<Stock?> GetEntityAsync(Stock _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_info, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }



        public IQueryable<Stock> GetQuery(StockFilter _filter, bool _enableTracking = false, bool _includeDetails = false)
        {
            var IsDisabled_Filter = _filter.IsDisabled_Filter;
            var IsSystemPredefined = _filter.IsSystemPredefined_Filter;

            return GetQuery(_filter.ToEntity(), _enableTracking, _includeDetails)
                .Where(c =>
                    (IsDisabled_Filter == null || c.IsDisabled == IsDisabled_Filter)
                    &&
                    (IsSystemPredefined == null || c.IsSystemPredefined == IsSystemPredefined)
                );
            ;
        }

        public IQueryable<Stock> GetQuery(Stock? _info, bool _enableTracking = false, bool _includeDetails = false)
        {

            var SIGNo = m_SIGNo;
            var StockNo = _info.StockNo;

            IQueryable<Stock> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_PsiDbContext
                 .Stocks;                
            }
            else
            {
                basedQuery = m_PsiDbContext
                    .Stocks;
            }



            var result = basedQuery
                .Where(c => 
                    (SIGNo.IsNullOrDefault() || c.SIGNo == SIGNo)
                    &&
                    (StockNo.IsNullOrDefault() || c.StockNo == StockNo)
                );

            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion











        public async Task<short> GetRowCountAsync(byte _sIGNo, short _stockNo)
        {
            return (short)
                await
                    m_PsiDbContext
                        .Stocks
                        .IgnoreQueryFilters()
                        .Where(c =>
                            (c.StockNo <= _stockNo)
                            &&
                            (_sIGNo.IsNullOrDefault() == true || c.SIGNo == _sIGNo)
                        )
                        .CountAsync();
        }





    }
}
