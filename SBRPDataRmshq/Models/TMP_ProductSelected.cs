using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("ProductSelectedGID", "ProductID")]
[Table("TMP_ProductSelected")]
public partial class TMP_ProductSelected
{
    [Key]
    public Guid ProductSelectedGID { get; set; }

    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public DateTime TimeAddNew { get; set; }
}
