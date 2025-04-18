using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_StoreSafetyStockSettingPivot_Import")]
public partial class OR_StoreSafetyStockSettingPivot_Import
{
    [Key]
    public int OrderSID { get; set; }

    [StringLength(50)]
    public string? FileNameUpload { get; set; }

    public int? PivotItemCount { get; set; }

    public int? TotalItemCount { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserAddNewID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeAddNew { get; set; }
}
