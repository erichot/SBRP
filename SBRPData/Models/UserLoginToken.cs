using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Models
{

    [Table(nameof(UserLoginToken), Schema = DbSystemModel.DB_Schema_common)]
    [PrimaryKey(nameof(IssuedDate),nameof(UserNo), nameof(SerialNo))]
    [Index(nameof(WebToken))]
    public class UserLoginToken
    {
        public DateOnly IssuedDate { get; set; }

        public short UserNo { get; set; }

        public byte SerialNo { get; set; }







        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoginActionNo { get; set; }



        [Column(TypeName = "CHAR(32)")]
        public string WebToken { get; set; }


        // Remark:  記錄一開始是由哪個app登入的。雖然都是SSO同一頁面，但有SSO有區分不同的AppId
        public SBRP_AppIdEnum AppId { get; set; }



        [Column(TypeName = "VARCHAR(50)")]
        public string? RemoteIpAddress { get; set; }




        public DateTime CreatedDate { get; set; }



        public DateTime? ExpiredDate { get; set; }



        public bool InValid { get; set; }


        public DateTime? InvalidDate { get; set; }











        
        [NotMapped]
        public string? LoginId { get; set; }


        [NotMapped]
        public bool? InValid_Filter { get; set; }









        [ForeignKey(nameof(UserNo))]
        public virtual User User { get; set; }



    }
}
