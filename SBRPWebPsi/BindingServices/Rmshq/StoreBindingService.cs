using SBRPDataRmshq.Models;
using SBRPDataRmshq.Services;
using SBRPWebPsi.ViewModels.Rmshq;


namespace SBRPWebPsi.BindingServices.Rmshq
{
    public class StoreBindingService
    {
        private readonly IMapper m_Mapper;
        private readonly SBRPDataRmshq.Services.StoreService m_StoreService;

        public StoreBindingService(IMapper mapper, SBRPDataRmshq.Services.StoreService storeService)
        {
            m_Mapper = mapper;
            m_StoreService = storeService;
        }




        public async Task<List<SelectListItem>> GetSelectListItemAsync(BF_Store? _filter)
        {
            var result = (
                from item in await GetListForPrimaryAsync(_filter)
                select item.SelectItemInfo
             ).ToList();

            return result;
        }


        public async Task<List<SBRPWebPsi.ViewModels.Rmshq.StoreViewModel>> GetListAsync(BF_Store? _filter)
        {
            var list = await m_StoreService.GetListAsync(null);
            return (
                from item in list
                select m_Mapper.Map<SBRPWebPsi.ViewModels.Rmshq.StoreViewModel>(item)
             )
             .ToList();
        }

        public async Task<List<SBRPWebPsi.ViewModels.Rmshq.StoreViewModel>> GetListForPrimaryAsync(BF_Store? _filter)
        {
            var list = await m_StoreService.GetListWithPrimaryAsync();
            return (
                from item in list
                select m_Mapper.Map<SBRPWebPsi.ViewModels.Rmshq.StoreViewModel>(item)
             )
             .ToList();
        }

    }
}
