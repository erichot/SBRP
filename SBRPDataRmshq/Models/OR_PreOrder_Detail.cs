using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("OrderSID", "ItemNo")]
[Table("OR_PreOrder_Detail")]
[Index("IsAllowItemForInStorePickUp", Name = "IX_OR_PreOrder_Detail_IsAllowItemForInStorePickUp")]
[Index("IsFinishedItemForStockUp", Name = "IX_OR_PreOrder_Detail_IsFinishedItemForStockUp")]
[Index("ProductID", Name = "IX_OR_PreOrder_Detail_ProductID")]
public partial class OR_PreOrder_Detail
{
    [Key]
    public int OrderSID { get; set; }

    [Key]
    public short ItemNo { get; set; }

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int Qty { get; set; }

    [Column(TypeName = "money")]
    public decimal? ListPrice { get; set; }

    [Column(TypeName = "money")]
    public decimal? Price { get; set; }

    [StringLength(50)]
    public string? Remark { get; set; }

    /// <summary>
    /// 紀錄本單據本貨號的到貨數量（資料來源：OR_PreOrderInStorePickUp_Detail）
    /// </summary>
    public int StockUpQty { get; set; }

    /// <summary>
    /// 該項目已全部到貨完成
    /// </summary>
    public bool IsFinishedItemForStockUp { get; set; }

    /// <summary>
    /// 到貨次數
    /// </summary>
    public short StockUpTimes { get; set; }

    /// <summary>
    /// 該項目是否允許取貨（有存在已到貨、尚未取貨之項目）
    /// </summary>
    public bool IsAllowItemForInStorePickUp { get; set; }

    /// <summary>
    /// 本單據本貨號累計已取貨數量
    /// </summary>
    public int? InStorePickUpQty { get; set; }

    /// <summary>
    /// 取貨次數
    /// </summary>
    public short? InStorePickUpTimes { get; set; }

    public bool IsFinishedItemForInStorePickUp { get; set; }

    public DateTime? TimeStockUpFirst { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string? UserStockUpFirstID { get; set; }

    public int? PreOrderArrivalLastOrderSID { get; set; }

    public DateTime? TimeStockUpLast { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string? UserStockUpLastID { get; set; }

    public int? InStorePickUpLastOrderSID { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string? UserInStorePickUpLastID { get; set; }

    public DateTime? TimeInStorePickUpLast { get; set; }
}
