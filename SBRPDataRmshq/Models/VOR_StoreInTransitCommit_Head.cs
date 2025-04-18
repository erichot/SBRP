using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_StoreInTransitCommit_Head
{
    public int OrderSID { get; set; }

    public byte OrderType { get; set; }

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    [StringLength(32)]
    public string StoreName { get; set; } = null!;

    [StringLength(32)]
    public string TransactionID { get; set; } = null!;

    public DateOnly OrderDate { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? OrderDateText { get; set; }

    [StringLength(50)]
    public string? Remark { get; set; }

    public DateTime TimeAddNew { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? AAA { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;

    [StringLength(16)]
    public string? UserAddNewName { get; set; }

    public DateTime? TimeModified { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserModifiedID { get; set; }

    public bool InActive { get; set; }
}
