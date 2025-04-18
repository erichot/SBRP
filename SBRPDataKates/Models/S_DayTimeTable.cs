using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("HourValue", "MinuteValue")]
[Table("S_DayTimeTable")]
public partial class S_DayTimeTable
{
    public byte ItemNo { get; set; }

    [Key]
    public byte HourValue { get; set; }

    [Key]
    public byte MinuteValue { get; set; }
}
