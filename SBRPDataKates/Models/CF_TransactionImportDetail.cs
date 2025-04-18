using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("ImportOperationNo", "ItemNo")]
[Table("CF_TransactionImportDetail")]
public partial class CF_TransactionImportDetail
{
    [Key]
    public int ImportOperationNo { get; set; }

    [Key]
    public short ItemNo { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string? DeviceID { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? CardID { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string? TranDateTimeNo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TranDateTime { get; set; }

    public bool InValid { get; set; }

    public bool IsIrrelevantUser { get; set; }

    public int? TranSID { get; set; }

    [ForeignKey("ImportOperationNo")]
    [InverseProperty("CF_TransactionImportDetails")]
    public virtual CF_TransactionImportHead ImportOperationNoNavigation { get; set; } = null!;
}
