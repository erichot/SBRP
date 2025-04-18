using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_EXPORT_SaleOrder
{
    public Guid ExportGID { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? ExportTypeID { get; set; }

    [StringLength(2)]
    public string? ExportTypeName { get; set; }

    public int SerialNo { get; set; }

    public int SaleHeadRowCount { get; set; }

    public int SaleOrderDetailSubRowCount { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string? ReturnValue { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? HasErrorWhenSendData { get; set; }

    [StringLength(5)]
    public string? HasErrorWhenSendDataDesc { get; set; }

    [StringLength(50)]
    public string? Remark { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserAddNewID { get; set; }

    public DateTime TimeAddNew { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TimeAddNewString { get; set; }
}
