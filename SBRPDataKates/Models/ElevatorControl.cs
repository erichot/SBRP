using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("ElevatorControl")]
public partial class ElevatorControl
{
    [Key]
    public int EleavatorID { get; set; }

    public int SlaveSID { get; set; }

    [StringLength(30)]
    public string? EleavatorName { get; set; }

    [StringLength(255)]
    public string? EleavatorDes { get; set; }
}
