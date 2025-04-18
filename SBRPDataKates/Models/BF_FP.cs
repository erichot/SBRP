using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("BF_FP")]
[Index("CardID", Name = "IX_BF_FP_CardID")]
[Index("FPNo", Name = "IX_BF_FP_FPNo")]
public partial class BF_FP
{
    [Key]
    public int FPSID { get; set; }

    public int FPNo { get; set; }

    [Column(TypeName = "image")]
    public byte[]? FingerData { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    public bool IsNative { get; set; }

    public bool IsReplicated { get; set; }

    public short SlaveID { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime TimeAddNew { get; set; }
}
