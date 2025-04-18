namespace SBRPWebPsi.ViewModels
{
    public class AppUserViewModel : AppUser
    {

        public string PersonName { get { return Person?.PersonName ?? string.Empty; } }







        public PersonViewModel? Person { get; set; }
    }
}
