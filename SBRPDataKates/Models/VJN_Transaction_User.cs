using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VJN_Transaction_User
{
    public int TranSID { get; set; }

    public int UserSID { get; set; }

    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    [StringLength(12)]
    public string UserID { get; set; } = null!;

    [StringLength(64)]
    public string? UserName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TranDateTime { get; set; }

    public int? TranYear { get; set; }

    public int? TranMonth { get; set; }

    public int? TranDay { get; set; }

    public int? TranYearLastDay { get; set; }

    public int? TranMonthLastDay { get; set; }

    public int? TranDayLastDay { get; set; }

    public byte TranType { get; set; }

    [StringLength(18)]
    public string? SlaveIP { get; set; }

    public bool IsReplicated { get; set; }

    public int WorkShiftNo { get; set; }

    public bool InActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SyncTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public int? UserModifyLastSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeNullified { get; set; }

    public int? UserNullifySID { get; set; }

    [StringLength(18)]
    public string Note { get; set; } = null!;

    [StringLength(14)]
    public string? Original_CardID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Original_TranDateTime { get; set; }

    public byte? Original_TranType { get; set; }
}
