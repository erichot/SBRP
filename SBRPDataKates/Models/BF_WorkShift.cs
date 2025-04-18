using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("BF_WorkShift")]
public partial class BF_WorkShift
{
    [Key]
    [StringLength(6)]
    public string ShiftCode { get; set; } = null!;

    [StringLength(20)]
    public string? ShiftName { get; set; }

    public byte StartTimeHour { get; set; }

    public byte StartTimeMinute { get; set; }

    public byte EndTimeHour { get; set; }

    public byte EndTimeMinute { get; set; }

    public byte AcrossOffsetHour { get; set; }

    public short DeductBreakMinute { get; set; }

    public short TolerateLateMinute { get; set; }

    public bool IsEndTimeNextDay { get; set; }

    public bool IsDefault { get; set; }

    public bool InActive { get; set; }

    public byte StartTimeHour_System { get; set; }

    public byte StartTimeMinute_System { get; set; }

    public byte StartTimeSecond_System { get; set; }

    public byte EndTimeHour_System { get; set; }

    public byte EndTimeMinute_System { get; set; }

    public byte EndTimeSecond_System { get; set; }

    /// <summary>
    /// 允許早到時間，若早於此時間則不計入
    /// </summary>
    public short? AllowWorkEarlyMinute { get; set; }

    /// <summary>
    /// 要求在下班時間後的一定區間內要刷退，否則不計入合法刷卡
    /// </summary>
    public short? ForceSignOutAfterWorkOffMinute { get; set; }

    /// <summary>
    /// 此類班別是否不要求刷下班卡（該WorkShift僅要求一次刷卡）
    /// </summary>
    public bool IsIgnoreSignOut { get; set; }

    public byte WorkShiftTypeID { get; set; }

    /// <summary>
    /// 比重值／加權計量值（用於不同應用程式、不同規則計算中使用）
    /// </summary>
    public short WeightValue { get; set; }

    [StringLength(10)]
    public string? DepartmentID { get; set; }

    public byte BreakStartTimeHour { get; set; }

    public byte BreakStartTimeMinute { get; set; }

    public byte BreakEndTimeHour { get; set; }

    public byte BreakEndTimeMinute { get; set; }

    public byte BreakStartTimeHour_System { get; set; }

    public byte BreakStartTimeMinute_System { get; set; }

    public byte BreakStartTimeSecond_System { get; set; }

    public byte BreakEndTimeHour_System { get; set; }

    public byte BreakEndTimeMinute_System { get; set; }

    public byte BreakEndTimeSecond_System { get; set; }

    public bool IsDeductBreakByPeiod { get; set; }

    public byte BreakStartTimeHour2 { get; set; }

    public byte BreakStartTimeMinute2 { get; set; }

    public byte BreakEndTimeHour2 { get; set; }

    public byte BreakEndTimeMinute2 { get; set; }

    public byte BreakStartTimeHour2_System { get; set; }

    public byte BreakStartTimeMinute2_System { get; set; }

    public byte BreakStartTimeSecond2_System { get; set; }

    public byte BreakEndTimeHour2_System { get; set; }

    public byte BreakEndTimeMinute2_System { get; set; }

    public byte BreakEndTimeSecond2_System { get; set; }

    public byte DeductBreakTypeID { get; set; }
}
