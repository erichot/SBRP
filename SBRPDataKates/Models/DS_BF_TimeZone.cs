using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("DoorID", "TimeZoneID")]
[Table("DS_BF_TimeZone")]
public partial class DS_BF_TimeZone
{
    [Key]
    public byte DoorID { get; set; }

    [Key]
    public byte TimeZoneID { get; set; }

    public byte Frame01 { get; set; }

    public byte Frame02 { get; set; }

    public byte Frame03 { get; set; }

    public byte Frame04 { get; set; }

    [StringLength(20)]
    public string? Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public int? UserModifyLastSID { get; set; }
}
