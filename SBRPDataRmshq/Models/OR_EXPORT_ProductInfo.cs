using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_EXPORT_ProductInfo")]
[Index("SerialNo", Name = "IX_OR_EXPORT_ProductInfo_SerialNo")]
public partial class OR_EXPORT_ProductInfo
{
    [Key]
    public Guid ExportGID { get; set; }

    public int SerialNo { get; set; }

    public int? ProductInfoRowCount { get; set; }

    public int? StockQtyTotal { get; set; }

    public int? ProductInfoRowCount2 { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string ReturnValue { get; set; } = null!;

    public bool HasErrorWhenSendData { get; set; }

    [StringLength(50)]
    public string Remark { get; set; } = null!;

    [StringLength(32)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;

    public DateTime TimeAddNew { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeCompleteExported { get; set; }

    public bool InActive { get; set; }

    public DateTime? TimeNullified { get; set; }
}
