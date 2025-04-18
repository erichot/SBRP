using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBussinessPsi.Services
{
    public class SupplierGroupService : ISystemIsolationGroupInterface
    {
       
        private readonly PsiDbContext m_PsiDbContext;
        private readonly SupplierRepository m_SupplierRepository;
        private readonly SupplierGroupRepository m_SupplierGroupRepository;

        public SupplierGroupService(PsiDbContext psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
            m_SupplierRepository = new SupplierRepository(psiDbContext);
            m_SupplierGroupRepository = new SupplierGroupRepository(psiDbContext);
        }

        


        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_SupplierRepository.SetSIG(m_SIGNo);
            m_SupplierGroupRepository.SetSIG(m_SIGNo);
        }


        
















        #region "Basic based Procedure"
        public SupplierGroup? GetEntity(short _supplierGroupNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_supplierGroupNo.IsNullOrDefault()) return null;
            return m_SupplierGroupRepository.GetEntity(_supplierGroupNo, _enableTracking, _includeDetails);
        }
        public async Task<SupplierGroup?> GetEntityAsync(short _supplierGroupNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_supplierGroupNo.IsNullOrDefault()) return null;
            return await m_SupplierGroupRepository.GetEntityAsync(_supplierGroupNo, _enableTracking, _includeDetails);
        }
        
        public SupplierGroup? GetEntity(SupplierGroup _info, bool _enableTracking, bool _includeDetails = true)
        {
            return m_SupplierGroupRepository.GetEntity(_info, _enableTracking, _includeDetails);
        }
        public async Task<SupplierGroup?> GetEntityAsync(SupplierGroup _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_SupplierGroupRepository.GetEntityAsync(_info, _enableTracking, _includeDetails);
        }
        public List<SupplierGroup> GetList(SupplierGroup _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_SupplierGroupRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToList();
        }
        public async Task<List<SupplierGroup>> GetListAsync(SupplierGroup _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_SupplierGroupRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToListAsync();
        }
        public IQueryable<SupplierGroup> GetQuery(SupplierGroup? _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            return m_SupplierGroupRepository.GetQuery(_info, _enableTracking, _includeDetails);
        }
        #endregion












        public SupplierGroup? GetStock_BySupplierDefault(short _supplierNo)
        {
            var stock = 
                m_SupplierRepository
                    .GetEntity(_supplierNo, _includeDetails:false);

            if (stock == null)
                return null;

            var result = 
                m_SupplierGroupRepository
                    .GetEntity(stock.SupplierGroupNo, _includeDetails: false);

            if (result != null)
                return result;

            result =
                m_SupplierGroupRepository
                    .GetEntity(SBRPData.DbSystemData.DEF_ALL_Id_Everyone, _includeDetails: false);

            return result;
        }















    }
}
