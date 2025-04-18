using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VJN_BFX_UserSlaveAddSync_BF_User
{
    public int UserSID { get; set; }

    public short ID { get; set; }
}
