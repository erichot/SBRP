using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBussinessPsi.Services
{
    public class ProductGeneralCategoryItemService : ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;        
        private readonly ProductGeneralCategoryItemRepository m_ProductGeneralCategoryItemRepository;

        public ProductGeneralCategoryItemService(PsiDbContext psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
            m_ProductGeneralCategoryItemRepository = new ProductGeneralCategoryItemRepository(psiDbContext);
        }



        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_ProductGeneralCategoryItemRepository.SetSIG(_sIGNo);
        }


        
















        #region "Basic based Procedure"
        public ProductGeneralCategoryItem? GetEntity(short _pGCItemNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_pGCItemNo.IsNullOrDefault()) return null;
            return m_ProductGeneralCategoryItemRepository.GetEntity(_pGCItemNo, _enableTracking, _includeDetails);
        }
        public async Task<ProductGeneralCategoryItem?> GetEntityAsync(short _pGCItemNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_pGCItemNo.IsNullOrDefault()) return null;
            return await m_ProductGeneralCategoryItemRepository.GetEntityAsync(_pGCItemNo, _enableTracking, _includeDetails);
        }
        public ProductGeneralCategoryItem? GetEntity(string _pGCItemId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_pGCItemId)) return null;
            return GetEntity(_pGCItemId, _enableTracking, _includeDetails);
        }
        public async Task<ProductGeneralCategoryItem?> GetEntityAsync(string _pGCItemId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_pGCItemId)) return null;
            return await GetEntityAsync(_pGCItemId, _enableTracking, _includeDetails);
        }
        public ProductGeneralCategoryItem? GetEntity(ProductGeneralCategoryItem _info, bool _enableTracking, bool _includeDetails = true)
        {
            return m_ProductGeneralCategoryItemRepository.GetEntity(_info, _enableTracking, _includeDetails);
        }
        public async Task<ProductGeneralCategoryItem?> GetEntityAsync(ProductGeneralCategoryItem _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_ProductGeneralCategoryItemRepository.GetEntityAsync(_info, _enableTracking, _includeDetails);
        }
        public List<ProductGeneralCategoryItem> GetList(ProductGeneralCategoryItem _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_ProductGeneralCategoryItemRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToList();
        }
        public async Task<List<ProductGeneralCategoryItem>> GetListAsync(ProductGeneralCategoryItem _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_ProductGeneralCategoryItemRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToListAsync();
        }
        public IQueryable<ProductGeneralCategoryItem> GetQuery(ProductGeneralCategoryItem? _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            return m_ProductGeneralCategoryItemRepository.GetQuery(_info, _enableTracking, _includeDetails);
        }
        #endregion




     
        public async Task<List<ProductGeneralCategoryItem>> GetListAsync(ProductGeneralCategoryItemFilter _filter, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_ProductGeneralCategoryItemRepository
                 .GetQuery(_filter.ToEntity(), _enableTracking, _includeDetails)
                 .ToListAsync();
        }

        public async Task<List<ProductGeneralCategoryItem>> GetGeneralListAsync(byte? _pGCategoryNo = null, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_ProductGeneralCategoryItemRepository
                 .GetQuery(
                    new ProductGeneralCategoryItem() { PGCategoryNo = _pGCategoryNo.ToByte() }
                        , _enableTracking, _includeDetails)
                 .Where(c => 
                    c.IsDisabled == false 
                 )
                 .ToListAsync();
        }


















        public ProductGeneralCategoryItem AddNewDefault(byte _pGCategoryNo)
        {
            var result = new ProductGeneralCategoryItem()
            {
                PGCategoryNo = _pGCategoryNo
            };
            return result;
        }








        public ValidationResultEntity IsValidEntity(ProductGeneralCategoryItem _info, SubmitActionModeEnum _formEditMode)
        {
            var result = new ValidationResultEntity();


            return result;
        }












        public async Task<BusinessProcessResult<ProductGeneralCategoryItem>> ProcessToInsertAsync(ProductGeneralCategoryItem _info)
        {
            var result = new BusinessProcessResult<ProductGeneralCategoryItem>();
            
          

            var entity = await m_ProductGeneralCategoryItemRepository.AddEntityAsync(_info);


            await m_PsiDbContext.SaveChangesAsync();
            result.ResultInfo = entity;
            result.ResultNo = entity.PGCItemNo;

            try
            {
                
            }
            catch (Exception ex)
            {
                result.SetErrorMessage(ex.Message);
            }


            return result;
        }






        public async Task<BusinessProcessResult> ProcessToUpdateAsync(ProductGeneralCategoryItem _info)
        {
            var result = new BusinessProcessResult();


            var updating = await m_ProductGeneralCategoryItemRepository.GetEntityAsync(_info.PGCItemNo, _enableTracking:true);
            if (updating == null)
            {
                result.SetErrorMessage("The Entity not found!");
                return result;
            }

            // ========================================================
            updating.MergeFrom(_info);


            // =====================================================
            m_ProductGeneralCategoryItemRepository.UpdateEntity(updating);

            await m_PsiDbContext.SaveChangesAsync();
            result.ResultNo = updating.PGCItemNo;

            try
            {

            }
            catch (Exception ex)
            {
                result.SetErrorMessage(ex.Message);
            }


            return result;
        }










        public async Task<BusinessProcessResult<ProductGeneralCategoryItem>> ProcessToDeleteAsync(ProductGeneralCategoryItem _info)
        {
            var result = new BusinessProcessResult<ProductGeneralCategoryItem>();


            var deleting = await m_ProductGeneralCategoryItemRepository.GetEntityAsync(_info.PGCItemNo, _enableTracking: true);
            if (deleting == null)
            {
                result.SetErrorMessage("The Entity not found!");
                return result;
            }

            // ========================================================
            

            // =====================================================
            m_ProductGeneralCategoryItemRepository.DeleteEntity(deleting);

            await m_PsiDbContext.SaveChangesAsync();

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
