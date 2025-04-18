using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
[Table("S_TreeviewMenu_bak20230619")]
public partial class S_TreeviewMenu_bak20230619
{
    [StringLength(12)]
    [Unicode(false)]
    public string NodeValue { get; set; } = null!;

    [StringLength(24)]
    public string NodeText { get; set; } = null!;

    [StringLength(80)]
    [Unicode(false)]
    public string NavigateUrl { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string ParentNodeValue { get; set; } = null!;

    public byte UserPermissionTypeID { get; set; }

    [StringLength(50)]
    public string? ToolTip { get; set; }

    public bool IsLeafNode { get; set; }

    public int OrderNo { get; set; }

    public bool InActive { get; set; }

    public bool SystemReserve { get; set; }
}
