using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPLogPsi.Models
{
    [Table(nameof(InboundStockOrderLog), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    public class InboundStockOrderLog:InboundStockOrder, IBasedArchiveModelInterface
    {
        //public InboundStockOrderLog() { }

        //// Write a Constructor accept only one parameter which from its base class, then copy all property data which has the same member name including LoginActionNo and LogNo from the parameter to its own property.
        //public InboundStockOrderLog(InboundStockOrder inboundStockOrder)
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
        public Supplier? Supplier { get; set; }



        [NotMapped]
        public ICollection<InboundStockOrderDetailLog> InboundStockOrderDetails { get; set; }




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









        public void MergeFrom(InboundStockOrder inboundStockOrder, LogTypeEnum? _logTypeNo = null)
        {
            OrderNo = inboundStockOrder.OrderNo;
            OrderId = inboundStockOrder.OrderId;
            SIGNo = inboundStockOrder.SIGNo;
            SupplierNo = inboundStockOrder.SupplierNo;
            OrderDate = inboundStockOrder.OrderDate;
            StockNo = inboundStockOrder.StockNo;
            TotalAmount = inboundStockOrder.TotalAmount;
            UniqueProductCount = inboundStockOrder.UniqueProductCount;
            TotalQuantity = inboundStockOrder.TotalQuantity;
            TotalAmount = inboundStockOrder.TotalAmount;
            Remark = inboundStockOrder.Remark;
            CreatedPerson = inboundStockOrder.CreatedPerson;
            CreatedDate = inboundStockOrder.CreatedDate;
            UpdatedPerson = inboundStockOrder.UpdatedPerson;
            UpdatedDate = inboundStockOrder.UpdatedDate;
            LoginActionNo = inboundStockOrder.LoginActionNo;

            LogTypeNo = _logTypeNo ?? default(byte);
        }



    }
}
