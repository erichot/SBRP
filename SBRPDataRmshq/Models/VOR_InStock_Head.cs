using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_InStock_Head
{
    [StringLength(32)]
    public string TransactionID { get; set; } = null!;

    public DateOnly TransactionDate { get; set; }

    [StringLength(32)]
    public string SupplierID { get; set; } = null!;

    [StringLength(32)]
    public string CashierId { get; set; } = null!;

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    public bool IsReceived { get; set; }

    public DateOnly? OrderDateReceived { get; set; }

    public DateTime? TimeAddNew { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserAddNewID { get; set; }

    [StringLength(22)]
    public string? UserAddNewName { get; set; }
}
