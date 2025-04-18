using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("S_SystemSetting")]
public partial class S_SystemSetting
{
    [Key]
    [StringLength(16)]
    public string SystemID { get; set; } = null!;

    [StringLength(16)]
    public string SystemCustomerID { get; set; } = null!;

    [StringLength(32)]
    public string SystemCustomerName { get; set; } = null!;

    public int OrderNo { get; set; }
}
