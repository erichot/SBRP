using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VRP_Transactions_EmployeeInOutStatus
{
    [StringLength(10)]
    public string DepartmentID { get; set; } = null!;

    [StringLength(36)]
    public string? DepartmentName { get; set; }

    public int UserSID { get; set; }

    [StringLength(12)]
    public string UserID { get; set; } = null!;

    [StringLength(64)]
    public string? UserName { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    public byte TranType { get; set; }

    [StringLength(4)]
    public string JobCode { get; set; } = null!;

    [StringLength(16)]
    public string JobName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TranDateTime { get; set; }

    public int SlaveCategoryID { get; set; }

    [StringLength(18)]
    public string? SlaveIP_Public { get; set; }

    [StringLength(30)]
    public string? SlaveDescription { get; set; }
}
