using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VJN_Transactions_WorkCalendar_Advance
{
    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    public int UserSID { get; set; }

    public short Year { get; set; }

    public byte Month { get; set; }

    public byte Day { get; set; }

    public int WorkShiftNo { get; set; }

    [StringLength(6)]
    public string ShiftCode { get; set; } = null!;

    public int? TranSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TranDateTime { get; set; }
}
