using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    /// <summary>
    /// 商品類別定義
    /// PGCategoryNo 1~9    系統內定      [PGCItemId] 與 [ProductId]相關的定義檔
    /// </summary>
    /// <remarks>
    /// 可自訂商品各項分類，並該分類項目進行建檔
    /// </remarks>
    [Table(nameof(ProductGeneralCategoryDefinition), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    [Index(nameof(PGCOrderNo))]
    public class ProductGeneralCategoryDefinition
    {
        [Display(Name = "類別定義編號")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public byte PGCategoryNo { get; set; }




        // 怕欄位名稱會跟[ProductGeneralCategoryItem].[PGCItemId]被user造成混淆 
        private string m_PGCategoryId;
        [Display(Name = "類別定義識別碼")]
        [Column(TypeName = "CHAR(16)")]
        public string PGCategoryId 
        { 
            get
            {
                return m_PGCategoryId?.Trim()??string.Empty;
            }
            set
            {
                m_PGCategoryId = value;
            }
        }


        public byte SIGNo { get; set; } = default(byte);










        [Display(Name = "類別定義名稱")]
        [StringLength(16)]
        [MaxLength(16)]
        public string PGCategoryName { get; set; }






        [Display(Name = "類別代碼長度最小值")]
        [Range(0, 16)]
        [LessThanOrEqualTo(nameof(ItemIdMaxLength), ErrorMessage = "不得大於")]
        public byte ItemIdMinLength { get; set; }


        [Display(Name = "類別代碼長度最大值")]
        [Range(0, 16)]
        [GreaterThan(nameof(ItemIdMinLength),ErrorMessage ="不得小於")]
        public byte ItemIdMaxLength { get; set; }




        // UI表單欄位排序依據
        // 如果用於貨號編碼分類，則為1~10，且要求緊接
        [Display(Name = "類別排序編號")]
        [Range(default(short), short.MaxValue)]
        public short PGCOrderNo { get; set; } = default(short);






        /// <summary>
        /// SELECT  ref _ProductGeneralCategoryEntitiesPartial.cshtml
        /// UPDATE  ref ProductIdStructureDefinitionService.ProcessToInsertAsync
        /// </summary>
        [Display(Name = "是否為商品編碼結構所引用之定義檔")]
        public bool IsProductIdStructure { get; set; }

        public bool IsSystemPredefined { get; set; }

        public bool IsInvisible { get; set; }

        public bool IsDisabled { get; set; }






        [Display(Name = "備註")]
        [StringLength(48)]
        [MaxLength(48)]
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










        public void SetSIG(byte _sIGNo)
        {
            this.SIGNo = _sIGNo;
        }



        public void SetCreatePerson(short _userNo, DateTime? _createdDate = null)
        {
            this.CreatedDate = _createdDate ?? DateTime.Now;
            this.CreatedPerson = _userNo;
        }


        public void SetForProductIdStructure(bool _isProductIdStructure = true)
        {
            if (this.IsProductIdStructure != _isProductIdStructure)
            {
                this.IsProductIdStructure = _isProductIdStructure;
            }
        }



        public static string GetDisplayName<TProperty>(Expression<Func<ProductGeneralCategoryDefinition, TProperty>> expression)
        {
            return (new ProductGeneralCategoryDefinition()).GetDisplayName(expression);
        }
    }




    public class ProductGeneralCategoryDefinitionFilter
    {
        public string PGCategoryId { get; set; } = string.Empty;
    }



}
