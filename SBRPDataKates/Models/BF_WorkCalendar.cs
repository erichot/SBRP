using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("UserSID", "Year", "Month", "Day", "WorkShiftNo", "ShiftCode")]
[Table("BF_WorkCalendar")]
[Index("IsComputed", Name = "IX_BF_WorkCalendar_IsComputed")]
public partial class BF_WorkCalendar
{
    [Key]
    public int UserSID { get; set; }

    [Key]
    public short Year { get; set; }

    [Key]
    public byte Month { get; set; }

    [Key]
    public byte Day { get; set; }

    [Key]
    public int WorkShiftNo { get; set; }

    [Key]
    [StringLength(6)]
    public string ShiftCode { get; set; } = null!;

    [StringLength(32)]
    public string? Note { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? WorkDate { get; set; }

    [StringLength(16)]
    public string WeekdayName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? WorkStartDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkEndDateTime { get; set; }

    [StringLength(6)]
    public string? ShiftCode_LastDay { get; set; }

    /// <summary>
    /// 經過查詢計算後所得之第一個吻合該時段（進）的刷卡紀錄
    /// </summary>
    public int ComputedTranInSID { get; set; }

    public int ComputedTranLateInSID { get; set; }

    /// <summary>
    /// 經過查詢計算後所得之第一個吻合該時段（出）的刷卡紀錄
    /// </summary>
    public int ComputedTranOutSID { get; set; }

    public int ComputedExpectedScale { get; set; }

    /// <summary>
    /// 經過查詢計算後所得之第一個吻合該時段（出）的刷卡紀錄
    /// </summary>
    public int ComputedAttendanceScale { get; set; }

    /// <summary>
    /// 該筆資料列的相關計算欄位（Computed）是否已計算完成
    /// </summary>
    public bool IsComputed { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public int? UserModifyLast { get; set; }
}
