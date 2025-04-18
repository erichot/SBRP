using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("BF_Coupon")]
[Index("CouponAccount", Name = "IX_BF_Coupon_CouponAccount")]
[Index("MemberID", Name = "IX_BF_Coupon_MemberID")]
public partial class BF_Coupon
{
    [Key]
    [StringLength(100)]
    [Unicode(false)]
    public string CouponID { get; set; } = null!;

    [StringLength(36)]
    [Unicode(false)]
    public string CouponAccount { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string MemberID { get; set; } = null!;

    public int Denomination { get; set; }

    public DateOnly? Useful_end { get; set; }

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    [StringLength(32)]
    [Unicode(false)]
    public string? SaleOrderID { get; set; }

    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserAddNewID { get; set; }

    public DateTime? TimeModified { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? UserModifiedID { get; set; }
}
