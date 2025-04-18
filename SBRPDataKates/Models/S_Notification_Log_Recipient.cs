using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("LogSID", "UserSID")]
[Table("S_Notification_Log_Recipient")]
public partial class S_Notification_Log_Recipient
{
    [Key]
    public int LogSID { get; set; }

    [Key]
    public int UserSID { get; set; }

    [StringLength(64)]
    public string? DisplayName { get; set; }

    [StringLength(46)]
    public string? MailAddress { get; set; }

    [StringLength(16)]
    public string? PhoneMobile { get; set; }

    public bool IsNotificationFailure { get; set; }
}
