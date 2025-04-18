using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VS_SlaveEventLog
{
    public int EventSID { get; set; }

    public short EventCategoryID { get; set; }

    public short SlaveID { get; set; }

    [StringLength(36)]
    public string? IP { get; set; }

    [StringLength(255)]
    public string? SlaveDescription { get; set; }

    public short ErrorCategory { get; set; }

    public int ErrorCode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? StatusCodeDefinition { get; set; }

    [StringLength(100)]
    public string? SlaveStatusDescription { get; set; }

    public bool HasBeenNotified { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeLastSendMail { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public bool InActive { get; set; }
}
