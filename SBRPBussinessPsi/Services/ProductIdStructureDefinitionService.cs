using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBussinessPsi.Services
{
    public class ProductIdStructureDefinitionService : ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;        
        private readonly ProductIdStructureDefinitionRepository m_ProductIdStructureDefinitionRepository;
        private readonly ProductGeneralCategoryDefinitionRepository m_ProductGeneralCategoryDefinitionRepository;

        public ProductIdStructureDefinitionService(PsiDbContext psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
            m_ProductIdStructureDefinitionRepository = new ProductIdStructureDefinitionRepository(psiDbContext);
            m_ProductGeneralCategoryDefinitionRepository = new ProductGeneralCategoryDefinitionRepository(psiDbContext);
        }




        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_ProductIdStructureDefinitionRepository.SetSIG(_sIGNo);
            m_ProductGeneralCategoryDefinitionRepository.SetSIG(_sIGNo);
        }


        
















        #region "Basic based Procedure"
        public ProductIdStructureDefinition? GetEntity(short _pGCOrderNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_pGCOrderNo.IsNullOrDefault()) return null;
            return m_ProductIdStructureDefinitionRepository.GetEntity(_pGCOrderNo, _enableTracking:_enableTracking, _includeDetails:_includeDetails);
        }
        public async Task<ProductIdStructureDefinition?> GetEntityAsync(short _pGCOrderNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_pGCOrderNo.IsNullOrDefault()) return null;
            return await m_ProductIdStructureDefinitionRepository.GetEntityAsync(_pGCOrderNo, _enableTracking:_enableTracking, _includeDetails:_includeDetails);
        }
      
        public ProductIdStructureDefinition? GetEntity(ProductIdStructureDefinition _info, bool _enableTracking, bool _includeDetails = true)
        {
            return m_ProductIdStructureDefinitionRepository.GetEntity(_info, _enableTracking, _includeDetails);
        }
        public async Task<ProductIdStructureDefinition?> GetEntityAsync(ProductIdStructureDefinition _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_ProductIdStructureDefinitionRepository.GetEntityAsync(_info, _enableTracking:_enableTracking, _includeDetails:_includeDetails);
        }
        public List<ProductIdStructureDefinition> GetList(ProductIdStructureDefinition _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_ProductIdStructureDefinitionRepository
                 .GetQuery(_info, _enableTracking:_enableTracking, _includeDetails:_includeDetails)
                 .ToList();
        }
        public async Task<List<ProductIdStructureDefinition>> GetListAsync(ProductIdStructureDefinition? _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_ProductIdStructureDefinitionRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToListAsync();
        }
        public IQueryable<ProductIdStructureDefinition> GetQuery(ProductIdStructureDefinition? _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            return m_ProductIdStructureDefinitionRepository.GetQuery(_info, _enableTracking: _enableTracking, _includeDetails: _includeDetails);
        }
        #endregion




        public async Task<List<ProductIdStructureDefinition>> GetGeneralListAsync( bool _enableTracking = false, bool _includeDetails = false)
        {
            return await m_ProductIdStructureDefinitionRepository
                 .GetQuery(new ProductIdStructureDefinition())
                 .ToListAsync();
        }
        

















        public List<ProductIdStructureDefinition> AddNewDefault()
        {
            List<ProductIdStructureDefinition> result = null;

            var generalCategoryDefinitions = 
                    m_ProductGeneralCategoryDefinitionRepository
                        .GetQuery()
                        .Where(c => c.PGCOrderNo < 10)
                        .OrderBy(c => c.PGCOrderNo)
                        .ToList();

            if (generalCategoryDefinitions != null && generalCategoryDefinitions.Any() == true)
            {
                result = (
                    from item in generalCategoryDefinitions
                    select new ProductIdStructureDefinition(item)
                    )
                    .ToList();
            }

            return result;
        }
        public async Task<List<ProductIdStructureDefinition>> AddNewDefaultAsync()
        {
            List<ProductIdStructureDefinition> result = null;

            var generalCategoryDefinitions = await
                    m_ProductGeneralCategoryDefinitionRepository
                        .GetQuery(_includeDetails:true)
                        .Where(c => c.PGCOrderNo > 0 && c.PGCOrderNo < 10)
                        .OrderBy(c => c.PGCOrderNo)
                        .ToListAsync();

            if (generalCategoryDefinitions != null && generalCategoryDefinitions.Any() == true)
            {
                result = (
                    from item in generalCategoryDefinitions
                    select new ProductIdStructureDefinition(item)
                    )
                    .ToList();
            }

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
        public async Task<BusinessProcessResult> ProcessToInsertAsync(List<ProductIdStructureDefinition> _list)
        {
            var result = new BusinessProcessResult();

            var pGCCategoryNoEnumer = _list.Select(r => r.PGCategoryNo);
            _list.ForEach(r => r.SetSIG(m_SIGNo));



            // ==================================================================
            // Update ProductGeneralCategoryDefinition.IsProductIdStructure
            var PGCDs =
                m_ProductGeneralCategoryDefinitionRepository
                    .GetQuery(pGCCategoryNoEnumer, _enableTracking: true);
            PGCDs.ToList()
                .ForEach(r => r.SetForProductIdStructure(true));
            m_PsiDbContext.ProductGeneralCategoryDefinitions.UpdateRange(PGCDs);

            // Insert ProductIdStructureDefinition
            await m_ProductIdStructureDefinitionRepository.AddEntitiesAsync(_list);
                        


            var affectedRows = await m_PsiDbContext.SaveChangesAsync();
            result.ResultValue = affectedRows;

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
