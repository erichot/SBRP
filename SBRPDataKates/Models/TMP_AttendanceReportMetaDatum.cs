using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("AppSID", "UserSID", "DateColumn", "ShiftCode")]
[Index("DepartmentID", Name = "IX_TMP_AttendanceReportMetaData_DepartmentID")]
public partial class TMP_AttendanceReportMetaDatum
{
    [Key]
    public int AppSID { get; set; }

    [Key]
    public int UserSID { get; set; }

    [Key]
    public DateOnly DateColumn { get; set; }

    [Key]
    [StringLength(6)]
    public string ShiftCode { get; set; } = null!;

    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    public short YearValue { get; set; }

    public byte MonthValue { get; set; }

    public byte DayValue { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingStdTimeOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingStdTimeOff { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingTimeOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? WorkingTimeOff { get; set; }

    public int WorkShiftNormalTime { get; set; }

    public int WorkingTimeTotal { get; set; }

    public int? WorkingTimeNormal { get; set; }

    public int WorkingTimeOnEarly { get; set; }

    public int WorkingTimeLate { get; set; }

    public int WorkingTimeLeaveEarly { get; set; }

    public int WorkingTimeOver { get; set; }

    public int Overtime1_5 { get; set; }

    public int Overtime2_0 { get; set; }

    public int Overtime3_0 { get; set; }

    public bool IsEarlyIn { get; set; }

    public bool IsEarlyOut { get; set; }

    public bool IsLateIn { get; set; }

    public bool IsLateOut { get; set; }

    public bool IsIncompleteDataIn { get; set; }

    public bool IsIncompleteDataOut { get; set; }

    public bool IsAbsence { get; set; }

    public bool IsOvertime { get; set; }

    public bool IsNonWorkingDay { get; set; }

    public bool IsPublicHoliday { get; set; }

    public bool IsDayFitSUPV { get; set; }

    public bool IsDayFitDAL { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    [StringLength(50)]
    public string? Leave { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal OTAL { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal SAL { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal TAL { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal BFAL { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal LAL { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal DAL { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal SUPV { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal TOTAL { get; set; }

    [StringLength(16)]
    public string? EmployeeTypeID { get; set; }
}
