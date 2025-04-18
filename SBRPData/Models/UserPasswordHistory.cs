using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Models
{
    [Table(nameof(UserPasswordHistory), Schema = DbSystemModel.DB_Schema_common)]
    [Index(nameof(UserNo))]
    public class UserPasswordHistory
    {

        public UserPasswordHistory() { }



        public UserPasswordHistory(UserPasswordChangingAction _info) 
        {
            this.UserNo = _info.UserNo;
            this.Password = CryptoHelper.AesEncrypt(_info.Password_New);            
            this.LoginActionNo = _info.LoginActionNo;
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistoryNo { get; set; }


        public short UserNo { get; set; }


        [DataType(DataType.Password)]
        [Column(TypeName = "VARCHAR(128)")]
        public string? Password { get; set; }


        public int? LoginActionNo { get; set; }



        public DateTime CreatedDate { get; set; }




    }












    [NotMapped]
    public class UserPasswordChangingAction
    {
        
        public short UserNo { get; set; }

        

        [Display(Name = "old password")]
        public string? Password_Original { get; set; }

        [Display(Name = "new password")]
        public string? Password_New { get; set; }


        
        [Display(Name = "repeat password")]
        public string? Password_Confirm { get; set; }


        public int LoginActionNo { get; set; }


    }



}
