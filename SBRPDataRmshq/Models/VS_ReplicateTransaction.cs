using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VS_ReplicateTransaction
{
    public int ReplicatedSID { get; set; }

    public byte ReplicatedDirectionID { get; set; }

    public byte ReplicatedCategoryID { get; set; }

    public int ReplicatedScopeID { get; set; }

    [StringLength(18)]
    public string? ReplicatedScopeName { get; set; }

    public Guid? ProductSelectedGID { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? DateBeginReplicating { get; set; }

    public DateTime TimeBeginReplicating { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TimeBeginReplicatingHourMinute { get; set; }

    public DateTime? TimeEndReplicated { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TimeEndReplicatedHourMinute { get; set; }

    public int? ReplicatingDurationSecond { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? ReplicatingDurationMinuteSecondText { get; set; }

    public bool IsFinished { get; set; }

    [StringLength(32)]
    public string? ErrorCode { get; set; }

    [StringLength(64)]
    public string? ErrorDescription { get; set; }

    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;

    [StringLength(16)]
    public string? UserAddNewName { get; set; }
}
