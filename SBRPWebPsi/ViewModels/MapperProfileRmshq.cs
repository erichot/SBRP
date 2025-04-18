using SBRPDataRmshq.Models;
using SBRPWebPsi.ViewModels.Rmshq;

namespace SBRPWebPsi.ViewModels
{
    public class MapperProfileRmshq:Profile
    {
        public MapperProfileRmshq()
        {
            CreateMap<BF_Store, StoreViewModel>();
            CreateMap<StoreViewModel, BF_Store>();
        }

    }
}
