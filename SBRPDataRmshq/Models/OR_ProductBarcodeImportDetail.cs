using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("ImportHeaderSID", "ItemNo")]
[Table("OR_ProductBarcodeImportDetail")]
public partial class OR_ProductBarcodeImportDetail
{
    [Key]
    public int ImportHeaderSID { get; set; }

    [Key]
    public short ItemNo { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string ProductCode { get; set; } = null!;

    public int Qty { get; set; }

    public bool HasError { get; set; }
}
