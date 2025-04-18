using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("TMP_GlobalHolidaySetting_Head_1116")]
public partial class TMP_GlobalHolidaySetting_Head_1116
{
    [Key]
    public int ImportSID { get; set; }

    public DateOnly? DateStart { get; set; }

    public DateOnly? DateEnd { get; set; }

    [StringLength(50)]
    public string? Description { get; set; }

    public bool IsImported { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    public int UserAddNewSID { get; set; }
}
