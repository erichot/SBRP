using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class xxxVOR_CounterProductOrder
{
    public int OrderSID { get; set; }

    public DateOnly OrderDate { get; set; }

    [StringLength(32)]
    public string CounterID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    public string UserAddNewID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? TimeModified { get; set; }

    [StringLength(32)]
    public string? UserModifiedID { get; set; }

    public int SN { get; set; }

    [StringLength(32)]
    public string ProductId { get; set; } = null!;

    [StringLength(32)]
    public string? CustomCode { get; set; }

    public int Qty { get; set; }

    [StringLength(50)]
    public string? Remark { get; set; }
}
