using SBRPData.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPLogPsi.Models
{
    [Table(nameof(SaleOrderDetailLog), Schema = SBRPData.DbSystemModel.DB_Schema_psi)]
    public class SaleOrderDetailLog:SaleOrderDetail, IBasedArchiveModelInterface
    {
        //public SaleOrderDetailLog() { }

        //// Write a Constructor accept only one parameter which from its base class, then copy all property data which has the same member name including LoginActionNo and LogNo from the parameter to its own property.
        //public SaleOrderDetailLog(SaleOrderDetail SaleOrderDetail)
        //{
        //    OrderNo = SaleOrderDetail.OrderNo;
        //    ItemNo = SaleOrderDetail.ItemNo;
        //    ProductNo = SaleOrderDetail.ProductNo;
        //    UnitPrice = SaleOrderDetail.UnitPrice;
        //    Quantity = SaleOrderDetail.Quantity;
        //    Amount = SaleOrderDetail.Amount;
        //    Remark = SaleOrderDetail.Remark;
        //    CreatedPerson = SaleOrderDetail.CreatedPerson;
        //    CreatedDate = SaleOrderDetail.CreatedDate;
        //    UpdatedPerson = SaleOrderDetail.UpdatedPerson;
        //    UpdatedDate = SaleOrderDetail.UpdatedDate;
        //    LoginActionNo = SaleOrderDetail.LoginActionNo;
        //    LogNo = SaleOrderDetail.LogNo;
        //}


        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LogNo { get; set; }
        public LogTypeEnum LogTypeNo { get; set; }
        public int LoginActionNo { get; set; }        
        public DateTime ArchivedDate { get; set; }









        [NotMapped]
        public Product? Product { get; set; }






        public SaleOrderDetailLog MergeFrom(SaleOrderDetail _SaleOrderDetail)
        {
            if (_SaleOrderDetail.OrderNo.IsNullOrDefault())
            {

            }
            //UnitCost = SaleOrderDetail.UnitCost;
            Quantity = _SaleOrderDetail.Quantity;
            //SubAmount = SaleOrderDetail.SubAmount;
            Remark = _SaleOrderDetail.Remark??this.Remark;
            return this;
        }
    }
}
