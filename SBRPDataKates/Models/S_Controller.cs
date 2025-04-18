using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("S_Controller")]
public partial class S_Controller
{
    [Key]
    [StringLength(15)]
    public string IP { get; set; } = null!;

    [StringLength(15)]
    public string? SubMask { get; set; }

    [StringLength(15)]
    public string? Gateway { get; set; }

    [StringLength(15)]
    public string? DNS { get; set; }

    public short? Port { get; set; }

    [StringLength(64)]
    public string? ControllerName { get; set; }

    [StringLength(16)]
    public string PWD { get; set; } = null!;

    [StringLength(16)]
    public string Version { get; set; } = null!;

    [StringLength(24)]
    public string? AspNetServer_DomainName { get; set; }

    [StringLength(24)]
    public string? AspNetServer_UserName { get; set; }

    [StringLength(128)]
    public string? AspNetServer_Password { get; set; }
}
