using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_ProductBarcodeImportHead")]
public partial class OR_ProductBarcodeImportHead
{
    [Key]
    public int ImportHeaderSID { get; set; }

    [StringLength(60)]
    public string? FileName { get; set; }

    public short? ItemCount { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserAddNewID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeAddNew { get; set; }
}
