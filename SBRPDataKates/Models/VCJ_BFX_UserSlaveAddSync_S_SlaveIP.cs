using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VCJ_BFX_UserSlaveAddSync_S_SlaveIP
{
    public int UserSID { get; set; }

    public short ID { get; set; }
}
