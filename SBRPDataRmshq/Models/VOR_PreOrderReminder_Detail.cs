using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_PreOrderReminder_Detail
{
    public int PreOrderSID { get; set; }

    public int ItemNo { get; set; }

    public byte? PreOrderOperationTypeNo { get; set; }

    [StringLength(10)]
    public string? PreOrderOperationTypeName { get; set; }

    public byte? PreOrderContactResultNo { get; set; }

    [StringLength(10)]
    public string? PreOrderContactResultName { get; set; }

    public DateOnly ReminderBaseDate { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? ReminderBaseDateText { get; set; }

    public byte DayAddValue { get; set; }

    public DateOnly ReminderDueDate { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? ReminderDueDateText { get; set; }

    [StringLength(100)]
    public string Remark { get; set; } = null!;

    [StringLength(16)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;

    [StringLength(16)]
    public string? UserAddNewName { get; set; }

    public DateTime TimeAddNew { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TimeAddNewText { get; set; }
}
