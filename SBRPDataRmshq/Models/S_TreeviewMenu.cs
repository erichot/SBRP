using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("S_TreeviewMenu")]
[Index("InActive", Name = "IX_S_TreeviewMenu_InActive")]
[Index("IsLeafNode", Name = "IX_S_TreeviewMenu_IsLeafNode")]
[Index("OrderNo", Name = "IX_S_TreeviewMenu_OrderNo")]
[Index("ParentNodeValue", Name = "IX_S_TreeviewMenu_ParentNodeValue")]
[Index("UserPermissionTypeID", Name = "IX_S_TreeviewMenu_UserPermissionTypeID")]
public partial class S_TreeviewMenu
{
    [Key]
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

    public int BitwisePermissionNo { get; set; }

    public bool IsCollapseForLeafNode { get; set; }
}
