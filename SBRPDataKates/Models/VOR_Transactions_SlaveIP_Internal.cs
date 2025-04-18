using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VOR_Transactions_SlaveIP_Internal
{
    public int TranSID { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    public int? UserSID { get; set; }

    [StringLength(12)]
    public string? UserID { get; set; }

    [StringLength(64)]
    public string? UserName { get; set; }

    [StringLength(10)]
    public string? DepartmentID { get; set; }

    [StringLength(36)]
    public string? DepartmentName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TranDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TranTime { get; set; }

    public short? Year { get; set; }

    public int? Month { get; set; }

    public int? Day { get; set; }

    public int? WeekdayNo { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TranDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TranDate_DateTime { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TranDateTimeString { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TranDateTimeOffset { get; set; }

    public byte TranType { get; set; }

    [StringLength(4)]
    public string? JobCode { get; set; }

    public int WorkShiftNo { get; set; }

    [StringLength(18)]
    public string? SlaveIP { get; set; }

    public bool IsReplicated { get; set; }

    public bool InActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SyncTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    [StringLength(64)]
    public string? UserAddNewName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }

    public int? UserModifyLastSID { get; set; }

    [StringLength(64)]
    public string? UserModifyLastName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeNullified { get; set; }

    public int? UserNullifySID { get; set; }

    [StringLength(64)]
    public string? UserNullifyName { get; set; }

    [StringLength(18)]
    public string Note { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? Original_TranDateTime { get; set; }

    public int? TranDateInt { get; set; }

    public int? TranTimeInt { get; set; }

    [StringLength(16)]
    public string? JobName { get; set; }

    public short? ID { get; set; }

    [StringLength(30)]
    public string? SlaveName { get; set; }

    [StringLength(255)]
    public string? SlaveDescription { get; set; }

    public int? SlaveCategoryID { get; set; }

    [StringLength(16)]
    public string? SlaveCategoryName { get; set; }

    [StringLength(18)]
    public string? SlaveIP_Public { get; set; }

    public byte DataType { get; set; }

    public bool IsByTranType { get; set; }
}
