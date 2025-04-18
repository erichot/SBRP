using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Models
{
    [Table(nameof(Company), Schema = DbSystemModel.DB_Schema_common)]
    [Index(nameof(CurrencyId), IsUnique =true)]
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short CountryNo { get; set; }


        [StringLength(12)]
        public string CountryName { get; set; }


        [Column(TypeName = "CHAR(3)")]
        public string CurrencyId { get; set; }



        [StringLength(8)]
        public string CurrencyName { get; set; }

    }
}
