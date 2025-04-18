using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("OperationSID", "ProductID")]
[Table("TMP_PreOrderArrival_ProductHead")]
public partial class TMP_PreOrderArrival_ProductHead
{
    [Key]
    public int OperationSID { get; set; }

    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public bool IsSelected { get; set; }

    public int SerialNo { get; set; }

    public int PreOrderQty { get; set; }

    public int StockUpQty { get; set; }

    public int? TranInStockWithoutReceived { get; set; }

    public int? CustomerOrderQtyPackaged { get; set; }

    /// <summary>
    /// 同一貨號有存在於幾張預購單中
    /// </summary>
    public int? PreOrderHeadCount { get; set; }

    public int? StockSubTotal { get; set; }

    public int? StockSubTotalWithReceivedWithoutCustomerOrder { get; set; }

    public int? SumToStockUpQty { get; set; }

    public int? SafetyStockQty { get; set; }

    public DateTime? TimeModified { get; set; }
}
