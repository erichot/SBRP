using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("WithdrawIDName", "ReceiptIDName")]
[Table("TMP_TransactionResult")]
public partial class TMP_TransactionResult
{
    [Key]
    [StringLength(50)]
    public string WithdrawIDName { get; set; } = null!;

    [Key]
    [StringLength(50)]
    public string ReceiptIDName { get; set; } = null!;

    [Column(TypeName = "decimal(7, 0)")]
    public decimal? Amount { get; set; }
}
