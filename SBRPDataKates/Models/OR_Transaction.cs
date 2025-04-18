using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Index("CardID", Name = "IX_OR_Transactions_CardID")]
[Index("DataType", Name = "IX_OR_Transactions_DataType")]
[Index("InActive", Name = "IX_OR_Transactions_InActive")]
[Index("TranDateTime", Name = "IX_OR_Transactions_TranDateTime")]
[Index("TranType", Name = "IX_OR_Transactions_TranType")]
[Index("TranDateTime", Name = "IX_OR_Transactions_TransDateTime")]
[Index("WeekdayNo", Name = "IX_OR_Transactions_WeekdayNo")]
[Index("WorkShiftNo", Name = "IX_OR_Transactions_WorkShiftNo")]
public partial class OR_Transaction
{
    [Key]
    public int TranSID { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TranDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TranDateTimeOffset { get; set; }

    public byte TranType { get; set; }

    public bool? IsTranIn { get; set; }

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

    public byte WeekdayNo { get; set; }

    public byte DataType { get; set; }

    [StringLength(18)]
    public string? SlaveIP_Public { get; set; }

    public bool IsByTranType { get; set; }

    public byte? Original_DataType { get; set; }

    public short SlaveID { get; set; }

    public int SlaveSID { get; set; }

    public int ClientTranSID { get; set; }

    [Column(TypeName = "decimal(3, 1)")]
    public decimal? DegreeCelsius { get; set; }
}
