using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("ProductSelectedGID", "StoreID", "ProductID", "SerialNo")]
[Table("TMP_StoreProductSelected")]
public partial class TMP_StoreProductSelected
{
    [Key]
    public Guid ProductSelectedGID { get; set; }

    [Key]
    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [Key]
    public int SerialNo { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string TableOrderCode { get; set; } = null!;

    public DateTime TimeAddNew { get; set; }
}
