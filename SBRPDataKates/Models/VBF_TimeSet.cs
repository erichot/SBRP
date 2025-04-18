using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBF_TimeSet
{
    public byte DoorID { get; set; }

    public byte TimeSetID { get; set; }

    public byte StartHour { get; set; }

    public byte StartMin { get; set; }

    public byte EndHour { get; set; }

    public byte EndMin { get; set; }

    [StringLength(199)]
    [Unicode(false)]
    public string? StartHourMinString { get; set; }

    [StringLength(199)]
    [Unicode(false)]
    public string? EndHourMinString { get; set; }

    [StringLength(399)]
    [Unicode(false)]
    public string? StartEndHourMinString { get; set; }

    [StringLength(422)]
    public string? StartEndHourMinDescriptString { get; set; }

    [StringLength(20)]
    public string? Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public int? UserModifyLastSID { get; set; }
}
