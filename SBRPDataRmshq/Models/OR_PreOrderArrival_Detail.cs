using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("OrderSID", "PreOrderSID", "PreOrderItemNo")]
[Table("OR_PreOrderArrival_Detail")]
public partial class OR_PreOrderArrival_Detail
{
    [Key]
    public int OrderSID { get; set; }

    [Key]
    public int PreOrderSID { get; set; }

    [Key]
    public int PreOrderItemNo { get; set; }

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    /// <summary>
    /// 已到貨件數（系統計算，此單據成立前，其它到貨單的件數）
    /// </summary>
    public int StockUpQty { get; set; }

    /// <summary>
    /// 本張單據指定之到貨件數（操作人員設定）
    /// </summary>
    public int ToStockUpQty { get; set; }

    public int? ToStockUpQty_Inserted { get; set; }
}
