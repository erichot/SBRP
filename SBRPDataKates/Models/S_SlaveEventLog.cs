using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("S_SlaveEventLog")]
public partial class S_SlaveEventLog
{
    [Key]
    public int EventSID { get; set; }

    public short EventCategoryID { get; set; }

    public short SlaveID { get; set; }

    public short ErrorCategory { get; set; }

    public int ErrorCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public bool HasBeenNotified { get; set; }

    public bool InActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeLastSendMail { get; set; }
}
