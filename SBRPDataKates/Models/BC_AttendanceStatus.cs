using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("BC_AttendanceStatus")]
public partial class BC_AttendanceStatus
{
    [Key]
    [StringLength(12)]
    public string AttendanceStatusCode { get; set; } = null!;

    [StringLength(16)]
    public string AttendanceStatusName { get; set; } = null!;

    [StringLength(6)]
    [Unicode(false)]
    public string ColorHtml { get; set; } = null!;
}
