using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_CounterProductOrderHead")]
public partial class OR_CounterProductOrderHead
{
    [Key]
    public int OrderSID { get; set; }

    public DateOnly OrderDate { get; set; }

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    [StringLength(32)]
    public string? Remark { get; set; }

    public bool IsSelectedTemp { get; set; }

    public bool IsDeleted { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    public string UserAddNewID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? TimeModified { get; set; }

    [StringLength(32)]
    public string? UserModifiedID { get; set; }
}
