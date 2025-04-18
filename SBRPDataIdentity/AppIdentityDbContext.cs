using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataIdentity
{
    /*
     * https://learn.microsoft.com/en-us/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-8.0
     * <IdentityUser<Guid>, IdentityRole<Guid>, Guid>
     IdentityDbContext<AppIdentityUser, AppIdentityRole, short
           ,IdentityUserClaim<short>, AppIdentityRole, IdentityUserLogin<short>,
            IdentityRoleClaim<short>, IdentityUserToken<short>
     */
    public class AppIdentityDbContext 
        : IdentityDbContext<AppIdentityUser, AppIdentityRole, short>
    {
        public AppIdentityDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<AppIdentityUser>(entity =>
            {
                // [Id] 為Global全域不重複
                entity.Property(e => e.Id).UseIdentityColumn<short>(100);

                // [LoginId] 由Application控制，同一SIGIDN底下不重複
                entity.HasIndex(c => c.LoginId);
                entity.HasIndex(c => c.SIGIDN);

                // DB level & Application Level皆給Default Value
                entity.Property(c => c.SIGIDN).HasDefaultValueSql("0");
            });
            

            

        }
    }
}
