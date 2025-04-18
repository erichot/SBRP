using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VJN_Transaction_Depart_User_JobCode
{
    public int TranSID { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    public int UserSID { get; set; }

    [StringLength(12)]
    public string UserID { get; set; } = null!;

    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TranDateTime { get; set; }

    public byte TranType { get; set; }

    [StringLength(4)]
    public string JobCode { get; set; } = null!;

    public int WorkShiftNo { get; set; }

    public byte DataType { get; set; }

    public bool IsByTranType { get; set; }
}
