

namespace SBRPWebPsi.BindingServices
{
    public class SupplierBindingService : ISystemIsolationGroupInterface
    {
        private readonly IMapper m_Mapper;
        private readonly SupplierService m_SupplierService;
        


        public SupplierBindingService( IMapper mapper, SupplierService supplierService)
        {
            m_Mapper = mapper;
            m_SupplierService = supplierService;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_SupplierService.SetSIG(_sIGNo);
        }












        public async Task<SupplierViewModel> GetEntityAsync(short _supplierNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<SupplierViewModel>(
                await m_SupplierService.GetEntityAsync(_supplierNo));
        }






        public async Task<List<SupplierViewModel>> GetListAsync(SupplierFilter _filter)
        {
            return m_Mapper.Map<List<SupplierViewModel>>(
                await m_SupplierService.GetListAsync(_filter));
        }





        public async Task<List<SelectListItem>> GetSelectListItemAsync(SupplierFilter? _filter = null)
        {
            var list = m_Mapper.Map<List<SupplierViewModel>>(
                    await m_SupplierService.GetListAsync(_filter??new SupplierFilter()));
            return list.ToSelectListItem<SupplierViewModel>();
        }












        public SupplierViewModel AddNewDefault(byte _sIGNo, short _createdPerson)
        {
            return m_Mapper.Map<SupplierViewModel>(
                m_SupplierService.AddNewDefault(_sIGNo,_createdPerson));
        }





        public async Task<BusinessProcessResult> ProcessToInsertAsync(SupplierViewModel _info)
        {
            return await m_SupplierService.ProcessToInsertAsync(
                            m_Mapper.Map<Supplier>(_info));
        }






    }
}
