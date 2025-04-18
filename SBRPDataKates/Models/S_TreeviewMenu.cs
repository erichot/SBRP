using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Table("S_TreeviewMenu")]
public partial class S_TreeviewMenu
{
    [Key]
    [StringLength(13)]
    [Unicode(false)]
    public string NodeValue { get; set; } = null!;

    [StringLength(40)]
    public string NodeText_en { get; set; } = null!;

    [StringLength(60)]
    public string ToolTip_en { get; set; } = null!;

    [StringLength(80)]
    [Unicode(false)]
    public string NavigateUrl { get; set; } = null!;

    [StringLength(13)]
    [Unicode(false)]
    public string ParentNodeValue { get; set; } = null!;

    public byte UserPermissionTypeID { get; set; }

    [StringLength(40)]
    public string NodeText_tw { get; set; } = null!;

    [StringLength(60)]
    public string ToolTip_tw { get; set; } = null!;

    [StringLength(40)]
    public string NodeText_cn { get; set; } = null!;

    [StringLength(60)]
    public string ToolTip_cn { get; set; } = null!;

    [StringLength(50)]
    public string NodeText_es { get; set; } = null!;

    [StringLength(60)]
    public string ToolTip_es { get; set; } = null!;

    [StringLength(50)]
    public string NodeText_ko { get; set; } = null!;

    [StringLength(60)]
    public string ToolTip_ko { get; set; } = null!;

    public bool IsLeafNode { get; set; }

    public int OrderNo { get; set; }

    public bool InActive { get; set; }

    public bool SystemReserve { get; set; }
}
