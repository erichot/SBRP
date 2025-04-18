using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VS_Notification_Receipient
{
    [StringLength(36)]
    public string? NotificationCode { get; set; }

    public int UserSID { get; set; }

    [StringLength(12)]
    public string UserID { get; set; } = null!;

    [StringLength(64)]
    public string? UserName { get; set; }

    [StringLength(46)]
    public string? Email { get; set; }

    [StringLength(16)]
    public string? PhoneMobile { get; set; }

    public bool? Selected { get; set; }
}
