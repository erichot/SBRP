using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("OR_LeaveApplication_Detail")]
[Index("UserSID", Name = "IX_OR_LeaveApplication_Detail_UserSID")]
public partial class OR_LeaveApplication_Detail
{
    public int LeaveApplicationHeadSID { get; set; }

    [Key]
    public int LeaveApplicationDetailSID { get; set; }

    public int UserSID { get; set; }

    [StringLength(12)]
    public string LeaveTypeID { get; set; } = null!;

    /// <summary>
    /// will above zero if it&apos;s enable
    /// </summary>
    public bool IsJustificationLeave { get; set; }

    [StringLength(50)]
    public string Reason { get; set; } = null!;

    public short LeaveMinute { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime LeaveTimeStart { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime LeaveTimeEnd { get; set; }

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
