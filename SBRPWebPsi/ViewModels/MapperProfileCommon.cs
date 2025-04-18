using SBRPData.Models;



namespace SBRPWebPsi.ViewModels
{
    public class MapperProfileCommon : Profile
    {
        public MapperProfileCommon()
        {
            CreateMap<CompanyContactPerson, CompanyContactPersonViewModel>();
            CreateMap<CompanyContactPersonViewModel, CompanyContactPerson>();



            CreateMap<Company, CompanyViewModel>();
            CreateMap<CompanyViewModel, Company>();










            CreateMap<Person, PersonViewModel>();
            CreateMap<PersonViewModel, Person>();

            CreateMap<PersonContactAddress, PersonContactAddressViewModel>();
            CreateMap<PersonContactAddressViewModel, PersonContactAddress>();

            CreateMap<PersonContactEmail, PersonContactEmailViewModel>();
            CreateMap<PersonContactEmailViewModel, PersonContactEmail>();

            CreateMap<PersonContactPhone, PersonContactPhoneViewModel>();
            CreateMap<PersonContactPhoneViewModel, PersonContactPhone>();

        }
    }
}
