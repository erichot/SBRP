using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("OR_GlobleAPB")]
public partial class OR_GlobleAPB
{
    [Key]
    [StringLength(14)]
    public string CardID { get; set; } = null!;

    public short SlaveID { get; set; }

    public byte InOrOut { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TranDateTime { get; set; }
}
