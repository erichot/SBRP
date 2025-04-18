using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks> 
    /// 若有增加欄位，需要同步調整SBRPLogPsi.Models.SaleOrderLog.MergeFrom
    /// </remarks>
    [Table(nameof(SaleOrder), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    public class SaleOrder
    {
        public SaleOrder() { }

        public SaleOrder(byte _sIGNo, short _stockNo, short _createPerson
         , int? _loginActionNo = null)
        {
            SIGNo = _sIGNo;
            StockNo = _stockNo;
            OrderDate = DateOnly.FromDateTime(DateTime.Now);
            SetCreatePerson(_createPerson);
            LoginActionNo = _loginActionNo ?? default;
        }

        public short OrderDateNo { get; set; }

        public short DaySerialNo { get; set; }


        public int OrderNo { get; set; }


        [Display(Name = "單據編號")]
        [Column(TypeName = "CHAR(12)")]
        public string OrderId { get; set; }

        public byte SIGNo { get; set; } = default(byte);



        [Display(Name = "單據日期")]
        public DateOnly OrderDate { get; set; }





        [Display(Name = "門市")]
        public short StockNo { get; set; }


        [Display(Name = "會員")]
        public int? MemberNo { get; set; }








        public short UniqueProductCount { get; set; }

        [Display(Name = "總件數")]
        public int TotalQuantity { get; set; }




        [Display(Name = "總金額")]
        [Column(TypeName = "DECIMAL(10,2)")]
        public decimal TotalAmount { get; set; }






        [Display(Name = "備註")]
        [StringLength(48)]
        [MaxLength(48)]
        public string? Remark { get; set; } = string.Empty;


        [Display(Name = "是否已刪除")]
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







        // 只有（具有關聯明細資料特性）單據表頭額外增加此稽核欄位
        [ValidateNever]
        public int LogNo { get; set; }






        [ForeignKey(nameof(MemberNo))]
        public Member? Member { get; set; }



        [ForeignKey(nameof(StockNo))]
        public Stock Stock { get; set; }

        public ICollection<SaleOrderDetail> SaleOrderDetails { get; set; }






        [NotMapped]
        public Store? Store { get; set; }















        [BindNever]
        [JsonIgnore]
        [ValidateNever]
        [NotMapped]
        public int LoginActionNo { get; set; }












        public void SetCreatePerson(short _createdPerson)
        {
            CreatedPerson = _createdPerson;
            CreatedDate = DateTime.Now;
        }
        public void SetSIG(byte _sIGNo)
        {
            SIGNo = _sIGNo;
        }
        // 執行時機：｛WebPsi｝在POST（拿到OrderDate）之後
        // 相依影響：｛DataPsi｝載入[DaySerialNo]需要用到[OrderDateNo]
        public void SetOrderDateNo()
        {
            if (OrderDateNo.IsNullOrDefault())
                OrderDateNo = DbSystemFunction.GetOrderDateNo(OrderDate);
        }
        // 執行時機：｛BusinessPsi｝Inserting之前
        // 相依影響：[DaySerialNo]取得後才能得到[OrderNo]，且才能assign Foriegn Key
        public void SetDaySerialNo(short _daySerialNo)
        {
            DaySerialNo = _daySerialNo;
            if (OrderNo.IsNullOrDefault() && OrderDateNo.IsNullOrDefault() == false)
            {
                OrderNo = DbSystemFunction.ConvertToOrderNo(OrderDateNo, DaySerialNo);
                if (SaleOrderDetails != null && SaleOrderDetails.Any())
                {
                    SaleOrderDetails.ToList().ForEach(f => f.OrderNo = OrderNo);
                }
            }
        }





        public static string GetDisplayName<TProperty>(Expression<Func<SaleOrder, TProperty>> expression)
        {
            return (new SaleOrder()).GetDisplayName(expression);
        }
    }











    public class SaleOrderFilter
    {
        public SaleOrder ToEntity()
        {
            return new SaleOrder
            {

            };
        }
    }
}
