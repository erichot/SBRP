using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VGB_DS_User_Add_DownloadSettingCount_BySlaveSID
{
    public int SlaveSID { get; set; }

    public int? AllowedReplicationCount { get; set; }

    public int? RejectDownloadCount { get; set; }
}
