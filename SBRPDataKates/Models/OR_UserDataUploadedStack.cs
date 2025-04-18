using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("OR_UserDataUploadedStack")]
public partial class OR_UserDataUploadedStack
{
    [Key]
    public int SID { get; set; }

    public short? SlaveID { get; set; }

    [StringLength(14)]
    public string? CardID { get; set; }

    [StringLength(12)]
    public string? UserID { get; set; }

    [StringLength(64)]
    public string? UserName { get; set; }

    public bool HasImported { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeAddNew { get; set; }
}
