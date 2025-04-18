using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("S_SystemSetting_SMTP")]
public partial class S_SystemSetting_SMTP
{
    [Key]
    public byte SettingID { get; set; }

    [StringLength(32)]
    public string MailServer { get; set; } = null!;

    public short MailServerPort { get; set; }

    public bool IsRequiresAuthentication { get; set; }

    public bool IsRequiresSSL { get; set; }

    public bool IsRequiresSPA { get; set; }

    [StringLength(24)]
    public string? LoginUserName { get; set; }

    [StringLength(128)]
    public string? LoginPassword { get; set; }

    [StringLength(36)]
    public string? SenderName { get; set; }

    [StringLength(50)]
    public string? SenderAddress { get; set; }

    [StringLength(50)]
    public string? ReplyTo { get; set; }

    [StringLength(16)]
    public string CharacterSet { get; set; } = null!;

    [StringLength(8)]
    public string NewLineCharacter { get; set; } = null!;

    public bool IsHTML { get; set; }

    public short MaxIdleTime { get; set; }

    public bool IsDefault { get; set; }
}
