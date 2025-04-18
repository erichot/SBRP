using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VUP_User_Add
{
    public int UserSID { get; set; }

    public short IsSync { get; set; }

    [StringLength(128)]
    public string? SlaveHost { get; set; }
}
