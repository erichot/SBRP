using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VTMP_PreOrderProductSelected
{
    public Guid OperationGID { get; set; }

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(100)]
    public string? ProductName { get; set; }

    [StringLength(32)]
    public string ItemID { get; set; } = null!;

    public int ItemSID { get; set; }

    [Column(TypeName = "money")]
    public decimal? ListPrice { get; set; }

    [Column(TypeName = "money")]
    public decimal? Price { get; set; }

    public int Qty { get; set; }

    [Column(TypeName = "money")]
    public decimal? Total { get; set; }

    [StringLength(50)]
    public string? Remark { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;

    public DateTime TimeAddNew { get; set; }

    [StringLength(100)]
    public string? ImageSubFolderFileName1 { get; set; }
}
