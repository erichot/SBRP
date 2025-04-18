using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("OR_LeaveApplication_Head")]
[Index("DateJustification", Name = "IX_OR_LeaveApplication_Head_DateJustification")]
[Index("UserSID", Name = "IX_OR_LeaveApplication_Head_UserSID")]
public partial class OR_LeaveApplication_Head
{
    [Key]
    public int LeaveApplicationHeadSID { get; set; }

    public int UserSID { get; set; }

    public DateOnly? DateJustification { get; set; }

    [StringLength(50)]
    public string Reason { get; set; } = null!;

    public bool IsApproved { get; set; }

    public bool IsRejected { get; set; }

    public bool IsNullified { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public int? UserModifyLastSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeApproved { get; set; }

    public int? UserApprovedSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeRejected { get; set; }

    public int? UserRejectedSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeNullified { get; set; }

    public int? UserNullifiedSID { get; set; }
}
