using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    /// <summary>
    /// 商品類別設定
    /// </summary>
    /// <remarks>
    /// 一種商品，只能針對一種類別，指派一項CategoryItem，例如：[顏色]=>[紅色], [尺寸]=>[XL]
    /// DB本身允許同一商品、同一類別，多筆Row，但APP需避免這種情況。所以 [PGCategoryNo] 應吻合 [PGCItemNo] => [ProductGeneralCategoryItem]，應該是唯一值
    /// </remarks>
    [Table(nameof(ProductGeneralCategory), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    [PrimaryKey(nameof(ProductNo), nameof(PGCategoryNo))]
    [Index(nameof(PGCItemNo))]
    public class ProductGeneralCategory
    {
        public ProductGeneralCategory() { }

        public ProductGeneralCategory(ProductGeneralCategoryDefinition _info) 
        { 
            this.PGCategoryNo = _info.PGCategoryNo;
            ProductGeneralCategoryDefinition = _info;
        }

        public int ProductNo { get; set; }

        public byte PGCategoryNo { get; set; }




        // null => not specified
        public short? PGCItemNo { get; set; }






        [Display(Name = "建檔人員")]
        public short CreatedPerson { get; set; }

        [Display(Name = "建檔日期")]
        public DateTime CreatedDate { get; set; }



        [Display(Name = "異動人員")]
        public short? UpdatedPerson { get; set; }

        [Display(Name = "異動日期")]
        public DateTime? UpdatedDate { get; set; }





        // Note: 2025/01/10 改由DbContext指定relationship，從單一個Entity宣告Relationship並指定雙向/父子關聯
        //[ForeignKey(nameof(ProductNo))]
        public virtual Product Product { get; set; }



        
        [ForeignKey(nameof(PGCategoryNo))]
        public virtual ProductGeneralCategoryDefinition ProductGeneralCategoryDefinition { get; set; }



        // Note: 2025/01/10 不知何故，似乎都正常了，不需從DbContext指定relationship
        // Note: 2024/12/28 若未指定NoAction => This may cause a cycle or multiple cascade paths. Please specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints. Unable to create constraint or index
        [ForeignKey(nameof(PGCItemNo))]
        public virtual ProductGeneralCategoryItem ProductGeneralCategoryItem { get; set; }



    }
}
