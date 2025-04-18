using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("BF_Contact")]
public partial class BF_Contact
{
    [Key]
    public int ContactSID { get; set; }

    public int RelatedUserSID { get; set; }

    public short ContactType { get; set; }

    [StringLength(64)]
    public string ContactName { get; set; } = null!;

    [StringLength(32)]
    public string Email { get; set; } = null!;
}
