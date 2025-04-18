using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_CounterProductOrderHead
{
    public int OrderSID { get; set; }

    public DateOnly OrderDate { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? OrderDateText { get; set; }

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    [StringLength(30)]
    public string? StoreName { get; set; }

    [StringLength(6)]
    public string? StoreAbbreviation { get; set; }

    [StringLength(32)]
    public string? Remark { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TimeAddNewText { get; set; }

    [StringLength(32)]
    public string UserAddNewID { get; set; } = null!;

    [StringLength(22)]
    public string? UserAddNewName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModified { get; set; }

    [StringLength(32)]
    public string? UserModifiedID { get; set; }
}
