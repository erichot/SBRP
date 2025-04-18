using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPLogPsi.Models
{
    [Table(nameof(SaleOrderLog), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    public class SaleOrderLog: SaleOrder, IBasedArchiveModelInterface
    {
        //public SaleOrderLog() { }

        //// Write a Constructor accept only one parameter which from its base class, then copy all property data which has the same member name including LoginActionNo and LogNo from the parameter to its own property.
        //public SaleOrderLog(InboundStockOrder inboundStockOrder)
        //{
        //    OrderNo = inboundStockOrder.OrderNo;
        //    OrderId = inboundStockOrder.OrderId;
        //    SIGNo = inboundStockOrder.SIGNo;
        //    SupplierNo = inboundStockOrder.SupplierNo;
        //    OrderDate = inboundStockOrder.OrderDate;
        //    StockNo = inboundStockOrder.StockNo;
        //    TotalAmount = inboundStockOrder.TotalAmount;
        //    DetailPriceItemNo = inboundStockOrder.DetailPriceItemNo;
        //    DetailRowCount = inboundStockOrder.DetailRowCount;
        //    DetailSubQty = inboundStockOrder.DetailSubQty;
        //    DetailSubAmount = inboundStockOrder.DetailSubAmount;
        //    Remark = inboundStockOrder.Remark;
        //    CreatedPerson = inboundStockOrder.CreatedPerson;
        //    CreatedDate = inboundStockOrder.CreatedDate;
        //    UpdatedPerson = inboundStockOrder.UpdatedPerson;
        //    UpdatedDate = inboundStockOrder.UpdatedDate;
        //    LoginActionNo = inboundStockOrder.LoginActionNo;
        //    LogNo = inboundStockOrder.LogNo;
        //}







        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogNo { get; set; }
        public LogTypeEnum LogTypeNo { get; set; }
        public int LoginActionNo { get; set; }        
        public DateTime ArchivedDate { get; set; }









        [NotMapped]
        public Stock? Stock { get; set; }



        [NotMapped]
        public Member? Member { get; set; }



        [NotMapped]
        public ICollection<InboundStockOrderDetail> InboundStockOrderDetails { get; set; }




        // Convert to its base class instance and return it.
        //public InboundStockOrder ToInboundStockOrder()
        //{
        //    return new InboundStockOrder
        //    {
        //        OrderNo = OrderNo,
        //        OrderId = OrderId,
        //        SIGNo = SIGNo,
        //        SupplierNo = SupplierNo,
        //        OrderDate = OrderDate,
        //        StockNo = StockNo,
        //        TotalAmount = TotalAmount,
        //        DetailPriceItemNo = DetailPriceItemNo,
        //        DetailRowCount = DetailRowCount,
        //        DetailSubQty = DetailSubQty,
        //        DetailSubAmount = DetailSubAmount,
        //        Remark = Remark,
        //        CreatedPerson = CreatedPerson,
        //        CreatedDate = CreatedDate,
        //        UpdatedPerson = UpdatedPerson,
        //        UpdatedDate = UpdatedDate,
        //        LoginActionNo = LoginActionNo,
        //        LogNo = LogNo
        //    };
        //}









        public void MergeFrom(SaleOrder saleOrder, LogTypeEnum? _logTypeNo = null)
        {
            if (_logTypeNo != null)
            {
                LogTypeNo = (LogTypeEnum)_logTypeNo;
            }
            OrderId = saleOrder.OrderId;
            SIGNo = saleOrder.SIGNo;
            MemberNo = saleOrder.MemberNo;
            OrderDate = saleOrder.OrderDate;
            StockNo = saleOrder.StockNo;
            UniqueProductCount = saleOrder.UniqueProductCount;
            TotalQuantity = saleOrder.TotalQuantity;
            TotalAmount = saleOrder.TotalAmount;
            IsDeleted = saleOrder.IsDeleted;
            Remark = saleOrder.Remark ?? this.Remark;
        }




    }
}
