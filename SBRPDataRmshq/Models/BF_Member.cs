using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("BF_Member")]
[Index("Account", Name = "IX_BF_Member_Account", IsUnique = true)]
[Index("Email", Name = "IX_BF_Member_Email", IsUnique = true)]
[Index("ID", Name = "IX_BF_Member_ID", IsUnique = true)]
public partial class BF_Member
{
    [Key]
    public int MemberSID { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string Account { get; set; } = null!;

    [StringLength(64)]
    [Unicode(false)]
    public string ID { get; set; } = null!;

    [StringLength(16)]
    public string Name { get; set; } = null!;

    [StringLength(128)]
    [Unicode(false)]
    public string? Email { get; set; }

    public DateOnly? Birthday { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? MobilePhoneTW { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? MemberLevel { get; set; }

    public int? Points { get; set; }

    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string UserAddNewID { get; set; } = null!;

    public DateTime? TimeModified { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserModifiedID { get; set; }

    public bool InActive { get; set; }
}
