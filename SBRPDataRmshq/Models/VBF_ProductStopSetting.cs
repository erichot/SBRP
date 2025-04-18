using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VBF_ProductStopSetting
{
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public bool IsStoped { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModified { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserModifiedID { get; set; }

    [StringLength(22)]
    public string? EmpName { get; set; }

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(100)]
    public string? ProductName { get; set; }

    [StringLength(32)]
    public string? ColorID { get; set; }

    [StringLength(32)]
    public string? SizeID { get; set; }
}
