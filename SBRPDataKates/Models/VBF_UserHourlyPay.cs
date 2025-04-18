using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBF_UserHourlyPay
{
    public int UHPSID { get; set; }

    public int UserSID { get; set; }

    [StringLength(12)]
    public string UserID { get; set; } = null!;

    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    [StringLength(88)]
    public string? ListField { get; set; }

    [StringLength(64)]
    public string? UserName { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    [Column(TypeName = "smalldatetime")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime EndDate { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? StartDate_101 { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? EndDate_101 { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string HourlyPayID { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal HourlyPay { get; set; }

    public double? HourlyPay_Float { get; set; }

    [StringLength(26)]
    public string? Note { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeModifyLast { get; set; }

    public int UserModifyLastSID { get; set; }
}
