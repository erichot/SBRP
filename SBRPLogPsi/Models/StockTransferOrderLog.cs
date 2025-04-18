using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPLogPsi.Models
{
    [Table(nameof(StockTransferOrderLog), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    public class StockTransferOrderLog:StockTransferOrder, IBasedArchiveModelInterface
    {
        //public StockTransferOrderLog() { }

        //// Write a Constructor accept only one parameter which from its base class, then copy all property data which has the same member name including LoginActionNo and LogNo from the parameter to its own property.
        //public StockTransferOrderLog(StockTransferOrder inboundStockOrder)
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
        public Stock? FromStock { get; set; }


        [NotMapped]
        public Stock? ToStock { get; set; }


        [NotMapped]
        public ICollection<StockTransferOrderDetail> StockTransferOrderDetails { get; set; }




        // Convert to its base class instance and return it.
        //public StockTransferOrder ToStockTransferOrder()
        //{
        //    return new StockTransferOrder
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


        public void MergeFrom(StockTransferOrder stockTransferOrder, LogTypeEnum? _logTypeNo = null)
        {
            OrderNo = stockTransferOrder.OrderNo;
            OrderId = stockTransferOrder.OrderId;
            SIGNo = stockTransferOrder.SIGNo;
            LogTypeNo = _logTypeNo??default(byte);
            FromStockNo = stockTransferOrder.FromStockNo;
            ToStockNo = stockTransferOrder.ToStockNo;
            OrderDate = stockTransferOrder.OrderDate;
            UniqueProductCount = stockTransferOrder.UniqueProductCount;
            TotalQuantity = stockTransferOrder.TotalQuantity;
            Remark = stockTransferOrder.Remark;
            CreatedPerson = stockTransferOrder.CreatedPerson;
            CreatedDate = stockTransferOrder.CreatedDate;
            UpdatedPerson = stockTransferOrder.UpdatedPerson;
            UpdatedDate = stockTransferOrder.UpdatedDate;
            LoginActionNo = stockTransferOrder.LoginActionNo;
            LogNo = stockTransferOrder.LogNo;
        }


    }
}
