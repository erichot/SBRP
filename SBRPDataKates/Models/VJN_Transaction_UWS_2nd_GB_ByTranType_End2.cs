using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VJN_Transaction_UWS_2nd_GB_ByTranType_End2
{
    public int? UserSID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TranDate_DateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TranDateTimeMin { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TranDateTimeMax { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDateTimeSystem_Time_2nd { get; set; }
}
