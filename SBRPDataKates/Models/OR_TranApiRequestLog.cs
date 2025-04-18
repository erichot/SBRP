using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("OR_TranApiRequestLog")]
public partial class OR_TranApiRequestLog
{
    [Key]
    public int RequestSN { get; set; }

    public int? TranSID { get; set; }

    [StringLength(14)]
    [Unicode(false)]
    public string? CardID { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string? UserID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TranDateTime { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string? RequestUrl { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string? ResponseText { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }
}
