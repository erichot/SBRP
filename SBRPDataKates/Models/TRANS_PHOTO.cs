using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("TRANS_PHOTO")]
public partial class TRANS_PHOTO
{
    [Key]
    public int PhotoID { get; set; }

    public int SlaveSID { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? TransTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SyncTime { get; set; }

    [Column(TypeName = "image")]
    public byte[]? Photos { get; set; }
}
