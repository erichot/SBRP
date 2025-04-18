using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    [Table(nameof(ProductSupplier), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    [PrimaryKey(nameof(ProductNo), nameof(SupplierNo), nameof(ItemNo))]
    public class ProductSupplier
    {
        public ProductSupplier() { }

        public ProductSupplier(byte _itemNo) { ItemNo = _itemNo; }


        public int ProductNo { get; set; }  

        public short? SupplierNo { get; set; }

        public byte ItemNo { get; set; }






        public bool IsDefault { get; set; }

        public bool IsDisabled { get; set; }

        public bool IsDeleted { get; set; }








        [Display(Name = "建檔人員")]
        public short CreatedPerson { get; set; }

        [Display(Name = "建檔日期")]
        public DateTime CreatedDate { get; set; }



        [Display(Name = "異動人員")]
        public short? UpdatedPerson { get; set; }

        [Display(Name = "異動日期")]
        public DateTime? UpdatedDate { get; set; }













        //[ForeignKey(nameof(ProductNo))]
        public virtual Product Product { get; set; }



        [ForeignKey(nameof(SupplierNo))]
        public virtual Supplier Supplier { get; set; }


    }
}
