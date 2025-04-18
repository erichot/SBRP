using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("DoorID", "GroupID")]
[Table("DS_BF_UserGroup")]
public partial class DS_BF_UserGroup
{
    [Key]
    public byte DoorID { get; set; }

    [Key]
    public byte GroupID { get; set; }

    public byte Sun { get; set; }

    public byte Mon { get; set; }

    public byte Tue { get; set; }

    public byte Wed { get; set; }

    public byte Thu { get; set; }

    public byte Fri { get; set; }

    public byte Sat { get; set; }

    public byte Holi1Group { get; set; }

    public byte Holi2Group { get; set; }

    public byte Holi3Group { get; set; }

    public byte Holi4Group { get; set; }

    public byte Holi5Group { get; set; }

    public byte Holi6Group { get; set; }

    public byte Holi7Group { get; set; }

    public byte Holi8Group { get; set; }

    [StringLength(20)]
    public string Description { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public int? UserModifyLastSID { get; set; }
}
