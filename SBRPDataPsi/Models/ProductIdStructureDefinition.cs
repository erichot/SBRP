using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// [PGCOrderNo]要求必須為1起始且連續的整數，不可有遺漏。用以對應貨號編碼區段組合
    /// 允許從UI來刪除，不允許從UI變更
    /// </remarks>
    [Table(nameof(ProductIdStructureDefinition), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    [PrimaryKey(nameof(PGCOrderNo), nameof(SIGNo))]
    [Index(nameof(PGCategoryNo))]
    public class ProductIdStructureDefinition
    {
        public ProductIdStructureDefinition() { }


        public ProductIdStructureDefinition(ProductGeneralCategoryDefinition _info) 
        { 
            this.SIGNo = _info.SIGNo;
            this.PGCOrderNo = _info.PGCOrderNo;
            this.PGCategoryNo = _info.PGCategoryNo;
            this.CreatedPerson = _info.CreatedPerson;
            this.CreatedDate = DateTime.Now;
            this.ProductGeneralCategoryDefinition = _info;
        }



        [Display(Name = "項次")]
        public short PGCOrderNo { get; set; }

        public byte SIGNo { get; set; } = default(byte);






        public byte PGCategoryNo { get; set; }








        [Display(Name = "建檔人員")]
        public short CreatedPerson { get; set; }

        [Display(Name = "建檔日期")]
        public DateTime CreatedDate { get; set; }









        [ForeignKey(nameof(PGCategoryNo))]
        public virtual ProductGeneralCategoryDefinition ProductGeneralCategoryDefinition { get; set; }









        public void SetSIG(byte _sIGNo)
        {
            this.SIGNo = _sIGNo;
        }

        public void SetCreatePerson(short _userNo, DateTime? _createdDate = null)
        {
            this.CreatedDate = _createdDate ?? DateTime.Now;
            this.CreatedPerson = _userNo;
        }









        public static string GetDisplayName<TProperty>(Expression<Func<ProductIdStructureDefinition, TProperty>> expression)
        {
            return (new ProductIdStructureDefinition()).GetDisplayName(expression);
        }
    }
}
