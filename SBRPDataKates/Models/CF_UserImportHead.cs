using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("CF_UserImportHead")]
public partial class CF_UserImportHead
{
    [Key]
    public int ImportOperationNo { get; set; }

    [StringLength(50)]
    public string? FileName { get; set; }

    public short TotalRecord { get; set; }

    public short ValidRecord { get; set; }

    public short ImportedRecord { get; set; }

    public bool IsImported { get; set; }

    public bool IsDeleted { get; set; }

    public bool HasError { get; set; }

    [StringLength(100)]
    public string? Remark { get; set; }

    public int? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ImportedDate { get; set; }

    [InverseProperty("ImportOperationNoNavigation")]
    public virtual ICollection<CF_UserImportDetail> CF_UserImportDetails { get; set; } = new List<CF_UserImportDetail>();
}
