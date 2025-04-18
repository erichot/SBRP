using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("S_SystemParameter")]
[Index("ParameterID", Name = "IX_S_SystemParameter_ParameterID", IsUnique = true)]
public partial class S_SystemParameter
{
    [Key]
    public int ParameterNo { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string? ParameterID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ParameterSectionID { get; set; }

    public int? ParameterNoInSection { get; set; }

    [StringLength(50)]
    public string ParameterName { get; set; } = null!;

    public byte? ValueTypeNo { get; set; }

    public short ValueLength { get; set; }

    public byte TextMode { get; set; }

    [StringLength(300)]
    public string ParameterValue { get; set; } = null!;
}
