using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VGB_DS_BF_User_Add_BySlaveSID
{
    public int SlaveSID { get; set; }

    public int? UserCounts { get; set; }
}
