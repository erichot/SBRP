using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VBF_Employee
{
    [StringLength(32)]
    public string Class { get; set; } = null!;

    [StringLength(32)]
    public string Id { get; set; } = null!;

    public int? UpdateCount { get; set; }

    [StringLength(32)]
    public string? BelongToClass { get; set; }

    [StringLength(2)]
    public string? StoreID { get; set; }

    [StringLength(32)]
    public string? StoreName { get; set; }

    [StringLength(32)]
    public string? BelongToId { get; set; }

    [StringLength(32)]
    public string? Code { get; set; }

    [StringLength(32)]
    public string? Password { get; set; }

    [StringLength(8)]
    public string? HireDate { get; set; }

    [StringLength(32)]
    public string? JobTitleClass { get; set; }

    [StringLength(32)]
    public string? JobTitleId { get; set; }

    public float? Salary { get; set; }

    [StringLength(22)]
    public string? Name { get; set; }
}
