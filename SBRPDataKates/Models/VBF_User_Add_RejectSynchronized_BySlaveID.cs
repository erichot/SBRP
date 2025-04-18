using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VBF_User_Add_RejectSynchronized_BySlaveID
{
    public short? SlaveID { get; set; }

    public int? RejectedUserCounts { get; set; }
}
