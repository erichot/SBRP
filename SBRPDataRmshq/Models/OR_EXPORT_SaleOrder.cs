using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_EXPORT_SaleOrder")]
public partial class OR_EXPORT_SaleOrder
{
    [Key]
    public Guid ExportGID { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? ExportTypeID { get; set; }

    public int SerialNo { get; set; }

    public int? SaleHeadRowCount { get; set; }

    public int SaleOrderDetailSubRowCount { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string? ReturnValue { get; set; }

    [StringLength(50)]
    public string? Remark { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? HasErrorWhenSendData { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserAddNewID { get; set; }

    public DateTime TimeAddNew { get; set; }

    public DateTime? TimeCompleteExported { get; set; }
}
