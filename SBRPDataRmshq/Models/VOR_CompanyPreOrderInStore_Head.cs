using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_CompanyPreOrderInStore_Head
{
    public int OrderSID { get; set; }

    [StringLength(300)]
    public string? Remark { get; set; }

    public bool InActive { get; set; }

    public bool IsConfirmed { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;

    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserModifiedID { get; set; }

    [StringLength(16)]
    public string? UserModifiedName { get; set; }

    public DateTime? TimeModified { get; set; }
}
