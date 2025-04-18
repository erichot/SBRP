using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("UserSID", "NodeValue")]
[Table("S_TreeviewMenu_User")]
public partial class S_TreeviewMenu_User
{
    [Key]
    public int UserSID { get; set; }

    [Key]
    [StringLength(13)]
    [Unicode(false)]
    public string NodeValue { get; set; } = null!;

    public bool InActive { get; set; }

    public int UserAddNewSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int? TimeModifyLastSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeModifyLast { get; set; }
}
