using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("CHANGE_CARD")]
public partial class CHANGE_CARD
{
    [Key]
    public int ChangeID { get; set; }

    public int SlaveSID { get; set; }

    [StringLength(14)]
    public string? OldCardID { get; set; }

    [StringLength(14)]
    public string? NewCardID { get; set; }

    public bool IsReplicated { get; set; }

    [StringLength(30)]
    public string? CREATE_NAME { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CREATE_TIME { get; set; }
}
