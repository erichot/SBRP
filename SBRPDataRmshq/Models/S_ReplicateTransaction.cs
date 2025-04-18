using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("S_ReplicateTransaction")]
public partial class S_ReplicateTransaction
{
    [Key]
    public int ReplicatedSID { get; set; }

    public byte ReplicatedDirectionID { get; set; }

    public byte ReplicatedCategoryID { get; set; }

    public int ReplicatedScopeID { get; set; }

    public DateTime TimeBeginReplicating { get; set; }

    public DateTime? TimeEndReplicated { get; set; }

    public Guid? ProductSelectedGID { get; set; }

    public bool IsFinished { get; set; }

    [StringLength(32)]
    public string? ErrorCode { get; set; }

    [StringLength(64)]
    public string? ErrorDescription { get; set; }

    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;
}
