using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
[Table("TMP_BF_Contact_1116")]
public partial class TMP_BF_Contact_1116
{
    [StringLength(12)]
    public string? UserID { get; set; }

    [StringLength(64)]
    public string? UserName { get; set; }

    public int? ContactType { get; set; }

    [StringLength(64)]
    public string? ContactName { get; set; }

    [StringLength(32)]
    public string? Email { get; set; }
}
