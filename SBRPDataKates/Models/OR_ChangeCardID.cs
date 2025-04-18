using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("OR_ChangeCardID")]
public partial class OR_ChangeCardID
{
    [Key]
    public int OrderSID { get; set; }

    [StringLength(14)]
    public string NewCardID { get; set; } = null!;

    [StringLength(14)]
    public string OldCardID { get; set; } = null!;

    [StringLength(15)]
    public string ClientIP { get; set; } = null!;

    public int AddNewUserSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }
}
