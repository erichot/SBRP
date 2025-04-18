using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("SystemCustomerID", "StoreID")]
[Table("S_SystemCustomerAndStore")]
public partial class S_SystemCustomerAndStore
{
    [Key]
    [StringLength(16)]
    public string SystemCustomerID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    public bool IsPrimaryStore { get; set; }

    public bool InActive { get; set; }

    public DateTime TimeAddNew { get; set; }

    public DateTime? TimeNullified { get; set; }
}
