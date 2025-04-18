using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("SessionGID", "OrderSID")]
[Table("OR_ProductAdditionalOrderSource")]
public partial class OR_ProductAdditionalOrderSource
{
    [Key]
    public Guid SessionGID { get; set; }

    [Key]
    public int OrderSID { get; set; }

    public bool IsFinished { get; set; }

    public bool IsDeleted { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    public string UserAddNewID { get; set; } = null!;
}
