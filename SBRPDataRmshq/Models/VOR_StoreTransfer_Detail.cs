using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_StoreTransfer_Detail
{
    [StringLength(32)]
    public string TransactionID { get; set; } = null!;

    [StringLength(32)]
    public string StoreTransferItemID { get; set; } = null!;

    public DateOnly TransactionDate { get; set; }

    [StringLength(32)]
    public string FromStoreID { get; set; } = null!;

    [StringLength(32)]
    public string ToStoreID { get; set; } = null!;

    [StringLength(32)]
    public string CashierId { get; set; } = null!;

    [StringLength(16)]
    public string? CashierName { get; set; }

    public bool IsReceived { get; set; }

    public DateOnly? OrderDateReceived { get; set; }

    public DateTime? TimeAddNew { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserAddNewID { get; set; }

    [StringLength(22)]
    public string? UserAddNewName { get; set; }

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public int Qty { get; set; }

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(100)]
    public string? ProductName { get; set; }

    [StringLength(100)]
    public string? ImageSubFolderFileName1 { get; set; }

    [StringLength(50)]
    public string? ImageFileName1 { get; set; }

    [StringLength(50)]
    public string ImageSubFolder { get; set; } = null!;
}
