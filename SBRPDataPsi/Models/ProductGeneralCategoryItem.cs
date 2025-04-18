using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace SBRPDataPsi.Models
{
    /// <summary>
    /// 商品類別項目
    /// </summary>
    /// <remarks>
    /// </remarks>
    [Table(nameof(ProductGeneralCategoryItem), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    [Index(nameof(PGCategoryNo))]
    public class ProductGeneralCategoryItem 
    {
        [Display(Name = "序號")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short PGCItemNo { get; set; }




        // 必定歸屬於某一個[ProductGeneralCategory]，故不需在子表中指定 [SIGNo]
        [Required]
        public byte PGCategoryNo { get; set; }


        private string m_PGCItemId;
        [Display(Name = "代碼")]
        [Column(TypeName = "CHAR(16)")]
        [Required]
        [MaxLength(16)]
        public string PGCItemId 
        { 
            get { return m_PGCItemId?.Trim()??string.Empty; }
            set { m_PGCItemId = value.ToUpper(); }
        }



        [Display(Name ="名稱")]
        [Required]
        [StringLength(16)]
        [MaxLength(16)]
        public string PGCItemName { get; set; }





        [Display(Name = "顏色碼")]
        [Column(TypeName = "CHAR(6)")]
        public string? PGCItemColorHex { get; set; }


        [Display(Name = "數值")]        
        public int? PGCItemNumericValue { get; set; }


        [Display(Name = "圖片檔")]       
        [Column(TypeName = "VARCHAR(32)")]
        public string? PGCItemImagePathFileName { get; set; }


        [Display(Name = "項目排序")]
        [Range(default(short), short.MaxValue)]
        public short PGCItemOrderNo { get; set; }



        [JsonIgnore]
        [BindNever]
        [ValidateNever]
        public bool IsSystemPredefined { get; set; }


        [Display(Name = "是否為預設")]
        public bool IsDefault { get; set; }

        public bool IsDisabled { get; set; }




        [Display(Name = "備註")]
        [StringLength(48)]
        [MaxLength(48)]
        public string? Remark { get; set; } = string.Empty;



        [BindNever]
        [JsonIgnore]
        [ValidateNever]
        [Display(Name = "是否已刪除")]
        public bool IsDeleted { get; set; }










        [BindNever]
        [ValidateNever]
        [Display(Name = "建檔人員")]
        public short CreatedPerson { get; set; }


        [BindNever]
        [ValidateNever]
        [Display(Name = "建檔日期")]
        public DateTime CreatedDate { get; set; }



        [BindNever]
        [ValidateNever]
        [Display(Name = "異動人員")]
        public short? UpdatedPerson { get; set; }

        [BindNever]
        [ValidateNever]
        [Display(Name = "異動日期")]
        public DateTime? UpdatedDate { get; set; }


        [BindNever]
        [ValidateNever]
        [Display(Name = "刪除人員")]
        public short? DeletedPerson { get; set; }

        [BindNever]
        [ValidateNever]
        [Display(Name = "刪除日期")]
        public DateTime? DeletedDate { get; set; }












        [ForeignKey(nameof(PGCategoryNo))]
        public virtual ProductGeneralCategoryDefinition ProductGeneralCategoryDefinition { get; set; }











        public void SetCreatePerson(short _userNo, DateTime? _createdDate = null)
        {
            this.CreatedPerson = _userNo;
            this.CreatedDate = _createdDate ?? DateTime.Now;            
        }
        public void SetUpdatePerson(short _userNo, DateTime? _updatedDate = null)
        {
            this.UpdatedPerson = _userNo;
            this.UpdatedDate = _updatedDate ?? DateTime.Now;            
        }
        public void SetDeletePerson(short _userNo, DateTime? _deletedDate = null)
        {
            this.DeletedPerson = _userNo;
            this.DeletedDate = _deletedDate ?? DateTime.Now;
        }

        public void MergeFrom(ProductGeneralCategoryItem _source)
        {
            if (string.IsNullOrWhiteSpace(_source.PGCItemId) == false) this.PGCItemId = _source.PGCItemId;
            this.PGCItemName = _source.PGCItemName;
            this.PGCItemColorHex = _source.PGCItemColorHex;
            this.PGCItemNumericValue = _source.PGCItemNumericValue;
            this.PGCItemImagePathFileName = _source.PGCItemImagePathFileName;
            this.PGCItemOrderNo = _source.PGCItemOrderNo;
            this.IsDisabled = _source.IsDisabled;
            this.UpdatedPerson = _source.UpdatedPerson;
            this.UpdatedDate = _source.UpdatedDate;
            this.Remark = _source.Remark;
        }



        public static string GetDisplayName<TProperty>(Expression<Func<ProductGeneralCategoryItem, TProperty>> expression)
        {
            return (new ProductGeneralCategoryItem()).GetDisplayName(expression);
        }
    }













    public class ProductGeneralCategoryItemFilter
    {
        public byte? PGCategoryNo { get; set; }

        public ProductGeneralCategoryDefinitionFilter? ProductGeneralCategoryDefinitionFilter { get; set; }




        public ProductGeneralCategoryItem ToEntity()
        {

            var productGeneralCategoryDefinition = new ProductGeneralCategoryDefinition()
            {
                PGCategoryId = this.ProductGeneralCategoryDefinitionFilter?.PGCategoryId ?? string.Empty
            };

            return new ProductGeneralCategoryItem()
            {
                PGCategoryNo = this.PGCategoryNo.ToByte(),
                ProductGeneralCategoryDefinition = productGeneralCategoryDefinition
            };
        }
    }
}