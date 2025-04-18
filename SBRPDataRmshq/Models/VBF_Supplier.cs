using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VBF_Supplier
{
    [StringLength(32)]
    public string Class { get; set; } = null!;

    [StringLength(32)]
    public string Id { get; set; } = null!;

    [StringLength(73)]
    public string? ListField { get; set; }

    public int? UpdateCount { get; set; }

    [StringLength(20)]
    public string? AccountNumber { get; set; }

    [StringLength(80)]
    public string? Address { get; set; }

    [StringLength(80)]
    public string? Address2 { get; set; }

    [StringLength(20)]
    public string? Bank { get; set; }

    [StringLength(20)]
    public string? Branch { get; set; }

    [StringLength(32)]
    public string? Code { get; set; }

    [StringLength(8)]
    public string? CompanyNumber { get; set; }

    [StringLength(20)]
    public string? CompanyOwner { get; set; }

    [StringLength(20)]
    public string? ContactName { get; set; }

    [StringLength(60)]
    public string? Description { get; set; }

    [StringLength(200)]
    public string? EmailAddress { get; set; }

    [StringLength(20)]
    public string? FaxNumber { get; set; }

    public DateTime? LastSync { get; set; }

    [StringLength(40)]
    public string? Name { get; set; }

    [StringLength(120)]
    public string? Note1 { get; set; }

    [StringLength(60)]
    public string? Note2 { get; set; }

    [StringLength(60)]
    public string? Note3 { get; set; }

    public int? OrderCycle { get; set; }

    public int? OrderMethod { get; set; }

    [StringLength(20)]
    public string? OrderPhoneNumber { get; set; }

    public int? PaymentCycle { get; set; }

    [StringLength(20)]
    public string? PhoneNumber1 { get; set; }

    [StringLength(20)]
    public string? PhoneNumber2 { get; set; }

    public int? TradeType { get; set; }

    public int? TypeOfClosing { get; set; }

    [StringLength(200)]
    public string? WebSite { get; set; }

    [StringLength(108)]
    public string? c1 { get; set; }

    [StringLength(108)]
    public string? c2 { get; set; }

    [StringLength(108)]
    public string? c3 { get; set; }

    [StringLength(108)]
    public string? c4 { get; set; }

    [StringLength(108)]
    public string? c5 { get; set; }
}
