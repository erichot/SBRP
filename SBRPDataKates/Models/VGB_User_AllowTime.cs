using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VGB_User_AllowTime
{
    public byte AllowTimeStartHour { get; set; }

    public byte AllowTimeStartMinute { get; set; }

    public byte AllowTimeEndHour { get; set; }

    public byte AllowTimeEndMinute { get; set; }
}
