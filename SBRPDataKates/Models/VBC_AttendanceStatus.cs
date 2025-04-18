using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBC_AttendanceStatus
{
    [StringLength(12)]
    public string AttendanceStatusCode { get; set; } = null!;

    [StringLength(12)]
    public string AttendanceStatusName { get; set; } = null!;

    [StringLength(27)]
    public string ListField { get; set; } = null!;

    [StringLength(6)]
    [Unicode(false)]
    public string ColorHtml { get; set; } = null!;
}
