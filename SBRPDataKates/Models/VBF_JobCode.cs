using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBF_JobCode
{
    public byte TranType { get; set; }

    [StringLength(4)]
    public string JobCode { get; set; } = null!;

    [StringLength(16)]
    public string JobName { get; set; } = null!;

    public short? Value { get; set; }

    [StringLength(36)]
    public string? Remark { get; set; }

    [StringLength(106)]
    public string? ListField { get; set; }
}
