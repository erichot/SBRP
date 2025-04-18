using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBussinessPsi.Services
{
    public class ProductGeneralCategoryDefinitionService : ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;
        private readonly ProductGeneralCategoryDefinitionRepository m_ProductGeneralCategoryDefinitionRepository;
        private readonly ProductGeneralCategoryItemRepository m_ProductGeneralCategoryItemRepository;

        public ProductGeneralCategoryDefinitionService(PsiDbContext psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
            m_ProductGeneralCategoryDefinitionRepository = new ProductGeneralCategoryDefinitionRepository(psiDbContext);
            m_ProductGeneralCategoryItemRepository = new ProductGeneralCategoryItemRepository(psiDbContext);
        }



        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_ProductGeneralCategoryDefinitionRepository.SetSIG(_sIGNo);
            m_ProductGeneralCategoryItemRepository.SetSIG(_sIGNo);
        }



















        #region "Basic based Procedure"
        public ProductGeneralCategoryDefinition? GetEntity(byte _pGCategoryNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_pGCategoryNo.IsNullOrDefault()) return null;
            return m_ProductGeneralCategoryDefinitionRepository.GetEntity(_pGCategoryNo, _enableTracking, _includeDetails);
        }
        public async Task<ProductGeneralCategoryDefinition?> GetEntityAsync(byte _pGCategoryNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_pGCategoryNo.IsNullOrDefault()) return null;
            return await m_ProductGeneralCategoryDefinitionRepository.GetEntityAsync(_pGCategoryNo, _enableTracking, _includeDetails);
        }
        public ProductGeneralCategoryDefinition? GetEntity(string _pGCategoryId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_pGCategoryId)) return null;
            return GetEntity(_pGCategoryId, _enableTracking, _includeDetails);
        }
        public async Task<ProductGeneralCategoryDefinition?> GetEntityAsync(string _pGCategoryId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_pGCategoryId)) return null;
            return await GetEntityAsync(_pGCategoryId, _enableTracking, _includeDetails);
        }
        public ProductGeneralCategoryDefinition? GetEntity(ProductGeneralCategoryDefinition _info, bool _enableTracking, bool _includeDetails = true)
        {
            return m_ProductGeneralCategoryDefinitionRepository.GetEntity(_info, _enableTracking, _includeDetails);
        }
        public async Task<ProductGeneralCategoryDefinition?> GetEntityAsync(ProductGeneralCategoryDefinition _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_ProductGeneralCategoryDefinitionRepository.GetEntityAsync(_info, _enableTracking, _includeDetails);
        }
        public List<ProductGeneralCategoryDefinition> GetList(ProductGeneralCategoryDefinition _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_ProductGeneralCategoryDefinitionRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToList();
        }
        public async Task<List<ProductGeneralCategoryDefinition>> GetListAsync(ProductGeneralCategoryDefinition _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_ProductGeneralCategoryDefinitionRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToListAsync();
        }
        public IQueryable<ProductGeneralCategoryDefinition> GetQuery(ProductGeneralCategoryDefinition? _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            return m_ProductGeneralCategoryDefinitionRepository.GetQuery(_info, _enableTracking, _includeDetails);
        }
        #endregion








        // 一套Product最常用的共用列表資料
        public async Task<List<ProductGeneralCategoryDefinition>> GetGeneralListAsync()
        {
            return await m_PsiDbContext
                .ProductGeneralCategoryDefinitions
                .Where(c =>
                    (c.SIGNo == m_SIGNo)
                    && (c.IsDisabled == false && c.IsInvisible == false)
                )
                .OrderBy(c => c.PGCOrderNo)
                .ToListAsync();
        }




























        public ProductGeneralCategoryDefinition AddNewDefault()
        {
            var result = new ProductGeneralCategoryDefinition();
            return result;
        }




        public ValidationResultEntity IsValidEntity(ProductGeneralCategoryDefinition _info, byte _submitActionMode)
        {
            return IsValidEntity(_info, (SubmitActionModeEnum)_submitActionMode);
        }
        public ValidationResultEntity IsValidEntity(ProductGeneralCategoryDefinition _info, SubmitActionModeEnum _submitActionMode)
        {
            var result = new ValidationResultEntity();

            if (_submitActionMode == SubmitActionModeEnum.Remove)
            {
                var items =
                    m_ProductGeneralCategoryItemRepository.GetQuery(
                        new ProductGeneralCategoryItem() { PGCategoryNo = _info.PGCategoryNo },
                        _includeDetails: false
                        ).ToList();

                if (items.Count > 0)
                {
                    result.SetInValid("請先移除類別下的所有項目");
                    return result;
                }
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
        public async Task<BusinessProcessResult<ProductGeneralCategoryDefinition>> ProcessToInsertAsync(ProductGeneralCategoryDefinition _info)
        {
            var result = new BusinessProcessResult<ProductGeneralCategoryDefinition>();

            _info.SetSIG(m_SIGNo);


            var entity = await m_ProductGeneralCategoryDefinitionRepository.AddEntityAsync(_info);


            await m_PsiDbContext.SaveChangesAsync();
            result.ResultInfo = entity;
            result.ResultNo = entity.PGCategoryNo;

            try
            {

            }
            catch (Exception ex)
            {
                result.SetErrorMessage(ex.Message);
            }


            return result;
        }








        public async Task<BusinessProcessResult> ProcessToDeleteAsync(ProductGeneralCategoryDefinition _info)
        {
            var result = new BusinessProcessResult();
            var deleting = m_ProductGeneralCategoryDefinitionRepository.GetEntity(_info.PGCategoryNo);
            if (deleting == null)
            {
                result.SetErrorMessage("找不到資料");
                return result;
            }

            m_ProductGeneralCategoryDefinitionRepository.DeleteEntity(deleting);
            await m_PsiDbContext.SaveChangesAsync();
            return result;
        }









    }
}
