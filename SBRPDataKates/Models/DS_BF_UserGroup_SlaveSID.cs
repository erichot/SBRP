using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("DoorID", "GroupID", "SlaveSID")]
[Table("DS_BF_UserGroup_SlaveSID")]
public partial class DS_BF_UserGroup_SlaveSID
{
    [Key]
    public byte DoorID { get; set; }

    [Key]
    public byte GroupID { get; set; }

    [Key]
    public int SlaveSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public bool IsReplicated { get; set; }

    public int ReplicateReturnID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeReplicated { get; set; }
}
