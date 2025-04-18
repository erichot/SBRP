using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("TempGID", "ProductID")]
[Table("TMP_Product")]
[Index("ProductID", Name = "IX_TMP_Product_ProductID")]
public partial class TMP_Product
{
    [Key]
    public Guid TempGID { get; set; }

    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public DateTime TimeAddNew { get; set; }
}
