using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class ProductStockRepository : EFCoreRepository<ProductStock>
    {
        private readonly PsiDbContext m_PsiDbContext;
        public ProductStockRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }



        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
        }










        #region "Basic based Procedure"
        public ProductStock? GetEntity(short _stockNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new ProductStock() { StockNo = _stockNo }, _enableTracking, _includeDetails);
        }
        public async Task<ProductStock?> GetEntityAsync(short _stockNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new ProductStock() { StockNo = _stockNo }, _enableTracking, _includeDetails);
        }
       
        public ProductStock? GetEntity(ProductStock _info, bool _enableTracking, bool _includeDetails = true)
        {
            return GetQuery(_info, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<ProductStock?> GetEntityAsync(ProductStock _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_info, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }


        public IQueryable<ProductStock> GetQuery(ProductStock _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            var StockNo = _info.StockNo;
            var ProductNo = _info.ProductNo;

            IQueryable<ProductStock> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_PsiDbContext
                 .ProductStocks;
            }
            else
            {
                basedQuery = m_PsiDbContext
                    .ProductStocks;
            }



            var result = basedQuery
                .Where(c => 
                    (StockNo.IsNullOrDefault() || c.StockNo == StockNo)
                    &&
                    (ProductNo.IsNullOrDefault() || c.ProductNo == ProductNo)
                );

            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion

























        public StringBuilder GET_ProductStock_PivotReport(ProductStockPivotReportFilter _filter)
        {

            var result = new StringBuilder();
            var connectionString = m_PsiDbContext.Database.GetConnectionString();

          
            using (var conn = new SqlConnection(connectionString))
            {
                var dparams = new DynamicParameters();
                dparams.Add("@SIGNo", m_SIGNo, dbType: DbType.Byte);

                var res = conn.Query("psi.uspGET_ProductStock_PivotReport", dparams, commandType: CommandType.StoredProcedure).ToList();
                result = new StringBuilder(
                    System.Text.Json.JsonSerializer.Serialize(res
                        ,new System.Text.Json.JsonSerializerOptions
                        {
                            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // 中文字不編碼
                            //WriteIndented = false  // 換行與縮排
                        })
                    );                
            }

            return result;
        }















    }
}
