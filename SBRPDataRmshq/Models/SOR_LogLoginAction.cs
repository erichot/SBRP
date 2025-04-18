using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("SOR_LogLoginAction")]
public partial class SOR_LogLoginAction
{
    [Key]
    public int LoginTaskSID { get; set; }

    [StringLength(32)]
    public string UserID { get; set; } = null!;

    [StringLength(32)]
    public string UserPWD { get; set; } = null!;

    public DateTime TimeAddNew { get; set; }

    public bool IsSuccessLogin { get; set; }

    [StringLength(50)]
    public string? REMOTE_ADDR { get; set; }

    [StringLength(50)]
    public string? REMOTE_HOST { get; set; }

    [StringLength(50)]
    public string? REMOTE_USER { get; set; }

    [StringLength(50)]
    public string? HTTP_VIA { get; set; }

    [StringLength(50)]
    public string? HTTP_X_FORWARDED_FOR { get; set; }
}
