using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_ProductAdditionalOrderHead")]
[Index("IsDeleted", Name = "IX_OR_ProductAdditionalOrderHead_IsDeleted")]
[Index("IsFinished", Name = "IX_OR_ProductAdditionalOrderHead_IsFinished")]
[Index("OrderDate", Name = "IX_OR_ProductAdditionalOrderHead_OrderDate")]
public partial class OR_ProductAdditionalOrderHead
{
    [Key]
    public int OrderSID { get; set; }

    public DateOnly OrderDate { get; set; }

    [StringLength(50)]
    public string? Remark { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsFinished { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    public string UserAddNewID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? TimeModified { get; set; }

    [StringLength(32)]
    public string? UserModifiedID { get; set; }
}
