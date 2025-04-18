using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("BF_UserHourlyPay")]
public partial class BF_UserHourlyPay
{
    [Key]
    public int UHPSID { get; set; }

    public int UserSID { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime EndDate { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string HourlyPayID { get; set; } = null!;

    [StringLength(26)]
    public string? Note { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeModifyLast { get; set; }

    public int UserModifyLastSID { get; set; }

    [ForeignKey("HourlyPayID")]
    [InverseProperty("BF_UserHourlyPays")]
    public virtual BF_HourlyPay HourlyPay { get; set; } = null!;

    [ForeignKey("UserSID")]
    [InverseProperty("BF_UserHourlyPays")]
    public virtual BF_User UserS { get; set; } = null!;
}
