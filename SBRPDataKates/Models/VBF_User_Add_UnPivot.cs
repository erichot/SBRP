using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBF_User_Add_UnPivot
{
    [StringLength(14)]
    public string? CardID { get; set; }

    public short? SlaveID { get; set; }

    public short SlaveValue { get; set; }
}
