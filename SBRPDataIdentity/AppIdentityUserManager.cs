using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataIdentity
{
    /*
     https://robertwray.co.uk/blog/extending-the-asp-net-core-identity-usermanager-to-set-the-employee-id-during-registration
     */
    public class AppIdentityUserManager : UserManager<AppIdentityUser>
    {
        public AppIdentityUserManager(IUserStore<AppIdentityUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<AppIdentityUser> passwordHasher, IEnumerable<IUserValidator<AppIdentityUser>> userValidators, IEnumerable<IPasswordValidator<AppIdentityUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<AppIdentityUser>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        public override Task<IdentityResult> CreateAsync(AppIdentityUser user, string password)
        {

            return base.CreateAsync(user, password);
        }
    }
}
