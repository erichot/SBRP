using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VGB_Transactions_WorkCalendar_bak
{
    public int? UserSID { get; set; }

    public short? Year { get; set; }

    public int? Month { get; set; }

    public int? Day { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? MinTranDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? MinTranDateTimeOffset { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? MaxTranDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? MaxTranDateTimeOffset { get; set; }

    public int? MinTranSID { get; set; }

    public int? MaxTranSID { get; set; }

    public int? CountTranSID { get; set; }

    [StringLength(6)]
    public string? ShiftCode { get; set; }

    public byte? AcrossOffsetHour { get; set; }
}
