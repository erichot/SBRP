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
    /// 若有增加欄位，需要同步調整SBRPLogPsi.Models.InboundStockOrderLog.MergeFrom
    /// </remarks>
    [Table(nameof(InboundStockOrder), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    public class InboundStockOrder : IEntityEditBriefHistory
    {
        public InboundStockOrder() { }

        public InboundStockOrder(byte _sIGNo, short _supplierNo, short _createPerson
            , int? _loginActionNo = null)
        {
            SIGNo = _sIGNo;
            SupplierNo = _supplierNo;
            OrderDate = DateOnly.FromDateTime(DateTime.Now);
            SetCreatePerson(_createPerson);
            LoginActionNo = _loginActionNo ?? default;
        }


        //private short m_OrderDateNo;
        //public short OrderDateNo 
        //{ 
        //    get { return m_OrderDateNo; }
        //    set
        //    {
        //        m_OrderDateNo = value;
        //        if (OrderNo.IsNullOrDefault() && m_DaySerialNo.IsNullOrDefault() == false)
        //            OrderNo = DbSystemFunction.ConvertToOrderNo(m_OrderDateNo, m_DaySerialNo);
        //    }
        //}
        public short OrderDateNo { get; set; }


        // 2025/02/16 目前玉如資料單日銷貨單可達2068筆
        // 正值：一日最大32767筆單據，單一用戶10間門市每間3000張    
        //private short m_DaySerialNo;
        //public short DaySerialNo 
        //{ 
        //    get  { return m_DaySerialNo; }
        //    set
        //    {
        //        m_DaySerialNo = value;
        //        if (OrderNo.IsNullOrDefault() && m_OrderDateNo.IsNullOrDefault() == false)
        //            OrderNo = DbSystemFunction.ConvertToOrderNo(m_OrderDateNo, m_DaySerialNo);
        //    }
        //}
        public short DaySerialNo { get; set; }


        public int OrderNo { get; set; }


        private string m_OrderId;
        [Display(Name = "單號")]
        [Column(TypeName = "CHAR(12)")]
        public string OrderId 
        { 
            get { return m_OrderId?.Trim(); } 
            set { m_OrderId = value; }
        }


        public byte SIGNo { get; set; } = default(byte);




        [Display(Name = "供應商")]
        public short SupplierNo { get; set; }



        private DateOnly m_OrderDate;
        //public DateOnly OrderDate 
        //{
        //    get
        //    {
        //        return m_OrderDate;
        //    }
        //    set
        //    {
        //        m_OrderDate = value;
        //        if (OrderDateNo.IsNullOrDefault())
        //            OrderDateNo = DbSystemFunction.GetOrderDateNo(m_OrderDate);
        //    }
        //}

        [Display(Name = "單據日期")]
        public DateOnly OrderDate { get; set; }


        // 預設入庫總倉／公司倉
        [Display(Name = "入庫倉別")]
        public short StockNo { get; set; }







        

        [Display(Name = "貨品次數")]
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








        [ForeignKey(nameof(StockNo))]
        public Stock Stock { get; set; }



        [ForeignKey(nameof(SupplierNo))]
        public Supplier Supplier { get; set; }


        public ICollection<InboundStockOrderDetail> InboundStockOrderDetails { get; set; }








        [BindNever]
        [JsonIgnore]
        [ValidateNever]
        [NotMapped]
        public int LoginActionNo { get; set; }

       

        [NotMapped]
        public AppUser? CreatedUser { get; set; }








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
                if (InboundStockOrderDetails != null && InboundStockOrderDetails.Any())
                {
                    InboundStockOrderDetails.ToList().ForEach(f => f.OrderNo = OrderNo);
                }
            }
        }




        public static string GetDisplayName<TProperty>(Expression<Func<InboundStockOrder, TProperty>> expression)
        {
            return (new InboundStockOrder()).GetDisplayName(expression);
        }
    }











    public class InboundStockOrderFilter
    {
        public short? SupplierNo { get; set; }


        

        public InboundStockOrder ToEntity()
        {
            return new InboundStockOrder
            {
                SupplierNo = SupplierNo.ToShort(),
            };
        }
    }
}
