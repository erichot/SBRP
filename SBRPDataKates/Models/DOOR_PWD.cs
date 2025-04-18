using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("DOOR_PWD")]
public partial class DOOR_PWD
{
    [Key]
    public int SlaveSID { get; set; }

    [StringLength(30)]
    public string? PIN1_NAME { get; set; }

    public byte? PIN1_CODE { get; set; }

    public DateOnly? PIN1_START_DATE { get; set; }

    public byte? PIN1_START_HOUR { get; set; }

    public byte? PIN1_START_MIN { get; set; }

    public DateOnly? PIN1_END_DATE { get; set; }

    public byte? PIN1_END_HOUR { get; set; }

    public byte? PIN1_END_MIN { get; set; }

    public byte[]? PIN1 { get; set; }

    [StringLength(30)]
    public string? PIN2_NAME { get; set; }

    public byte? PIN2_CODE { get; set; }

    public DateOnly? PIN2_START_DATE { get; set; }

    public byte? PIN2_START_HOUR { get; set; }

    public byte? PIN2_START_MIN { get; set; }

    public DateOnly? PIN2_END_DATE { get; set; }

    public byte? PIN2_END_HOUR { get; set; }

    public byte? PIN2_END_MIN { get; set; }

    public byte[]? PIN2 { get; set; }

    public bool IsReplicated { get; set; }
}
