using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VTMP_PreOrderArrival_ProductHead
{
    public int OperationSID { get; set; }

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(100)]
    public string? ProductName { get; set; }

    public int SerialNo { get; set; }

    public bool IsSelected { get; set; }

    public int PreOrderQty { get; set; }

    public int StockUpQty { get; set; }

    public int? PreOrderHeadCount { get; set; }

    public int? StockSubTotal { get; set; }

    public int? StockSubTotalWithReceivedWithoutCustomerOrder { get; set; }

    public int? SumToStockUpQty { get; set; }

    public DateTime? TimeModified { get; set; }

    [StringLength(100)]
    public string? ImageSubFolderFileName1 { get; set; }

    public int? TranInStockWithoutReceived { get; set; }

    public int? CustomerOrderQtyPackaged { get; set; }

    public int? SafetyStockQty { get; set; }
}
