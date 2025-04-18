using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Models
{

    [Table(nameof(UserLoginHistory), Schema = DbSystemModel.DB_Schema_common)]
    public class UserLoginHistory 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserLoginHistoryNo { get; set; }



     


        [Column(TypeName = "VARCHAR(32)")]
        public string? LoginId { get; set; }


        // Remark:  記錄一開始是由哪個app登入的。雖然都是SSO同一頁面，但有SSO有區分不同的AppId
        public SBRP_AppIdEnum AppId { get; set; }


        [Column(TypeName = "VARCHAR(50)")]
        public string? RemoteIpAddress { get; set; }



        public bool IsAccountDisabled { get; set; }


        public bool HasBeenLocked { get; set; }


        public bool IsLoginSuccessful { get; set; }

        
        public int LoginActionNo { get; set; } 








        public DateTime CreatedDate { get; set; }
    }
}
