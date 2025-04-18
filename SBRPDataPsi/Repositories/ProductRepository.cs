using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class ProductRepository : EFCoreRepository<Product>, ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;
        public ProductRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
        }

















        #region "Basic based Procedure"
        public Product? GetEntity(int _productNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new Product() { ProductNo =  _productNo }, _enableTracking, _includeDetails);
        }
        public async Task<Product?> GetEntityAsync(int _productNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new Product() { ProductNo =  _productNo }, _enableTracking, _includeDetails);
        }
        public Product? GetEntity(string _productId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new Product() { ProductId = _productId }, _enableTracking, _includeDetails);
        }
        public async Task<Product?> GetEntityAsync(string _productId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new Product() { ProductId = _productId }, _enableTracking, _includeDetails);
        }    
        public Product? GetEntity(Product _info, bool _enableTracking, bool _includeDetails = true)
        {            
            return GetQuery(_info, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<Product?> GetEntityAsync(Product _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_info, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }


        public IQueryable<Product?> GetQuery(Product? _info = null, bool _enableTracking = false, bool _includeDetails = false)
        {

            var SIGNo = m_SIGNo;
            var ProductNo =  _info?.ProductNo;
            var ProductId = _info?.ProductId;


            IQueryable<Product?> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_PsiDbContext
                    .Products
                    .Include(f => f.ProductCosts)
                    .Include(f => f.ProductPrices)
                    .Include(f => f.ProductSuppliers)
                    
                    .Include(f => f.ProductGeneralCategories
                            .OrderByDescending(pgc => pgc.ProductGeneralCategoryDefinition.IsProductIdStructure)
                            .OrderBy(pgc => pgc.ProductGeneralCategoryDefinition.PGCOrderNo)
                            )

                    .Include(f => f.ProductGeneralCategories)
                        .ThenInclude(ff => ff.ProductGeneralCategoryDefinition)
                    ;
            }
            else
            {
                basedQuery = m_PsiDbContext
                    .Products;
            }



            var result = basedQuery
                .Where(c =>
                    (ProductNo.IsNullOrDefault() || c.ProductNo == ProductNo)
                    &&
                    (string.IsNullOrWhiteSpace(ProductId) || c.ProductId == ProductId)
                    &&
                    (SIGNo.IsNullOrDefault() || c.SIGNo == SIGNo)
                );
                
                
            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion




        public IQueryable<Product?> GetQuery(Product? _info = null, bool _enableTracking = false, params DbTableNameEnum[] _includingTable)
        {
            var basedQuery = GetQuery(_info, _enableTracking, _includeDetails: false);


            if (_includingTable.Contains(DbTableNameEnum.ProductCost))
                basedQuery = basedQuery.Include(f => f.ProductCosts);

            return basedQuery;
        }



        public IQueryable<Product?> GetQuery(IEnumerable<int> _productNoEnumer, bool _enableTracking = false, bool _includeDetails = false)
        {

            IQueryable<Product?> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_PsiDbContext
                    .Products
                    .Include(f => f.ProductPrices)
                    .Include(f => f.ProductSuppliers)
                    .Include(f => f.ProductGeneralCategories)
                        .ThenInclude(ff => ff.ProductGeneralCategoryDefinition)
                        ;
            }
            else
            {
                basedQuery = m_PsiDbContext
                    .Products;
            }

            var result = basedQuery
                .Where(c => _productNoEnumer.Contains(c.ProductNo));

            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }




















        public bool IsValid_Product_Deleting(int _productNo)
        {
            var result = false;
            var returnValue = default(int);
            var connectionString = m_PsiDbContext.Database.GetConnectionString();

            using (var conn = new SqlConnection(connectionString))
            {
                var dparams = new DynamicParameters();
                dparams.Add("@ProductNo", _productNo, dbType: DbType.Int32);
                dparams.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                conn.Execute("psi.uspIsValid_Product_Deleting", dparams, commandType: CommandType.StoredProcedure);
                returnValue = dparams.Get<int>("@ReturnValue");
                if (returnValue == 1) result = true;
            }

            return result;
        }

        public DataProcessResult DELETE_Product(int _productNo)
        {
            var result = new DataProcessResult();
            var returnValue = default(int);
            var connectionString = m_PsiDbContext.Database.GetConnectionString();

            using (var conn = new SqlConnection(connectionString))
            {
                var dparams = new DynamicParameters();
                dparams.Add("@ProductNo", _productNo, dbType: DbType.Int32);
                dparams.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                conn.Execute("psi.uspDELETE_Product_ByProductNo", dparams, commandType: CommandType.StoredProcedure);
                returnValue = dparams.Get<int>("@ReturnValue");
                if (returnValue <= 0)
                {
                    result.ResultValue = returnValue;
                    result.Message = "刪除失敗";
                }
            }

            return result;
        }




    }
}
