using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("S_Notification_Log")]
[Index("NotificationCode", Name = "IX_S_Notification_Log_NotificationCode")]
public partial class S_Notification_Log
{
    [Key]
    public int LogSID { get; set; }

    [StringLength(36)]
    public string NotificationCode { get; set; } = null!;

    public bool IsHTML { get; set; }

    [Column(TypeName = "text")]
    public string? NotificationContent { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeAddNew { get; set; }
}
