using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("TMP_TransactionSource")]
public partial class TMP_TransactionSource
{
    [Key]
    [StringLength(50)]
    public string IDName { get; set; } = null!;

    [Column(TypeName = "decimal(7, 0)")]
    public decimal Amount { get; set; }

    public int ProcessCount { get; set; }

    [Column(TypeName = "decimal(7, 0)")]
    public decimal RemainAmount { get; set; }
}
