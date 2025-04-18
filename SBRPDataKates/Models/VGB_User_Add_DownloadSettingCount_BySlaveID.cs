using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VGB_User_Add_DownloadSettingCount_BySlaveID
{
    public short ID { get; set; }

    public int? AllowedReplicationCount { get; set; }

    public int? RejectDownloadCount { get; set; }
}
