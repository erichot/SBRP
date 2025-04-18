namespace SBRPAPIPsi.BindingServices
{
    public class SupplierBindingService
    {
        private readonly IMapper m_Mapper;
        private readonly SupplierService m_SupplierService;

        public SupplierBindingService(IMapper mapper, SupplierService SupplierService)
        {
            m_Mapper = mapper;
            m_SupplierService = SupplierService;
        }




        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_SupplierService.SetSIG(_sIGNo);
        }






        public async Task<List<SupplierBindingModel>> GetListAsync(SupplierFilterBindingModel _filter)
        {
            return 
                m_Mapper.Map<List<SupplierBindingModel>>(
                    await m_SupplierService.GetListAsync(
                        m_Mapper.Map<SupplierFilter>(_filter)
                        )
                    );
        }

        
        
        public async Task<List<SupplierBindingModel>> GetListAsync(SupplierDtAjaxEntity _filter)
        {
            return
                m_Mapper.Map<List<SupplierBindingModel>>(
                        await m_SupplierService.GetListAsync(
                            _filter.ToEntity()
                        )
                    );
        }










        public async Task<BusinessProcessResult<SupplierBindingModel>> ProcessToInsertAsync(SupplierBindingModel _info)
        {
            return 
                m_Mapper.Map<BusinessProcessResult<SupplierBindingModel>>(
                    await m_SupplierService.ProcessToInsertAsync(
                        m_Mapper.Map<Supplier>(_info)
                        )
                    );
        }

        //public async Task<BusinessProcessResult> ProcessToUpdateAsync(SupplierBindingModel _info)
        //{
        //    return
        //        await m_SupplierService.ProcessToUpdateAsync(
        //            m_Mapper.Map<Supplier>(_info)
        //            );
        //}

        //public async Task<BusinessProcessResult> ProcessToDeleteAsync(SupplierBindingModel _info)
        //{
        //    return
        //        await m_SupplierService.ProcessToDeleteAsync(
        //            m_Mapper.Map<Supplier>(_info)
        //            );
        //}









    }
}
