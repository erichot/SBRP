using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VJN_Transaction_WorkCalendar
{
    public int TranSID { get; set; }

    public int UserSID { get; set; }

    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    [StringLength(16)]
    public string UserID { get; set; } = null!;

    [StringLength(64)]
    public string? UserName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TranDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TranDateTimeOffset { get; set; }

    public int? Year { get; set; }

    public int? Month { get; set; }

    public int? Day { get; set; }

    public int? TranYearOffset { get; set; }

    public int? TranMonthOffset { get; set; }

    public int? TranDayOffset { get; set; }

    public byte TranType { get; set; }

    [StringLength(18)]
    public string? SlaveIP { get; set; }

    public bool IsReplicated { get; set; }

    public int WorkShiftNo { get; set; }

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

    [StringLength(6)]
    public string? ShiftCode { get; set; }

    [StringLength(20)]
    public string? ShiftName { get; set; }

    public byte? StartTimeHour { get; set; }

    public byte? StartTimeMinute { get; set; }

    public byte? EndTimeHour { get; set; }

    public byte? EndTimeMinute { get; set; }

    public byte? AcrossOffsetHour { get; set; }

    public short? DeductBreakMinute { get; set; }

    [StringLength(6)]
    public string? ShiftCode_LastDay { get; set; }

    public byte? AcrossOffsetHour_LastDay { get; set; }

    public byte? BreakStartTimeHour_System { get; set; }

    public byte? BreakStartTimeMinute_System { get; set; }

    public byte? BreakStartTimeSecond_System { get; set; }

    public byte? BreakEndTimeHour_System { get; set; }

    public byte? BreakEndTimeMinute_System { get; set; }

    public byte? BreakEndTimeSecond_System { get; set; }

    public bool? IsDeductBreakByPeiod { get; set; }

    public byte? BreakStartTimeHour2_System { get; set; }

    public byte? BreakStartTimeMinute2_System { get; set; }

    public byte? BreakStartTimeSecond2_System { get; set; }

    public byte? BreakEndTimeHour2_System { get; set; }

    public byte? BreakEndTimeMinute2_System { get; set; }

    public byte? BreakEndTimeSecond2_System { get; set; }

    public byte? DeductBreakTypeID { get; set; }
}
