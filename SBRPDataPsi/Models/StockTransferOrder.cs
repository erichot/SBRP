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
    /// 若有增加欄位，需要同步調整SBRPLogPsi.Models.StockTransferOrderLog.MergeFrom
    /// </remarks>
    [Table(nameof(StockTransferOrder), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    public class StockTransferOrder
    {
        public StockTransferOrder() { }

        public StockTransferOrder(byte _sIGNo, short _fromStockNo, short _createPerson
            , int? _loginActionNo = null) 
        {
            SIGNo = _sIGNo;
            FromStockNo = _fromStockNo;
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





        [Display(Name = "轉出倉別")]
        public short FromStockNo { get; set; }


        [Display(Name = "轉入倉別")]
        public short ToStockNo { get; set; }








        public short UniqueProductCount { get; set; }

        [Display(Name = "總件數")]
        public int TotalQuantity { get; set; }










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










        private Stock m_FromStock;
        public Stock FromStock
        {
            get { return m_FromStock; }
            set
            {
                m_FromStock = value;
                if (value != null)
                {
                    m_FromStock.StockOperationAction = StockOperationActionEnum.TransferFrom;
                    FromStockNo = value.StockNo;
                }
            }
        }


        
        private Stock m_ToStock;
        public Stock ToStock
        {
            get { return m_ToStock; }
            set
            {
                m_ToStock = value;
                if (value != null)
                {
                    m_ToStock.StockOperationAction = StockOperationActionEnum.TransferTo;
                    ToStockNo = value.StockNo;
                }
            }
        }


        public ICollection<StockTransferOrderDetail> StockTransferOrderDetails { get; set; }














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
                if (StockTransferOrderDetails != null && StockTransferOrderDetails.Any())
                {
                    StockTransferOrderDetails.ToList().ForEach(f => f.OrderNo = OrderNo);
                }
            }
        }





        public static string GetDisplayName<TProperty>(Expression<Func<StockTransferOrder, TProperty>> expression)
        {
            return (new StockTransferOrder()).GetDisplayName(expression);
        }
    }











    public class StockTransferOrderFilter
    {
        public StockTransferOrder ToEntity()
        {
            return new StockTransferOrder
            {

            };
        }
    }
}
