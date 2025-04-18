using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_RemotelyMemberQuerying")]
public partial class OR_RemotelyMemberQuerying
{
    [Key]
    public int QueryingSID { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(32)]
    [Unicode(false)]
    public string? Account { get; set; }

    [StringLength(32)]
    public string? Name { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string? PointsText { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? CopamtText { get; set; }

    public int? MemberSID { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string? MemberID { get; set; }

    public int? RetChk { get; set; }

    [StringLength(450)]
    [Unicode(false)]
    public string? ResponseString { get; set; }

    public bool IsInserted { get; set; }

    public bool IsUpdated { get; set; }

    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;
}
