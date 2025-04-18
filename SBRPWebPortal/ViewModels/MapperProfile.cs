namespace SBRPWebPortal.ViewModels
{
    public class MapperProfile :Profile
    {

        public MapperProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();

        }


    }
}
