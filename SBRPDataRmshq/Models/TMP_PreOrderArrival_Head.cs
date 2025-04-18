using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("TMP_PreOrderArrival_Head")]
public partial class TMP_PreOrderArrival_Head
{
    [Key]
    public int OperationSID { get; set; }

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    public DateTime TimeAddNew { get; set; }

    [StringLength(16)]
    [Unicode(false)]
    public string? UserAddNewID { get; set; }
}
