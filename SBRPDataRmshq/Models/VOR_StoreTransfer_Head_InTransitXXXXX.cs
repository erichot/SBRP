using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_StoreTransfer_Head_InTransitXXXXX
{
    [StringLength(32)]
    public string TransactionID { get; set; } = null!;

    public DateOnly TransactionDate { get; set; }

    [StringLength(32)]
    public string FromStoreID { get; set; } = null!;

    [StringLength(32)]
    public string ToStoreID { get; set; } = null!;
}
