using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("PreOrderSID", "ItemNo")]
[Table("OR_PreOrderReminder_Detail")]
public partial class OR_PreOrderReminder_Detail
{
    [Key]
    public int PreOrderSID { get; set; }

    [Key]
    public int ItemNo { get; set; }

    public byte? PreOrderOperationTypeNo { get; set; }

    public byte? PreOrderContactResultNo { get; set; }

    public DateOnly ReminderBaseDate { get; set; }

    public byte DayAddValue { get; set; }

    public DateOnly ReminderDueDate { get; set; }

    [StringLength(100)]
    public string Remark { get; set; } = null!;

    [StringLength(16)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;

    public DateTime TimeAddNew { get; set; }
}
