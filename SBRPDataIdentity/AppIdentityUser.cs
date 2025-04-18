using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SBRPDataIdentity
{
    /*
     https://learn.microsoft.com/en-us/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-8.0

    預設不接受組合PK
    entity.HasKey(c => new { c.Id, c.SIGIDN });
    Unable to create a 'DbContext' of type ''. The exception 'The relationship from 'IdentityUserClaim<short>' to 'AppIdentityUser' with foreign key properties {'UserId' : short} cannot target the primary key {'Id' : short, 'SIGIDN' : short} because it is not compatible. Configure a principal key or a set of foreign key properties with compatible types for this relationship.' 
     */
    public class AppIdentityUser:IdentityUser<short>
    {
        
      

        [Required]
        [Column(TypeName ="CHAR(16)")]
        public string LoginId { get; set; }


        // 識別該User屬於哪家客戶
        public short SIGIDN { get;set; } = default(short);





       

    }
}
