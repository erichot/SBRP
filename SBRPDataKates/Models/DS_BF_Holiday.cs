using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[PrimaryKey("DoorID", "DoorHoliID")]
[Table("DS_BF_Holiday")]
public partial class DS_BF_Holiday
{
    [Key]
    public byte DoorID { get; set; }

    [Key]
    public int DoorHoliID { get; set; }

    public byte HoliMonth { get; set; }

    public byte HoliDay { get; set; }

    public byte HoliType { get; set; }

    [StringLength(20)]
    public string? Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }
}
