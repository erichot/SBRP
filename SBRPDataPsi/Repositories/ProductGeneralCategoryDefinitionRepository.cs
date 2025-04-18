using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class ProductGeneralCategoryDefinitionRepository : EFCoreRepository<ProductGeneralCategoryDefinition>, ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;
        public ProductGeneralCategoryDefinitionRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
        }

















        #region "Basic based Procedure"
        public ProductGeneralCategoryDefinition? GetEntity(byte _pGCategoryNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new ProductGeneralCategoryDefinition() { PGCategoryNo =  _pGCategoryNo }, _enableTracking, _includeDetails);
        }
        public async Task<ProductGeneralCategoryDefinition?> GetEntityAsync(byte _pGCategoryNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new ProductGeneralCategoryDefinition() { PGCategoryNo =  _pGCategoryNo }, _enableTracking, _includeDetails);
        }
        public ProductGeneralCategoryDefinition? GetEntity(string _pGCategoryId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new ProductGeneralCategoryDefinition() { PGCategoryId = _pGCategoryId }, _enableTracking, _includeDetails);
        }
        public async Task<ProductGeneralCategoryDefinition?> GetEntityAsync(string _pGCategoryId, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new ProductGeneralCategoryDefinition() { PGCategoryId = _pGCategoryId }, _enableTracking, _includeDetails);
        }    
        public ProductGeneralCategoryDefinition? GetEntity(ProductGeneralCategoryDefinition _info, bool _enableTracking, bool _includeDetails = true)
        {
            return GetQuery(_info, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<ProductGeneralCategoryDefinition?> GetEntityAsync(ProductGeneralCategoryDefinition _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_info, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }


        public IQueryable<ProductGeneralCategoryDefinition?> GetQuery(ProductGeneralCategoryDefinition? _info = null, bool _enableTracking = false, bool _includeDetails = false)
        {

            var SIGNo = m_SIGNo;
            var PGCategoryNo =  _info?.PGCategoryNo;
            var PGCategoryId = _info?.PGCategoryId;


            IQueryable<ProductGeneralCategoryDefinition?> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_PsiDbContext
                 .ProductGeneralCategoryDefinitions;
            }
            else
            {
                basedQuery = m_PsiDbContext
                    .ProductGeneralCategoryDefinitions;
            }



            var result = basedQuery
                .Where(c => 
                    (PGCategoryNo.IsNullOrDefault() || c.PGCategoryNo == PGCategoryNo)
                    &&
                    (string.IsNullOrWhiteSpace(PGCategoryId) || c.PGCategoryId == PGCategoryId)
                    &&
                    (SIGNo.IsNullOrDefault() || c.SIGNo == SIGNo)
                );

            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion




        public IQueryable<ProductGeneralCategoryDefinition?> GetQuery(IEnumerable<byte> _pGCategoryNoEnumer, bool _enableTracking = false, bool _includeDetails = false)
        {
            var result = GetQuery(
                new ProductGeneralCategoryDefinition(), _enableTracking, _includeDetails
                )
                .Where(c => 
                    _pGCategoryNoEnumer.Contains(c.PGCategoryNo));
            
            return result;
        }





    }
}
