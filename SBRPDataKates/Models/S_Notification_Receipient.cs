using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("NotificationCode", "UserSID")]
[Table("S_Notification_Receipient")]
public partial class S_Notification_Receipient
{
    [Key]
    [StringLength(36)]
    public string NotificationCode { get; set; } = null!;

    [Key]
    public int UserSID { get; set; }
}
