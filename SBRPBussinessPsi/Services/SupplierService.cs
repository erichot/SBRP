using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBussinessPsi.Services
{
    public class SupplierService : ISystemIsolationGroupInterface
    {
        private readonly CommonDbContext m_CommonDbContext;
        private readonly CompanyService m_CompanyService;

        private readonly PsiDbContext m_PsiDbContext;        
        private readonly SupplierRepository m_SupplierRepository;

        public SupplierService(PsiDbContext psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
            m_SupplierRepository = new SupplierRepository(psiDbContext);
        }

        public SupplierService(CommonDbContext commonDbContext, PsiDbContext psiDbContext)
        {
            m_CommonDbContext = commonDbContext;
            m_CompanyService = new CompanyService(commonDbContext);


            m_PsiDbContext = psiDbContext;
            m_SupplierRepository = new SupplierRepository(psiDbContext);
        }


        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_SupplierRepository.SetSIG(_sIGNo);
        }


        
















        #region "Basic based Procedure"
        public Supplier? GetEntity(short _supplierNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_supplierNo.IsNullOrDefault()) return null;
            return m_SupplierRepository.GetEntity(_supplierNo, _enableTracking, _includeDetails);
        }
        public async Task<Supplier?> GetEntityAsync(short _supplierNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_supplierNo.IsNullOrDefault()) return null;
            return await m_SupplierRepository.GetEntityAsync(_supplierNo, _enableTracking, _includeDetails);
        }
        public Supplier? GetEntity(string _supplierId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_supplierId)) return null;
            return GetEntity(_supplierId, _enableTracking, _includeDetails);
        }
        public async Task<Supplier?> GetEntityAsync(string _supplierId, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (string.IsNullOrEmpty(_supplierId)) return null;
            return await GetEntityAsync(_supplierId, _enableTracking, _includeDetails);
        }
        public Supplier? GetEntity(Supplier _info, bool _enableTracking, bool _includeDetails = true)
        {
            return m_SupplierRepository.GetEntity(_info, _enableTracking, _includeDetails);
        }
        public async Task<Supplier?> GetEntityAsync(Supplier _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_SupplierRepository.GetEntityAsync(_info, _enableTracking, _includeDetails);
        }
        public List<Supplier> GetList(Supplier _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_SupplierRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToList();
        }
        public async Task<List<Supplier>> GetListAsync(Supplier _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_SupplierRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToListAsync();
        }
        public IQueryable<Supplier> GetQuery(Supplier? _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            return m_SupplierRepository.GetQuery(_info, _enableTracking, _includeDetails);
        }
        #endregion





        public async Task<List<Supplier>> GetListAsync(SupplierFilter _filter, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_SupplierRepository
                 .GetQuery(_filter.ToEntity(), _enableTracking, _includeDetails)
                 .ToListAsync();
        }













        public Supplier AddNewDefault(byte _sIGNo, short _createdPerson)
        {
            var entity = new Supplier();
            entity.Company = m_CompanyService.AddNewDefault(_sIGNo, _createdPerson);
            entity.SetSIG(_sIGNo);
            entity.SetSupplierGroup(_sIGNo);
            entity.SetCreatedPerson(_createdPerson);
            return entity;
        }










        /// <summary>
        /// 
        /// </summary>
        /// <param name="_info"></param>
        /// <returns></returns>
        /// <remarks>
        /// 前端頁面表單已有具備[Company]、[CompanyContactPersons]欄位
        /// </remarks>
        public async Task<BusinessProcessResult<Supplier>> ProcessToInsertAsync(Supplier _info)
        {
            var result = new BusinessProcessResult<Supplier>();
            
            _info.SetSIG(m_SIGNo);


            var entity = await m_SupplierRepository.AddEntityAsync(_info);


            await m_PsiDbContext.SaveChangesAsync();
            result.ResultInfo = entity;
            result.ResultNo = entity.SupplierNo;

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
