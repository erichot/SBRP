using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    [Table(nameof(StoreRegion), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    public class StoreRegion
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short StoreRegionNo { get; set; }

        public string StoreRegionId { get; set; }





        public byte SIGNo { get; set; }
        
        public string StoreRegionName { get; set; }






        public short? ParentStoreRegionNo { get; set; }








        public bool IsSystemPredefined { get; set; }
       
        public bool IsDisabled { get; set; }
        
        public bool IsDeleted { get; set; }





        [BindNever]
        [JsonIgnore]
        [ValidateNever]
        [Display(Name = "建檔人員")]
        public short CreatedPerson { get; set; }

        [BindNever]
        [JsonIgnore]
        [ValidateNever]
        [Display(Name = "建檔日期")]
        public DateTime CreatedDate { get; set; }


        [BindNever]
        [JsonIgnore]
        [ValidateNever]
        [Display(Name = "異動人員")]
        public short? UpdatedPerson { get; set; }

        [BindNever]
        [JsonIgnore]
        [ValidateNever]
        [Display(Name = "異動日期")]
        public DateTime? UpdatedDate { get; set; }


        [BindNever]
        [JsonIgnore]
        [ValidateNever]
        [Display(Name = "刪除人員")]
        public short? DeletedPerson { get; set; }

        [BindNever]
        [JsonIgnore]
        [ValidateNever]
        [Display(Name = "刪除日期")]
        public DateTime? DeletedDate { get; set; }








        [ForeignKey(nameof(ParentStoreRegionNo))]
        public virtual StoreRegion? ParentStoreRegion { get; set; }



    }
}
