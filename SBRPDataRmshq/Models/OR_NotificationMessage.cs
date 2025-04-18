using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_NotificationMessage")]
public partial class OR_NotificationMessage
{
    [Key]
    public int MessageSID { get; set; }

    public byte? MessageTypeNo { get; set; }

    [StringLength(36)]
    public string? Subject { get; set; }

    public int? BodyDataRowCount { get; set; }

    public string? BodyContent { get; set; }

    public int? EXP_Duplicated { get; set; }

    public int? EXP_Error { get; set; }

    public int? EXP_None { get; set; }

    public int? EXP_Count { get; set; }

    public int? SO_Count { get; set; }

    public bool? IsNormalResult { get; set; }

    public bool IsDeleted { get; set; }

    public bool HasSent { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? SentDate { get; set; }
}
