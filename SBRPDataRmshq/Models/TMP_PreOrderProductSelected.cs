using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("OperationGID", "ItemID")]
[Table("TMP_PreOrderProductSelected")]
public partial class TMP_PreOrderProductSelected
{
    [Key]
    public Guid OperationGID { get; set; }

    [Key]
    [StringLength(32)]
    public string ItemID { get; set; } = null!;

    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(50)]
    public string? ProductName { get; set; }

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
}
