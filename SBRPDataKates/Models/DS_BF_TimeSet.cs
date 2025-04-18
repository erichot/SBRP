using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("DoorID", "TimeSetID")]
[Table("DS_BF_TimeSet")]
public partial class DS_BF_TimeSet
{
    [Key]
    public byte DoorID { get; set; }

    [Key]
    public byte TimeSetID { get; set; }

    public byte StartHour { get; set; }

    public byte StartMin { get; set; }

    public byte EndHour { get; set; }

    public byte EndMin { get; set; }

    [StringLength(20)]
    public string? Description { get; set; }

    public bool IsDefault1 { get; set; }

    public bool IsDefault2 { get; set; }

    public bool IsDefault3 { get; set; }

    public bool IsDefault4 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public int? UserModifyLastSID { get; set; }
}
