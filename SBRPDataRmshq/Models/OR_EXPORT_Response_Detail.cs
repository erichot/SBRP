using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("ExportGID", "SerialNo")]
[Table("OR_EXPORT_Response_Detail")]
public partial class OR_EXPORT_Response_Detail
{
    [Key]
    public Guid ExportGID { get; set; }

    [Key]
    public int SerialNo { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string KeyField { get; set; } = null!;

    [StringLength(128)]
    public string? ValueField { get; set; }

    public DateTime TimeAddNew { get; set; }
}
