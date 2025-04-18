using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Models
{
    
    [Table(nameof(Person), Schema = DbSystemModel.DB_Schema_common)]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonNo { get; set; }

        
        [Column(TypeName = "CHAR(16)")]
        public string PersonId { get; set; }



        public byte SIGNo { get; set; } = default(byte);








        [StringLength(16)]
        [MaxLength(16)]
        public string PersonName { get; set; }






        public SexEnum Sex { get; set; } 





        public DateOnly? Birthday { get; set; }










        public bool IsSystemPredefined { get; set; }

        public bool IsDisabled { get; set; }






        [Display(Name = "備註")]
        [StringLength(36)]
        [MaxLength(36)]
        public string? Remark { get; set; } = string.Empty;


        [Display(Name = "是否已刪除")]
        public bool IsDeleted { get; set; }






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








        //[Display(Name = "是否已提交")]
        //public bool? IsSubmitted { get; set; }

        //[Display(Name = "提交人員")]
        //public short? SubmittedPerson { get; set; }

        //[Display(Name = "提交日期")]
        //public DateTime? SubmittedDate { get; set; }









        //[Display(Name = "是否已核准")]
        //public bool? IsApproved { get; set; }

        //[Display(Name = "核准主管")]
        //public short? ApprovedPerson { get; set; }

        //[Display(Name = "核准日期")]
        //public DateTime? ApprovedDate { get; set; }







        public ICollection<PersonContactAddress> PersonContactAddresses { get; set; }

        public ICollection<PersonContactEmail> PersonContactEmails { get; set; }

        public ICollection<PersonContactPhone> PersonContactPhones { get; set; } 


    }
}
