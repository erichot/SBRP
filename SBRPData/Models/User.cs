using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 系統操作人員 可能也是員工，但不一定是員工。DB層面不要求必須是員工。但AP層面，則要求必須是員工。
    /// </remarks>
    [Table(nameof(User), Schema = DbSystemModel.DB_Schema_common)]
    [Index(nameof(LoginId))]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short UserNo { get; set; }

        public byte SIGNo { get; set; } = default(byte);


        private string m_UserId = string.Empty;
        [Column(TypeName = "CHAR(16)")]
        public string UserId 
        { 
            get 
            { 
                if (string.IsNullOrEmpty(m_UserId) && !string.IsNullOrEmpty(Person?.PersonId))
                    return Person.PersonId?.Trim()?? string.Empty;

                return m_UserId?.Trim() ?? string.Empty; 
            }
            set { m_UserId = value; }
        }



        // Remark: 員工or個人身份關聯可擇一使用。
        public short? EmployeeNo { get; set; }

        public int PersonNo { get; set; }




        public short UserGroupNo { get; set; }

        public short UserRoleNo { get; set; }



        // Remark: 預設沒有人想使用太長的login，例如太長的Email
        private string m_LoginId = string.Empty;
        [Column(TypeName = "CHAR(32)")]
        public string LoginId
        {
            get { return m_LoginId?.Trim()?? string.Empty; }
            set { m_LoginId = value; }
        }



        [Column(TypeName = "VARCHAR(128)")]
        public string PasswordHash { get; set; }




        









        [EmailAddress]
        public string Email { get; set; } = string.Empty;








        public bool IsReadonly { get; set; }

        public bool IsDisabled { get; set; }

        public bool IsSystemPredefined { get; set; }

        public bool? IsLoggedOn { get; set; }

        public bool HasBeenLocked { get; set; }

        public bool IsDeleted { get; set; }



        [Display(Name = "過期日")]
        public DateOnly? ExpirationDate { get; set; }










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








        [Display(Name = "是否已提交")]
        public bool? IsSubmitted { get; set; }

        [Display(Name = "提交人員")]
        public short? SubmittedPerson { get; set; }

        [Display(Name = "提交日期")]
        public DateTime? SubmittedDate { get; set; }









        [Display(Name = "是否已核准")]
        public bool? IsApproved { get; set; }

        [Display(Name = "核准主管")]
        public short? ApprovedPerson { get; set; }

        [Display(Name = "核准日期")]
        public DateTime? ApprovedDate { get; set; }











        public DateTime? LastLoggedOnDate { get; set; }

        public DateTime? LastLoggedOutDate { get; set; }        

        public DateTime? LockedDate { get; set; }


        public DateTime? LastPasswordFailedDate { get; set; }

        public short? PasswordFailureAttemptCount { get; set; }







        [NotMapped]
        public string UserName
        {
            get
            {
                if (Person != null)
                    return Person.PersonName;
                else
                    return string.Empty;
            }
        }



        [NotMapped]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [NotMapped]
        [DataType(DataType.Password)]
        public string Password_Confirm { get; set; }














        [ForeignKey(nameof(PersonNo))]
        public virtual Person Person { get; set; }




        









        public void SetToNewPassword(UserPasswordChangingAction _info)
        {
            this.PasswordHash = CryptoHelper.AesEncrypt(_info.Password_New);
        }

        public void SetToLogon(UserLoginToken _info)
        {
            this.IsLoggedOn = true;
            this.LastLoggedOnDate = DateTime.Now;

            // 任一次成功登入後，則清除原有登入失敗錯誤次數記錄
            this.PasswordFailureAttemptCount = default(short);
        }
        public void SetToLogout()
        {
            this.IsLoggedOn = false;
            this.LastLoggedOutDate = DateTime.Now;
        }



        public void SetForPasswordFailure(DateTime? _logonDate = null)
        {
            this.LastPasswordFailedDate = _logonDate ?? DateTime.Now;
            this.PasswordFailureAttemptCount++;
        }

        public void ExceedPasswordFailureMaxCount(DateTime? _lockedDate = null)
        {
            this.HasBeenLocked = true;
            this.LockedDate = _lockedDate ?? DateTime.Now;
        }





    }
}
