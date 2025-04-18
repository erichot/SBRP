using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("BF_HourlyPay")]
public partial class BF_HourlyPay
{
    [Key]
    [StringLength(12)]
    [Unicode(false)]
    public string HourlyPayID { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal HourlyPay { get; set; }

    [StringLength(24)]
    public string? Note { get; set; }

    [InverseProperty("HourlyPay")]
    public virtual ICollection<BF_UserHourlyPay> BF_UserHourlyPays { get; set; } = new List<BF_UserHourlyPay>();
}
