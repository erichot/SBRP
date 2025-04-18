using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class vwUser
{
    [StringLength(32)]
    public string UserSID { get; set; } = null!;

    [StringLength(32)]
    public string? UserID { get; set; }

    [StringLength(32)]
    public string? Password { get; set; }

    [StringLength(20)]
    public string? Name { get; set; }

    [StringLength(2)]
    public string? StoreID { get; set; }

    [StringLength(32)]
    public string? BelongToId { get; set; }

    [StringLength(32)]
    public string? JobTitleId { get; set; }
}
