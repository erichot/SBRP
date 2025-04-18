using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("BC_SlaveCategory")]
[Index("SlaveCategoryName", Name = "IX_BC_SlaveCategory_SlaveCategoryName", IsUnique = true)]
public partial class BC_SlaveCategory
{
    [Key]
    public int SlaveCategoryID { get; set; }

    [StringLength(16)]
    public string SlaveCategoryName { get; set; } = null!;

    [InverseProperty("SlaveCategory")]
    public virtual ICollection<S_SlaveIP> S_SlaveIPs { get; set; } = new List<S_SlaveIP>();
}
