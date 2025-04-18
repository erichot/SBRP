using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class ProductIdStructureDefinitionRepository : EFCoreRepository<ProductIdStructureDefinition>, ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;
        public ProductIdStructureDefinitionRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
        }

















        #region "Basic based Procedure"
        public ProductIdStructureDefinition? GetEntity(short _pGCOrderNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new ProductIdStructureDefinition() { PGCOrderNo =  _pGCOrderNo }, _enableTracking, _includeDetails);
        }
        public async Task<ProductIdStructureDefinition?> GetEntityAsync(short _pGCOrderNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new ProductIdStructureDefinition() { PGCOrderNo =  _pGCOrderNo }, _enableTracking, _includeDetails);
        }
          
        public ProductIdStructureDefinition? GetEntity(ProductIdStructureDefinition _info, bool _enableTracking, bool _includeDetails = true)
        {
            return GetQuery(_info, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<ProductIdStructureDefinition?> GetEntityAsync(ProductIdStructureDefinition _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_info, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }


        public IQueryable<ProductIdStructureDefinition> GetQuery(ProductIdStructureDefinition? _info, bool _enableTracking = false, bool _includeDetails = false)
        {

            var SIGNo = m_SIGNo;
            var PGCOrderNo = _info?.PGCOrderNo;
            var PGCategoryNo =  _info?.PGCategoryNo;



            IQueryable<ProductIdStructureDefinition> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_PsiDbContext
                 .ProductIdStructureDefinitions
                    .Include(c => c.ProductGeneralCategoryDefinition);
            }
            else
            {
                basedQuery = m_PsiDbContext
                    .ProductIdStructureDefinitions;
            }



            var result = basedQuery
                .Where(c =>
                    (PGCOrderNo.IsNullOrDefault() || c.PGCOrderNo == PGCOrderNo)
                    &&
                    (PGCategoryNo.IsNullOrDefault() || c.PGCategoryNo == PGCategoryNo)
                    &&
                    (SIGNo.IsNullOrDefault() || c.SIGNo == SIGNo)
                );

            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion







    }
}
