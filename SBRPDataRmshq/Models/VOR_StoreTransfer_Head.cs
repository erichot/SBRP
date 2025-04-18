using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_StoreTransfer_Head
{
    [StringLength(32)]
    public string TransactionID { get; set; } = null!;

    public DateOnly TransactionDate { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TransactionDateText { get; set; }

    [StringLength(32)]
    public string FromStoreID { get; set; } = null!;

    [StringLength(32)]
    public string ToStoreID { get; set; } = null!;

    [StringLength(30)]
    public string? FromStoreName { get; set; }

    [StringLength(32)]
    public string CashierId { get; set; } = null!;

    [StringLength(22)]
    public string? CashierName { get; set; }

    public bool IsReceived { get; set; }

    public DateOnly? OrderDateReceived { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? OrderDateReceivedText { get; set; }

    public int SubTotalQty { get; set; }

    [StringLength(50)]
    public string? Remark { get; set; }

    public DateTime? TimeAddNew { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserAddNewID { get; set; }

    [StringLength(16)]
    public string? UserAddNewName { get; set; }
}
