using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[PrimaryKey("OperationSID", "PreOrderSID")]
[Table("TMP_PreOrderArrival_OrderList")]
public partial class TMP_PreOrderArrival_OrderList
{
    [Key]
    public int OperationSID { get; set; }

    [Key]
    public int PreOrderSID { get; set; }
}
