using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataKates.Models;

[Keyless]
public partial class VOR_Transactions_RowNumber_TranDateTime_DESC
{
    public int TranSID { get; set; }

    [StringLength(14)]
    public string CardID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TranDateTime { get; set; }

    public byte TranType { get; set; }

    public long? RowNumber { get; set; }

    [StringLength(18)]
    public string? SlaveIP { get; set; }

    [StringLength(18)]
    public string? SlaveIP_Public { get; set; }

    public short SlaveID { get; set; }
}
