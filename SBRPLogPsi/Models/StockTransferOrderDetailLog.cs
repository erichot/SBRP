using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPLogPsi.Models
{
    [Table(nameof(StockTransferOrderDetailLog), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    public class StockTransferOrderDetailLog:StockTransferOrderDetail, IBasedArchiveModelInterface
    {
        //public StockTransferOrderDetailLog() { }

        //// Write a Constructor accept only one parameter which from its base class, then copy all property data which has the same member name including LoginActionNo and LogNo from the parameter to its own property.
        //public StockTransferOrderDetailLog(StockTransferOrderDetail inboundStockOrderDetail)
        //{
        //    OrderNo = inboundStockOrderDetail.OrderNo;
        //    ItemNo = inboundStockOrderDetail.ItemNo;
        //    ProductNo = inboundStockOrderDetail.ProductNo;
        //    UnitPrice = inboundStockOrderDetail.UnitPrice;
        //    Quantity = inboundStockOrderDetail.Quantity;
        //    Amount = inboundStockOrderDetail.Amount;
        //    Remark = inboundStockOrderDetail.Remark;
        //    CreatedPerson = inboundStockOrderDetail.CreatedPerson;
        //    CreatedDate = inboundStockOrderDetail.CreatedDate;
        //    UpdatedPerson = inboundStockOrderDetail.UpdatedPerson;
        //    UpdatedDate = inboundStockOrderDetail.UpdatedDate;
        //    LoginActionNo = inboundStockOrderDetail.LoginActionNo;
        //    LogNo = inboundStockOrderDetail.LogNo;
        //}


        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LogNo { get; set; }
        public LogTypeEnum LogTypeNo { get; set; }
        public int LoginActionNo { get; set; }
        public DateTime ArchivedDate { get; set; }









        [NotMapped]
        public Product? Product { get; set; }

    }
}
