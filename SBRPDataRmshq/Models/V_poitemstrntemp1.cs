using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class V_poitemstrntemp1
{
    [StringLength(32)]
    [Unicode(false)]
    public string? Id { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? memberid { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? id1 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? id2 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? id3 { get; set; }

    [StringLength(32)]
    public string? Code { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? thestoreid { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? Potrntempid { get; set; }

    public float? cash { get; set; }

    public float? creditcard { get; set; }

    public float? sat { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? note1 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? note2 { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? note3 { get; set; }

    public float? Percent { get; set; }

    public float? Price { get; set; }

    public float? prepaidpoints { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Productdescription { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? ProductId { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? Productcustomcode { get; set; }

    public float? Quantity { get; set; }

    public float? Total { get; set; }

    public float? TotalPdtS { get; set; }

    [StringLength(1)]
    public string? pack_index { get; set; }
}
