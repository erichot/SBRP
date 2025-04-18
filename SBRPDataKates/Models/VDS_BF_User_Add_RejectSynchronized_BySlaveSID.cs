using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VDS_BF_User_Add_RejectSynchronized_BySlaveSID
{
    public int SlaveSID { get; set; }

    public int? RejectedUserCounts { get; set; }
}
