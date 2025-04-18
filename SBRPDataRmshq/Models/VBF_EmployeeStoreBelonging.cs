using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VBF_EmployeeStoreBelonging
{
    [StringLength(32)]
    public string UserID { get; set; } = null!;

    [StringLength(32)]
    public string? StoreID { get; set; }

    [StringLength(32)]
    public string StoreName { get; set; } = null!;

    [StringLength(66)]
    public string? ListField { get; set; }

    public bool IsDefault { get; set; }

    public int StoreOrderNo { get; set; }
}
