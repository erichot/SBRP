using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_CompanyPreOrderInStore_Head")]
public partial class OR_CompanyPreOrderInStore_Head
{
    [Key]
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

    public DateTime? TimeModified { get; set; }
}
