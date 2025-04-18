using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Models
{
    [Table(nameof(PersonContactEmail), Schema = DbSystemModel.DB_Schema_common)]
    public class PersonContactEmail
    {
        public int PersonNo { get; set; }

        [Display(Name = "項次")]
        public byte ItemNo { get; set; }




        [EmailAddress]
        [Display(Name = "電子郵件")]
        [Column(TypeName ="VARCHAR(128)")]
        public string EmailAddress { get; set; }






        public Person? Person { get; set; }
    }
}
