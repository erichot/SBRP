using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VBF_Store
{
    [StringLength(32)]
    public string Class { get; set; } = null!;

    [StringLength(32)]
    public string Id { get; set; } = null!;

    [StringLength(64)]
    public string? ListField { get; set; }

    [StringLength(6)]
    public string StoreAbbreviation { get; set; } = null!;

    public int? UpdateCount { get; set; }

    [StringLength(60)]
    public string? Address { get; set; }

    [StringLength(8)]
    public string? CloseDate { get; set; }

    [StringLength(32)]
    public string? Code { get; set; }

    [StringLength(8)]
    public string? CompanyNumber { get; set; }

    [StringLength(20)]
    public string? FaxNumber { get; set; }

    [StringLength(60)]
    public string? InvoiceAddress { get; set; }

    public DateTime? LastSync { get; set; }

    [StringLength(32)]
    public string? ManagerClass { get; set; }

    [StringLength(32)]
    public string? ManagerId { get; set; }

    [StringLength(30)]
    public string? Name { get; set; }

    [StringLength(8)]
    public string? OpenDate { get; set; }

    [StringLength(20)]
    public string? PhoneNumber { get; set; }

    [Column(TypeName = "image")]
    public byte[]? POST { get; set; }

    [StringLength(60)]
    public string? ShipToAddress { get; set; }

    [Column(TypeName = "image")]
    public byte[]? Warehouse { get; set; }

    public bool IsFavorite { get; set; }

    public bool InActive { get; set; }

    public short? OrderNo { get; set; }
}
