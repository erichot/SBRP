using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("UserSID", "SlaveSID")]
[Table("BFX_UserSlaveAddSync")]
public partial class BFX_UserSlaveAddSync
{
    [Key]
    public int UserSID { get; set; }

    [Key]
    public int SlaveSID { get; set; }

    public short? SlaveID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }

    public bool HasSetToSyncTable { get; set; }

    [ForeignKey("UserSID")]
    [InverseProperty("BFX_UserSlaveAddSyncs")]
    public virtual BF_User UserS { get; set; } = null!;
}
