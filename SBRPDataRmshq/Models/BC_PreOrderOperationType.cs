using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("BC_PreOrderOperationType")]
public partial class BC_PreOrderOperationType
{
    [Key]
    public byte PreOrderOperationTypeNo { get; set; }

    [StringLength(10)]
    public string? PreOrderOperationTypeName { get; set; }
}
