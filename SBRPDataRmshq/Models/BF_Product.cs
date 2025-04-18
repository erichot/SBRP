using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("BF_Product")]
[Index("IsFavorite", Name = "IX_BF_Product_IsFavorite")]
public partial class BF_Product
{
    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    public bool IsFavorite { get; set; }

    public bool IsDeleted { get; set; }

    [StringLength(50)]
    public string? SubFolder { get; set; }

    [StringLength(50)]
    public string? ImageFileName1 { get; set; }

    [StringLength(50)]
    public string? SSSNoteP1 { get; set; }

    [StringLength(50)]
    public string? SSSNoteP2 { get; set; }

    [StringLength(50)]
    public string? SSSNoteP3 { get; set; }

    [StringLength(50)]
    public string? SSSNoteP4 { get; set; }

    public bool IsSSSFlag { get; set; }

    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;

    public DateTime? TimeModified { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserModifiedID { get; set; }

    public DateTime? TimeDeleted { get; set; }
}
