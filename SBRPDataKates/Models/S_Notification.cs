using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("S_Notification")]
public partial class S_Notification
{
    [Key]
    [StringLength(36)]
    public string NotificationCode { get; set; } = null!;

    [StringLength(50)]
    public string Description { get; set; } = null!;

    public bool IsEnabled { get; set; }

    public short FrequencyMinute { get; set; }

    [StringLength(50)]
    public string MailSubject { get; set; } = null!;
}
