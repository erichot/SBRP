using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Models
{
    [Table(nameof(PersonContactPhone), Schema = DbSystemModel.DB_Schema_common)]
    public class PersonContactPhone
    {
        public int PersonNo { get; set; }

        [Display(Name = "項次")]
        public byte ItemNo { get; set; } 

        

        public ContactPhoneTypeEnum ContactPhoneType { get; set; }


        [Display(Name = "電話號碼")]
        public long PhoneNumber { get; set; }


        public Person? Person { get; set; }
    }
}
