using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("S_WiFi")]
public partial class S_WiFi
{
    [Key]
    [StringLength(32)]
    public string SSID { get; set; } = null!;

    [StringLength(16)]
    public string? Passphrase { get; set; }

    [StringLength(16)]
    public string? WirelessEncryption { get; set; }

    [StringLength(10)]
    public string? Key1 { get; set; }
}
