using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Models
{
    [Table(nameof(PersonContactAddress), Schema = DbSystemModel.DB_Schema_common)]
    public class PersonContactAddress
    {
        public int PersonNo { get; set; }

        [Display(Name = "項次")]
        public byte ItemNo { get; set; } 

        


        [StringLength(64)]
        [Display(Name = "地址")]
        public string Address { get; set; }



        public Person? Person { get; set; }
    }
}
