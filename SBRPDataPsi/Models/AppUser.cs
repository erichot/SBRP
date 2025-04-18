using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    [Table(nameof(AppUser))]
    public class AppUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short UserNo { get; set; }

        public short AppUserGroupNo { get; set; }

        public short AppUserRoleNo { get; set; }





        public bool IsAppReadonly { get; set; }

        public bool IsAppDisabled { get; set; }



        [Display(Name = "過期日")]
        public DateOnly? AppExpirationDate { get; set; }















        [Display(Name = "建檔人員")]
        public short CreatedPerson { get; set; }

        [Display(Name = "建檔日期")]
        public DateTime CreatedDate { get; set; }



        [Display(Name = "異動人員")]
        public short? UpdatedPerson { get; set; }

        [Display(Name = "異動日期")]
        public DateTime? UpdatedDate { get; set; }



        [Display(Name = "刪除人員")]
        public short? DeletedPerson { get; set; }

        [Display(Name = "刪除日期")]
        public DateTime? DeletedDate { get; set; }











        private string m_UserId;
        [NotMapped]
        public string UserId
        {
            get
            {
                if (string.IsNullOrEmpty(m_UserId))
                    return User?.UserId?.Trim() ?? string.Empty;

                return m_UserId;
            }
            set { m_UserId = value; }
        }



        private string m_LoginId;
        [NotMapped]
        public string LoginId 
        { 
            get
            {
                if (string.IsNullOrEmpty(m_LoginId))
                    return User?.LoginId?.Trim()??string.Empty;

                return m_LoginId;
            }
            set { m_LoginId = value; }
        }












        private string m_PasswordHash;        
        [NotMapped]
        [DataType(DataType.Password)]
        public string PasswordHash
        {
            get
            {
                if (string.IsNullOrEmpty(m_PasswordHash))
                    return User?.PasswordHash?.Trim() ?? string.Empty;

                return m_PasswordHash;
            }
            set { m_PasswordHash = value; }
        }









        [ForeignKey(nameof(UserNo))]
        public virtual SBRPData.Models.User User { get; set; }


    }
}
