using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("FPAddSID", "SlaveSID")]
[Table("DS_BF_FP_Add")]
[Index("CardID", Name = "IX_DS_BF_FP_Add_CardID")]
[Index("FPNo", Name = "IX_DS_BF_FP_Add_FPNo")]
[Index("InActive", Name = "IX_DS_BF_FP_Add_InActive")]
[Index("IsReplicated", Name = "IX_DS_BF_FP_Add_IsReplicated")]
public partial class DS_BF_FP_Add
{
    [Key]
    public int FPAddSID { get; set; }

    [Key]
    public int SlaveSID { get; set; }

    public int FPNo { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    public bool InActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public int? UserModifyLastSID { get; set; }

    public bool IsReplicated { get; set; }

    public int ReplicateReturnID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeReplicated { get; set; }
}
