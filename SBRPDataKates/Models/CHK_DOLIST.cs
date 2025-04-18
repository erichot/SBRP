using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("LIST_YEAR", "LIST_DATE")]
[Table("CHK_DOLIST")]
public partial class CHK_DOLIST
{
    [Key]
    public int LIST_YEAR { get; set; }

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime LIST_DATE { get; set; }

    [StringLength(20)]
    public string? LIST_WEEK { get; set; }

    [StringLength(20)]
    public string? LIST_MEMO { get; set; }

    public bool? HOLIDAY_CK { get; set; }

    [StringLength(30)]
    public string? CREATE_NAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CREATE_TIME { get; set; }

    [StringLength(30)]
    public string? BUILD_NAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? BUILD_TIME { get; set; }

    public byte? LIST_GRP { get; set; }
}
