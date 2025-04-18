using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("S_SlaveStatusDefinition")]
public partial class S_SlaveStatusDefinition
{
    [Key]
    public int StatusCode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string StatusCodeDefinition { get; set; } = null!;

    [StringLength(100)]
    public string? Description_enUS { get; set; }

    [StringLength(100)]
    public string? Description_zhTW { get; set; }

    [StringLength(100)]
    public string? Description_zhCN { get; set; }

    [StringLength(100)]
    public string? Description_es { get; set; }

    [StringLength(100)]
    public string? Description_ko { get; set; }
}
