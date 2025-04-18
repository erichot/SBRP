using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("BF_JobCode")]
public partial class BF_JobCode
{
    [Key]
    public byte TranType { get; set; }

    [StringLength(4)]
    public string JobCode { get; set; } = null!;

    [StringLength(16)]
    public string JobName { get; set; } = null!;

    public short Value { get; set; }

    [StringLength(36)]
    public string? Remark { get; set; }
}
