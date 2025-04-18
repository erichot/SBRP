using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("CHK_CALENDAR")]
public partial class CHK_CALENDAR
{
    [Key]
    public byte REST_GRP { get; set; }

    public bool? HOLIDAY_CK { get; set; }

    [StringLength(30)]
    public string? CREATE_NAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CREATE_TIME { get; set; }

    [StringLength(30)]
    public string? BUILD_NAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? BUILD_TIME { get; set; }
}
