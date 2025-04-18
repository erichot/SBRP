using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("EndOrderDate", "ProductID", "RowNo")]
[Table("TMP_ProductAdditionalOrder")]
public partial class TMP_ProductAdditionalOrder
{
    [Key]
    public DateOnly EndOrderDate { get; set; }

    [Key]
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [Key]
    public int RowNo { get; set; }

    public int OrderSID { get; set; }

    public DateOnly OrderDate { get; set; }

    public int AdditionalOrderQty { get; set; }

    public int InStockBeforeNextOrderQty { get; set; }

    public int RemainOrderQty { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    public string UserAddNewID { get; set; } = null!;
}
